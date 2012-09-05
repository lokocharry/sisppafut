using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for PronosticoBCTest and is intended
    ///to contain all PronosticoBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PronosticoBCTest
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
        ///A test for insertar_Pronostico
        ///</summary>
        [TestMethod()]
        public void insertar_PronosticoTest()
        {
            PronosticoBC target = new PronosticoBC();
            PronosticoBE objPronosticoBE = null;

            objPronosticoBE = new PronosticoBE();

            objPronosticoBE.CodigoPartido = 4;
            objPronosticoBE.Pronostico = "L";
            objPronosticoBE.PorcentajeEmpate = 5m;
            objPronosticoBE.PorcentajeLocal = 5m;
            objPronosticoBE.PorcentajeVisita = 5m;

            int expected = 4;
            int actual;
            actual = target.insertar_Pronostico(objPronosticoBE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for actualizar_Pronostico
        ///</summary>
        [TestMethod()]
        public void actualizar_PronosticoTest()
        {
            PronosticoBC target = new PronosticoBC(); // TODO: Initialize to an appropriate value
            PronosticoBE objPronosticoBE = objPronosticoBE = new PronosticoBE();
            PronosticoBE actual = null;
            objPronosticoBE.CodigoPronostico = 4;
            objPronosticoBE.CodigoPartido = 4;
            objPronosticoBE.Pronostico = "L";
            objPronosticoBE.PorcentajeEmpate = 5m;
            objPronosticoBE.PorcentajeLocal = 5m;
            objPronosticoBE.PorcentajeVisita = 5m;

            target.actualizar_Pronostico(objPronosticoBE);

            actual = target.listar_Pronosticos()[1];
            Assert.AreEqual(objPronosticoBE.CodigoPartido, actual.CodigoPartido);
            Assert.AreEqual(objPronosticoBE.PorcentajeVisita, actual.PorcentajeVisita);
            Assert.AreEqual(objPronosticoBE.PorcentajeLocal, actual.PorcentajeLocal);
            Assert.AreEqual(objPronosticoBE.PorcentajeEmpate, actual.PorcentajeEmpate);
            Assert.AreEqual(objPronosticoBE.Pronostico, actual.Pronostico);

        }

        /// <summary>
        ///A test for listar_PronosticosParaApostador
        ///</summary>
        [TestMethod()]
        public void listar_PronosticosParaApostadorTest()
        {
            PronosticoBC target = new PronosticoBC(); // TODO: Initialize to an appropriate value
            List<PronosticoBE> expected = new List<PronosticoBE>();

            PronosticoBE objPronosticoBE = new PronosticoBE();
            objPronosticoBE.CodigoPronostico = 4;
            objPronosticoBE.CodigoPartido = 4;
            objPronosticoBE.EquipoLocal = "Real Madrid";
            objPronosticoBE.EquipoVisita = "FC Barcelona";
            objPronosticoBE.Pronostico = "L";
            objPronosticoBE.Fecha = Convert.ToDateTime("2011-12-10");
            objPronosticoBE.CodLiga = 3;
            expected.Add(objPronosticoBE);

            List<PronosticoBE> actual;
            actual = target.listar_PronosticosParaApostador();

            Assert.AreEqual(expected[0].CodigoPartido, actual[0].CodigoPartido);
            Assert.AreEqual(expected[0].CodigoPronostico, actual[0].CodigoPronostico);
            Assert.AreEqual(expected[0].EquipoLocal, actual[0].EquipoLocal);
            Assert.AreEqual(expected[0].EquipoVisita, actual[0].EquipoVisita);
            Assert.AreEqual(expected[0].Fecha, actual[0].Fecha);
            Assert.AreEqual(expected[0].Pronostico, actual[0].Pronostico);
            Assert.AreEqual(expected[0].CodLiga, actual[0].CodLiga);
            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}
