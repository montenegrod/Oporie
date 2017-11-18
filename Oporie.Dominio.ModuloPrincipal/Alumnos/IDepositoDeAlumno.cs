using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oporie.Dominio.ModuloPrincipal.Entidades;
using Capas.Dominio.Core;

namespace Oporie.Dominio.ModuloPrincipal.Alumnos
{
    /// <summary>
    /// Contrato de Depósito Global para el Aggregate Raíz de Alumno
    /// </summary>
    public interface IDepositoDeAlumno : IRepository<ALUMNO>
    {
        /// <summary>
        /// Busca un Alumno por <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.EspecificacionPorCedula"/>
        /// </summary>
        /// <param name="especificacion">Instancia de EspecificacionPorCedula</param>
        /// <returns>Un Alumno el cual satisface el criterio de especificación</returns>
        ALUMNO BuscarAlumnoPorCedula(EspecificacionPorCedula especificacion);

        /// <summary>
        /// Busca un Alumno por <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.EspecificacionPorNombre"/>
        /// </summary>
        /// <param name="especificacion">Instancia de EspecificacionPorNombre</param>
        /// <returns>Un Alumno el cual satisface el criterio de especificación</returns>
        ALUMNO BuscarAlumnoPorNombre(EspecificacionPorNombre especificacion);

        /// <summary>
        /// Busca un Alumno por <see cref="Oporie.Dominio.ModuloPrincipal.Alumnos.EspecificacionPorApellido"/>
        /// </summary>
        /// <param name="especificacion">Instancia de EspecificacionPorApellido</param>
        /// <returns>Un Alumno el cual satisface el criterio de especificación</returns>
        ALUMNO BuscarAlumnoPorApellido(EspecificacionPorApellido especificacion);
    }
}
