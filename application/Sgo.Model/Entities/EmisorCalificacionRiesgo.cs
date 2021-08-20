using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisorCalificacionRiesgo {
        public virtual int Emisorcalificacionriesgoid { get; set; }
        public virtual Emisor Emisor { get; set; }
        public virtual FiltrosConsultas Empresacalificadora { get; set; }
        public virtual Tipocalificacionriesgo Tipocalificacionriesgo { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Nota { get; set; }
        public virtual DateTime? Creacion { get; set; }
        public virtual int? Rangocalificacionid { get; set; }
    }
}
