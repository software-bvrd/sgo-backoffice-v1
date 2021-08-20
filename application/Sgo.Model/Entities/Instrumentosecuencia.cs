using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Instrumentosecuencia {
        public virtual int Instrumentosecuenciaid { get; set; }
        public virtual int Instrumentoid { get; set; }
        public virtual Instrumento Instrumento { get; set; }
        public virtual Emisor Emisor { get; set; }
        public virtual int Secuencia { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as Instrumentosecuencia;
			if (t == null) return false;
			if (Instrumentosecuenciaid == t.Instrumentosecuenciaid
			 && Instrumentoid == t.Instrumentoid)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ Instrumentosecuenciaid.GetHashCode();
			hash = (hash * 397) ^ Instrumentoid.GetHashCode();

			return hash;
        }
        #endregion
    }
}
