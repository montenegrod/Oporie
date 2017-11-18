using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosDistribuidos.ModuloPrincipal
{
    using System.ServiceModel;
    using Oporie.Dominio.ModuloPrincipal.Entidades;
    using ServiciosDistribuidos.SeedWork.ErrorHandlers;

    /// <summary>
    /// Servicio WCF Fachada para el Módulo Principal
    /// </summary>
    [ServiceContract]
    public interface IServicioModuloPrincipal
    {
        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        void AgregarAlumno(ALUMNO alumno);

        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        List<ALUMNO> BuscarAlumnoPaginado(int indicePagina, int cantidadPagina);

        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        ALUMNO BuscarAlumnoPorCedula(string cedulaAlumno);
    }
}