using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oporie.Dominio.ModuloPrincipal.Entidades;

namespace Aplicacion.ModuloPrincipal.GestionDeAlumnos
{
    /// <summary>
    /// Contrato base para operaciones en Aplicaciones de Alumno
    /// </summary>
    public interface IServicioDeGestionDeAlumnos
    {
        /// <summary>
        /// Añade un nuevo Alumno
        /// </summary>
        /// <param name="alumno">Alumno a ser añadido</param>
        void AgregarAlumno(ALUMNO alumno);

        /// <summary>
        /// Modifica un Alumno existente
        /// </summary>
        /// <param name="alumno">Alumno con los cambios a ser modificados</param>
        void ModificarAlumno(ALUMNO alumno);

        /// <summary>
        /// Elimina un Alumno existente
        /// </summary>
        /// <param name="alumno">Alumno, registro específico</param>
        void EliminarAlumno(ALUMNO alumno);

        /// <summary>
        /// Busca un Alumno por el valor de su propiedad ALU_CEDULA
        /// </summary>
        /// <param name="cedulaAlumno">Alumno si existe, o null si no existe Alumno con un valor de ALU_CEDULA igual a cedulaAlumno</param>
        /// <returns>Alumno, registro específico</returns>
        ALUMNO BuscarAlumnoPorCedula(string cedulaAlumno);

        /// <summary>
        /// Busca un Alumno por el valor de su propiedad ALU_FIRSTNAME
        /// </summary>
        /// <param name="firstNameAlumno">Alumno si existe, o null si no existe Alumno con un valor de ALU_FIRSTNAME igual a firstNameAlumno</param>
        /// <returns>Alumno, registro específico</returns>
        ALUMNO BuscarAlumnoPorNombre(string firstNameAlumno);

        /// <summary>
        /// Busca un Alumno por el valor de su propiedad ALU_LASTNAME
        /// </summary>
        /// <param name="lastNameAlumno">Alumno si existe, o null si no existe Alumno con un valor de ALU_LASTNAME igual a lastNameAlumno</param>
        /// <returns>Alumno, registro específico</returns>
        ALUMNO BuscarAlumnoPorApellido(string lastNameAlumno);

        /// <summary>
        /// Encuentra Alumnos en modo Paginado
        /// </summary>
        /// <param name="indicePagina">Índice de la página</param>
        /// <param name="cantidadPagina">Número de elementos en cada página</param>
        /// <returns>Una colección de Alumnos</returns>
        List<ALUMNO> BuscarAlumnoPaginado(int indicePagina, int cantidadPagina);
    }
}
