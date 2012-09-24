using UPC.Seguridad.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Seguridad.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for UsuarioRolBCTest and is intended
    ///to contain all UsuarioRolBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsuarioRolBCTest
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
        ///A test for asignar_RolUsuario
        ///</summary>
        [TestMethod()]
        public void asignar_RolUsuarioTest()
        {
            UsuarioRolBC target = new UsuarioRolBC();
            List<UsuarioRolBE> lst_asoc = new List<UsuarioRolBE>();
            
            UsuarioRolBE obj1 = new UsuarioRolBE();
            obj1.IdUsuario = 4;
            obj1.IdRol = 1;

            lst_asoc.Add(obj1);

            UsuarioRolBE obj2 = new UsuarioRolBE();
            obj2.IdUsuario = 3;
            obj2.IdRol = 3;

            lst_asoc.Add(obj2);
            
            target.asignar_RolUsuario(lst_asoc);
        }

        /// <summary>
        ///A test for VerificarExiste_Asociacion
        ///</summary>
        [TestMethod()]
        public void VerificarExiste_AsociacionTest()
        {
            UsuarioRolBC target = new UsuarioRolBC();
            int idRol = 3; 
            int idUsuario = 3;
            int expected = 1; 
            int actual;
            actual = target.VerificarExiste_Asociacion(idRol, idUsuario);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Listar_RolesXUsuario
        ///</summary>
        [TestMethod()]
        public void Listar_RolesXUsuarioTest()
        {
            UsuarioRolBC target = new UsuarioRolBC(); 
            int idUsuario = 1;
            int expected = 1;
            List<RolBE> actual;
            actual = target.Listar_RolesXUsuario(idUsuario);
            Assert.AreEqual(expected, actual.Count);
        }

        /// <summary>
        ///A test for UsuarioRolBC Constructor
        ///</summary>
        [TestMethod()]
        public void UsuarioRolBCConstructorTest()
        {
            UsuarioRolBC target = new UsuarioRolBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
