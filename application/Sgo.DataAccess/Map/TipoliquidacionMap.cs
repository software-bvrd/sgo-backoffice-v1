using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipoliquidacionMap : ClassMap<Tipoliquidacion> {
        
        public TipoliquidacionMap() {
			Table("TipoLiquidacion");
			LazyLoad();
			Id(x => x.Tipoliquidacionid).GeneratedBy.Identity().Column("TipoLiquidacionID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Activo).Column("Activo").Not.Nullable();
			Map(x => x.Codigointerno).Column("CodigoInterno");
			Map(x => x.Dias).Column("Dias");
        }
    }
}
