using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class GrupoinstrumentosMap : ClassMap<Grupoinstrumentos> {
        
        public GrupoinstrumentosMap() {
			Table("GrupoInstrumentos");
			LazyLoad();
			Id(x => x.Idgrupo).GeneratedBy.Identity().Column("IdGrupo");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Rangoinicio).Column("RangoInicio");
			Map(x => x.Rangofinal).Column("RangoFinal");
			Map(x => x.Orden).Column("Orden");
        }
    }
}
