using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipoamortizacioncapital {
        public Tipoamortizacioncapital() { }
        public virtual int Tipoamortizacioncapitalid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool Activo { get; set; }
    }
}
