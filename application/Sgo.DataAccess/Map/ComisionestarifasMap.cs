using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ComisionestarifasMap : ClassMap<ComisionesTarifas> {
        
        public ComisionestarifasMap() {
			Table("ComisionesTarifas");
			LazyLoad();
			Id(x => x.Comisionestarifasid).GeneratedBy.Identity().Column("ComisionesTarifasID");
			Map(x => x.Concepto).Column("Concepto");
			Map(x => x.Activo).Column("Activo");
			Map(x => x.Entidad).Column("Entidad");
        }
    }
}
