//===================================================================================
// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftnlayerapp.codeplex.com/license
//===================================================================================
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects;

namespace Infraestructura.Data.Core
{
    /// <summary>
    /// Class for IQuerable extensions methods.
    /// Include method in IQueryable ( base contract for IObjectSet ) is 
    /// intended for mock Include method in ObjectQuery{T} 
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Include method for IQueryable
        /// </summary>
        /// <typeparam name="T">Type of elements</typeparam>
        /// <param name="queryable">Queryable object</param>
        /// <param name="path">Path to include</param>
        /// <returns>Queryable object with include path information</returns>
        public static IQueryable<T> Include<T>(this IQueryable<T> queryable, string path)
            where T : class
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentNullException(Resources.Messages.exception_IncludePathCannotBeNullOrEmpty);


            ObjectQuery<T> query = queryable as ObjectQuery<T>;

            if (query != null)//if is a EF ObjectQuery object
                return query.Include(path);
            else
            {
                //a fake or in memory object set for testing
                InMemoryObjectSet<T> fakeQuery = queryable as InMemoryObjectSet<T>;
                return fakeQuery.Include(path);

            }
        }

        /// <summary>
        /// Include extension method for IQueryable
        /// </summary>
        /// <typeparam name="T">Type of elements in IQueryable</typeparam>
        /// <param name="queryable">Queryable object</param>
        /// <param name="path">Expression with path to include</param>
        /// <returns>Queryable object with include path information</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static IQueryable<T> Include<T>(this IQueryable<T> queryable, Expression<Func<T, object>> path)
            where T : class,new()
        {
            if (path == (Expression<Func<T, object>>)null)
                throw new ArgumentNullException(Resources.Messages.exception_ExpressionPathNotValid);

            MemberExpression body = path.Body as MemberExpression;
            if (
                    (
                    (body == null)
                    ||
                    !body.Member.DeclaringType.IsAssignableFrom(typeof(T))
                    )
                    ||
                    (body.Expression.NodeType != ExpressionType.Parameter))
            {
                throw new ArgumentException(Resources.Messages.exception_ExpressionPathNotValid);
            }
            else
                return Include<T>(queryable, body.Member.Name);

        }
    }
}
