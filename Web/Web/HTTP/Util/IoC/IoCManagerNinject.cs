using Es.Udc.DotNet.Photogram.Model.Service;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Es.Udc.DotNet.ModelUtil.IoC;
using Ninject;
using System.Configuration;
using System.Data.Entity;

namespace Es.Udc.DotNet.Photogram.HTTP.Util.IoC
{
    internal class IoCManagerNinject : IIoCManager
    {
        private static IKernel kernel;
        private static NinjectSettings settings;

        public void Configure()
        {
            settings = new NinjectSettings() { LoadExtensions = true };
            kernel = new StandardKernel(settings);

            /* UserProfileDao */
            kernel.Bind<IUserProfileDao>().
                To<UserProfileDaoEntityFramework>();

            /* UserService */
            kernel.Bind<IUsuariosService>().
                To<UsuariosService>();

            /* PublicacionesDao */
            kernel.Bind<IPublicacionesDao>().
                To<PublicacionesDaoEntityFramework>();

            /* PublicacionesService */
            kernel.Bind<IPublicacionesService>().
                To<PublicacionesService>();

            /* ComentariosDao */
            kernel.Bind<IComentariosDao>().
                To<ComentariosDaoEntityFramework>();

            /* ComentariosService */
            kernel.Bind<IComentariosService>().
                To<ComentariosService>();
            /* DbContext */
            string connectionString =
                ConfigurationManager.ConnectionStrings["MAD_BDEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);
        }

        public T Resolve<T>()
        {
            return kernel.Get<T>();
        }
    }
}