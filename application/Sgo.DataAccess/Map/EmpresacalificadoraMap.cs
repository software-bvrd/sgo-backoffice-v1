using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {


    public class EmpresacalificadoraMap : ClassMap<EmpresaCalificadora>
    {
        
        public EmpresacalificadoraMap() {
			Table("EmpresaCalificadora");
			LazyLoad();
			Id(x => x.Empresacalificadoraid).GeneratedBy.Identity().Column("EmpresaCalificadoraID");
			Map(x => x.Empresacalificadoracodigo).Column("EmpresaCalificadoraCodigo");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Direccion).Column("Direccion");
			Map(x => x.Telefono).Column("Telefono");
			Map(x => x.Email).Column("Email");
			Map(x => x.Web).Column("Web");
			Map(x => x.Activa).Column("Activa").Not.Nullable();
        }
    }
}
