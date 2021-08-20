using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipomonedaMap : ClassMap<Tipomoneda> {
        
        public TipomonedaMap() {
			Table("TipoMoneda");
			LazyLoad();
			Id(x => x.Tipomonedaid).GeneratedBy.Identity().Column("TipoMonedaID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Simbolo).Column("Simbolo").Not.Nullable();
			Map(x => x.Local).Column("Local").Not.Nullable();
        }
    }
}
