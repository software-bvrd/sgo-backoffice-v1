using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Archivoimportarexportarlogs {
        public virtual int Archivoid { get; set; }
        public virtual int Archivoimportarexportarlogsid { get; set; }
        public virtual Archivoimportarexportarencabezado Archivoimportarexportarencabezado { get; set; }
        public virtual DateTime? Fechainicio { get; set; }
        public virtual DateTime? Fechafinal { get; set; }
        public virtual bool? Realizado { get; set; }
        public virtual string Error { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as Archivoimportarexportarlogs;
			if (t == null) return false;
			if (Archivoid == t.Archivoid
			 && Archivoimportarexportarlogsid == t.Archivoimportarexportarlogsid)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ Archivoid.GetHashCode();
			hash = (hash * 397) ^ Archivoimportarexportarlogsid.GetHashCode();

			return hash;
        }
        #endregion
    }
}
