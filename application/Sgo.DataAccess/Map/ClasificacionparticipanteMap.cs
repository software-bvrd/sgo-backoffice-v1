using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ClasificacionparticipanteMap : ClassMap<ClasificacionParticipante> {
        
        public ClasificacionparticipanteMap() {
			Table("ClasificacionParticipante");
			LazyLoad();
			Id(x => x.ClasificacionParticipanteId).GeneratedBy.Identity().Column("ClasificacionParticipanteID");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Codigomercado).Column("CodigoMercado");
			Map(x => x.Estatus).Column("Estatus");
        }
    }
}
