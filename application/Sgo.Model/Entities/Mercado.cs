using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Mercado {
        public Mercado() { }
        public virtual int Mercadoid { get; set; }
        public virtual Tipomercado Tipomercado { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool Activo { get; set; }
        public virtual string Codigomercado { get; set; }
        public virtual string Alias { get; set; }
        public virtual bool? Incluirreporteboletin { get; set; }
        public virtual int? Secuencia { get; set; }
    }
}
