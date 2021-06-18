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
    public class EtiquetasService : IEtiquetasService
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
            if (!EtiquetasDao.Exists(tag))
            {
                EtiquetaSet et = new EtiquetaSet();
                et.tag = tag;
                EtiquetasDao.Create(et);
            }
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

        public PublicacionesDto[] GetPublicaciones(string tag, int npag, int pagLen)
        {
            if (EtiquetasDao.Exists(tag))
            {
                Publicaciones[] list = EtiquetasDao.GetPublicaciones(tag, npag, pagLen);
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

        public (string et, int num)[] NubeEtiquetas(int pagLen)
        {
            var lista = EtiquetasDao.GetAllElements();
            var res = new List<(string, int)>();

            foreach (EtiquetaSet e in lista)
            {
                string tag = e.tag;
                int num = EtiquetasDao.GetNumPublicaciones(tag);
                res.Add((tag,num));
            }

            return res.OrderByDescending(t => t.Item2).Take(pagLen).ToArray();
        }
    }
}
