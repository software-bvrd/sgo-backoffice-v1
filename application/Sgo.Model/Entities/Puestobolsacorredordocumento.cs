using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Puestobolsacorredordocumento {
        public virtual int Puestobolsacorredordocumentoid { get; set; }
        public virtual Puestobolsacorredor Puestobolsacorredor { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Nombre { get; set; }
        public virtual byte[] Adjunto { get; set; }
        public virtual int? Tipodocumentoid { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual DateTime? Creacion { get; set; }
    }
}
