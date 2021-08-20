using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class CodigosParticipante {
        public virtual int Codigosparticipanteid { get; set; }
        public virtual int? Puestobolsaid { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Mercado { get; set; }
    }
}
