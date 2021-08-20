using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PuestobolsadocumentoMap : ClassMap<Puestobolsadocumento> {
        
        public PuestobolsadocumentoMap() {
			Table("PuestoBolsaDocumento");
			LazyLoad();
			CompositeId().KeyProperty(x => x.Puestobolsaid, "PuestoBolsaID")
			             .KeyProperty(x => x.Puestobolsadocumentoid, "PuestoBolsaDocumentoID");
			References(x => x.Puestobolsa).Column("PuestoBolsaID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Nombre).Column("nombre");
			Map(x => x.Adjunto).Column("Adjunto");
			Map(x => x.Tipodocumentoid).Column("TipoDocumentoID");
			Map(x => x.Descripcion).Column("Descripcion");
        }
    }
}
