using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class FormacolocacionMap : ClassMap<Formacolocacion> {
        
        public FormacolocacionMap() {
			Table("FormaColocacion");
			LazyLoad();
			Id(x => x.Formacolocacionid).GeneratedBy.Identity().Column("FormaColocacionID");
			References(x => x.Mercado).Column("MercadoID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Activo).Column("Activo").Not.Nullable();
        }
    }
}
