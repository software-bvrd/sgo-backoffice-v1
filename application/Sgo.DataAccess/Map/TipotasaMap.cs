using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipotasaMap : ClassMap<TipoTasa> {
        
        public TipotasaMap() {
			Table("TipoTasa");
			LazyLoad();
			Id(x => x.Idtipotasa).GeneratedBy.Identity().Column("idTipotasa");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Descripcioncorta).Column("DescripcionCorta");
			Map(x => x.Atributo).Column("Atributo");
			Map(x => x.Frecuencia).Column("Frecuencia");
        }
    }
}
