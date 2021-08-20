using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PermisosporperfilMap : ClassMap<Permisosporperfil> {
        
        public PermisosporperfilMap() {
			Table("PermisosPorPerfil");
			LazyLoad();
			Id(x => x.Idpermisoporperfil).GeneratedBy.Identity().Column("IdPermisoPorPerfil");
			References(x => x.Opcionesmenu).Column("IdOpcion");
			References(x => x.Perfiles).Column("IdPerfil");
        }
    }
}
