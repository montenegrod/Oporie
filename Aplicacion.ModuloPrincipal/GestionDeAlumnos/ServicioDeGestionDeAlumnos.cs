using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Dominio.Core;
using Oporie.Dominio.ModuloPrincipal.Entidades;
using Oporie.Dominio.ModuloPrincipal.Alumnos;
using Capas.Dominio.Core.Specification;

namespace Aplicacion.ModuloPrincipal.GestionDeAlumnos
{
    /// <summary>
    /// Implementación de IServicioDeGestionDeAlumnos
    /// </summary>
    public class ServicioDeGestionDeAlumnos : IServicioDeGestionDeAlumnos
    {
        #region Miembros
        IDepositoDeAlumno _depositoDeAlumno;
        #endregion

        #region Constructor
        public ServicioDeGestionDeAlumnos(IDepositoDeAlumno depositoDeAlumno)
        {
            if (depositoDeAlumno == (IDepositoDeAlumno)null)
                throw new ArgumentNullException("depositoDeAlumno");

            _depositoDeAlumno = depositoDeAlumno;
        }
        #endregion

        #region Miembros de IServicioDeGestionDeAlumnos
        public void AgregarAlumno(ALUMNO alumno)
        {
            IUnitOfWork unitOfWork = _depositoDeAlumno.UnitOfWork as IUnitOfWork;

            _depositoDeAlumno.Add(alumno);

            //Completar los cambios de la Unidad de Trabajo
            unitOfWork.Commit();
        }

        public void ModificarAlumno(ALUMNO alumno)
        {
            if (alumno == (ALUMNO)null)
                throw new ArgumentNullException("alumno");

            IUnitOfWork unitOfWork = _depositoDeAlumno.UnitOfWork as IUnitOfWork;

            _depositoDeAlumno.Modify(alumno);

            //Completar los cambios de la Unidad de Trabajo
            unitOfWork.CommitAndRefreshChanges();
        }

        public void EliminarAlumno(ALUMNO alumno)
        {
            if (alumno == (ALUMNO)null)
                throw new ArgumentNullException("alumno");

            IUnitOfWork unitOfWork = _depositoDeAlumno.UnitOfWork as IUnitOfWork;

            alumno.ALU_ESTADO = false;

            _depositoDeAlumno.Modify(alumno);

            //Completar los cambios de la Unidad de Trabajo
            unitOfWork.CommitAndRefreshChanges();

        }

        public ALUMNO BuscarAlumnoPorCedula(string cedulaAlumno)
        {
            //Crear la especificación 
            EspecificacionPorCedula esp = new EspecificacionPorCedula(cedulaAlumno);
            return _depositoDeAlumno.BuscarAlumnoPorCedula(esp);
        }

        public ALUMNO BuscarAlumnoPorNombre(string firstNameAlumno)
        {
            //Crear la especificación 
            EspecificacionPorNombre esp = new EspecificacionPorNombre(firstNameAlumno);
            return _depositoDeAlumno.BuscarAlumnoPorNombre(esp);
        }

        public ALUMNO BuscarAlumnoPorApellido(string lastNameAlumno)
        {
            //Crear la especificación 
            EspecificacionPorApellido esp = new EspecificacionPorApellido(lastNameAlumno);
            return _depositoDeAlumno.BuscarAlumnoPorApellido(esp);
        }

        public List<ALUMNO> BuscarAlumnoPaginado(int indicePagina, int cantidadPagina)
        {
            if (indicePagina < 0)
                throw new ArgumentException(Recursos.Messages.exception_InvalidPageIndex, "pageIndex");

            if (cantidadPagina <= 0)
                throw new ArgumentException(Recursos.Messages.exception_InvalidPageCount, "pageCount");


            //Create "enabled variable" transform adhoc execution plan in prepared plan
            //for more info: http://geeks.ms/blogs/unai/2010/07/91/ef-4-0-performance-tips-1.aspx
            bool activo = true;
            Specification<ALUMNO> onlyEnabledSpec = new DirectSpecification<ALUMNO>(c => c.ALU_ESTADO == activo);

            return _depositoDeAlumno.GetPagedElements(indicePagina, cantidadPagina, a => a.ID_ALUMNO, onlyEnabledSpec, true).ToList();
        }
        #endregion

    }
}
