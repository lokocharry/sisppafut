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
               
        /// <summary>
        ///A test for listarEquiposDeLiga
        ///</summary>
        [TestMethod()]
        public void listarEquiposDeLigaTest()
        {
            EquipoBC target = new EquipoBC();
            int Liga = 3;
            List<EquipoBE> expected = new List<EquipoBE>();

            EquipoBE equipo = new EquipoBE();
            equipo.CodigoEquipo = 21; equipo.CodigoPais = 1; equipo.NombreEquipo = "Sporting de Gijón"; equipo.AnioFundacion = 1905;
            equipo.CiudadEquipo = "Gijón"; equipo.CodigoEstadioPrincipal = 20; expected.Add(equipo);
            
            List<EquipoBE> actual;
            actual = target.listarEquiposDeLiga(Liga);

            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].CodigoEquipo, actual[i].CodigoEquipo);
                Assert.AreEqual(expected[i].CodigoPais, actual[i].CodigoPais);
                Assert.AreEqual(expected[i].NombreEquipo, actual[i].NombreEquipo);
                Assert.AreEqual(expected[i].AnioFundacion, actual[i].AnioFundacion);
                Assert.AreEqual(expected[i].CiudadEquipo, actual[i].CiudadEquipo);
                Assert.AreEqual(expected[i].CodigoEstadioPrincipal, actual[i].CodigoEstadioPrincipal);
            }
        }

        /// <summary>
        ///A test for listarEquipos
        ///</summary>
        [TestMethod()]
        public void listarEquiposTest()
        {
            EquipoBC target = new EquipoBC();
            string Pais = "España";
            List<EquipoBE> expected = new List<EquipoBE>();

            EquipoBE equipo1 = new EquipoBE(); equipo1.NombreEquipo = "FC Barcelona"; equipo1.AnioFundacion = 1899;
            EquipoBE equipo2 = new EquipoBE(); equipo2.NombreEquipo = "Real Madrid"; equipo2.AnioFundacion = 1902;
            EquipoBE equipo3 = new EquipoBE(); equipo3.NombreEquipo = "Valencia"; equipo3.AnioFundacion = 1919;
            EquipoBE equipo4 = new EquipoBE(); equipo4.NombreEquipo = "Levante"; equipo4.AnioFundacion = 1909;
            EquipoBE equipo5 = new EquipoBE(); equipo5.NombreEquipo = "Málaga"; equipo5.AnioFundacion = 1948;
            EquipoBE equipo6 = new EquipoBE(); equipo6.NombreEquipo = "Osasuna"; equipo6.AnioFundacion = 1920;
            EquipoBE equipo7 = new EquipoBE(); equipo7.NombreEquipo = "Espanyol"; equipo7.AnioFundacion = 1900;
            EquipoBE equipo8 = new EquipoBE(); equipo8.NombreEquipo = "Sevilla FC"; equipo8.AnioFundacion = 1905;
            EquipoBE equipo9 = new EquipoBE(); equipo9.NombreEquipo = "Atlético Madrid"; equipo9.AnioFundacion = 1903;
            EquipoBE equipo10 = new EquipoBE(); equipo10.NombreEquipo = "Getafe"; equipo10.AnioFundacion = 1983;
            EquipoBE equipo11 = new EquipoBE(); equipo11.NombreEquipo = "Athletic Bilbao"; equipo11.AnioFundacion = 1898;
            EquipoBE equipo12 = new EquipoBE(); equipo12.NombreEquipo = "Rayo Vallecano"; equipo12.AnioFundacion = 1924;
            EquipoBE equipo13 = new EquipoBE(); equipo13.NombreEquipo = "Real Betis"; equipo13.AnioFundacion = 1907;
            EquipoBE equipo14 = new EquipoBE(); equipo14.NombreEquipo = "Mallorca"; equipo14.AnioFundacion = 1916;
            EquipoBE equipo15 = new EquipoBE(); equipo15.NombreEquipo = "Real Sociedad"; equipo15.AnioFundacion = 1909;
            EquipoBE equipo16 = new EquipoBE(); equipo16.NombreEquipo = "Granada"; equipo16.AnioFundacion = 1931;
            EquipoBE equipo17 = new EquipoBE(); equipo17.NombreEquipo = "Villarreal"; equipo17.AnioFundacion = 1923;
            EquipoBE equipo18 = new EquipoBE(); equipo18.NombreEquipo = "Real Zaragoza"; equipo18.AnioFundacion = 1932;
            EquipoBE equipo19 = new EquipoBE(); equipo19.NombreEquipo = "Racing Santander"; equipo19.AnioFundacion = 1913;
            EquipoBE equipo20 = new EquipoBE(); equipo20.NombreEquipo = "Sporting de Gijón"; equipo20.AnioFundacion = 1905;

            expected.Add(equipo1);
            expected.Add(equipo2);
            expected.Add(equipo3);
            expected.Add(equipo4);
            expected.Add(equipo5);
            expected.Add(equipo6);
            expected.Add(equipo7);
            expected.Add(equipo8);
            expected.Add(equipo9);
            expected.Add(equipo10);
            expected.Add(equipo11);
            expected.Add(equipo12);
            expected.Add(equipo13);
            expected.Add(equipo14);
            expected.Add(equipo15);
            expected.Add(equipo16);
            expected.Add(equipo17);
            expected.Add(equipo18);
            expected.Add(equipo19);
            expected.Add(equipo20);

            List<EquipoBE> actual;
            actual = target.listarEquipos(Pais);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].NombreEquipo, actual[i].NombreEquipo);
                Assert.AreEqual(expected[i].AnioFundacion, actual[i].AnioFundacion);
            }

        }

        /// <summary>
        ///A test for actualizarEquipo
        ///</summary>
        [TestMethod()]
        public void actualizarEquipoTest()
        {
            EquipoBC target = new EquipoBC();
            int codigo_equipo = 5;
            int estadio_principal = 8;
            int estadio_alterno = 2;
            target.actualizarEquipo(codigo_equipo, estadio_principal, estadio_alterno);

            EquipoBE actual = target.obtenerEquipo("Levante");

            Assert.AreEqual(codigo_equipo, actual.CodigoEquipo);
            Assert.AreEqual(estadio_principal, actual.CodigoEstadioPrincipal);
            Assert.AreEqual(estadio_alterno, actual.CodigoEstadioAlterno);
        }
    }
}
