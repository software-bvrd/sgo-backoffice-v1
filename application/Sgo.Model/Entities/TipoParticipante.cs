using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class TipoParticipante {
        public virtual int Tipoparticipanteid { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual bool? Estado { get; set; }
    }
}
