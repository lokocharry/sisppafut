using UPC.Seguridad.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Seguridad.BL.BE;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass()]
    public class UsuarioBCTest
    {


        private TestContext testContextInstance;

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
        public void UsuarioBCConstructorTest()
        {
            UsuarioBC target = new UsuarioBC();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void insertar_UsuarioTest()
        {
            UsuarioBC.Propiedades.userLogged = "demoADMIN";
            UsuarioBC target = new UsuarioBC();
            UsuarioBE objUsuarioBE = new UsuarioBE();

            objUsuarioBE.NombreUsuario = "userPrueba";
            objUsuarioBE.Nombre = "John";
            objUsuarioBE.ApellidoPaterno = "Doe";
            objUsuarioBE.ApellidoMaterno = "Smith";
            objUsuarioBE.FechaNacimiento = DateTime.Now;
            objUsuarioBE.Contrasenia = "password";
            
            int expected = 0;
            int actual;
            actual = target.insertar_Usuario(objUsuarioBE);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void listar_UsuariosTest()
        {
            UsuarioBC.Propiedades.userLogged = "demoADMIN";
            UsuarioBC target = new UsuarioBC();
            List<UsuarioBE> expected = target.listar_Usuarios();
            int actual;
            actual = 0;

            Assert.AreNotEqual(expected.Count, actual);
            //Se verifica que la lista no este vacia y se puedann devolver valores
        }

        /// <summary>
        ///A test for Verificar_LoginUsuario
        ///</summary>
        [TestMethod()]
        public void Verificar_LoginUsuarioTest()
        {
            UsuarioBC.Propiedades.userLogged = "demoADMIN";
            UsuarioBC target = new UsuarioBC();
            string usuario = "demoADMIN";
            string contrasenia = "demoAdmin";
            int expected = 1;
            int actual;
            actual = target.Verificar_LoginUsuario(usuario, contrasenia);
            Assert.AreEqual(expected, actual);
        }
    }
}
