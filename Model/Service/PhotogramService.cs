using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Ninject;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public class PhotogramService
    {

        [Inject]
        public IUserProfileDao UserProfileDao { private get; set; }

        [Transactional]
        public long RegisterUser(string loginName, string clearPassword)
        {
            try
            {
                UserProfileDao.FindByLoginName(loginName);
                throw new Exception();
            }
            catch (Exception)
            {

                Usuarios user = new Usuarios();

                user.loginName = loginName;
                user.password = clearPassword;
                user.name = "Pepe";
                user.email = "pepe@jomail.es";
                user.pais = "espanita";
                user.idioma = "gallego";

                UserProfileDao.Create(user);

                return user.usrId;
            }
        }

    }
}
