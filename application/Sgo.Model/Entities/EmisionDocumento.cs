using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisionDocumento {
        public virtual int Emisionid { get; set; }
        public virtual int Emisiondocumentoid { get; set; }
        public virtual Emision Emision { get; set; }
        public virtual Tipodocumento Tipodocumento { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Nombre { get; set; }
        public virtual byte[] Adjunto { get; set; }
        public virtual string Archivo { get; set; }
        public virtual DateTime? Creacion { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as EmisionDocumento;
			if (t == null) return false;
			if (Emisionid == t.Emisionid
			 && Emisiondocumentoid == t.Emisiondocumentoid)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ Emisionid.GetHashCode();
			hash = (hash * 397) ^ Emisiondocumentoid.GetHashCode();

			return hash;
        }
        #endregion
    }
}
