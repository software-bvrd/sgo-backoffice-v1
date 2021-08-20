using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Puestobolsadirectivo {
        public virtual int Puestobolsadirectivoid { get; set; }
        public virtual Puestobolsa Puestobolsa { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Email { get; set; }
        public virtual string Puesto { get; set; }
        public virtual bool? Encargado { get; set; }
    }
}
