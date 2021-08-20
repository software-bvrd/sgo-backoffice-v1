using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class InstrumentosecuenciaMap : ClassMap<Instrumentosecuencia> {
        
        public InstrumentosecuenciaMap() {
			Table("InstrumentoSecuencia");
			LazyLoad();
			CompositeId().KeyProperty(x => x.Instrumentosecuenciaid, "InstrumentoSecuenciaID")
			             .KeyProperty(x => x.Instrumentoid, "InstrumentoID");
			References(x => x.Instrumento).Column("InstrumentoID");
			References(x => x.Emisor).Column("EmisorID");
			Map(x => x.Secuencia).Column("Secuencia").Not.Nullable();
        }
    }
}
