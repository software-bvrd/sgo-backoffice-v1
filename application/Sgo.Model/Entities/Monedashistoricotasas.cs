using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Monedashistoricotasas {
        public virtual int Monedashistoricotasasid { get; set; }
        public virtual Tipomoneda Tipomoneda { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual decimal Tasacompra { get; set; }
        public virtual decimal Tasaventa { get; set; }
        public virtual decimal? Tipp { get; set; }
    }
}
