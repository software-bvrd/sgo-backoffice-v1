using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ComisionestarifasdetalleMap : ClassMap<Comisionestarifasdetalle> {
        
        public ComisionestarifasdetalleMap() {
			Table("ComisionesTarifasDetalle");
			LazyLoad();
			Id(x => x.Comisionestarifasdetalleid).GeneratedBy.Identity().Column("ComisionesTarifasDetalleID");
			References(x => x.Comisionestarifas).Column("ComisionesTarifasID");
			Map(x => x.Concepto).Column("Concepto");
			Map(x => x.Valorinicio).Column("ValorInicio");
			Map(x => x.Valorfinal).Column("ValorFinal");
			Map(x => x.Porcentajecobrar).Column("PorcentajeCobrar");
			Map(x => x.Valorcobrar).Column("ValorCobrar");
        }
    }
}
