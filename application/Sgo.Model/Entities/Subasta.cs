using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Subasta {
        public virtual int Subastaid { get; set; }
        public virtual string Puestobolsacodigo { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Bono { get; set; }
        public virtual decimal? Monto { get; set; }
        public virtual string Codigoisin { get; set; }
        public virtual decimal? CantTit { get; set; }
        public virtual decimal? Precio { get; set; }
        public virtual decimal? Valortransado { get; set; }
        public virtual double? Ordenno { get; set; }
        public virtual DateTime? Fechalinea { get; set; }
        public virtual string Hora { get; set; }
        public virtual string Rtn { get; set; }
        public virtual string Noregistrolibro { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Condicion { get; set; }
    }
}
