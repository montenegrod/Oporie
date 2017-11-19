using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

using Oporie.Dominio.ModuloPrincipal.Entidades;
using Infraestructura.Data.Core;
using Oporie.Dominio.ModuloPrincipal.Alumnos;
using Capas.Dominio.Core.Specification;
using Oporie.Infraestructura.Data.ModuloPrincipal.Recursos;
using Infraestructura.CrossCutting.Logging;


namespace Oporie.Infraestructura.Data.ModuloPrincipal.Depositos
{
    /// <summary>
    /// Implementación del Depósito de IAlumno
    /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/>
    /// </summary>
    public class DepositoDeAlumno : GenericRepository<ALUMNO>, IDepositoDeAlumno 
    {
        #region Constructor

        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        /// <param name="traceManager">Trace manager dependency</param>
        /// <param name="context">Specific context for this repository</param>
        public DepositoDeAlumno(IModuloPrincipalModel context, ITraceManager traceManager) : base(context, traceManager) { }

        #endregion

        #region Implementación de IDepositoDeAlumno

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IDepositoDeAlumno"/>
        /// </summary>
        /// <param name="especificacion"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IDepositoDeAlumno"/></param>
        /// <returns>Alumno y su <paramref name="specification"/></returns>
        public ALUMNO BuscarAlumnoPorCedula(EspecificacionPorCedula especificacion)
        {
            //Validar la especificación
            if (especificacion == (ISpecification<ALUMNO>)null)
                throw new ArgumentNullException("especificacion");

            IModuloPrincipalModel activaContexto = this.StoreContext as IModuloPrincipalModel;
            if (activaContexto != null)
            {
                //Ejecutar la operación en este depósito (ALUMNO *)
                return activaContexto.ALUMNO
                                    .Include(c => c.ALU_FOTO)
                                    .Where(especificacion.SatisfiedBy())
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Mensajes.exception_InvalidStoreContext,
                                                                this.GetType().Name));

        }

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IDepositoDeAlumno"/>
        /// </summary>
        /// <param name="especificacion"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IDepositoDeAlumno"/></param>
        /// <returns>Alumno y su <paramref name="specification"/></returns>
        public ALUMNO BuscarAlumnoPorNombre(EspecificacionPorNombre especificacion)
        {
            //Validar la especificación
            if (especificacion == (ISpecification<ALUMNO>)null)
                throw new ArgumentNullException("especificacion");

            IModuloPrincipalModel activaContexto = this.StoreContext as IModuloPrincipalModel;
            if (activaContexto != null)
            {
                //Ejecutar la operación en este depósito
                return activaContexto.ALUMNO
                                    .Include(c => c.ALU_FOTO)
                                    .Where(especificacion.SatisfiedBy())
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Mensajes.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IDepositoDeAlumno"/>
        /// </summary>
        /// <param name="especificacion"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IDepositoDeAlumno"/></param>
        /// <returns>Alumno y su <paramref name="specification"/></returns>
        public ALUMNO BuscarAlumnoPorApellido(EspecificacionPorApellido especificacion)
        {
            //Validar la especificación
            if (especificacion == (ISpecification<ALUMNO>)null)
                throw new ArgumentNullException("especificacion");

            IModuloPrincipalModel activaContexto = this.StoreContext as IModuloPrincipalModel;
            if (activaContexto != null)
            {
                //Ejecutar la operación en este depósito
                return activaContexto.ALUMNO
                                    .Include(c => c.ALU_FOTO)
                                    .Where(especificacion.SatisfiedBy())
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Mensajes.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
        #endregion

    }
}
