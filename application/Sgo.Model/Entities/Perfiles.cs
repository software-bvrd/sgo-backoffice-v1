using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Perfiles {
        public Perfiles() { }
        public virtual int Idperfil { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool? Estatus { get; set; }
    }
}
