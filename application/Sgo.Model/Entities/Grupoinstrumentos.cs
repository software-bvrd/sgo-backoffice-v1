using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Grupoinstrumentos {
        public virtual int Idgrupo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int? Rangoinicio { get; set; }
        public virtual int? Rangofinal { get; set; }
        public virtual int? Orden { get; set; }
    }
}
