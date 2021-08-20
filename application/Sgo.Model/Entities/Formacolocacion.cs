using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Formacolocacion {
        public Formacolocacion() { }
        public virtual int Formacolocacionid { get; set; }
        public virtual Mercado Mercado { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool Activo { get; set; }
    }
}
