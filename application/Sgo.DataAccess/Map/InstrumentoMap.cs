using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class InstrumentoMap : ClassMap<Instrumento> {
        
        public InstrumentoMap() {
			Table("Instrumento");
			LazyLoad();
			Id(x => x.Instrumentoid).GeneratedBy.Identity().Column("InstrumentoID");
			References(x => x.Tipoinstrumento).Column("TipoInstrumentoID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Activo).Column("Activo").Not.Nullable();
			Map(x => x.Codsistema).Column("CodSistema");
			Map(x => x.Secuencia).Column("Secuencia");
        }
    }
}
