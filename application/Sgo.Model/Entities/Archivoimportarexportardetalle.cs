using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Archivoimportarexportardetalle {
        public virtual int Archivoid { get; set; }
        public virtual int Archivodetalleid { get; set; }
        public virtual Archivoimportarexportarencabezado Archivoimportarexportarencabezado { get; set; }
        public virtual int? Numerocolumnaarchivo { get; set; }
        public virtual string Nombrecolumnaarchivo { get; set; }
        public virtual string Nombrecolumnasql { get; set; }
        public virtual string Tipodedato { get; set; }
        public virtual int? Numerocolumnasql { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as Archivoimportarexportardetalle;
			if (t == null) return false;
			if (Archivoid == t.Archivoid
			 && Archivodetalleid == t.Archivodetalleid)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ Archivoid.GetHashCode();
			hash = (hash * 397) ^ Archivodetalleid.GetHashCode();

			return hash;
        }
        #endregion
    }
}
