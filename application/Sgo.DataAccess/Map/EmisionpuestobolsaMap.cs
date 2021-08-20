using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisionpuestobolsaMap : ClassMap<EmisionPuestoBolsa> {
        
        public EmisionpuestobolsaMap() {
			Table("EmisionPuestoBolsa");
			LazyLoad();
			Id(x => x.Emisionpuestobolsaid).GeneratedBy.Identity().Column("EmisionPuestoBolsaID");
			References(x => x.Emision).Column("EmisionID");
			Map(x => x.Nota).Column("Nota");
			Map(x => x.Puestobolsaid).Column("PuestoBolsaID");
			Map(x => x.Creacion).Column("Creacion");
        }
    }
}
