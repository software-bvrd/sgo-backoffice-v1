using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipoemision {
        public Tipoemision() { }
        public virtual int Tipodeemisionid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool Activo { get; set; }
    }
}
