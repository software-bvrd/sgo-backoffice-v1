using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisionCalificacionRiesgo {
        public virtual int Emisioncalificacionriesgoid { get; set; }
        public virtual Emision Emision { get; set; }
        public virtual FiltrosConsultas Empresacalificadora { get; set; }
        public virtual Tipocalificacionriesgo Tipocalificacionriesgo { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Nota { get; set; }
        public virtual int? Rangocalificacionid { get; set; }
        public virtual DateTime? Creacion { get; set; }
    }
}
