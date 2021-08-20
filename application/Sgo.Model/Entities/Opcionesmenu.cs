using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Opcionesmenu {
        public Opcionesmenu() { }
        public virtual int Idopcion { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Url { get; set; }
        public virtual string Parametro { get; set; }
        public virtual int? Idpadre { get; set; }
        public virtual int Ordendespliegue { get; set; }
        public virtual bool Estatus { get; set; }
    }
}
