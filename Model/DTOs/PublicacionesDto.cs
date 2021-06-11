using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.DTOs
{
    public class PublicacionesDto
    {
        public long Id { get; set; }
        public long Usuario { get; set; }
        public string imagen { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public long fecha { get; set; }
        public string categoria { get; set; }
        public Nullable<double> f { get; set; }
        public Nullable<int> ISO { get; set; }
        public Nullable<int> t { get; set; }
        public Nullable<int> wb { get; set; }
    }
}
