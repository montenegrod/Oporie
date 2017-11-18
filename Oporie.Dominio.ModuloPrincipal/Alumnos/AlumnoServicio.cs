using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oporie.Dominio.ModuloPrincipal.Entidades;
using Capas.Dominio.Core;
using Oporie.Dominio.ModuloPrincipal.Alumnos;
using Capas.Dominio.Core.Specification;

namespace Oporie.Dominio.ModuloPrincipal.Alumnos
{
    /// <summary>
    /// Dominio de Servicio de gestión de Alumnos
    /// </summary>
    public class AlumnoServicio : IAlumnoServicio, IDisposable
    {
        #region Miembros
        IDepositoDeAlumno _DepositoDeAlumno;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto para AlumnoServicio
        /// </summary>
        /// <param name="depositoDeAlumno">La dependencia DepositoDeAlumno, por lo general se trata de resolver con IoC </param>
        public AlumnoServicio(IDepositoDeAlumno depositoDeAlumno)
        {
            if (depositoDeAlumno == (IDepositoDeAlumno)null)
                throw new ArgumentNullException(Recursos.Mensajes.excepcion_DependenciasNotEstanInitializadas);

            _DepositoDeAlumno = depositoDeAlumno;
        }
        #endregion

        #region Implementación de IAlumnoServicio

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/>
        /// </summary>
        /// <param name="indicePagina"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></param>
        /// <param name="cantidadPagina"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></param>
        /// <returns></returns>
        public List<ALUMNO> BuscarAlumnoPaginado(int indicePagina, int cantidadPagina) 
        {
            if (indicePagina < 0)   
                throw new ArgumentException(Recursos.Mensajes.excepcion_IndiceDePaginaInvalido, "indicePagina");

            if (cantidadPagina <= 0)
                throw new ArgumentException(Recursos.Mensajes.excepcion_CantidadDePaginaInvalido, "cantidadPagina");

            bool activo = true;

            Specification<ALUMNO> specActivosSolamente = new DirectSpecification<ALUMNO>(a => a.ALU_ESTADO == activo);

            return _DepositoDeAlumno.GetPagedElements(indicePagina, cantidadPagina, da => da.ID_ALUMNO, specActivosSolamente, true).ToList(); 
        }

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/>
        /// </summary>
        /// <param name="cedulaAlumno"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></param>
        /// <returns><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></returns>
        public ALUMNO BuscarAlumnoPorCedula(string cedulaAlumno)
        {
            //Crear la especificación
            EspecificacionPorCedula aluXced = new EspecificacionPorCedula(cedulaAlumno);

            return _DepositoDeAlumno.BuscarAlumnoPorCedula(aluXced);
        }

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/>
        /// </summary>
        /// <param name="firstNameAlumno"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></param>
        /// <returns><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></returns>
        public ALUMNO BuscarAlumnoPorNombre(string firstNameAlumno)
        {
            //Crear la especificación
            EspecificacionPorNombre aluXnom = new EspecificacionPorNombre(firstNameAlumno);

            return _DepositoDeAlumno.BuscarAlumnoPorNombre(aluXnom);
        }

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/>
        /// </summary>
        /// <param name="lastNameAlumno"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></param>
        /// <returns><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></returns>
        public ALUMNO BuscarAlumnoPorApellido(string lastNameAlumno)
        {
            //Crear la especificación
            EspecificacionPorApellido aluXape = new EspecificacionPorApellido(lastNameAlumno);

            return _DepositoDeAlumno.BuscarAlumnoPorApellido(aluXape);
        }

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/>
        /// </summary>
        /// <param name="alumno"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></param>
        public void AgregarAlumno(ALUMNO alumno)
        {
            //Begin unit of work ( if Transaction is required init here a new TransactionScope element
            IUnitOfWork unitOfWork = _DepositoDeAlumno.StoreContext as IUnitOfWork;

            _DepositoDeAlumno.Add(alumno);

            //Completar los cambios en "unit of work"
            unitOfWork.Commit();
        }

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/>
        /// </summary>
        /// <param name="alumno"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></param>
        public void ModificarAlumno(ALUMNO alumno)
        {
            //Comience "unit of work" (si la transacción se requiere inicie aquí un elemento nuevo de TransactionScope
            IUnitOfWork unitOfWork = _DepositoDeAlumno.StoreContext as IUnitOfWork;

            _DepositoDeAlumno.Modify(alumno);

            //Completar los cambios en "unit of work"
            unitOfWork.CommitAndRefreshChanges();
        }

        /// <summary>
        /// <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/>
        /// </summary>
        /// <param name="alumno"><see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.IAlumnoServicio"/></param>
        public void EliminarAlumno(ALUMNO alumno)
        {
            if (alumno == (ALUMNO)null)
                throw new ArgumentNullException("alumno");

            //Comience "unit of work" (si la transacción se requiere inicie aquí un elemento nuevo de TransactionScope
            IUnitOfWork unitOfWork = _DepositoDeAlumno.StoreContext as IUnitOfWork;

            alumno.ALU_ESTADO = false;

            _DepositoDeAlumno.Modify(alumno); 

            //Complete changes in this unit of work
            unitOfWork.CommitAndRefreshChanges();
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Desechar el contexto asociado a este servicio de dominio
        /// </summary>
        public void Dispose()
        {
            if (_DepositoDeAlumno != null && _DepositoDeAlumno.StoreContext != null)
            {
                _DepositoDeAlumno.StoreContext.Dispose();
            }
        }
        #endregion
    }
}
