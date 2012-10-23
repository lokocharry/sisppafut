using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para EntrenadorBCTest y se pretende que
    ///contenga todas las pruebas unitarias EntrenadorBCTest.
    ///</summary>
    [TestClass()]
    public class EntrenadorBCTest
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


        /// <summary>
        ///Una prueba de Constructor EntrenadorBC
        ///</summary>
        [TestMethod()]
        public void EntrenadorBCConstructorTest()
        {
            EntrenadorBC target = new EntrenadorBC();
            Assert.Inconclusive("TODO: Implementar código para comprobar el destino");
        }

        /// <summary>
        ///Una prueba de ActualizarEntrenador
        ///</summary>
        [TestMethod()]
        public void ActualizarEntrenadorTest()
        {
            EntrenadorBC target = new EntrenadorBC();
            EntrenadorBE objEntrenadorBE = new EntrenadorBE();

            objEntrenadorBE.CodEntrenador = 2;
            objEntrenadorBE.Nombres = "Entrenador 1";
            objEntrenadorBE.Apellidos = "Apellidos Entrenador1";
            objEntrenadorBE.Nacionalidad = "Chileno";
            objEntrenadorBE.Fecha = DateTime.Now;

            target.ActualizarEntrenador(objEntrenadorBE);
        }

        /// <summary>
        ///Una prueba de ListarEntrenadores
        ///</summary>
        [TestMethod()]
        public void ListarEntrenadoresTest()
        {
            EntrenadorBC target = new EntrenadorBC();
            int expected = 2;
            int actual;
            actual = target.ListarEntrenadores().Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de RegistrarEntrenador
        ///</summary>
        [TestMethod()]
        public void RegistrarEntrenadorTest()
        {
            EntrenadorBC target = new EntrenadorBC();
            EntrenadorBE objEntrenadorBE = new EntrenadorBE();
            int expected = 3;

            objEntrenadorBE.Apellidos = "Apellidos Entrenador";
            objEntrenadorBE.Fecha = DateTime.Now;
            objEntrenadorBE.Nacionalidad = "Peruano";
            objEntrenadorBE.Nombres = "Nombres Entrenador";

            int actual;
            actual = target.RegistrarEntrenador(objEntrenadorBE);
            Assert.AreEqual(expected, actual);
        }
    }
}
