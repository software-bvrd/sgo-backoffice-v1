using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Subastaemisionserie {
        public virtual int Subastaemisionserieid { get; set; }
        public virtual string Emisionserie { get; set; }
        public virtual string Codigoisin { get; set; }
        public virtual decimal? Monto { get; set; }
        public virtual decimal? Montoadjudicado { get; set; }
    }
}
