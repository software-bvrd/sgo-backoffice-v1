using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Boletin {
        public virtual int Boletinid { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual long? Secuencial { get; set; }
        public virtual int? Userid { get; set; }
        public virtual DateTime? Fechacreacion { get; set; }
        public virtual string Tiporeporte { get; set; }
    }
}
