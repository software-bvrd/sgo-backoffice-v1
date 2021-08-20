using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class UsuariosSeguimientoActividad {
         public virtual int UsrSeguimientoActividadId { get; set; }
        	
        public virtual Usuarios Usuarios { get; set; }
        public virtual string Actividad { get; set; }
        public virtual string Pantalla { get; set; }
        public virtual string Comando { get; set; }
        public virtual DateTime? Fechahora { get; set; }
    }
}
