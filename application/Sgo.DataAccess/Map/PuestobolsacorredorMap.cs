using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PuestobolsacorredorMap : ClassMap<Puestobolsacorredor> {
        
        public PuestobolsacorredorMap() {
			Table("PuestoBolsaCorredor");
			LazyLoad();
			Id(x => x.Puestobolsacorredorid).GeneratedBy.Identity().Column("PuestoBolsaCorredorID");
			References(x => x.Puestobolsa).Column("PuestoBolsaID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Direccion).Column("Direccion");
			Map(x => x.Telefono).Column("Telefono");
			Map(x => x.Email).Column("Email");
			Map(x => x.Activo).Column("Activo");
			Map(x => x.Codbluuid).Column("CodBLUUID");
			Map(x => x.Emailpersonal).Column("EmailPersonal");
			Map(x => x.Foto).Column("Foto");
			Map(x => x.Cedula).Column("Cedula");
			Map(x => x.Nota).Column("Nota");
			Map(x => x.Telefonocasa).Column("TelefonoCasa");
			Map(x => x.Telefonocelular).Column("TelefonoCelular");
			Map(x => x.Codbvrd).Column("CodBVRD");
        }
    }
}
