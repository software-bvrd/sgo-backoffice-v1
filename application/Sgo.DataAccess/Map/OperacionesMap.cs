using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class OperacionesMap : ClassMap<Operaciones> {
        
        public OperacionesMap() {
			Table("Operaciones");
			LazyLoad();
			Id(x => x.Operacionesid).GeneratedBy.Identity().Column("OperacionesID");
            Map(x => x.Puestobolsacodigocomp).Column("PuestoBolsaCodigoComp");
            Map(x => x.Puestobolsacodigovend).Column("PuestoBolsaCodigoVend");
            Map(x => x.Tipoperiodocodigo).Column("TipoPeriodoCodigo");
            Map(x => x.Sectorcodigo).Column("SectorCodigo");
			References(x => x.Statusoperacion).Column("StatusOperacionID");
            Map(x => x.Tipointerescodigo).Column("TipoInteresCodigo");
			Map(x => x.Tiporegistro).Column("TipoRegistro").Not.Nullable();
			Map(x => x.Numerooperacion).Column("NumeroOperacion");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Codigoserie).Column("CodigoSerie");
			Map(x => x.Yield).Column("Yield");
			Map(x => x.Valorunitarionominal).Column("ValorUnitarioNominal");
			Map(x => x.Cantidadtitulos).Column("CantidadTitulos");
			Map(x => x.Valornominaltotal).Column("ValorNominalTotal");
			Map(x => x.Precio).Column("Precio");
			Map(x => x.Montotransado).Column("MontoTransado");
			Map(x => x.Hora).Column("Hora");
			Map(x => x.Interesacumulado).Column("InteresAcumulado");
			Map(x => x.Usuario).Column("Usuario");
			Map(x => x.Activa).Column("Activa").Not.Nullable();
        }
    }
}
