using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class RangocalificacionMap : ClassMap<Rangocalificacion> {
        
        public RangocalificacionMap() {
			Table("RangoCalificacion");
			LazyLoad();
			Id(x => x.Rangocalificacionid).GeneratedBy.Identity().Column("RangoCalificacionID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Empresacalificadoraid).Column("EmpresaCalificadoraID");
        }
    }
}
