using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class SectorMap : ClassMap<Sector> {
        
        public SectorMap() {
			Table("Sector");
			LazyLoad();
			Id(x => x.Sectorid).GeneratedBy.Identity().Column("SectorID");
			References(x => x.Actividadeconomica).Column("ActividadEconomicaID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Sectorcodigo).Column("SectorCodigo").Not.Nullable();
			Map(x => x.Activo).Column("Activo");
        }
    }
}
