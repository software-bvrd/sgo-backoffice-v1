using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Ciudad {
        public Ciudad() { }
        public virtual int Ciudadid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int? Paisid { get; set; }
    }
}
