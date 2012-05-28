using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for JugadorBCTest and is intended
    ///to contain all JugadorBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JugadorBCTest
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
        ///A test for JugadorBC Constructor
        ///</summary>
        [TestMethod()]
        public void JugadorBCConstructorTest()
        {
            JugadorBC target = new JugadorBC();
        }

        /// <summary>
        ///A test for insertar_Jugador
        ///</summary>
        [TestMethod()]
        public void insertar_JugadorTest()
        {
            JugadorBC target = new JugadorBC();
            JugadorBE objJugadorBE = new JugadorBE();

            objJugadorBE.Nombres = "Lionel";
            objJugadorBE.Apellidos = "Messi";
            objJugadorBE.Nacionalidad = "Argentina";
            objJugadorBE.FechaNacimiento = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            objJugadorBE.Altura = 1.69m;
            objJugadorBE.Peso = 60.0m;
            objJugadorBE.Posicion = "Delantero";

            int expected = 0;
            int actual;
            actual = target.insertar_Jugador(objJugadorBE);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for verificar_EstadoSuspension
        ///</summary>
        [TestMethod()]
        public void verificar_EstadoSuspensionTest()
        {
            JugadorBC target = new JugadorBC(); 
            int codigo_jugador = 40; 
            string expected = "NO SUSPENDIDO";
            string actual;
            actual = target.verificar_EstadoSuspension(codigo_jugador);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for listar_Jugadores_xEquipo
        ///</summary>
        [TestMethod()]
        public void listar_Jugadores_xEquipoTest()
        {
            JugadorBC target = new JugadorBC();
            int codigo_equipo = 1;
            
            int expected = 21;
            List<JugadorBE> actual;
            actual = target.listar_Jugadores_xEquipo(codigo_equipo);
            Assert.AreEqual(expected, actual.Count);
        }

        /// <summary>
        ///A test for asignar_JugadoraEquipo
        ///</summary>
        [TestMethod()]
        public void asignar_JugadoraEquipoTest()
        {
            List<JugadorEquipoBE> lista_jugadores = new List<JugadorEquipoBE>();

            JugadorEquipoBE obj = new JugadorEquipoBE();
            obj.Codigo_equipo = 1;
            obj.Codigo_jugador = 14;
            lista_jugadores.Add(obj);

            JugadorEquipoBE obj1 = new JugadorEquipoBE();
            obj1.Codigo_equipo = 1;
            obj1.Codigo_jugador = 15;
            lista_jugadores.Add(obj1);

            JugadorEquipoBE obj2 = new JugadorEquipoBE();
            obj2.Codigo_equipo = 3;
            obj2.Codigo_jugador = 40;
            lista_jugadores.Add(obj2);

            JugadorBC target = new JugadorBC();
            target.asignar_JugadoraEquipo(lista_jugadores);
        }

        /// <summary>
        ///A test for editar_Jugador
        ///</summary>
        [TestMethod()]
        public void editar_JugadorTest()
        {
            JugadorBC target = new JugadorBC();
            int codigoJugador = 1;
            Decimal nAltura = 1.70m;
            Decimal nPeso = 68.0m;
            target.editar_Jugador(codigoJugador, nAltura, nPeso);

            List<JugadorBE> actual = target.listar_Jugadores();

            Assert.AreEqual(codigoJugador, actual[0].CodigoJugador);
            Assert.AreEqual(nAltura, actual[0].Altura);
            Assert.AreEqual(nPeso, actual[0].Peso);
        }
    }
}
