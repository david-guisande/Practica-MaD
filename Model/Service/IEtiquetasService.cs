using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public interface IEtiquetasService
    {
        PublicacionesDto[] GetPublicaciones(string tag, int npag);

        string[] GetEtiquetas(long pubId);

        /// <exception cref="InstanceNotFoundException"></exception>
        void Etiquetar(string tag, long pubId);

        /// <exception cref="InstanceNotFoundException"></exception>
        void Desetiquetar(string tag, long pubId);

        (string et, int num)[] NubeEtiquetas();
    }
}
