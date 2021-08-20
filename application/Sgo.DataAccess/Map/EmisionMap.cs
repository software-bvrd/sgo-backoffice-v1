using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisionMap : ClassMap<Emision> {
        
        public EmisionMap() {
			Table("Emision");
			LazyLoad();
			Id(x => x.Emisionid).GeneratedBy.Identity().Column("EmisionID");
			References(x => x.Emisor).Column("EmisorID");
			References(x => x.Tipoamortizacioncapital).Column("TipoAmortizacionCapitalID");
			References(x => x.Tipoemision).Column("TipoDeEmisionID");
			References(x => x.Instrumento).Column("InstrumentoID");
			References(x => x.Tipomoneda).Column("TipoMonedaID");
			References(x => x.Puestobolsa).Column("PuestoBolsaID");
			References(x => x.Formacolocacion).Column("FormaColocacionID");
			References(x => x.Baseliquidacion).Column("BaseLiquidacionID");
			Map(x => x.Codemisionbvrd).Column("CodEmisionBVRD");
			Map(x => x.Codensistema).Column("CodEnSistema");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Cantidadtramos).Column("CantidadTramos");
			Map(x => x.Fechaaprobacionbvrd).Column("FechaAprobacionBVRD");
			Map(x => x.Fechaaprobacionsiv).Column("FechaAprobacionSIV");
			Map(x => x.Finalidaddelaemision).Column("FinalidadDeLaEmision");
			Map(x => x.Subiraop).Column("SubirAOP");
			Map(x => x.Montototaldelaemision).Column("MontoTotalDeLaEmision");
			Map(x => x.Montoofertadoalpublico).Column("MontoOfertadoAlPublico");
			Map(x => x.Montopendientedecolocaciondelaop).Column("MontoPendienteDeColocacionDelAOP");
			Map(x => x.Montopendientedeofertaralpublico).Column("MontoPendienteDeOfertarAlPublico");
			Map(x => x.Estatus).Column("Estatus");
			Map(x => x.Nota1).Column("Nota1");
			Map(x => x.Nota2).Column("Nota2");
			Map(x => x.Valornominal).Column("ValorNominal");
			Map(x => x.Creacion).Column("Creacion");
			Map(x => x.Tipoinstrumentoid).Column("TipoInstrumentoID");
			Map(x => x.Garantiaprogramaemision).Column("GarantiaProgramaEmision");
			Map(x => x.Calcularcomision).Column("CalcularComision");
			Map(x => x.Montototaldelaemisioncompletivo).Column("MontoTotalDeLaEmisionCompletivo");
			Map(x => x.Fechafinalcolocacion).Column("FechaFinalColocacion");
			Map(x => x.Tiponegociacionid).Column("TipoNegociacionID");
        }
    }
}
