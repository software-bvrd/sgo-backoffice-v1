using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisioncalificacionriesgoMap : ClassMap<EmisionCalificacionRiesgo> {
        
        public EmisioncalificacionriesgoMap() {
			Table("EmisionCalificacionRiesgo");
			LazyLoad();
			Id(x => x.Emisioncalificacionriesgoid).GeneratedBy.Identity().Column("EmisionCalificacionRiesgoID");
			References(x => x.Emision).Column("EmisionID");
			References(x => x.Empresacalificadora).Column("EmpresaCalificadoraID");
			References(x => x.Tipocalificacionriesgo).Column("TipoCalificacionRiesgoID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Nota).Column("Nota");
			Map(x => x.Rangocalificacionid).Column("RangoCalificacionID");
			Map(x => x.Creacion).Column("Creacion");
        }
    }
}
