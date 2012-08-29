using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

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
            objPartidoBE.Fecha_partido = Convert.ToDateTime("2012-04-24");

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
        }

        /// <summary>
        ///A test for obtener_Partido
        ///</summary>
        [TestMethod()]
        public void obtener_PartidoTest()
        {
            PartidoBE expected = new PartidoBE();
            expected.Codigo_partido = 2;
            expected.Codigo_liga = 3;
            expected.Codigo_equipo_local = 14;
            expected.Codigo_equipo_visitante = 12;
            expected.Codigo_estadio = 13;
            expected.Fecha_partido = Convert.ToDateTime("2011-08-19");

            PartidoBC target = new PartidoBC(); 
            int codigo_partido = 2;

            PartidoBE actual;
            actual = target.obtener_Partido(codigo_partido);

            Assert.AreEqual(expected.Codigo_partido, actual.Codigo_partido);
            Assert.AreEqual(expected.Codigo_liga, actual.Codigo_liga);
            Assert.AreEqual(expected.Codigo_equipo_local, actual.Codigo_equipo_local);
            Assert.AreEqual(expected.Codigo_equipo_visitante, actual.Codigo_equipo_visitante);
            Assert.AreEqual(expected.Codigo_estadio, actual.Codigo_estadio);
            Assert.AreEqual(expected.Fecha_partido, actual.Fecha_partido);
        }

        /// <summary>
        ///A test for lista_partidos_sinjugar
        ///</summary>
        [TestMethod()]
        public void lista_partidos_sinjugarTest()
        {
            List<PartidoSinJugarBE> expected = new List<PartidoSinJugarBE>();

            PartidoSinJugarBE obj = new PartidoSinJugarBE();
            obj.Codigo_partido = 1;
            obj.Equipo_local = "Málaga";
            obj.Equipo_visitante = "FC Barcelona";
            obj.Liga = "La Liga BBVA 2011/2012";
            obj.Pais = "España";
            obj.Fecha = Convert.ToDateTime("2011-08-18");
            expected.Add(obj);

            PartidoSinJugarBE obj2 = new PartidoSinJugarBE();
            obj2.Codigo_partido = 2;
            obj2.Equipo_local = "Real Betis";
            obj2.Equipo_visitante = "Athletic Bilbao";
            obj2.Liga = "La Liga BBVA 2011/2012";
            obj2.Pais = "España";
            obj2.Fecha = Convert.ToDateTime("2011-08-19");
            expected.Add(obj2);

            PartidoSinJugarBE obj3 = new PartidoSinJugarBE();
            obj3.Codigo_partido = 3;
            obj3.Equipo_local = "Villarreal";
            obj3.Equipo_visitante = "Espanyol";
            obj3.Liga = "La Liga BBVA 2011/2012";
            obj3.Pais = "España";
            obj3.Fecha = Convert.ToDateTime("2011-08-20");
            expected.Add(obj3);

            PartidoSinJugarBE obj4 = new PartidoSinJugarBE();
            obj4.Codigo_partido = 4;
            obj4.Equipo_local = "Real Madrid";
            obj4.Equipo_visitante = "FC Barcelona";
            obj4.Liga = "La Liga BBVA 2011/2012";
            obj4.Pais = "España";
            obj4.Fecha = Convert.ToDateTime("2011-12-10");
            expected.Add(obj4);

            PartidoBC target = new PartidoBC();
            List<PartidoSinJugarBE> actual = new List<PartidoSinJugarBE>();
            actual = target.lista_partidos_sinjugar();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Codigo_partido, actual[i].Codigo_partido);
                Assert.AreEqual(expected[i].Equipo_local, actual[i].Equipo_local);
                Assert.AreEqual(expected[i].Equipo_visitante, actual[i].Equipo_visitante);
                Assert.AreEqual(expected[i].Liga, actual[i].Liga);
                Assert.AreEqual(expected[i].Pais, actual[i].Pais);
                Assert.AreEqual(expected[i].Fecha, actual[i].Fecha);
            }
        }

        /// <summary>
        ///A test for editar_Partido
        ///</summary>
        [TestMethod()]
        public void editar_PartidoTest()
        {
            PartidoBC target = new PartidoBC();
            int codigoPartido = 1;
            DateTime nuevaFecha = new DateTime(2012,5,10);
            target.editar_Partido(codigoPartido, nuevaFecha);

            PartidoBE actual = target.obtener_Partido(codigoPartido);

            Assert.AreEqual(codigoPartido, actual.Codigo_partido);
            Assert.AreEqual(nuevaFecha, actual.Fecha_partido);
        }


        /// <summary>
        ///A test for actualizar_Resultado
        ///</summary>
        [TestMethod()]
        public void actualizar_ResultadoTest()
        {
            PartidoBC target = new PartidoBC(); // TODO: Initialize to an appropriate value
            int codigo_partido = 5; // TODO: Initialize to an appropriate value
            int goles_local = 3; // TODO: Initialize to an appropriate value
            int goles_visita = 1; // TODO: Initialize to an appropriate value

            target.actualizar_Resultado(codigo_partido, goles_local, goles_visita);

            PartidoBE actual = new PartidoBE();
            actual = target.obtener_Partido(codigo_partido);

            Assert.AreEqual(goles_visita, actual.Goles_visita);
        }

        /// <summary>
        ///A test for lista_ultimosPartidos
        ///</summary>
        [TestMethod()]
        public void lista_ultimosPartidosTest()
        {
            PartidoBC target = new PartidoBC(); 
            int codigo_equipo = 1;
            int codigo_liga = 3;
            List<PartidoJugadoBE> expected = new List<PartidoJugadoBE>();

            PartidoJugadoBE oPartido = new PartidoJugadoBE();
            oPartido.CodPartido = 5;
            oPartido.Equipo_visita = "Real Madrid";
            oPartido.Equipo_local = "FC Barcelona";
            oPartido.Fecha = Convert.ToDateTime("2012-04-21");
            oPartido.Goles_local = 3;
            oPartido.Goles_visita = 1;
            oPartido.Liga = "La Liga BBVA 2011/2012";

            expected.Add(oPartido);

            List<PartidoJugadoBE> actual;
            actual = target.lista_ultimosPartidos(codigo_equipo, codigo_liga);
            Assert.AreEqual(expected[0].Equipo_local, actual[0].Equipo_local);
            Assert.AreEqual(expected[0].Equipo_visita, actual[0].Equipo_visita);
            Assert.AreEqual(expected[0].Goles_local, actual[0].Goles_local);
            Assert.AreEqual(expected[0].Goles_visita, actual[0].Goles_visita);
            Assert.AreEqual(expected[0].Liga, actual[0].Liga);
            Assert.AreEqual(expected[0].Fecha, actual[0].Fecha);
            Assert.AreEqual(expected[0].CodPartido, actual[0].CodPartido);
        }
    }
}
