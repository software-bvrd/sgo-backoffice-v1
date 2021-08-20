using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Operacionescsv {
        public virtual DateTime FechaOper { get; set; }
        public virtual string NumOper { get; set; }
        public virtual DateTime? HoraOper { get; set; }
        public virtual string NemoIns { get; set; }
        public virtual string CodIsin { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime? FechaEmi { get; set; }
        public virtual DateTime? FechaVenc { get; set; }
        public virtual decimal? DiasAcum { get; set; }
        public virtual decimal? DiasAlvenci { get; set; }
        public virtual decimal? ValorNomUnit { get; set; }
        public virtual decimal? CantTit { get; set; }
        public virtual decimal? ValorNomTot { get; set; }
        public virtual decimal? InteresAcum { get; set; }
        public virtual decimal? PrecioLimp { get; set; }
        public virtual decimal? ValorTran { get; set; }
        public virtual decimal? Yield { get; set; }
        public virtual DateTime? FechaLiquid { get; set; }
        public virtual string MoneTrans { get; set; }
        public virtual string PuesComp { get; set; }
        public virtual string PuesVend { get; set; }
        public virtual string DescripInstru { get; set; }
        public virtual string Mercado { get; set; }
        public virtual decimal? TasaInteres { get; set; }
        public virtual string TipoInteres { get; set; }
        public virtual string Periodicidad { get; set; }
        public virtual string Sector { get; set; }
        public virtual string StatusTrans { get; set; }
        public virtual string NemoEmisor { get; set; }
        public virtual string DescripEmisor { get; set; }
        public virtual bool? Aplicaparaprecio { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as Operacionescsv;
			if (t == null) return false;
			if (FechaOper == t.FechaOper
			 && NumOper == t.NumOper)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ FechaOper.GetHashCode();
			hash = (hash * 397) ^ NumOper.GetHashCode();

			return hash;
        }
        #endregion
    }
}
