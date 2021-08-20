using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipoentidad {
        public virtual int Tipoentidadid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Siglas { get; set; }
        public virtual bool? Activo { get; set; }
        public virtual bool? Incluirencomision { get; set; }
    }
}
