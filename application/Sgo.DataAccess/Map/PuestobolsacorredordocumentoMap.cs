using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PuestobolsacorredordocumentoMap : ClassMap<Puestobolsacorredordocumento> {
        
        public PuestobolsacorredordocumentoMap() {
			Table("PuestoBolsaCorredorDocumento");
			LazyLoad();
			Id(x => x.Puestobolsacorredordocumentoid).GeneratedBy.Identity().Column("PuestoBolsaCorredorDocumentoID");
			References(x => x.Puestobolsacorredor).Column("PuestoBolsaCorredorID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Nombre).Column("nombre").Not.Nullable();
			Map(x => x.Adjunto).Column("Adjunto");
			Map(x => x.Tipodocumentoid).Column("TipoDocumentoID");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Creacion).Column("Creacion");
        }
    }
}
