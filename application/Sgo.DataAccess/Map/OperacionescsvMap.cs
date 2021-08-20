using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class OperacionescsvMap : ClassMap<Operacionescsv> {
        
        public OperacionescsvMap() {
			Table("OperacionesCSV");
			LazyLoad();
			CompositeId().KeyProperty(x => x.FechaOper, "fecha_oper")
			             .KeyProperty(x => x.NumOper, "num_oper");
			Map(x => x.HoraOper).Column("hora_oper");
			Map(x => x.NemoIns).Column("nemo_ins");
			Map(x => x.CodIsin).Column("cod_isin");
			Map(x => x.Usuario).Column("usuario");
			Map(x => x.FechaEmi).Column("fecha_emi");
			Map(x => x.FechaVenc).Column("fecha_venc");
			Map(x => x.DiasAcum).Column("dias_acum");
			Map(x => x.DiasAlvenci).Column("dias_alvenci");
			Map(x => x.ValorNomUnit).Column("valor_nom_unit");
			Map(x => x.CantTit).Column("cant_tit");
			Map(x => x.ValorNomTot).Column("valor_nom_tot");
			Map(x => x.InteresAcum).Column("interes_acum");
			Map(x => x.PrecioLimp).Column("precio_limp");
			Map(x => x.ValorTran).Column("valor_tran");
			Map(x => x.Yield).Column("yield");
			Map(x => x.FechaLiquid).Column("fecha_liquid");
			Map(x => x.MoneTrans).Column("mone_trans");
			Map(x => x.PuesComp).Column("pues_comp");
			Map(x => x.PuesVend).Column("pues_vend");
			Map(x => x.DescripInstru).Column("descrip_instru");
			Map(x => x.Mercado).Column("mercado");
			Map(x => x.TasaInteres).Column("tasa_interes");
			Map(x => x.TipoInteres).Column("tipo_interes");
			Map(x => x.Periodicidad).Column("periodicidad");
			Map(x => x.Sector).Column("sector");
			Map(x => x.StatusTrans).Column("status_trans");
			Map(x => x.NemoEmisor).Column("nemo_emisor");
			Map(x => x.DescripEmisor).Column("descrip_emisor");
			Map(x => x.Aplicaparaprecio).Column("AplicaParaPrecio");
        }
    }
}
