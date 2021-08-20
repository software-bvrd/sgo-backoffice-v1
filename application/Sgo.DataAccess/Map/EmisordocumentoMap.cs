using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisordocumentoMap : ClassMap<EmisorDocumento> {
        
        public EmisordocumentoMap() {
			Table("EmisorDocumento");
			LazyLoad();
			CompositeId().KeyProperty(x => x.Emisorid, "EmisorID")
			             .KeyProperty(x => x.Emisordocumentoid, "EmisorDocumentoID");
			References(x => x.Emisor).Column("EmisorID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Nombre).Column("nombre").Not.Nullable();
			Map(x => x.Adjunto).Column("Adjunto");
			Map(x => x.Tipodocumentoid).Column("TipoDocumentoID");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Creacion).Column("Creacion");
        }
    }
}
