using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipoentidadMap : ClassMap<Tipoentidad> {
        
        public TipoentidadMap() {
			Table("TipoEntidad");
			LazyLoad();
			Id(x => x.Tipoentidadid).GeneratedBy.Identity().Column("TipoEntidadID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Siglas).Column("Siglas");
			Map(x => x.Activo).Column("Activo");
			Map(x => x.Incluirencomision).Column("IncluirEnComision");
        }
    }
}
