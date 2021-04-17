using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    interface IPublicacionesService
    {
        Int64 SubirImagen(long usrId, string titulo, string descripcion, string fichero);

        Publicaciones[] BuscarImagenes(string keywords, string categoria);

        void DarMeGusta(Int64 usrId, Int64 pubId);
    }
}
