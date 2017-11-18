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
using Capas.Dominio.Core.Entidades;


namespace Capas.Dominio.Core
{
    /// <summary>
    /// Really Context is the main class for interact with data and this is
    /// used usually in repositories for storing and query data. For mantein PI
    /// into Domain Layer and add features for Mocking this context is expressed 
    /// as interfaces and fluent this into repositories implementation.
    /// </summary>
    public interface IContext
         : IUnitOfWork,ISQL,IDisposable
    {
        /// <summary>
        /// Apply changes made in item or related items in your graph
        /// </summary>
        /// <typeparam name="TEntity">Type of item</typeparam>
        /// <param name="item">Item with changes</param>
        void SetChanges<TEntity>(TEntity item)
            where TEntity : class, IObjectWithChangeTracker, new();
    }
}
