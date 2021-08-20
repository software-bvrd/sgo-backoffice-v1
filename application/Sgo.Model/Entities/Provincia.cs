using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Provincia {
        public virtual int Provinciaid { get; set; }
        public virtual int? Ciudadid { get; set; }
        public virtual string Nombre { get; set; }
    }
}
