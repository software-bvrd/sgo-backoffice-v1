using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ProvinciaMap : ClassMap<Provincia> {
        
        public ProvinciaMap() {
			Table("Provincia");
			LazyLoad();
			Id(x => x.Provinciaid).GeneratedBy.Identity().Column("ProvinciaID");
			Map(x => x.Ciudadid).Column("CiudadID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
        }
    }
}
