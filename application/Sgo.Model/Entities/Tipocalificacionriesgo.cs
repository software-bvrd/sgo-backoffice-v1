using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Tipocalificacionriesgo {
        public Tipocalificacionriesgo() { }
        public virtual int Tipocalificacionriesgoid { get; set; }
        public virtual Rangocalificacion Rangocalificacion { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Codensistema { get; set; }
        public virtual string Color { get; set; }
        public virtual string Definicion { get; set; }
        public virtual int? Empresacalificadoraid { get; set; }
    }
}
