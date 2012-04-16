using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for PartidoBCTest and is intended
    ///to contain all PartidoBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PartidoBCTest
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
        ///A test for insertar_Partido
        ///</summary>
        [TestMethod()]
        public void insertar_PartidoTest()
        {
            PartidoBC target = new PartidoBC(); 
            PartidoBE objPartidoBE = new PartidoBE();

            objPartidoBE.Codigo_liga = 3;
            objPartidoBE.Codigo_equipo_local = 1;
            objPartidoBE.Codigo_equipo_visitante = 3;
            objPartidoBE.Codigo_estadio = 2;
            objPartidoBE.Goles_local = 0;
            objPartidoBE.Goles_visita = 0;
            objPartidoBE.Fecha_partido = DateTime.Today;

            int expected = 0;
            int actual;
            
            actual = target.insertar_Partido(objPartidoBE);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for PartidoBC Constructor
        ///</summary>
        [TestMethod()]
        public void PartidoBCConstructorTest()
        {
            PartidoBC target = new PartidoBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
