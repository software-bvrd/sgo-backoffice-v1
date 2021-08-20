using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisorcalificacionriesgoMap : ClassMap<EmisorCalificacionRiesgo> {
        
        public EmisorcalificacionriesgoMap() {
			Table("EmisorCalificacionRiesgo");
			LazyLoad();
			Id(x => x.Emisorcalificacionriesgoid).GeneratedBy.Identity().Column("EmisorCalificacionRiesgoID");
			References(x => x.Emisor).Column("EmisorID");
			References(x => x.Empresacalificadora).Column("EmpresaCalificadoraID");
			References(x => x.Tipocalificacionriesgo).Column("TipoCalificacionRiesgoID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Nota).Column("Nota");
			Map(x => x.Creacion).Column("Creacion");
			Map(x => x.Rangocalificacionid).Column("RangoCalificacionID");
        }
    }
}
