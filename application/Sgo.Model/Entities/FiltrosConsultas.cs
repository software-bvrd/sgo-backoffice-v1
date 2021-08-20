using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class FiltrosConsultas {
        public virtual int Idconsulta { get; set; }
        public virtual string Nombreconsulta { get; set; }
        public virtual string Filtro { get; set; }
        public virtual string Nombreconsultausuario { get; set; }
        public virtual int? Idusuario { get; set; }
        public virtual string Estruturagrid { get; set; }
    }
}
