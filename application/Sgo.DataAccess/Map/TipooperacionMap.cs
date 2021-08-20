using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipooperacionMap : ClassMap<TipoOperacion> {
        
        public TipooperacionMap() {
			Table("TipoOperacion");
			LazyLoad();
			Id(x => x.Tipooperacionid).GeneratedBy.Identity().Column("TipoOperacionId");
			Map(x => x.Nombeabreviado).Column("NombeAbreviado");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Mercadoid).Column("MercadoID");
        }
    }
}
