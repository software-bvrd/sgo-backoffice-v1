using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class ClasificacionParticipante {
        public virtual int ClasificacionParticipanteId { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Codigomercado { get; set; }
        public virtual bool? Estatus { get; set; }
    }
}
