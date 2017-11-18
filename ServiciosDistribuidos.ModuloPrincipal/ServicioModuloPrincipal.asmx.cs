using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiciosDistribuidos.ModuloPrincipal
{
    using System.ServiceModel;
    using Oporie.Dominio.ModuloPrincipal.Entidades;
    using Aplicacion.ModuloPrincipal.GestionDeAlumnos;
    using ServiciosDistribuidos.ModuloPrincipal.InstanceProviders;
    using ServiciosDistribuidos.SeedWork.ErrorHandlers;

    
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    [ApplicationErrorHandlerAttribute()] // manage all unhandled exceptions
    [UnityInstanceProviderServiceBehavior()] //create instance and inject dependencies using unity container
    public class ServicioModuloPrincipal : IServicioModuloPrincipal
    {
        
        #region Miembros
        readonly IServicioDeGestionDeAlumnos _servicioAlumno;
        #endregion 

        #region Constructor
        public ServicioModuloPrincipal(IServicioDeGestionDeAlumnos servicioAlumno)
        {
            if (servicioAlumno == null) throw new ArgumentNullException("servicioAlumno");
            _servicioAlumno = servicioAlumno;
        }
        #endregion

        #region Miembros de IServicioModuloPrincipal
        public List<ALUMNO> BuscarAlumnoPaginado(int indicePagina, int cantidadPagina)
        {
            return _servicioAlumno.BuscarAlumnoPaginado(indicePagina, cantidadPagina);
        }

        public ALUMNO BuscarAlumnoPorCedula(string cedulaAlumno) 
        {
            return _servicioAlumno.BuscarAlumnoPorCedula(cedulaAlumno);
        }

        public void AgregarAlumno(ALUMNO alumno)
        {
            _servicioAlumno.AgregarAlumno(alumno);
        }
        #endregion

    }
}
