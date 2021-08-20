using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class UsuariosMap : ClassMap<Usuarios> {
        
        public UsuariosMap() {
			Table("Usuarios");
			LazyLoad();
			Id(x => x.Idusuario).GeneratedBy.Identity().Column("IdUsuario");
			References(x => x.Perfiles).Column("IdPerfil");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Apellidos).Column("Apellidos");
			Map(x => x.Correoelectronico).Column("CorreoElectronico");
			Map(x => x.Nombreusuario).Column("NombreUsuario");
			Map(x => x.Clave).Column("Clave");
			Map(x => x.Codigosecreto).Column("CodigoSecreto");
			Map(x => x.Idestatus).Column("IdEstatus");
        }
    }
}
