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
    /// Summary description for PublicacionesServiceTest
    /// </summary>
    [TestClass]
    public class PublicacionesServiceTest
    {
        private static IKernel kernel;

        private TestContext testContextInstance;
        private static IUsuariosService usuariosService;
        private static IPublicacionesService publicacionesService;
        private static IComentariosService comentariosService;

        private static IUserProfileDao userProfileDao;
        private static IPublicacionesDao publicacionesDao;
        private static IComentariosDao comentariosDao;
        public PublicacionesServiceTest()
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
        // Use ClassInitialize to run code before running the first test in the class
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
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SubirImagenTest()
        {
            try
            {
                Int64 usrId = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "pepe@gmail.es", "spain", "es");
                Int64 id = publicacionesService.SubirImagen(usrId, "paisaje", "un paisaje", "foto");
                publicacionesDao.Find(id);


                publicacionesDao.Remove(id);
                userProfileDao.Remove(usrId);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void VerPublicacionesTest()
        {
            try
            {
                Int64 usrId = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "pepe@gmail.es", "spain", "es");
                Int64 id = publicacionesService.SubirImagen(usrId, "paisaje", "un paisaje", "foto");
                
                Assert.AreEqual(publicacionesService.VerPublicacionesUsuario(usrId, 0)[0].Id, id);


                publicacionesDao.Remove(id);
                userProfileDao.Remove(usrId);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void BuscarImagenesTest()
        {
            try
            {
                Int64 usrId = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "pepe@gmail.es", "spain", "es");
                Int64 id = publicacionesService.SubirImagen(usrId, "paisaje", "un paisaje", "foto");

                Assert.AreEqual(publicacionesService.BuscarImagenes("paisaje", 0)[0].Id, id);


                publicacionesDao.Remove(id);
                userProfileDao.Remove(usrId);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void DarMeGustaTest()
        {
            try
            {
                Int64 usrId = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "pepe@gmail.es", "spain", "es");
                Int64 id = publicacionesService.SubirImagen(usrId, "paisaje", "un paisaje", "foto");

                Assert.AreEqual(publicacionesService.NumeroMeGusta(id), 0);
                publicacionesService.DarMeGusta(usrId, id);
                Assert.AreEqual(publicacionesService.NumeroMeGusta(id), 1);

                publicacionesDao.Remove(id);
                userProfileDao.Remove(usrId);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}