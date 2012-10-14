using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para LogBCTest y se pretende que
    ///contenga todas las pruebas unitarias LogBCTest.
    ///</summary>
    [TestClass()]
    public class LogBCTest
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
        ///Una prueba de RegistrarLog
        ///</summary>
        [TestMethod()]
        public void RegistrarLogTest()
        {
            LogBC target = new LogBC();
            
            LogBE objLogBE = new LogBE();
            objLogBE.CodOperacion = 1;
            objLogBE.Fecha = DateTime.Now;
            objLogBE.IP = "192.168.1.123";
            objLogBE.Razon = "Se registró un estadio";
            objLogBE.Tabla = "Estadio";
            objLogBE.Usuario = "demoADMIN";
            int expected = 1499;
            int actual;
            actual = target.RegistrarLog(objLogBE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de ListarLogsFecha
        ///</summary>
        [TestMethod()]
        public void ListarLogsFechaTest()
        {
            LogBC target = new LogBC();
            DateTime Fecha = DateTime.Now;
            int expected = 1502;
            int actual;
            actual = target.ListarLogsFecha(Fecha).Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
