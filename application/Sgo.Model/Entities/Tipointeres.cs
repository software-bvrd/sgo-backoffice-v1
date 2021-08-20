using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipointeres {
        public virtual int Tipointeresid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Tipointerescodigo { get; set; }
        public virtual bool Activo { get; set; }
    }
}
