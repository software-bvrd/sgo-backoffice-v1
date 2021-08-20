using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipoamortizacioncapitalMap : ClassMap<Tipoamortizacioncapital> {
        
        public TipoamortizacioncapitalMap() {
			Table("TipoAmortizacionCapital");
			LazyLoad();
			Id(x => x.Tipoamortizacioncapitalid).GeneratedBy.Identity().Column("TipoAmortizacionCapitalID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Activo).Column("Activo").Not.Nullable();
        }
    }
}
