using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for TablaPosicionesBCTest and is intended
    ///to contain all TablaPosicionesBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TablaPosicionesBCTest
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
        ///A test for ObtenerTablaPosicionLiga
        ///</summary>
        [TestMethod()]
        public void ObtenerTablaPosicionLigaTest()
        {
            TablaPosicionesBC target = new TablaPosicionesBC(); // TODO: Initialize to an appropriate value
            int codLiga = 3; // TODO: Initialize to an appropriate value
            List<TablaPosicionesBE> expected = new List<TablaPosicionesBE>();

            TablaPosicionesBE objTablaBE = new TablaPosicionesBE();
            objTablaBE.codEquipo = 1;
            objTablaBE.NombreEquipo = "FC Barcelona";
            objTablaBE.codLiga = 3;
            objTablaBE.codTabla = 2;
            objTablaBE.posicion = 1;
            
            objTablaBE.partidosJugadosLocal = 3;
            objTablaBE.victoriasLocal = 1;
            objTablaBE.empatesLocal = 2;
            objTablaBE.derrotasLocal = 0;
            objTablaBE.golesAnotadosLocal = 10;
            objTablaBE.golesEncajadosLocal = 5;
            objTablaBE.partidosJugadosVisita = 1;
            objTablaBE.victoriasVisita = 1;
            objTablaBE.empatesVisita = 0;
            objTablaBE.derrotasVisita = 0;
            objTablaBE.golesAnotadosVisita = 5;
            objTablaBE.golesEncajadosVisita = 0;
            
            objTablaBE.PartidosJugadosTotal = objTablaBE.partidosJugadosVisita + objTablaBE.partidosJugadosLocal;
            objTablaBE.VictoriasTotal = objTablaBE.victoriasVisita + objTablaBE.victoriasLocal;
            objTablaBE.EmpatesTotal = objTablaBE.empatesVisita + objTablaBE.empatesLocal;
            objTablaBE.DerrotasTotal = objTablaBE.derrotasLocal + objTablaBE.derrotasVisita;
            objTablaBE.GolesAnotadosTotal = objTablaBE.golesAnotadosLocal + objTablaBE.golesAnotadosVisita;
            objTablaBE.GolesEncajadosTotal = objTablaBE.golesEncajadosVisita + objTablaBE.golesEncajadosLocal;
            objTablaBE.PuntosGeneral = objTablaBE.VictoriasTotal * 3 + objTablaBE.EmpatesTotal;
            expected.Add(objTablaBE);

            List<TablaPosicionesBE> actual;
            actual = target.ObtenerTablaPosicionLiga(codLiga);

            Assert.AreEqual(expected[0].codEquipo, actual[0].codEquipo);
            Assert.AreEqual(expected[0].codLiga, actual[0].codLiga);
            Assert.AreEqual(expected[0].codTabla, actual[0].codTabla);
            Assert.AreEqual(expected[0].posicion, actual[0].posicion);
            Assert.AreEqual(expected[0].PuntosGeneral, actual[0].PuntosGeneral);
            Assert.AreEqual(expected[0].partidosJugadosLocal, actual[0].partidosJugadosLocal);
            Assert.AreEqual(expected[0].victoriasLocal, actual[0].victoriasLocal);
            Assert.AreEqual(expected[0].empatesLocal, actual[0].empatesLocal);
            Assert.AreEqual(expected[0].derrotasLocal, actual[0].derrotasLocal);
            Assert.AreEqual(expected[0].golesAnotadosLocal, actual[0].golesAnotadosLocal);
            Assert.AreEqual(expected[0].golesEncajadosLocal, actual[0].golesEncajadosLocal);
            Assert.AreEqual(expected[0].partidosJugadosVisita, actual[0].partidosJugadosVisita);
            Assert.AreEqual(expected[0].victoriasVisita, actual[0].victoriasVisita);
            Assert.AreEqual(expected[0].empatesVisita, actual[0].empatesVisita);
            Assert.AreEqual(expected[0].derrotasVisita, actual[0].derrotasVisita);
            Assert.AreEqual(expected[0].golesAnotadosVisita, actual[0].golesAnotadosVisita);
            Assert.AreEqual(expected[0].golesEncajadosVisita, actual[0].golesEncajadosVisita);

            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}
