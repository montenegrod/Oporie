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

namespace ServiciosDistribuidos.ModuloPrincipal.InstanceProviders
{
    using Microsoft.Practices.Unity;

    using Oporie.Dominio.ModuloPrincipal.Alumnos;

    using Aplicacion.ModuloPrincipal;

    using Infraestructura.CrossCutting.Logging;
    using Infraestructura.Crosscutting.Adapter;
    using Infraestructura.CrossCutting.NetFramework.Logging;
    using Infraestructura.Crosscutting.NetFramework.Validator;
    using Infraestructura.Crosscutting.Validator;

    using Oporie.Infraestructura.Data.ModuloPrincipal.Depositos;
    using Aplicacion.ModuloPrincipal.GestionDeAlumnos;
    using Infraestructura.CrossCutting.NetFramework.Adapter;
    using Oporie.Infraestructura.Data.ModuloPrincipal.UnitOfWork;
    

    /// <summary>
    /// DI container accessor
    /// </summary>
    public static class Container
    {
        #region Properties

        static  IUnityContainer _currentContainer;

        /// <summary>
        /// Get the current configured container
        /// </summary>
        /// <returns>Configured container</returns>
        public static IUnityContainer Current
        {
            get
            {
                return _currentContainer;
            }
        }

        #endregion

        #region Constructor
        
        static Container()
        {
            ConfigureContainer();

            ConfigureFactories();
        }

        #endregion

        #region Methods

        static void ConfigureContainer()
        {
            /*
             * Add here the code configuration or the call to configure the container 
             * using the application configuration file
             */

            _currentContainer = new UnityContainer();
            
            
            //-> Unit of Work and repositories
            _currentContainer.RegisterType(typeof(MainBCUnitOfWork), new PerResolveLifetimeManager());
            

            _currentContainer.RegisterType<IDepositoDeAlumno, DepositoDeAlumno>();

            //-> Adapters
            _currentContainer.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());

            
        }


        static void ConfigureFactories()
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            var typeAdapterFactory = _currentContainer.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        #endregion
    }
}