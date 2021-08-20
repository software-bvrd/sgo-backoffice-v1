using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipoemisorMap : ClassMap<Tipoemisor> {
        
        public TipoemisorMap() {
			Table("TipoEmisor");
			LazyLoad();
			Id(x => x.Tipoemisorid).GeneratedBy.Identity().Column("TipoEmisorID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Activo).Column("Activo").Not.Nullable();
        }
    }
}
