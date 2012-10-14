using UPC.Seguridad.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Seguridad.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for RolXFuncionalidadBCTest and is intended
    ///to contain all RolXFuncionalidadBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RolXFuncionalidadBCTest
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
        ///A test for Insertar_RolXFuncionalidad
        ///</summary>
        [TestMethod()]
        public void Insertar_RolXFuncionalidadTest()
        {
            RolXFuncionalidadBC.Propiedades.userLogged = "demoADMIN";
            RolXFuncionalidadBC target = new RolXFuncionalidadBC();
            List<RolXFuncionalidadBE> lst_RolFunc = new List<RolXFuncionalidadBE>();

            RolXFuncionalidadBE obj1 = new RolXFuncionalidadBE();
            obj1.idRol = 4;
            obj1.idFuncionalidad = 20;

            lst_RolFunc.Add(obj1);

            RolXFuncionalidadBE obj2 = new RolXFuncionalidadBE();
            obj2.idRol = 3;
            obj2.idFuncionalidad = 19;

            lst_RolFunc.Add(obj2);
            
            target.Insertar_RolXFuncionalidad(lst_RolFunc);
        }

        /// <summary>
        ///A test for Listar_FuncionalidadesXRol
        ///</summary>
        [TestMethod()]
        public void Listar_FuncionalidadesXRolTest()
        {
            RolXFuncionalidadBC.Propiedades.userLogged = "demoADMIN";
            RolXFuncionalidadBC target = new RolXFuncionalidadBC();
            int idRol = 1;
            int expected = 17;
            List<FuncionalidadBE> actual;
            actual = target.Listar_FuncionalidadesXRol(idRol);
            Assert.AreEqual(expected, actual.Count);
        }

        /// <summary>
        ///A test for VerificarSiExiste_RolXFuncionalidad
        ///</summary>
        [TestMethod()]
        public void VerificarSiExiste_RolXFuncionalidadTest()
        {
            RolXFuncionalidadBC.Propiedades.userLogged = "demoADMIN";
            RolXFuncionalidadBC target = new RolXFuncionalidadBC();
            int idRol = 1;
            int idFuncionalidad = 1;
            int expected = 1;
            int actual;
            actual = target.VerificarSiExiste_RolXFuncionalidad(idRol, idFuncionalidad);
            Assert.AreEqual(expected, actual);
        }
    }
}
