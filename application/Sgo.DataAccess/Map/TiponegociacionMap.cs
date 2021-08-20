using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TiponegociacionMap : ClassMap<Tiponegociacion> {
        
        public TiponegociacionMap() {
			Table("TipoNegociacion");
			LazyLoad();
			Id(x => x.Tiponegociacionid).GeneratedBy.Identity().Column("TipoNegociacionID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Activo).Column("Activo");
        }
    }
}
