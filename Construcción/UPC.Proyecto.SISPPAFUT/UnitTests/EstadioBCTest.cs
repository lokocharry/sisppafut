using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

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
                
        /// <summary>
        ///A test for listarEstadios
        ///</summary>
        [TestMethod()]
        public void listarEstadiosTest()
        {
            EstadioBC target = new EstadioBC();
            List<EstadioBE> expected = new List<EstadioBE>();
            List<EstadioBE> actual;

            EstadioBE estadio1 = new EstadioBE(); estadio1.Codigo_estadio = 1; estadio1.Nombre_estadio = "Santiago Bernabéu";
            EstadioBE estadio2 = new EstadioBE(); estadio2.Codigo_estadio = 2; estadio2.Nombre_estadio = "Camp Nou";
            EstadioBE estadio3 = new EstadioBE(); estadio3.Codigo_estadio = 3; estadio3.Nombre_estadio = "Mestalla";
            EstadioBE estadio4 = new EstadioBE(); estadio4.Codigo_estadio = 4; estadio4.Nombre_estadio = "La Rosadela";
            EstadioBE estadio5 = new EstadioBE(); estadio5.Codigo_estadio = 5; estadio5.Nombre_estadio = "Ciudad de Valencia";
            EstadioBE estadio6 = new EstadioBE(); estadio6.Codigo_estadio = 6; estadio6.Nombre_estadio = "Reyno de Navarra";
            EstadioBE estadio7 = new EstadioBE(); estadio7.Codigo_estadio = 7; estadio7.Nombre_estadio = "Cornella El Prat";
            EstadioBE estadio8 = new EstadioBE(); estadio8.Codigo_estadio = 8; estadio8.Nombre_estadio = "Ramón Sánchez Pizjuá";
            EstadioBE estadio9 = new EstadioBE(); estadio9.Codigo_estadio = 9; estadio9.Nombre_estadio = "Vicente Calderón";
            EstadioBE estadio10 = new EstadioBE(); estadio10.Codigo_estadio = 10; estadio10.Nombre_estadio = "Alfonso Pérez";
            EstadioBE estadio11 = new EstadioBE(); estadio11.Codigo_estadio = 11; estadio11.Nombre_estadio = "San Mamés";
            EstadioBE estadio12 = new EstadioBE(); estadio12.Codigo_estadio = 12; estadio12.Nombre_estadio = "Teresa Rivero";
            EstadioBE estadio13 = new EstadioBE(); estadio13.Codigo_estadio = 13; estadio13.Nombre_estadio = "Benito Villamarín";
            EstadioBE estadio14 = new EstadioBE(); estadio14.Codigo_estadio = 14; estadio14.Nombre_estadio = "Iberostar Estadi";
            EstadioBE estadio15 = new EstadioBE(); estadio15.Codigo_estadio = 15; estadio15.Nombre_estadio = "Anoeta";
            EstadioBE estadio16 = new EstadioBE(); estadio16.Codigo_estadio = 16; estadio16.Nombre_estadio = "Los Cármenes";
            EstadioBE estadio17 = new EstadioBE(); estadio17.Codigo_estadio = 17; estadio17.Nombre_estadio = "El Madrigal";
            EstadioBE estadio18 = new EstadioBE(); estadio18.Codigo_estadio = 18; estadio18.Nombre_estadio = "La Romareda";
            EstadioBE estadio19 = new EstadioBE(); estadio19.Codigo_estadio = 19; estadio19.Nombre_estadio = "El Sardinero";
            EstadioBE estadio20 = new EstadioBE(); estadio20.Codigo_estadio = 20; estadio20.Nombre_estadio = "El Molinón";

            expected.Add(estadio1);
            expected.Add(estadio2);
            expected.Add(estadio3);
            expected.Add(estadio4);
            expected.Add(estadio5);
            expected.Add(estadio6);
            expected.Add(estadio7);
            expected.Add(estadio8);
            expected.Add(estadio9);
            expected.Add(estadio10);
            expected.Add(estadio11);
            expected.Add(estadio12);
            expected.Add(estadio13);
            expected.Add(estadio14);
            expected.Add(estadio15);
            expected.Add(estadio16);
            expected.Add(estadio17);
            expected.Add(estadio18);
            expected.Add(estadio19);
            expected.Add(estadio20);

            actual = target.listarEstadios();
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Codigo_estadio, actual[i].Codigo_estadio);
                Assert.AreEqual(expected[i].Nombre_estadio, actual[i].Nombre_estadio);
            }
        }

        /// <summary>
        ///A test for listarEstadiosDeEquipo
        ///</summary>
        [TestMethod()]
        public void listarEstadiosDeEquipoTest()
        {
            EstadioBC target = new EstadioBC();
            int codigo_equipo = 1;
            List<EstadioBE> expected = new List<EstadioBE>();
            List<EstadioBE> actual;

            EstadioBE estadio = new EstadioBE();
            estadio.Codigo_estadio = 2; estadio.Codigo_pais = 1; estadio.Anho_fundacion = 1957; estadio.Nombre_estadio="Camp Nou";
            estadio.Ciudad_estadio = "Barcelona"; estadio.Aforo_estadio = 98772; expected.Add(estadio);

            actual = target.listarEstadiosDeEquipo(codigo_equipo);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Codigo_estadio, actual[i].Codigo_estadio);
                Assert.AreEqual(expected[i].Nombre_estadio, actual[i].Nombre_estadio);
            }
        }
    }
}
