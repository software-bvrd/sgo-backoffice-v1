using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class CodigosparticipanteMap : ClassMap<CodigosParticipante> {
        
        public CodigosparticipanteMap() {
			Table("CodigosParticipante");
			LazyLoad();
			Id(x => x.Codigosparticipanteid).GeneratedBy.Identity().Column("CodigosParticipanteID");
			Map(x => x.Puestobolsaid).Column("PuestoBolsaID");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Mercado).Column("Mercado");
        }
    }
}
