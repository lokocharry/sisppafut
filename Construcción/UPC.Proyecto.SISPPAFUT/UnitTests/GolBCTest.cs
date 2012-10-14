using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for GolBCTest and is intended
    ///to contain all GolBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GolBCTest
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
        ///A test for insertar_Goles
        ///</summary>
        [TestMethod()]
        public void insertar_GolesTest()
        {
            GolBC.Propiedades.userLogged = "demoADMIN";
            List<GolBE> lista_goles = new List<GolBE>();

            GolBE obj = new GolBE();
            obj.Codigo_partido = 6;
            obj.Codigo_jugador = 40;
            obj.Minuto_gol = 58;
            lista_goles.Add(obj);

            GolBC target = new GolBC();
            target.insertar_Goles(lista_goles);
        }
    }
}
