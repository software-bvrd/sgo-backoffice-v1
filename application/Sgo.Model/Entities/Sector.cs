using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Sector {
        public virtual int Sectorid { get; set; }
        public virtual ActividadEconomica Actividadeconomica { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Sectorcodigo { get; set; }
        public virtual bool? Activo { get; set; }
    }
}
