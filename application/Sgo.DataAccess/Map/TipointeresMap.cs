using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipointeresMap : ClassMap<Tipointeres> {
        
        public TipointeresMap() {
			Table("TipoInteres");
			LazyLoad();
			Id(x => x.Tipointeresid).GeneratedBy.Identity().Column("TipoInteresID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Tipointerescodigo).Column("TipoInteresCodigo").Not.Nullable();
			Map(x => x.Activo).Column("Activo").Not.Nullable();
        }
    }
}
