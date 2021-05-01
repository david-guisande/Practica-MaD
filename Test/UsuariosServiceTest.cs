using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Ninject;
using System.Data.Entity;
using System.Transactions;
using Es.Udc.DotNet.ModelUtil.Dao;
using Ninject.Activation;
using Es.Udc.DotNet.Photogram.Model;
using Es.Udc.DotNet.Photogram.Model.Service;

namespace Es.Udc.DotNet.Photogram.Test
{
    /// <summary>
    /// Summary description for UsuariosServiceTest
    /// </summary>
    [TestClass]
    public class UsuariosServiceTest
    {
        private static IKernel kernel;

        private TestContext testContextInstance;
        private static IUsuariosService usuariosService;
        private static IPublicacionesService publicacionesService;
        private static IComentariosService comentariosService;

        private static IUserProfileDao userProfileDao;
        private static IPublicacionesDao publicacionesDao;
        private static IComentariosDao comentariosDao;

        public UsuariosServiceTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


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
        // You can use the following additional attributes as you write your tests:
        //
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            usuariosService = kernel.Get<IUsuariosService>();
            publicacionesService = kernel.Get<IPublicacionesService>();
            comentariosService = kernel.Get<IComentariosService>();

            userProfileDao = kernel.Get<IUserProfileDao>();
            publicacionesDao = kernel.Get<IPublicacionesDao>();
            comentariosDao = kernel.Get<IComentariosDao>();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod()]
        public void RegistrarUsuarioTest()
        {
            try
            {
                Int64 id = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "pepe@gmail.es", "spain", "es");
                userProfileDao.Find(id);

                userProfileDao.Remove(id);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void AutenticarTest()
        {
            try
            {
                Int64 id = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "pepe@gmail.es", "spain", "es");
                Assert.IsFalse(usuariosService.Autenticar("elpepe", "contraseña"));
                Assert.IsTrue(usuariosService.Autenticar("elpepe", "12345"));

                userProfileDao.Remove(id);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void SeguidoresTest()
        {
            try
            {
                Int64 id = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "pepe@gmail.es", "spain", "es");
                Int64 id2 = usuariosService.RegistrarUsuario("elmanolo", "contrase", "manolo", "manolo@gmail.es", "spain", "es");
                Usuarios pepe = userProfileDao.Find(id);
                Usuarios manu = userProfileDao.Find(id2);

                usuariosService.SeguirA(id, id2);

                Assert.AreEqual(usuariosService.VerSeguidores(id2, 0)[0].usrId, id);
                Assert.AreEqual(usuariosService.VerSeguidos(id, 0)[0].usrId, id2);

                userProfileDao.Remove(id);
                userProfileDao.Remove(id2);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}