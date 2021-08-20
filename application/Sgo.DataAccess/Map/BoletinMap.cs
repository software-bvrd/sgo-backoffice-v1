using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class BoletinMap : ClassMap<Boletin> {
        
        public BoletinMap() {
			Table("Boletin");
			LazyLoad();
			Id(x => x.Boletinid).GeneratedBy.Identity().Column("BoletinID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Secuencial).Column("Secuencial");
			Map(x => x.Userid).Column("UserID");
			Map(x => x.Fechacreacion).Column("FechaCreacion");
			Map(x => x.Tiporeporte).Column("TipoReporte");
        }
    }
}
