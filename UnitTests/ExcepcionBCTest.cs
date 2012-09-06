using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for ExcepcionBCTest and is intended
    ///to contain all ExcepcionBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExcepcionBCTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for RegistrarExcepcion
        ///</summary>
        [TestMethod()]
        public void RegistrarExcepcionTest()
        {
            ExcepcionBC target = new ExcepcionBC();
            ExcepcionBE objExcepcionBE = new ExcepcionBE();
            objExcepcionBE.FechaCliente = DateTime.Now;
            objExcepcionBE.FechaServidor = DateTime.Now;
            objExcepcionBE.IPCliente = "192.168.1.13";
            objExcepcionBE.Mensaje = "Error de prueba - UnitTest";
            objExcepcionBE.StackTrace = "StackTrace";
            
            int expected = 51; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.RegistrarExcepcion(objExcepcionBE);
            Assert.AreEqual(expected, actual);
        }
    }
}
