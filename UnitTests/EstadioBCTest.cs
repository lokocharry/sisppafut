using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for EstadioBCTest and is intended
    ///to contain all EstadioBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EstadioBCTest
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
        ///A test for EstadioBC Constructor
        ///</summary>
        [TestMethod()]
        public void EstadioBCConstructorTest()
        {
            EstadioBC target = new EstadioBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for insertar_Estadio
        ///</summary>
        [TestMethod()]
        public void insertar_EstadioTest()
        {
            EstadioBC target = new EstadioBC();

            EstadioBE objEstadioBE = new EstadioBE();
            objEstadioBE.Codigo_pais = 7;
            objEstadioBE.Nombre_estadio = "Estadio Do Dragao";
            objEstadioBE.Ciudad_estadio = "Oporto";
            objEstadioBE.Anho_fundacion = 2003;
            objEstadioBE.Aforo_estadio = 52000;

            int expected = 0;
            int actual;
            actual = target.insertar_Estadio(objEstadioBE);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
