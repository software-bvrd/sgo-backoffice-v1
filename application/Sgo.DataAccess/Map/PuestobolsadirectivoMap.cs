using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PuestobolsadirectivoMap : ClassMap<Puestobolsadirectivo> {
        
        public PuestobolsadirectivoMap() {
			Table("PuestoBolsaDirectivo");
			LazyLoad();
			Id(x => x.Puestobolsadirectivoid).GeneratedBy.Identity().Column("PuestoBolsaDirectivoID");
			References(x => x.Puestobolsa).Column("PuestoBolsaID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Direccion).Column("Direccion");
			Map(x => x.Telefono).Column("Telefono");
			Map(x => x.Email).Column("Email");
			Map(x => x.Puesto).Column("Puesto");
			Map(x => x.Encargado).Column("Encargado");
        }
    }
}
