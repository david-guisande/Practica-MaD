using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public interface IPublicacionesService
    {
        Int64 SubirImagen(long usrId, string titulo, string descripcion, string fichero, string categoria);

        PublicacionesDto[] VerPublicacionesUsuario(Int64 usrId, int npag);

        PublicacionesDto[] BuscarImagenes(string keywords, int npag);

        PublicacionesDto[] BuscarImagenes(string keywords, string categoria, int npag);

        void DarMeGusta(Int64 usrId, Int64 pubId);

        int NumeroMeGusta(Int64 pubId);
    }
}
