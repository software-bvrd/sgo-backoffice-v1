using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipoparticipanteMap : ClassMap<TipoParticipante> {
        
        public TipoparticipanteMap() {
			Table("TipoParticipante");
			LazyLoad();
			Id(x => x.Tipoparticipanteid).GeneratedBy.Identity().Column("TipoParticipanteID");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Estado).Column("Estado");
        }
    }
}
