using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class SubastaemisionserieMap : ClassMap<Subastaemisionserie> {
        
        public SubastaemisionserieMap() {
			Table("SubastaEmisionSerie");
			LazyLoad();
			Id(x => x.Subastaemisionserieid).GeneratedBy.Identity().Column("SubastaEmisionSerieID");
			Map(x => x.Emisionserie).Column("EmisionSerie");
			Map(x => x.Codigoisin).Column("CodigoISIN");
			Map(x => x.Monto).Column("Monto");
			Map(x => x.Montoadjudicado).Column("MontoAdjudicado");
        }
    }
}
