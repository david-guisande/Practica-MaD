﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Es.Udc.DotNet.Photogram.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MAD_BDEntities : DbContext
    {
        public MAD_BDEntities()
            : base("name=MAD_BDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<EtiquetaSet> EtiquetaSet { get; set; }
        public virtual DbSet<Publicaciones> Publicaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
