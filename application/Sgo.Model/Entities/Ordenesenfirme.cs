using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Ordenesenfirme {
        public virtual int Ordenesenfirmeid { get; set; }
        public virtual string Type { get; set; }
        public virtual string Orderstate { get; set; }
        public virtual string Blockstatus { get; set; }
        public virtual string Side { get; set; }
        public virtual string Local { get; set; }
        public virtual string Isin { get; set; }
        public virtual string Curency { get; set; }
        public virtual DateTime? Issuedt { get; set; }
        public virtual DateTime? Matdt { get; set; }
        public virtual decimal? Mininc { get; set; }
        public virtual decimal? Coupondec { get; set; }
        public virtual DateTime? Tradedt { get; set; }
        public virtual DateTime? Time { get; set; }
        public virtual decimal? Quiantity { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual decimal? Yield { get; set; }
        public virtual DateTime? Setdt { get; set; }
        public virtual DateTime? Updated { get; set; }
        public virtual string Lastupdtime { get; set; }
        public virtual decimal? Accint { get; set; }
        public virtual decimal? Net { get; set; }
        public virtual decimal? Brkr { get; set; }
        public virtual string Username { get; set; }
        public virtual string Ebndseller { get; set; }
        public virtual string Ebndbuyer { get; set; }
        public virtual string Accdays { get; set; }
        public virtual int? Seq { get; set; }
        public virtual int? Ebondmarket { get; set; }
        public virtual DateTime? Orddur { get; set; }
        public virtual DateTime? Createdate { get; set; }
    }
}
