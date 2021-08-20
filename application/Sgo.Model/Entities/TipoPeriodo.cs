using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class TipoPeriodo {
        public TipoPeriodo() { }
        public virtual int Tipoperiodoid { get; set; }
        public virtual int Tipoperiodocodigo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int Equivalenteanual { get; set; }
        public virtual bool Activo { get; set; }
    }
}
