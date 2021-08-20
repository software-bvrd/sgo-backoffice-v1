using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class OpcionesmenuMap : ClassMap<Opcionesmenu> {
        
        public OpcionesmenuMap() {
			Table("OpcionesMenu");
			LazyLoad();
			Id(x => x.Idopcion).GeneratedBy.Identity().Column("IdOpcion");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Url).Column("Url");
			Map(x => x.Parametro).Column("Parametro");
			Map(x => x.Idpadre).Column("IdPadre");
			Map(x => x.Ordendespliegue).Column("OrdenDespliegue").Not.Nullable();
			Map(x => x.Estatus).Column("Estatus").Not.Nullable();
        }
    }
}
