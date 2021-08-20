using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Instrumento {
        public Instrumento() { }
        public virtual int Instrumentoid { get; set; }
        public virtual Tipoinstrumento Tipoinstrumento { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool Activo { get; set; }
        public virtual string Codsistema { get; set; }
        public virtual int? Secuencia { get; set; }
    }
}
