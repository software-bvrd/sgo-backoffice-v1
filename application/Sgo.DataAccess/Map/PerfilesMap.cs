using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PerfilesMap : ClassMap<Perfiles> {
        
        public PerfilesMap() {
			Table("Perfiles");
			LazyLoad();
			Id(x => x.Idperfil).GeneratedBy.Identity().Column("IdPerfil");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Estatus).Column("Estatus");
        }
    }
}
