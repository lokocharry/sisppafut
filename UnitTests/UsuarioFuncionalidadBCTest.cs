using UPC.Seguridad.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Seguridad.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for UsuarioFuncionalidadBCTest and is intended
    ///to contain all UsuarioFuncionalidadBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsuarioFuncionalidadBCTest
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
        ///A test for Insertar_UsuarioFuncionalidad
        ///</summary>
        [TestMethod()]
        public void Insertar_UsuarioFuncionalidadTest()
        {
            UsuarioFuncionalidadBC.Propiedades.userLogged = "demoADMIN";
            UsuarioFuncionalidadBC target = new UsuarioFuncionalidadBC();
            List<UsuarioFuncionalidadBE> lst_usuarios = new List<UsuarioFuncionalidadBE>();

            UsuarioFuncionalidadBE obj1 = new UsuarioFuncionalidadBE();
            obj1.idFuncionalidad = 17;
            obj1.idUsuario = 4;

            lst_usuarios.Add(obj1);

            target.Insertar_UsuarioFuncionalidad(lst_usuarios);
 
        }

        /// <summary>
        ///A test for Verificar_ExisteUsuarioFuncionalidad
        ///</summary>
        [TestMethod()]
        public void Verificar_ExisteUsuarioFuncionalidadTest()
        {
            UsuarioFuncionalidadBC.Propiedades.userLogged = "demoADMIN";
            UsuarioFuncionalidadBC target = new UsuarioFuncionalidadBC();
            int idUsuario = 1;
            int idFuncionalidad = 1;
            int expected = 1; 
            int actual;
            actual = target.Verificar_ExisteUsuarioFuncionalidad(idUsuario, idFuncionalidad);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Listar_FuncionalidadesXUsuario
        ///</summary>
        [TestMethod()]
        public void Listar_FuncionalidadesXUsuarioTest()
        {
            UsuarioFuncionalidadBC.Propiedades.userLogged = "demoADMIN";
            UsuarioFuncionalidadBC target = new UsuarioFuncionalidadBC();
            int idUsuario = 1;
            int expected = 17;
            List<FuncionalidadBE> actual;
            actual = target.Listar_FuncionalidadesXUsuario(idUsuario);
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
