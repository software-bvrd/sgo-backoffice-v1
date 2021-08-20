using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class BaseliquidacionMap : ClassMap<BaseLiquidacion> {
        
        public BaseliquidacionMap() {
			Table("BaseLiquidacion");
			LazyLoad();
			Id(x => x.Baseliquidacionid).GeneratedBy.Identity().Column("BaseLiquidacionID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Diasnatural).Column("DiasNatural");
			Map(x => x.Anonatural).Column("AnoNatural");
			Map(x => x.Tipo).Column("Tipo");
			Map(x => x.Activo).Column("Activo");
        }
    }
}
