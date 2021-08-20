using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tiponegociacion {
        public virtual int Tiponegociacionid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool? Activo { get; set; }
    }
}
