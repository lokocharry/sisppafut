using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for AmonestacionBCTest and is intended
    ///to contain all AmonestacionBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AmonestacionBCTest
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
        ///A test for insertar_Amonestacion
        ///</summary>
        [TestMethod()]
        public void insertar_AmonestacionTest()
        {
            AmonestacionBC.Propiedades.userLogged = "demoADMIN";
            List<AmonestacionBE> lista_amonestaciones = new List<AmonestacionBE>();

            AmonestacionBE obj = new AmonestacionBE();
            obj.Codigo_partido = 7;
            obj.Codigo_jugador = 40;
            obj.Tipo = 1;
            obj.Minuto = 90;
            lista_amonestaciones.Add(obj);

            AmonestacionBE obj1 = new AmonestacionBE();

            obj1.Codigo_partido = 7;
            obj1.Codigo_jugador = 34;
            obj1.Tipo = 2;
            obj1.Minuto = 78;
            lista_amonestaciones.Add(obj1);

            AmonestacionBC target = new AmonestacionBC();
            target.insertar_Amonestacion(lista_amonestaciones);
        }
    }
}
