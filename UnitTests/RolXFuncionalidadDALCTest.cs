using UPC.Seguridad.DL.DALC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Seguridad.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for RolXFuncionalidadDALCTest and is intended
    ///to contain all RolXFuncionalidadDALCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RolXFuncionalidadDALCTest
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
        ///A test for listar_FuncionalidadesXRol
        ///</summary>
        [TestMethod()]
        public void listar_FuncionalidadesXRolTest()
        {
            RolXFuncionalidadDALC target = new RolXFuncionalidadDALC();
            int idRol = 1;
            int expected = 17; // TODO: Initialize to an appropriate value
            List<FuncionalidadBE> actual;
            actual = target.listar_FuncionalidadesXRol(idRol);
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
