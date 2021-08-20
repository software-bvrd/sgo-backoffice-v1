using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Puestobolsadocumento {
        public virtual int Puestobolsaid { get; set; }
        public virtual int Puestobolsadocumentoid { get; set; }
        public virtual Puestobolsa Puestobolsa { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Nombre { get; set; }
        public virtual byte[] Adjunto { get; set; }
        public virtual int? Tipodocumentoid { get; set; }
        public virtual string Descripcion { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as Puestobolsadocumento;
			if (t == null) return false;
			if (Puestobolsaid == t.Puestobolsaid
			 && Puestobolsadocumentoid == t.Puestobolsadocumentoid)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ Puestobolsaid.GetHashCode();
			hash = (hash * 397) ^ Puestobolsadocumentoid.GetHashCode();

			return hash;
        }
        #endregion
    }
}
