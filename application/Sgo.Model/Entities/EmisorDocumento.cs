using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisorDocumento {
        public virtual int Emisorid { get; set; }
        public virtual int Emisordocumentoid { get; set; }
        public virtual Emisor Emisor { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Nombre { get; set; }
        public virtual byte[] Adjunto { get; set; }
        public virtual int? Tipodocumentoid { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual DateTime? Creacion { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as EmisorDocumento;
			if (t == null) return false;
			if (Emisorid == t.Emisorid
			 && Emisordocumentoid == t.Emisordocumentoid)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ Emisorid.GetHashCode();
			hash = (hash * 397) ^ Emisordocumentoid.GetHashCode();

			return hash;
        }
        #endregion
    }
}
