using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Rangocalificacion {
        public Rangocalificacion() { }
        public virtual int Rangocalificacionid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int? Empresacalificadoraid { get; set; }
    }
}
