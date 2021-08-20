using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Usuarios {
        public Usuarios() { }
        public virtual int Idusuario { get; set; }
        public virtual Perfiles Perfiles { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellidos { get; set; }
        public virtual string Correoelectronico { get; set; }
        public virtual string Nombreusuario { get; set; }
        public virtual string Clave { get; set; }
        public virtual int? Codigosecreto { get; set; }
        public virtual string Idestatus { get; set; }
    }
}
