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
    /// Summary description for ComentariosServiceTest
    /// </summary>
    [TestClass]
    public class ComentariosServiceTest
    {
        private static IKernel kernel;

        private TestContext testContextInstance;
        private static IUsuariosService usuariosService;
        private static IPublicacionesService publicacionesService;
        private static IComentariosService comentariosService;

        private static IUserProfileDao userProfileDao;
        private static IPublicacionesDao publicacionesDao;
        private static IComentariosDao comentariosDao;

        public ComentariosServiceTest()
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
        public void ComentarTest()
        {
            long usrId = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "elpepe@gmail.es", "spain", "es");
            long pubId = publicacionesService.SubirImagen(usrId,"mi casa","foto de mi casa","/home/user/micasa.png","paisaje");
            long comId = comentariosService.Comentar(usrId, pubId, "es una casa muy chula");

            try
            {
                comentariosDao.Find(comId);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }

            comentariosDao.Remove(comId);
            publicacionesDao.Remove(pubId);
            userProfileDao.Remove(usrId);
        }

        [TestMethod()]
        public void ActualizarComentarioTest()
        {
            long usrId = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "elpepe@gmail.es", "spain", "es");
            long pubId = publicacionesService.SubirImagen(usrId,"mi casa","foto de mi casa","/home/user/micasa.png","paisaje");
            long comId = comentariosService.Comentar(usrId, pubId, "es una casa muy chula");

            string texto = "edit: no es tan chula en persona";
            comentariosService.ActualizarComentario(comId, usrId, texto);
            Assert.AreEqual(comentariosService.VerComentarios(pubId,0)[0].texto,texto);

            comentariosDao.Remove(comId);
            publicacionesDao.Remove(pubId);
            userProfileDao.Remove(usrId);
        }

        [TestMethod()]
        public void EliminarComentarioTest()
        {
            long usrId = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "elpepe@gmail.es", "spain", "es");
            long pubId = publicacionesService.SubirImagen(usrId,"mi casa","foto de mi casa","/home/user/micasa.png","paisaje");
            long comId = comentariosService.Comentar(usrId, pubId, "es una casa muy chula");

            comentariosService.EliminarComentario(comId,usrId);
            try
            {
                comentariosDao.Find(comId);
                Assert.Fail("Fallo borrar");
            }
            catch(Exception e)
            {
                // Correcto
            }

            publicacionesDao.Remove(pubId);
            userProfileDao.Remove(usrId);
        }

        [TestMethod()]
        public void VerComentariosTest()
        {
            long usrId = usuariosService.RegistrarUsuario("elpepe", "12345", "pepe", "elpepe@gmail.es", "spain", "es");
            long pubId = publicacionesService.SubirImagen(usrId,"mi casa","foto de mi casa","/home/user/micasa.png","paisaje");
            long comId = comentariosService.Comentar(usrId, pubId, "es una casa muy chula");

            Assert.AreEqual(comentariosService.VerComentarios(pubId,0)[0].id,comId);

            comentariosDao.Remove(comId);
            publicacionesDao.Remove(pubId);
            userProfileDao.Remove(usrId);
        }
    }
}