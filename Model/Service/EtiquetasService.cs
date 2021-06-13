using Es.Udc.DotNet.Photogram.Model.DAOs;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    class EtiquetasService : IEtiquetasService
    {
        [Inject]
        public IPublicacionesDao PublicacionesDao { private get; set; }
        [Inject]
        public IEtiquetasDao EtiquetasDao { private get; set; }

        /// <exception cref="InstanceNotFoundException"></exception>
        public void Desetiquetar(string tag, long pubId)
        {
            EtiquetasDao.Desetiquetar(tag, pubId);
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public void Etiquetar(string tag, long pubId)
        {
            EtiquetasDao.Etiquetar(tag, pubId);
        }

        public string[] GetEtiquetas(long pubId)
        {
            if (PublicacionesDao.Exists(pubId))
            {
                EtiquetaSet[] list = EtiquetasDao.GetEtiquetas(pubId);
                string[] res = new string[list.Length];
                for (int i=0; i<list.Length; i++)
                {
                    res[i] = list[i].tag;
                }
                return res;
            }
            else
            {
                return new string[] { };
            }
        }

        public PublicacionesDto[] GetPublicaciones(string tag, int npag)
        {
            if (EtiquetasDao.Exists(tag))
            {
                Publicaciones[] list = EtiquetasDao.GetPublicaciones(tag, npag);
                PublicacionesDto[] res = new PublicacionesDto[list.Length];
                for (int i = 0; i < list.Length; i++)
                {
                    res[i] = list[i];
                }
                return res;
            }
            else
            {
                return new PublicacionesDto[] { };
            }
        }

        public (string et, int num)[] NubeEtiquetas()
        {
            EtiquetaSet[] lista = EtiquetasDao.GetAllElements().ToArray();
            var res = new (string, int)[lista.Length];

            for(int i=0; i<lista.Length; i++)
            {
                res[i].Item1 = lista[i].tag;
                res[i].Item2 = EtiquetasDao.GetNumPublicaciones(lista[i].tag);
            }

            return res;
        }
    }
}
