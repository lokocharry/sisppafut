using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for CompeticionBCTest and is intended
    ///to contain all CompeticionBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompeticionBCTest
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
        ///A test for CompeticionBC Constructor
        ///</summary>
        [TestMethod()]
        public void CompeticionBCConstructorTest()
        {
            CompeticionBC target = new CompeticionBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for insertar_Competicion
        ///</summary>
        [TestMethod()]
        public void insertar_CompeticionTest()
        {
            CompeticionBC target = new CompeticionBC();
            
            CompeticionBE objCompeticionBE = new CompeticionBE();
            objCompeticionBE.Codigo_pais = 7;
            objCompeticionBE.Nombre_competicion = "Copa de Portugal";

            int expected = 0;
            int actual;
            actual = target.insertar_Competicion(objCompeticionBE);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for ListarCompeticion
        ///</summary>
        [TestMethod()]
        public void ListarCompeticionTest()
        {
            CompeticionBC target = new CompeticionBC();
            string Pais = "España";

            List<CompeticionBE> expected = new List<CompeticionBE>();

            CompeticionBE comp1 = new CompeticionBE();
            comp1.Codigo_competicion = 1; comp1.Codigo_pais = 0; comp1.Nombre_competicion = "La liga";
            expected.Add(comp1);
            CompeticionBE comp2 = new CompeticionBE();
            comp2.Codigo_competicion = 2; comp2.Codigo_pais = 0; comp2.Nombre_competicion = "Segunda División";
            expected.Add(comp2);
            CompeticionBE comp3 = new CompeticionBE();
            comp3.Codigo_competicion = 3; comp3.Codigo_pais = 0; comp3.Nombre_competicion = "Copa del Rey";
            expected.Add(comp3);

            List<CompeticionBE> actual = new List<CompeticionBE>();
            actual = target.ListarCompeticion(Pais);

            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Codigo_competicion, actual[i].Codigo_competicion);
                Assert.AreEqual(expected[i].Codigo_pais, actual[i].Codigo_pais);
                Assert.AreEqual(expected[i].Nombre_competicion, actual[i].Nombre_competicion);
            }
        }
    }
}
