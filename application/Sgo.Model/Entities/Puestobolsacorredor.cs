using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Puestobolsacorredor {
        public Puestobolsacorredor() { }
        public virtual int Puestobolsacorredorid { get; set; }
        public virtual Puestobolsa Puestobolsa { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Email { get; set; }
        public virtual bool? Activo { get; set; }
        public virtual string Codbluuid { get; set; }
        public virtual string Emailpersonal { get; set; }
        public virtual byte[] Foto { get; set; }
        public virtual string Cedula { get; set; }
        public virtual string Nota { get; set; }
        public virtual string Telefonocasa { get; set; }
        public virtual string Telefonocelular { get; set; }
        public virtual string Codbvrd { get; set; }
    }
}
