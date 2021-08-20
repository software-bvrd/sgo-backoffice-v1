using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipoemisionMap : ClassMap<Tipoemision> {
        
        public TipoemisionMap() {
			Table("TipoEmision");
			LazyLoad();
			Id(x => x.Tipodeemisionid).GeneratedBy.Identity().Column("TipoDeEmisionID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Activo).Column("Activo").Not.Nullable();
        }
    }
}
