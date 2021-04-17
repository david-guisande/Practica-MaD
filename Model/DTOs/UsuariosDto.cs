using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.DTOs
{
    public class UsuariosDto
    {
        public long usrId { get; set; }
        public string loginName { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string pais { get; set; }
        public string idioma { get; set; }
    }
}
