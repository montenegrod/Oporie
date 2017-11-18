using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oporie.Dominio.ModuloPrincipal.Entidades;
using Capas.Dominio.Core.Specification;

namespace Oporie.Dominio.ModuloPrincipal.Alumnos
{
    /// <summary>
    /// Especificación de AdHoc para encontrar Alumnos por criterio FirstName 
    /// </summary>
    public class EspecificacionPorNombre : Specification<ALUMNO>
    {
        #region Variables Miembro
        public string _StrCriterioAlumno = null;
        #endregion

        #region Constructor
        public EspecificacionPorNombre(string alumnoCriterio)
        {
            if (string.IsNullOrEmpty(alumnoCriterio)
                ||
                string.IsNullOrWhiteSpace(alumnoCriterio)
               )
            {
                throw new ArgumentNullException("alumnoCriterio");
            }

            this._StrCriterioAlumno = alumnoCriterio;
        }
        #endregion

        #region Implementación de Overrides

        
        /// <summary>
        /// <see cref=" Oporie.Dominio.Core.Specification.Specification{TEntity}"/>
        /// </summary>
        /// <returns><see cref=" Oporie.Dominio.Core.Specification.Specification{TEntity}"/></returns>
        public override System.Linq.Expressions.Expression<Func<ALUMNO, bool>> SatisfiedBy()
        {
            Specification<ALUMNO> spec = new TrueSpecification<ALUMNO>();

            //Alumnos activos solamente
            spec &= new DirectSpecification<ALUMNO>(a => a.ALU_ESTADO);

            //spec de Alumno es el campo ALU_FIRSTNAME
            spec &= new DirectSpecification<ALUMNO>(c => c.ALU_FIRSTNAME != null && (c.ALU_FIRSTNAME.ToUpper() == _StrCriterioAlumno.ToUpper()));

            return spec.SatisfiedBy();
        }

        #endregion
    }
}
