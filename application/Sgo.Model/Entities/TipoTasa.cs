using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class TipoTasa {
        public virtual int Idtipotasa { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Descripcioncorta { get; set; }
        public virtual string Atributo { get; set; }
        public virtual int? Frecuencia { get; set; }
    }
}
