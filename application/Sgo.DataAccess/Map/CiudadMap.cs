using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class CiudadMap : ClassMap<Ciudad> {
        
        public CiudadMap() {
			Table("Ciudad");
			LazyLoad();
			Id(x => x.Ciudadid).GeneratedBy.Identity().Column("CiudadID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Paisid).Column("PaisID");
        }
    }
}
