using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for JugadorPartidoBCTest and is intended
    ///to contain all JugadorPartidoBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JugadorPartidoBCTest
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
        ///A test for insertar_jugadores
        ///</summary>
        [TestMethod()]
        public void insertar_jugadoresTest()
        {
            JugadorPartidoBC.Propiedades.userLogged = "demoADMIN";
            List<JugadorPartidoBE> lista_jugadores = new List<JugadorPartidoBE>();

            JugadorPartidoBE obj = new JugadorPartidoBE();
            obj.Codigo_partido = 7;
            obj.Codigo_jugador = 14;
            obj.Estado = 1;
            lista_jugadores.Add(obj);
            
            JugadorPartidoBE obj1 = new JugadorPartidoBE();
            obj1.Codigo_partido = 7;
            obj1.Codigo_jugador = 15;
            obj1.Estado = 0;
            lista_jugadores.Add(obj1);
            
            JugadorPartidoBE obj2 = new JugadorPartidoBE();
            obj2.Codigo_partido = 7;
            obj2.Codigo_jugador = 16;
            obj2.Estado = 1;
            lista_jugadores.Add(obj2);
            
            JugadorPartidoBE obj3 = new JugadorPartidoBE();
            obj3.Codigo_partido = 7;
            obj3.Codigo_jugador = 19;
            obj3.Estado = 1;

            lista_jugadores.Add(obj3);

            JugadorPartidoBC target = new JugadorPartidoBC();
            target.insertar_jugadores(lista_jugadores);
        }
    }
}
