using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisiondocumentoMap : ClassMap<EmisionDocumento> {
        
        public EmisiondocumentoMap() {
			Table("EmisionDocumento");
			LazyLoad();
			CompositeId().KeyProperty(x => x.Emisionid, "EmisionID")
			             .KeyProperty(x => x.Emisiondocumentoid, "EmisionDocumentoID");
			References(x => x.Emision).Column("EmisionID");
			References(x => x.Tipodocumento).Column("TipoDocumentoID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Nombre).Column("nombre").Not.Nullable();
			Map(x => x.Adjunto).Column("Adjunto");
			Map(x => x.Archivo).Column("Archivo");
			Map(x => x.Creacion).Column("Creacion");
        }
    }
}
