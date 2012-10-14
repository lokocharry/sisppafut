using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for JugadorEquipoBCTest and is intended
    ///to contain all JugadorEquipoBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JugadorEquipoBCTest
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
        ///A test for listaJugadorEquipo
        ///</summary>
        [TestMethod()]
        public void listaJugadorEquipoTest()
        {
            JugadorEquipoBC.Propiedades.userLogged = "demoADMIN";
            JugadorEquipoBC target = new JugadorEquipoBC();
            int expected = 44;
            List<JugadorEquipoBE> actual;
            actual = target.listaJugadorEquipo();
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
