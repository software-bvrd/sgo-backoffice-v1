using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipoinstrumento {
        public Tipoinstrumento() { }
        public virtual int Tipoinstrumentoid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool? Activo { get; set; }
    }
}
