using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class OrdenesenfirmeMap : ClassMap<Ordenesenfirme> {
        
        public OrdenesenfirmeMap() {
			Table("OrdenesEnFirme");
			LazyLoad();
			Id(x => x.Ordenesenfirmeid).GeneratedBy.Identity().Column("OrdenesEnFirmeID");
			Map(x => x.Type).Column("Type");
			Map(x => x.Orderstate).Column("OrderState");
			Map(x => x.Blockstatus).Column("BlockStatus");
			Map(x => x.Side).Column("Side");
			Map(x => x.Local).Column("Local");
			Map(x => x.Isin).Column("ISIN");
			Map(x => x.Curency).Column("Curency");
			Map(x => x.Issuedt).Column("IssueDt");
			Map(x => x.Matdt).Column("MatDt");
			Map(x => x.Mininc).Column("MinInc");
			Map(x => x.Coupondec).Column("CouponDec");
			Map(x => x.Tradedt).Column("TradeDt");
			Map(x => x.Time).Column("Time");
			Map(x => x.Quiantity).Column("Quiantity");
			Map(x => x.Price).Column("Price");
			Map(x => x.Yield).Column("Yield");
			Map(x => x.Setdt).Column("SetDt");
			Map(x => x.Updated).Column("Updated");
			Map(x => x.Lastupdtime).Column("LastupdTime");
			Map(x => x.Accint).Column("AccInt");
			Map(x => x.Net).Column("Net");
			Map(x => x.Brkr).Column("Brkr#");
			Map(x => x.Username).Column("UserName");
			Map(x => x.Ebndseller).Column("EBNDSeller");
			Map(x => x.Ebndbuyer).Column("EBNDBuyer");
			Map(x => x.Accdays).Column("AccDays");
			Map(x => x.Seq).Column("Seq#");
			Map(x => x.Ebondmarket).Column("EBONDmarket");
			Map(x => x.Orddur).Column("OrdDur");
			Map(x => x.Createdate).Column("Createdate");
        }
    }
}
