using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipomercadoMap : ClassMap<Tipomercado> {
        
        public TipomercadoMap() {
			Table("TipoMercado");
			LazyLoad();
			Id(x => x.Tipomercadoid).GeneratedBy.Identity().Column("TipoMercadoID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
        }
    }
}
