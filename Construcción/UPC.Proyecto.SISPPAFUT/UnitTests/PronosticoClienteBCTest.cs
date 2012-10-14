using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for PronosticoClienteBCTest and is intended
    ///to contain all PronosticoClienteBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PronosticoClienteBCTest
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

        [TestMethod()]
        public void PronosticoClienteBCConstructorTest()
        {
            PronosticoClienteBC target = new PronosticoClienteBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void inssertarPronosticoClienteTest()
        {
            PronosticoClienteBC target = new PronosticoClienteBC();
            PronosticoClienteBC.Propiedades.userLogged = "demoADMIN";
            PronosticoClienteBE objPronosticoClienteBE = new PronosticoClienteBE();

            objPronosticoClienteBE.CodigoPartido = 769;
            objPronosticoClienteBE.CodigoUsuario = 2;
            objPronosticoClienteBE.Pronostico = "L";

            target.inssertarPronosticoCliente(objPronosticoClienteBE);

            Assert.AreEqual(target.listarPronosticosCliente(2).Count, 1);
        }

        [TestMethod()]
        public void listarPronosticosClienteTest()
        {
            PronosticoClienteBC target = new PronosticoClienteBC();
            PronosticoClienteBC.Propiedades.userLogged = "demoADMIN";
            PronosticoClienteBE objPronosticoClienteBE = new PronosticoClienteBE();
            objPronosticoClienteBE.CodigoPartido = 756;
            objPronosticoClienteBE.CodigoUsuario = 1;
            objPronosticoClienteBE.Pronostico = "L";
            target.inssertarPronosticoCliente(objPronosticoClienteBE);

            objPronosticoClienteBE = new PronosticoClienteBE();
            objPronosticoClienteBE.CodigoPartido = 757;
            objPronosticoClienteBE.CodigoUsuario = 1;
            objPronosticoClienteBE.Pronostico = "E";
            target.inssertarPronosticoCliente(objPronosticoClienteBE);

            objPronosticoClienteBE = new PronosticoClienteBE();
            objPronosticoClienteBE.CodigoPartido = 758;
            objPronosticoClienteBE.CodigoUsuario = 1;
            objPronosticoClienteBE.Pronostico = "V";
            target.inssertarPronosticoCliente(objPronosticoClienteBE);

            Assert.AreEqual(target.listarPronosticosCliente(1).Count, 13);
        }

        /// <summary>
        ///Una prueba de inssertarPronosticoCliente
        ///</summary>
    }
}
