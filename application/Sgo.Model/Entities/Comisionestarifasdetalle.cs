using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Comisionestarifasdetalle {
        public virtual int Comisionestarifasdetalleid { get; set; }
        public virtual ComisionesTarifas Comisionestarifas { get; set; }
        public virtual string Concepto { get; set; }
        public virtual decimal? Valorinicio { get; set; }
        public virtual decimal? Valorfinal { get; set; }
        public virtual decimal? Porcentajecobrar { get; set; }
        public virtual decimal? Valorcobrar { get; set; }
    }
}
