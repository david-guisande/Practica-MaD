using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.DTOs
{
    public class ComentariosDto
    {
        public long Id { get; set; }
        public long Usuario { get; set; }
        public long PublicacionId { get; set; }
        public string texto { get; set; }
    }
}
