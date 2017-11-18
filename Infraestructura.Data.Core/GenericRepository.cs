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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

using Capas.Dominio.Core;
using Capas.Dominio.Core.Entidades;
using Capas.Dominio.Core.Specification;
using Infraestructura.CrossCutting.Logging;

namespace Infraestructura.Data.Core
{
    /// <summary>
    /// Default base class for repostories. This generic repository 
    /// is a default implementation of <see cref=" Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
    /// and your specific repositories can inherit from this base class so automatically will get default implementation.
    /// IMPORTANT: Using this Base Repository class IS NOT mandatory. It is just a useful base class:
    /// You could also decide that you do not want to use this base Repository class, because sometimes you don't want a 
    /// specific Repository getting all these features and it might be wrong for a specific Repository. 
    /// For instance, you could want just read-only data methods for your Repository, etc. 
    /// in that case, just simply do not use this base class on your Repository.
    /// </summary>
    /// <typeparam name="TEntity">Type of elements in repostory</typeparam>
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class,IObjectWithChangeTracker, new()
    {
       

        #region Members

        ITraceManager _TraceManager = null;
        private IQueryableContext _context;
        IUnitOfWork _UnitOfWork;
        #endregion


        #region Constructor


        /// <summary>
        /// Default constructor for GenericRepository
        /// </summary>
        /// <param name="traceManager">Trace Manager dependency</param>
        /// <param name="context">A context for this repository</param>
        public GenericRepository(IQueryableContext context,ITraceManager traceManager)
        {
            //check preconditions
            if (context == (IQueryableContext)null)
                throw new ArgumentNullException("context", Resources.Messages.exception_ContainerCannotBeNull);

            //set internal values
            _context = context;
            _TraceManager = traceManager;


            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                             Resources.Messages.trace_ConstructRepository,
                             typeof(TEntity).Name));
        }

        #endregion

        #region IRepository<TEntity> Members

        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        /// <summary>
        /// Return a context in this repository
        /// </summary>
        public IContext StoreContext
        {
            get
            {
                return _context as IContext;
            }
        }

        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        public void Add(TEntity item)
        {
            //check item
            if (item == (TEntity)null)
                throw new ArgumentNullException("item", Resources.Messages.exception_ItemArgumentIsNull);

            //add object to IObjectSet for this type
            (_context.CreateObjectSet<TEntity>()).AddObject(item);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                              Resources.Messages.trace_AddedItemRepository,
                              typeof(TEntity).Name));
        }
        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        public void Remove(TEntity item)
        {
            //check item
            if (item == (TEntity)null)
                throw new ArgumentNullException("item", Resources.Messages.exception_ItemArgumentIsNull);


            IObjectSet<TEntity> objectSet = (_context.CreateObjectSet<TEntity>());

            //Attach object to context and delete this
            // this is valid only if T is a type in model
            objectSet.Attach(item);

            //delete object to IObjectSet for this type
            objectSet.DeleteObject(item);

            _TraceManager.TraceInfo(
               string.Format(CultureInfo.InvariantCulture,
                            Resources.Messages.trace_DeletedItemRepository,
                            typeof(TEntity).Name));
        }

        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        public void Attach(TEntity item)
        {
            if (item == (TEntity)null)
                throw new ArgumentNullException("item");

            (_context.CreateObjectSet<TEntity>()).Attach(item);

            _TraceManager.TraceInfo(
               string.Format(CultureInfo.InvariantCulture,
                            Resources.Messages.trace_AttachedItemToRepository,
                            typeof(TEntity).Name));
        }
        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        public void Modify(TEntity item)
        {
            //check arguments
            if (item == (TEntity)null)
                throw new ArgumentNullException("item", Resources.Messages.exception_ItemArgumentIsNull);

            //Set modifed state if change tracker is enabled
            if (item.ChangeTracker != null)
                item.MarkAsModified();

            //apply changes for item object
            _context.SetChanges(item);

            _TraceManager.TraceInfo(
                           string.Format(CultureInfo.InvariantCulture,
                                        Resources.Messages.trace_AppliedChangedItemRepository,
                                        typeof(TEntity).Name));
        }
        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetAll()
        {

            _TraceManager.TraceInfo(
                           string.Format(CultureInfo.InvariantCulture,
                                        Resources.Messages.trace_GetAllRepository,
                                        typeof(TEntity).Name));

            //Create IObjectSet and perform query 
            return (_context.CreateObjectSet<TEntity>()).AsEnumerable<TEntity>();
        }
        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="specification"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification)
        {
            if (specification == (ISpecification<TEntity>)null)
                throw new ArgumentNullException("specification");

            _TraceManager.TraceInfo(
                           string.Format(CultureInfo.InvariantCulture,
                                        Resources.Messages.trace_GetBySpec,
                                        typeof(TEntity).Name));

            return (_context.CreateObjectSet<TEntity>()
                            .Where(specification.SatisfiedBy())
                            .AsEnumerable<TEntity>());

        }

        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="pageIndex"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="pageCount"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetPagedElements<S>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {
            //checking arguments for this query 
            if (pageIndex < 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == (Expression<Func<TEntity, S>>)null)
                throw new ArgumentNullException("orderByExpression", Resources.Messages.exception_OrderByExpressionCannotBeNull);

            _TraceManager.TraceInfo(
                           string.Format(CultureInfo.InvariantCulture,
                                        Resources.Messages.trace_GetPagedElementsRepository,
                                        typeof(TEntity).Name, pageIndex, pageCount, orderByExpression.ToString()));

            //Create associated IObjectSet and perform query

            IObjectSet<TEntity> objectSet = _context.CreateObjectSet<TEntity>();

            return (ascending)
                                ?
                                    objectSet.OrderBy(orderByExpression)
                                     .Skip(pageIndex * pageCount)
                                     .Take(pageCount)
                                     .ToList()
                                :
                                    objectSet.OrderByDescending(orderByExpression)
                                     .Skip(pageIndex * pageCount)
                                     .Take(pageCount)
                                     .ToList();
        }


        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <typeparam name="S"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></typeparam>
        /// <param name="pageIndex"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="pageCount"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="specification"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetPagedElements<S>(int pageIndex, int pageCount, Expression<Func<TEntity, S>> orderByExpression, ISpecification<TEntity> specification, bool ascending)
        {
            //checking arguments for this query 
            if (pageIndex < 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == (Expression<Func<TEntity, S>>)null)
                throw new ArgumentNullException("orderByExpression", Resources.Messages.exception_OrderByExpressionCannotBeNull);

            if (specification == (ISpecification<TEntity>)null)
                throw new ArgumentNullException("specification", Resources.Messages.exception_SpecificationIsNull);

            _TraceManager.TraceInfo(
                           string.Format(CultureInfo.InvariantCulture,
                                        Resources.Messages.trace_GetPagedElementsRepository,
                                        typeof(TEntity).Name, pageIndex, pageCount, orderByExpression.ToString()));

            //Create associated IObjectSet and perform query

            IObjectSet<TEntity> objectSet = _context.CreateObjectSet<TEntity>();

            return (ascending)
                                ?
                                    objectSet
                                     .Where(specification.SatisfiedBy())
                                     .OrderBy(orderByExpression)
                                     .Skip(pageIndex * pageCount)
                                     .Take(pageCount)
                                     .ToList()
                                :
                                    objectSet
                                     .Where(specification.SatisfiedBy())
                                     .OrderByDescending(orderByExpression)
                                     .Skip(pageIndex * pageCount)
                                     .Take(pageCount)
                                     .ToList();
        }


        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="filter"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            //checking query arguments
            if (filter == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("filter", Resources.Messages.exception_FilterCannotBeNull);

            _TraceManager.TraceInfo(
                           string.Format(CultureInfo.InvariantCulture,
                                        Resources.Messages.trace_GetFilteredElementsRepository,
                                        typeof(TEntity).Name, filter.ToString()));

            //Create IObjectSet and perform query
            return _context.CreateObjectSet<TEntity>()
                             .Where(filter)
                             .ToList();
        }

        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="filter"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetFilteredElements<S>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {
            //Checking query arguments
            if (filter == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("filter", Resources.Messages.exception_FilterCannotBeNull);

            if (orderByExpression == (Expression<Func<TEntity, S>>)null)
                throw new ArgumentNullException("orderByExpression", Resources.Messages.exception_OrderByExpressionCannotBeNull);

            _TraceManager.TraceInfo(
                           string.Format(CultureInfo.InvariantCulture,
                                        Resources.Messages.trace_GetFilteredElementsRepository,
                                        typeof(TEntity).Name, filter.ToString()));

            //Create IObjectSet for this type and perform query
            IObjectSet<TEntity> objectSet = _context.CreateObjectSet<TEntity>();

            return (ascending)
                                ?
                                    objectSet
                                     .Where(filter)
                                     .OrderBy(orderByExpression)
                                     .ToList()
                                :
                                    objectSet
                                     .Where(filter)
                                     .OrderByDescending(orderByExpression)
                                     .ToList();
        }

        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="filter"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="pageIndex"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="pageCount"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></param>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetFilteredElements<S>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageCount, Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {

            //checking query arguments
            if (filter == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("filter", Resources.Messages.exception_FilterCannotBeNull);

            if (pageIndex < 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == (Expression<Func<TEntity, S>>)null)
                throw new ArgumentNullException("orderByExpression", Resources.Messages.exception_OrderByExpressionCannotBeNull);

            _TraceManager.TraceInfo(
                           string.Format(CultureInfo.InvariantCulture,
                                        Resources.Messages.trace_GetFilteredPagedElementsRepository,
                                        typeof(TEntity).Name, filter.ToString(), pageIndex, pageCount, orderByExpression.ToString()));

            //Create IObjectSet for this particular type and query this
            IObjectSet<TEntity> objectSet = _context.CreateObjectSet<TEntity>();

            return (ascending)
                                ?
                                    objectSet
                                     .Where(filter)
                                     .OrderBy(orderByExpression)
                                     .Skip(pageIndex * pageCount)
                                     .Take(pageCount)
                                     .ToList()
                                :
                                    objectSet
                                     .Where(filter)
                                     .OrderByDescending(orderByExpression)
                                     .Skip(pageIndex * pageCount)
                                     .Take(pageCount)
                                     .ToList();


        }

        #endregion
    }
}
