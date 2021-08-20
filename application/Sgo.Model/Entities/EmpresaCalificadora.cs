using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmpresaCalificadora {
        public EmpresaCalificadora() { }
        public virtual int Empresacalificadoraid { get; set; }
        public virtual string Empresacalificadoracodigo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Email { get; set; }
        public virtual string Web { get; set; }
        public virtual bool Activa { get; set; }
    }
}
