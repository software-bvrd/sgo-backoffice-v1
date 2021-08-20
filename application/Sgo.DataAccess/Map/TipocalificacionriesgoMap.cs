using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipocalificacionriesgoMap : ClassMap<Tipocalificacionriesgo> {
        
        public TipocalificacionriesgoMap() {
			Table("TipoCalificacionRiesgo");
			LazyLoad();
			Id(x => x.Tipocalificacionriesgoid).GeneratedBy.Identity().Column("TipoCalificacionRiesgoID");
			References(x => x.Rangocalificacion).Column("RangoCalificacionID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Codensistema).Column("CodEnSistema");
			Map(x => x.Color).Column("Color");
			Map(x => x.Definicion).Column("Definicion");
			Map(x => x.Empresacalificadoraid).Column("EmpresaCalificadoraID");
        }
    }
}
