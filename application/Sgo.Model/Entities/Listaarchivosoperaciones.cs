using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Listaarchivosoperaciones {
        public virtual int Idarchivos { get; set; }
        public virtual string Nombre { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual int? Lineasvalidas { get; set; }
        public virtual int? Lineasnovalidas { get; set; }
    }
}
