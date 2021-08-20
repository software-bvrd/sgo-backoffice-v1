using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Puestobolsacorredorlicencia {
        public virtual int Puestobolsacorredorlicenciaid { get; set; }
        public virtual Puestobolsacorredor Puestobolsacorredor { get; set; }
        public virtual string Licencia { get; set; }
        public virtual DateTime? Fechalicencia { get; set; }
        public virtual DateTime? Fechalicenciavence { get; set; }
        public virtual string Licenciasiv { get; set; }
        public virtual DateTime? Fechalicenciasiv { get; set; }
        public virtual DateTime? Fechalicenciasivvence { get; set; }
        public virtual string Nota { get; set; }
    }
}
