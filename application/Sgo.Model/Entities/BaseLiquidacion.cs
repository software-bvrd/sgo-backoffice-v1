using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class BaseLiquidacion {
        public BaseLiquidacion() { }
        public virtual int Baseliquidacionid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int? Diasnatural { get; set; }
        public virtual int? Anonatural { get; set; }
        public virtual string Tipo { get; set; }
        public virtual bool? Activo { get; set; }
    }
}
