using Aplicacion.ModuloPrincipal.GestionDeAlumnos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Oporie.Dominio.ModuloPrincipal.Alumnos;
using Oporie.Dominio.ModuloPrincipal.Entidades;
using Oporie.Dominio.ModuloPrincipal.Alumnos.Moles;
using System.Collections.Generic;
using Oporie.Infraestructura.Data.ModuloPrincipal;
using System.Data.EntityClient;
using System.Linq;
using Capas.Dominio.Core.Specification;
using System.Linq.Expressions;
using Capas.Dominio.Core;
using Infraestructura.Data.Core;

namespace Aplicacion.ModuloPrincipal.Test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para ServicioDeGestionDeAlumnosTest y se pretende que
    ///contenga todas las pruebas unitarias ServicioDeGestionDeAlumnosTest.
    ///</summary>
    [TestClass()]
    public class ServicioDeGestionDeAlumnosTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        public class GestionarAlumnos : IDepositoDeAlumno
        {

            #region Miembros de IRepository

            public void Add(ALUMNO entidadAlumno){
                
            }

            public void Remove(ALUMNO entidadAlumno)
            {

            }

            public void Attach(ALUMNO entidadAlumno)
            {

            }

            public void Modify(ALUMNO entidadAlumno)
            {

            }

            public IEnumerable<ALUMNO> GetAll()
            {
                using (ModuloPrincipalContext miContexto = new ModuloPrincipalContext())
                {
                    var alumnos = from alu in miContexto.ALUMNO
                                 select alu;

                    return alumnos.ToList();
                }
            }

            public IEnumerable<ALUMNO> GetBySpec(ISpecification<ALUMNO> specification)
            {
                return null;
            }

            public IEnumerable<ALUMNO> GetPagedElements<S>(int pageIndex, int pageCount, Expression<Func<ALUMNO, S>> orderByExpression, bool ascending)
            {
                return null;
            }

            public IEnumerable<ALUMNO> GetFilteredElements(Expression<Func<ALUMNO, bool>> filter)
            {
                return null;
            }

            public IEnumerable<ALUMNO> GetFilteredElements<S>(Expression<Func<ALUMNO, bool>> filter, int pageIndex, int pageCount, Expression<Func<ALUMNO, S>> orderByExpression, bool ascending)
            {
                return null;
            }

            public IEnumerable<ALUMNO> GetPagedElements<S>(int pageIndex, int pageCount, Expression<Func<ALUMNO, S>> orderByExpression, ISpecification<ALUMNO> specification, bool ascending)
            {
                return null;
            }

            IUnitOfWork _aux;
            IContext _aux2;

            public IUnitOfWork UnitOfWork {
                get{return _aux;}
            }

            public IContext StoreContext { get { return _aux2; } }

            #endregion

            #region Miembros de IDepositoDeAlumno

            public ALUMNO BuscarAlumnoPorCedula(EspecificacionPorCedula especificacion)
            {

                List<ALUMNO> lAlumnoXcedula = new List<ALUMNO>();

                if (especificacion == null)
                {
                    throw new ArgumentNullException("especificacion");
                }
                var x = especificacion;
                using (ModuloPrincipalContext miContexto = new ModuloPrincipalContext())
                {
                    var alumno = from alu in miContexto.ALUMNO
                                  where alu.ALU_CEDULA == x._StrCriterioAlumno
                                  select alu;

                    return (ALUMNO)alumno.FirstOrDefault();
                }
            }

            public ALUMNO BuscarAlumnoPorNombre(EspecificacionPorNombre especificacion) 
            {
                List<ALUMNO> lAlumnoXcedula = new List<ALUMNO>();

                if (especificacion == null)
                {
                    throw new ArgumentNullException("especificacion");
                }
                var x = especificacion;
                using (ModuloPrincipalContext miContexto = new ModuloPrincipalContext())
                {
                    var alumno = from alu in miContexto.ALUMNO
                                 where alu.ALU_FIRSTNAME == x._StrCriterioAlumno
                                 select alu;

                    return (ALUMNO)alumno.FirstOrDefault();
                }
            }

            public ALUMNO BuscarAlumnoPorApellido(EspecificacionPorApellido especificacion)
            {
                List<ALUMNO> lAlumnoXcedula = new List<ALUMNO>();

                if (especificacion == null)
                {
                    throw new ArgumentNullException("especificacion");
                }
                var x = especificacion;
                using (ModuloPrincipalContext miContexto = new ModuloPrincipalContext())
                {
                    var alumno = from alu in miContexto.ALUMNO
                                 where alu.ALU_LASTNAME == x._StrCriterioAlumno
                                 select alu;

                    return (ALUMNO)alumno.FirstOrDefault();
                }
            }

            #endregion
        }

        /// <summary>
        ///Una prueba de BuscarAlumnoPorCedula
        ///</summary>
        [TestMethod()]
        public void BuscarAlumnoPorCedulaTest()
        {
            //Instanciar la clase para gestionar alumnos
            var depositoDeAlumno = new GestionarAlumnos();

            //Establecer la especificación
            EspecificacionPorCedula espec;
            espec = new EspecificacionPorCedula("1717735425");
            if(espec != null)
            espec.SatisfiedBy();

            //Llamada al método de búsqueda
            ALUMNO miAlumno = depositoDeAlumno.BuscarAlumnoPorCedula(espec);

            //Registro con datos reales de la base para comprobar el Assert.AreNotEqual
            ALUMNO expected = new ALUMNO {
                ID_ALUMNO = Guid.Parse("E732344B-5CCC-4222-932D-721A089E4D7B"),
                ID_AREAGEOGRAFICA = Guid.Parse("EC3E0B45-C5A9-46D4-9EEC-CEA8FFA98E9E"),
                ID_TELEFONO = Guid.Parse("70DCFDFB-ADCD-4BE5-A013-201929D8F7EF"),
                ALU_CEDULA = "1717735425",
                ALU_FIRSTNAME = "REYES GALLARDO",
                ALU_LASTNAME = "MARÍA JOSÉ",
                ALU_GENERO = "F",
                ALU_FECHANAC = DateTime.Parse("1988-11-03"), //DateTime.Parse("1959-12-17"),
                ALU_LUGARNAC = "QUITO",
                ALU_DIRECCION = "CHILLOGALLO",
                ALU_ESTADOCIVIL = "CASADA                                            ",
                ALU_EMAIL = "mjpepis@yahoo.es",
                ALU_ESTADO = true
            };

            //Evaluar el Test
            if (miAlumno == null)
                Assert.Fail("Error, no se recuperaron datos"); 
            if(miAlumno != null)
                Assert.AreNotEqual(expected, miAlumno); //Si no son iguales no pasa el test.

            
        }
    }
}
