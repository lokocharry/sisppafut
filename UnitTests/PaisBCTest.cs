using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for PaisBCTest and is intended
    ///to contain all PaisBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PaisBCTest
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
        ///A test for PaisBC Constructor
        ///</summary>
        [TestMethod()]
        public void PaisBCConstructorTest()
        {
            PaisBC target = new PaisBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for insertarPais
        ///</summary>
        [TestMethod()]
        public void insertarPaisTest()
        {
            PaisBC target = new PaisBC(); 
            
            PaisBE objPaisBE = new PaisBE();
            objPaisBE.NombrePais = "Mexico";

            int expected = 0;
            int actual;
            actual = target.insertarPais(objPaisBE);
            
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for listarPaises
        ///</summary>
        [TestMethod()]
        public void listarPaisesTest()
        {
            PaisBC target = new PaisBC(); 

            List<PaisBE> expected = new List<PaisBE>();

            PaisBE pais1 = new PaisBE(); pais1.CodigoPais = 0; pais1.NombrePais = "Argentina"; expected.Add(pais1);
            PaisBE pais2 = new PaisBE(); pais2.CodigoPais = 0; pais2.NombrePais = "Brasil"; expected.Add(pais2);
            PaisBE pais3 = new PaisBE(); pais3.CodigoPais = 0; pais3.NombrePais = "Holanda"; expected.Add(pais3);
            PaisBE pais4 = new PaisBE(); pais4.CodigoPais = 0; pais4.NombrePais = "Francia"; expected.Add(pais4);
            PaisBE pais5 = new PaisBE(); pais5.CodigoPais = 0; pais5.NombrePais = "Alemania"; expected.Add(pais5);
            PaisBE pais6 = new PaisBE(); pais6.CodigoPais = 0; pais6.NombrePais = "España"; expected.Add(pais6);
            PaisBE pais7 = new PaisBE(); pais7.CodigoPais = 0; pais7.NombrePais = "Portugal"; expected.Add(pais7);
            
            List<PaisBE> actual;
            
            actual = target.listarPaises();
            Assert.AreEqual(expected, actual);
        }
    }
}
