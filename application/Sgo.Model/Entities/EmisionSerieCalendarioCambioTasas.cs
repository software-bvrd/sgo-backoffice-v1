using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisionSerieCalendarioCambioTasas {
        public virtual int Emisionseriecalendariocambiotasasid { get; set; }
        public virtual EmisionSerie Emisionserie { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual double? Tasa { get; set; }
        public virtual bool? Activo { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? Fechaend { get; set; }
        public virtual DateTime? Fechastart { get; set; }
        public virtual int? Recurrenceparentid { get; set; }
        public virtual string Recurrencerule { get; set; }
        public virtual int? Reminder { get; set; }
        public virtual string Statusid { get; set; }
        public virtual string Subject { get; set; }
        public virtual int? Emisionid { get; set; }
        public virtual int? Emisorid { get; set; }
    }
}
