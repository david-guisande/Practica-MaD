﻿using Es.Udc.DotNet.Photogram.Model.DAOs;
using Es.Udc.DotNet.Photogram.Model.Service;
using Ninject;
using System.Configuration;
using System.Data.Entity;

namespace Es.Udc.DotNet.Photogram.Test
{
    public class TestManager
    {
        /// <summary>
        /// Configures and populates the Ninject kernel
        /// </summary>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel()
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };

            IKernel kernel = new StandardKernel(settings);

            kernel.Bind<IUserProfileDao>().
                To<UserProfileDaoEntityFramework>();

            kernel.Bind<IPublicacionesDao>().
                To<PublicacionesDaoEntityFramework>();

            kernel.Bind<IComentariosDao>().
                To<ComentariosDaoEntityFramework>();

            kernel.Bind<IUsuariosService>().
                To<UsuariosService>();

            kernel.Bind<IPublicacionesService>().
                To<PublicacionesService>();

            kernel.Bind<IComentariosService>().
                To<ComentariosService>();

            string connectionString =
                ConfigurationManager.ConnectionStrings["MAD_BDEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);

            return kernel;
        }

        /// <summary>
        /// Configures the Ninject kernel from an external module file.
        /// </summary>
        /// <param name="moduleFilename">The module filename.</param>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel(string moduleFilename)
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };
            IKernel kernel = new StandardKernel(settings);

            kernel.Load(moduleFilename);

            return kernel;
        }

        public static void ClearNInjectKernel(IKernel kernel)
        {
            kernel.Dispose();
        }
    }
}