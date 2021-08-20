using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisionserieMap : ClassMap<EmisionSerie> {
        
        public EmisionserieMap() {
			Table("EmisionSerie");
			LazyLoad();
			Id(x => x.Emisionserieid).GeneratedBy.Identity().Column("EmisionSerieID");
			References(x => x.Tipoliquidacion).Column("TipoLiquidacionID");
			References(x => x.Tipoperiodo).Column("TipoPeriodoID");
			Map(x => x.Emisiontramoid).Column("EmisionTramoID").Not.Nullable();
			Map(x => x.Serie).Column("Serie");
			Map(x => x.Codigoserie).Column("CodigoSerie").Not.Nullable();
			Map(x => x.Idtipotasa).Column("idTipotasa").Not.Nullable();
			Map(x => x.Codigoisin).Column("CodigoISIN");
			Map(x => x.Fechaemision).Column("FechaEmision");
			Map(x => x.Fechavencimiento).Column("FechaVencimiento");
			Map(x => x.Fechaliquidacion).Column("FechaLiquidacion").Not.Nullable();
			Map(x => x.Valorunitarionominal).Column("ValorUnitarioNominal");
			Map(x => x.Inversionminima).Column("InversionMinima");
			Map(x => x.Tasa).Column("Tasa");
			Map(x => x.Inversionmaxima).Column("InversionMaxima");
			Map(x => x.Baseliquidacionid).Column("BaseLiquidacionID");
			Map(x => x.Fechafinalcolocacion).Column("FechaFinalColocacion");
			Map(x => x.Fechainiciocolocacion).Column("FechaInicioColocacion");
			Map(x => x.Creacion).Column("Creacion");
			Map(x => x.Spread).Column("Spread");
			Map(x => x.Nobloomberg).Column("NoBloomberg");
			Map(x => x.Valornominalunitarioserie).Column("ValorNominalUnitarioSerie");
			Map(x => x.Cantidadtitulos).Column("CantidadTitulos");
			Map(x => x.Fecharedencion).Column("FechaRedencion");
			Map(x => x.Notaredencion).Column("NotaRedencion");
			Map(x => x.Valorredencion).Column("ValorRedencion");
        }
    }
}
