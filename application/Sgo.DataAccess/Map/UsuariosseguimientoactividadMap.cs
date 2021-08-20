using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class UsuariosseguimientoactividadMap : ClassMap<UsuariosSeguimientoActividad> {
        
        public UsuariosseguimientoactividadMap() {
			Table("UsuariosSeguimientoActividad");
			LazyLoad();
            Id(x => x.UsrSeguimientoActividadId).GeneratedBy.Identity().Column("UsrSeguimientoActividadId");
			References(x => x.Usuarios).Column("IdUsuario");
			Map(x => x.Actividad).Column("Actividad");
			Map(x => x.Pantalla).Column("Pantalla");
			Map(x => x.Comando).Column("Comando");
			Map(x => x.Fechahora).Column("FechaHora");
        }
    }
}
