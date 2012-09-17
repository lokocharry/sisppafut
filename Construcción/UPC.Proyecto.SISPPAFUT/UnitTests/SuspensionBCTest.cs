using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for SuspensionBCTest and is intended
    ///to contain all SuspensionBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SuspensionBCTest
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
        ///A test for SuspensionBC Constructor
        ///</summary>
        [TestMethod()]
        public void SuspensionBCConstructorTest()
        {
            SuspensionBC target = new SuspensionBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for actualizar_Suspension
        ///</summary>
        [TestMethod()]
        public void actualizar_SuspensionTest()
        {
            SuspensionBC target = new SuspensionBC();
            int codJugador = 1;
            int tipo = 3;
            int codLiga = 1;
            target.actualizar_Suspension(codJugador, codLiga,tipo);
            String actual = target.leer_EstadoSuspension(codJugador, codLiga);
            String expected = "NO SUSPENDIDO";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for crear_Suspension
        ///</summary>
        [TestMethod()]
        public void crear_SuspensionTest()
        {
            SuspensionBC target = new SuspensionBC();
            SuspensionBE objSuspensionBE = new SuspensionBE();
            objSuspensionBE.CodigoJugador = 4;
            objSuspensionBE.CodLiga = 1;
            target.crear_Suspension(objSuspensionBE);
            int codJugador = objSuspensionBE.CodigoJugador;

            String actual = target.leer_EstadoSuspension(codJugador, objSuspensionBE.CodLiga);
            String expected = "NO SUSPENDIDO";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for leer_EstadoSuspension
        ///</summary>
        [TestMethod()]
        public void leer_EstadoSuspensionTest()
        {
            SuspensionBC target = new SuspensionBC();
            int codJugador = 1;
            int codLiga = 1;
            String expected = "NO SUSPENDIDO";
            String actual;
            actual = target.leer_EstadoSuspension(codJugador, codLiga);

            Assert.AreEqual(expected, actual);
        }
    }
}
