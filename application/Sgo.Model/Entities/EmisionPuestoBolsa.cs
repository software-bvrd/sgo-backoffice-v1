using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisionPuestoBolsa {
        public virtual int Emisionpuestobolsaid { get; set; }
        public virtual Emision Emision { get; set; }
        public virtual string Nota { get; set; }
        public virtual int? Puestobolsaid { get; set; }
        public virtual DateTime? Creacion { get; set; }
    }
}
