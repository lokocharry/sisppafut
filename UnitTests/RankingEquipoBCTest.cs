using UPC.Proyecto.SISPPAFUT.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for RankingEquipoBCTest and is intended
    ///to contain all RankingEquipoBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RankingEquipoBCTest
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
        ///A test for RankingEquipoBC Constructor
        ///</summary>
        [TestMethod()]
        public void RankingEquipoBCConstructorTest()
        {
            RankingEquipoBC target = new RankingEquipoBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for insertar_ranking
        ///</summary>
        [TestMethod()]
        public void insertar_rankingTest()
        {
            RankingEquipoBC target = new RankingEquipoBC();
            RankingEquipoBE objRankingEquipoBE = new RankingEquipoBE();

            objRankingEquipoBE.CodigoEquipo = 4;
            objRankingEquipoBE.PosicionRanking = 4;
            objRankingEquipoBE.AnioRanking = 2012;
            objRankingEquipoBE.MesRanking = 4;
            objRankingEquipoBE.PuntosRanking = 250;

            int expected = 0;
            int actual;
            actual = target.insertar_ranking(objRankingEquipoBE);

            Assert.AreNotEqual(expected, actual);
        }        

        /// <summary>
        ///A test for obtener_ranking
        ///</summary>
        [TestMethod()]
        public void obtener_rankingTest()
        {
            RankingEquipoBC target = new RankingEquipoBC();
            int anio = 2012;
            int mes = 4;
            int codigoPais = 1;
            List<RankingBE> expected = null;
            List<RankingBE> actual;
            actual = target.obtener_ranking(anio, mes, codigoPais);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
