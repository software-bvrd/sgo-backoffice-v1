using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipomoneda {
        public Tipomoneda() { }
        public virtual int Tipomonedaid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Simbolo { get; set; }
        public virtual bool Local { get; set; }
    }
}
