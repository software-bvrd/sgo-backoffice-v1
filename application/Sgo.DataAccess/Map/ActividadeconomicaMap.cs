using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ActividadeconomicaMap : ClassMap<ActividadEconomica> {
        
        public ActividadeconomicaMap() {
			Table("ActividadEconomica");
			LazyLoad();
			Id(x => x.Actividadeconomicaid).GeneratedBy.Identity().Column("ActividadEconomicaID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Activo).Column("Activo").Not.Nullable();
        }
    }
}
