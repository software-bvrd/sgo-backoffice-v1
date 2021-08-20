using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisionTramo {
        public virtual int Emisiontramoid { get; set; }
        public virtual Emision Emision { get; set; }
        public virtual int Numerotramo { get; set; }
        public virtual int? Cantidadseriesportramo { get; set; }
        public virtual DateTime? Fechainiciocolocacion { get; set; }
        public virtual DateTime? Fechadeemision { get; set; }
        public virtual DateTime? Fechaplanvencimiento { get; set; }
        public virtual DateTime? Fecharealvencimiento { get; set; }
        public virtual DateTime? Creacion { get; set; }
    }
}
