using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Pais {
        public Pais() { }
        public virtual int Paisid { get; set; }
        public virtual int? Isonum { get; set; }
        public virtual string Iso2 { get; set; }
        public virtual string Iso3 { get; set; }
        public virtual string Nombre { get; set; }
    }
}
