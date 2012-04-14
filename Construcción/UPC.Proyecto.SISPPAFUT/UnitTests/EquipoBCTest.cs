using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for EquipoBCTest and is intended
    ///to contain all EquipoBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EquipoBCTest
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
        ///A test for EquipoBC Constructor
        ///</summary>
        [TestMethod()]
        public void EquipoBCConstructorTest()
        {
            EquipoBC target = new EquipoBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for insertarEquipo
        ///</summary>
        [TestMethod()]
        public void insertarEquipoTest()
        {
            EquipoBC target = new EquipoBC();
            
            EquipoBE objEquipoBE = new EquipoBE();
            objEquipoBE.CodigoPais = 1;
            objEquipoBE.NombreEquipo = "Equipo de Prueba";
            objEquipoBE.AnioFundacion = 1999;
            objEquipoBE.CiudadEquipo = "Teamland";
            objEquipoBE.CodigoEstadioPrincipal = 1;
            
            int expected = 0;
            int actual;

            actual = target.insertarEquipo(objEquipoBE);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
