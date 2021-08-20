using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipoliquidacion {
        public Tipoliquidacion() { }
        public virtual int Tipoliquidacionid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool Activo { get; set; }
        public virtual string Codigointerno { get; set; }
        public virtual int? Dias { get; set; }
    }
}
