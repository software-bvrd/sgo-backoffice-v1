using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PaisMap : ClassMap<Pais> {
        
        public PaisMap() {
			Table("Pais");
			LazyLoad();
			Id(x => x.Paisid).GeneratedBy.Identity().Column("PaisID");
			Map(x => x.Isonum).Column("ISONUM");
			Map(x => x.Iso2).Column("ISO2");
			Map(x => x.Iso3).Column("ISO3");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
        }
    }
}
