using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class MercadoMap : ClassMap<Mercado> {
        
        public MercadoMap() {
			Table("Mercado");
			LazyLoad();
			Id(x => x.Mercadoid).GeneratedBy.Identity().Column("MercadoID");
			References(x => x.Tipomercado).Column("TipoMercadoID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Activo).Column("Activo").Not.Nullable();
			Map(x => x.Codigomercado).Column("CodigoMercado");
			Map(x => x.Alias).Column("Alias");
			Map(x => x.Incluirreporteboletin).Column("IncluirReporteBoletin");
			Map(x => x.Secuencia).Column("Secuencia");
        }
    }
}
