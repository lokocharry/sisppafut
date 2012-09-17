using UPC.Seguridad.BL.BC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para RolBCTest y se pretende que
    ///contenga todas las pruebas unitarias RolBCTest.
    ///</summary>
    [TestClass()]
    public class RolBCTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
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

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de Insertar_Rol
        ///</summary>
        [TestMethod()]
        public void Insertar_RolTest()
        {
            RolBC target = new RolBC();
            string NombreRol = "Administrador del Sistema";
            string ClaveRol = "admin";
            string DescripcionRol = "El administrador del sistema puede gestionar toda la información";
            int expected = 1; 
            int actual;
            actual = target.Insertar_Rol(NombreRol, ClaveRol, DescripcionRol);
            Assert.AreEqual(expected, actual);
        }
    }
}
