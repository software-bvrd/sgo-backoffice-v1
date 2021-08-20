using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisionseriehistoricocambiotasasMap : ClassMap<EmisionSerieHistoricoCambioTasas> {
        
        public EmisionseriehistoricocambiotasasMap() {
			Table("EmisionSerieHistoricoCambioTasas");
			LazyLoad();
			Id(x => x.Emisionseriehistoricocambiotasasid).GeneratedBy.Identity().Column("EmisionSerieHistoricoCambioTasasID");
			References(x => x.Emisionserie).Column("EmisionSerieID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Tasa).Column("Tasa");
			Map(x => x.Activo).Column("Activo");
        }
    }
}
