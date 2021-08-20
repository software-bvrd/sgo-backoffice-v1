using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class PuestobolsacorredorlicenciaMap : ClassMap<Puestobolsacorredorlicencia> {
        
        public PuestobolsacorredorlicenciaMap() {
			Table("PuestoBolsaCorredorLicencia");
			LazyLoad();
			Id(x => x.Puestobolsacorredorlicenciaid).GeneratedBy.Identity().Column("PuestoBolsaCorredorLicenciaID");
			References(x => x.Puestobolsacorredor).Column("PuestoBolsaCorredorID");
			Map(x => x.Licencia).Column("Licencia");
			Map(x => x.Fechalicencia).Column("FechaLicencia");
			Map(x => x.Fechalicenciavence).Column("FechaLicenciaVence");
			Map(x => x.Licenciasiv).Column("LicenciaSIV");
			Map(x => x.Fechalicenciasiv).Column("FechaLicenciaSIV");
			Map(x => x.Fechalicenciasivvence).Column("FechaLicenciaSIVVence");
			Map(x => x.Nota).Column("Nota");
        }
    }
}
