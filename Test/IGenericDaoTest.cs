﻿using Es.Udc.DotNet.Photogram.Model.DAOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Data.Entity;
using System.Transactions;
using Es.Udc.DotNet.ModelUtil.Dao;
using Ninject.Activation;
using Es.Udc.DotNet.Photogram.Model;
using Es.Udc.DotNet.Photogram.Model.Service;

namespace Es.Udc.DotNet.Photogram.Test
{
    /// <summary>
    ///This is a test class for IGenericDaoTest and is intended
    ///to contain all IGenericDaoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IGenericDaoTest
    {
        private static IKernel kernel;

        private TestContext testContextInstance;
        private Usuarios userProfile;
        private Publicaciones publi;
        private static IUserProfileDao userProfileDao;
        private static IPublicacionesDao publicacionesDao;
        private static IComentariosDao comentariosDao;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Additional test attributes

        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            userProfileDao = kernel.Get<IUserProfileDao>();
            publicacionesDao = kernel.Get<IPublicacionesDao>();
            comentariosDao = kernel.Get<IComentariosDao>();
        }

        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            userProfile = new Usuarios();
            userProfile.loginName = "jsmith";
            userProfile.password = "password";
            userProfile.name = "John";
            userProfile.email = "jsmith@acme.com";
            userProfile.idioma = "en";
            userProfile.pais = "US";

            userProfileDao.Create(userProfile);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            try
            {
                userProfileDao.Remove(userProfile.usrId);
            }
            catch (Exception)
            {
            }
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void DAO_FindTest()
        {
            try
            {
                Usuarios actual = userProfileDao.Find(userProfile.usrId);
                Assert.AreEqual(userProfile, actual, "User found does not correspond with the original one.");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DAO_ExistsTest()
        {
            try
            {
                bool userExists = userProfileDao.Exists(userProfile.usrId);

                Assert.IsTrue(userExists);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DAO_NotExistsTest()
        {
            try
            {
                bool userNotExists = userProfileDao.Exists(-1);

                Assert.IsFalse(userNotExists);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void DAO_UpdateTest()
        {
            try
            {
                userProfile.name = "Juan";
                userProfile.email = "jgonzalez@acme.es";
                userProfile.idioma = "es";
                userProfile.pais = "ES";
                userProfile.password = "contrasena";

                userProfileDao.Update(userProfile);

                Usuarios actual = userProfileDao.Find(userProfile.usrId);

                Assert.AreEqual(userProfile, actual);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Remove
        [TestMethod()]
        public void DAO_RemoveTest()
        {
            try
            {
                userProfileDao.Remove(userProfile.usrId);

                bool userExists = userProfileDao.Exists(userProfile.usrId);

                Assert.IsFalse(userExists);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Create
        ///</summary> 
        [TestMethod()]
        public void DAO_CreateTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Usuarios newUserProfile = new Usuarios();
                newUserProfile.loginName = "login";
                newUserProfile.password = "password";
                newUserProfile.name = "John";
                newUserProfile.email = "john.smith@acme.com";
                newUserProfile.idioma = "en";
                newUserProfile.pais = "US";

                userProfileDao.Create(newUserProfile);

                bool userExists = userProfileDao.Exists(newUserProfile.usrId);

                Assert.IsTrue(userExists);

                userProfileDao.Remove(newUserProfile.usrId);
                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        ///A test for Attach
        ///</summary>
        [TestMethod()]
        public void DAO_AttachTest()
        {
            Usuarios user = userProfileDao.Find(userProfile.usrId);
            userProfileDao.Remove(user.usrId);   // removes the user created in MyTestInitialize();
            
            // First we get CommonContext from GenericDAO...
            DbContext dbContext = ((GenericDaoEntityFramework<Usuarios, Int64>) userProfileDao).Context;

            // Check the user is not in the context now (EntityState.Detached notes that entity is not tracked by the context)
            Assert.AreEqual(dbContext.Entry(user).State, EntityState.Detached);

            // If we attach the entity it will be tracked again
            userProfileDao.Attach(user);

           
            // EntityState.Unchanged = entity exists in context and in DataBase with the same values 
            Assert.AreEqual(dbContext.Entry(user).State, EntityState.Unchanged);

        }
        
        /// <summary>
        ///A test for Follow
        ///</summary>
        [TestMethod()]
        public void DAO_SeguirTest()
		{
            using (TransactionScope transaction = new TransactionScope())
            {
                Usuarios usr = new Usuarios();
                usr.loginName = "qwerty";
                usr.password = "password";
                usr.name = "John";
                usr.email = "jsmith@acme.com";
                usr.idioma = "en";
                usr.pais = "US";

                userProfileDao.Create(usr);
                userProfileDao.SeguirA(usr.usrId, userProfile.usrId);

                Usuarios[] seguidores = userProfileDao.GetSeguidores(userProfile.usrId, 0);
                Usuarios[] seguidos = userProfileDao.GetSeguidos(usr.usrId, 0);

                Assert.AreEqual(seguidores.Length, 1);
                Assert.AreEqual(seguidos.Length, 1);

                Assert.AreEqual(seguidores[0], usr);
                Assert.AreEqual(seguidos[0], userProfile);
                userProfileDao.Remove(usr.usrId);
            }
        }
        
        /// <summary>
        ///A test for Like
        ///</summary>
        [TestMethod()]
        public void DAO_DarFavTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Publicaciones pub = new Publicaciones();
                pub.imagen = "/home/david/a.png";
                pub.titulo = "imagen";
                pub.descripcion = "una foto";
                pub.fecha = 0;
                pub.Usuario = userProfile.usrId;
                pub.categoria = "asdfgh";

                publicacionesDao.Create(pub);
                userProfileDao.DarFav(userProfile.usrId, pub.Id);

                Assert.AreEqual(publicacionesDao.Favs(pub.Id), 1);
                publicacionesDao.Remove(pub.Id);
            }
        }
        
        /// <summary>
        ///A test for Attach
        ///</summary>
        [TestMethod()]
        public void DAO_BuscarTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Publicaciones pub = new Publicaciones();
                pub.imagen = "/home/david/a.png";
                pub.titulo = "imagen";
                pub.descripcion = "una foto";
                pub.fecha = 0;
                pub.Usuario = userProfile.usrId;
                pub.categoria = "asdfgh";

                publicacionesDao.Create(pub);
                Assert.AreEqual(publicacionesDao.Buscar("comida", 0).Length, 0);
                Assert.AreEqual(publicacionesDao.Buscar("foto", 0).Length, 1);

                publicacionesDao.Remove(pub.Id);
            }
        }
        
        /// <summary>
        ///A test for Attach
        ///</summary>
        [TestMethod()]
        public void DAO_GetPubliUsuarioTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Publicaciones pub = new Publicaciones();
                pub.imagen = "/home/david/a.png";
                pub.titulo = "imagen";
                pub.descripcion = "una foto";
                pub.fecha = 0;
                pub.Usuario = userProfile.usrId;
                pub.categoria = "asdfgh";

                publicacionesDao.Create(pub);
                Assert.AreEqual(publicacionesDao.GetPubliUsuario(userProfile.usrId, 0).Length, 1);
                publicacionesDao.Remove(pub.Id);
            }
        }
        
        /// <summary>
        ///A test for Attach
        ///</summary>
        [TestMethod()]
        public void DAO_GetComentariosPubliTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Publicaciones pub = new Publicaciones();
                pub.imagen = "/home/david/a.png";
                pub.titulo = "imagen";
                pub.descripcion = "una foto";
                pub.fecha = 0;
                pub.Usuario = userProfile.usrId;
                pub.categoria = "asdfgh";
                publicacionesDao.Create(pub);

                Comentarios com = new Comentarios();
                com.texto = "muy chula la foto";
                com.PublicacionId = pub.Id;
                com.Usuario = userProfile.usrId;
                comentariosDao.Create(com);

                Assert.AreEqual(comentariosDao.GetComentariosPubli(pub.Id, 0).Length, 1);
                comentariosDao.Remove(com.Id);
                publicacionesDao.Remove(pub.Id);
            }
        }
        
    }

}