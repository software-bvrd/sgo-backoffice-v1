using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class TipoOperacion {
        public virtual int Tipooperacionid { get; set; }
        public virtual string Nombeabreviado { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int? Mercadoid { get; set; }
    }
}
