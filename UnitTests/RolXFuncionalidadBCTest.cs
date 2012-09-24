using UPC.Seguridad.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using UPC.Seguridad.BL.BC;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for RolXFuncionalidadBCTest and is intended
    ///to contain all RolXFuncionalidadBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RolXFuncionalidadBCTest
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
        ///A test for Insertar_RolXFuncionalidad
        ///</summary>
        [TestMethod()]
        public void Insertar_RolXFuncionalidadTest()
        {
            //RolXFuncionalidadBC target = new RolXFuncionalidadBC();
            int idRol = 3;
            int idFuncionalidad = 20;
            //target.Insertar_RolXFuncionalidad(idRol, idFuncionalidad);
        }
    }
}
