using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipoinstrumentoMap : ClassMap<Tipoinstrumento> {
        
        public TipoinstrumentoMap() {
			Table("TipoInstrumento");
			LazyLoad();
			Id(x => x.Tipoinstrumentoid).GeneratedBy.Identity().Column("TipoInstrumentoID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Activo).Column("Activo");
        }
    }
}
