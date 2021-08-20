using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PuestobolsaMap : ClassMap<Puestobolsa> {
        
        public PuestobolsaMap() {
			Table("PuestoBolsa");
			LazyLoad();
			Id(x => x.Puestobolsaid).GeneratedBy.Identity().Column("PuestoBolsaID");
			Map(x => x.Puestobolsacodigo).Column("PuestoBolsaCodigo");
			Map(x => x.Puestobolsacodigoorden).Column("PuestoBolsaCodigoOrden");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Direccion).Column("Direccion");
			Map(x => x.Telefono).Column("Telefono");
			Map(x => x.Email).Column("Email");
			Map(x => x.Web).Column("Web");
			Map(x => x.Rnc).Column("Rnc");
			Map(x => x.Noregistrobv).Column("NoRegistroBV");
			Map(x => x.Noregistrosiv).Column("NoRegistroSIV");
			Map(x => x.Representantelegal).Column("RepresentanteLegal");
			Map(x => x.Fechaconstitucion).Column("FechaConstitucion");
			Map(x => x.Capitalsuscritopagado).Column("CapitalSuscritoPagado");
			Map(x => x.Activo).Column("Activo").Not.Nullable();
			Map(x => x.Presidente).Column("Presidente");
			Map(x => x.Logo).Column("Logo");
			Map(x => x.Tipoparticipanteid).Column("TipoParticipanteID");
			Map(x => x.Clasificacionparticipanteid).Column("ClasificacionParticipanteID");
			Map(x => x.Referenciaa).Column("ReferenciaA");
			Map(x => x.Referenciab).Column("ReferenciaB");
        }
    }
}
