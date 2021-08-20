using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class MonedashistoricotasasMap : ClassMap<Monedashistoricotasas> {
        
        public MonedashistoricotasasMap() {
			Table("MonedasHistoricoTasas");
			LazyLoad();
			Id(x => x.Monedashistoricotasasid).GeneratedBy.Identity().Column("MonedasHistoricoTasasID");
			References(x => x.Tipomoneda).Column("TipoMonedaID");
			Map(x => x.Fecha).Column("Fecha").Not.Nullable();
			Map(x => x.Tasacompra).Column("TasaCompra").Not.Nullable();
			Map(x => x.Tasaventa).Column("TasaVenta").Not.Nullable();
			Map(x => x.Tipp).Column("TIPP");
        }
    }
}
