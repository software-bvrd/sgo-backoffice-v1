using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Permisosporperfil {
        public virtual int Idpermisoporperfil { get; set; }
        public virtual Opcionesmenu Opcionesmenu { get; set; }
        public virtual Perfiles Perfiles { get; set; }
    }
}
