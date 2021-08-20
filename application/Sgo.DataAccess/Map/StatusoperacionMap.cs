using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class StatusoperacionMap : ClassMap<Statusoperacion> {
        
        public StatusoperacionMap() {
			Table("StatusOperacion");
			LazyLoad();
			Id(x => x.Statusoperacionid).GeneratedBy.Identity().Column("StatusOperacionID");
			Map(x => x.Descripcion).Column("Descripcion").Not.Nullable();
        }
    }
}
