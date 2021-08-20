using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipodocumento {
        public Tipodocumento() { }
        public virtual int Tipodocumentoid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool? Activo { get; set; }
    }
}
