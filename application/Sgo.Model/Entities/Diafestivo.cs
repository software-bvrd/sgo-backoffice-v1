using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Diafestivo {
        public virtual int Diafestivoid { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual bool Activo { get; set; }
        public virtual string CodigoMercado { get; set; }
        public virtual Int64 TipoInstrumentoID { get; set; }
    }
}
