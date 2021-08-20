using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class ComisionesTarifas {
        public ComisionesTarifas() { }
        public virtual int Comisionestarifasid { get; set; }
        public virtual string Concepto { get; set; }
        public virtual bool? Activo { get; set; }
        public virtual string Entidad { get; set; }
    }
}
