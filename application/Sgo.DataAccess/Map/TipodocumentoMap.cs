using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipodocumentoMap : ClassMap<Tipodocumento> {
        
        public TipodocumentoMap() {
			Table("TipoDocumento");
			LazyLoad();
			Id(x => x.Tipodocumentoid).GeneratedBy.Identity().Column("TipoDocumentoID");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Activo).Column("Activo");
        }
    }
}
