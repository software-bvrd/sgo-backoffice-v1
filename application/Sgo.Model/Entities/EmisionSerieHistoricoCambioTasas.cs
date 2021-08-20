using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisionSerieHistoricoCambioTasas {
        public virtual int Emisionseriehistoricocambiotasasid { get; set; }
        public virtual EmisionSerie Emisionserie { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual double? Tasa { get; set; }
        public virtual bool? Activo { get; set; }
    }
}
