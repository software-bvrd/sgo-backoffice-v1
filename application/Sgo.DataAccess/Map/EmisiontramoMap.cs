using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisiontramoMap : ClassMap<EmisionTramo> {
        
        public EmisiontramoMap() {
			Table("EmisionTramo");
			LazyLoad();
			Id(x => x.Emisiontramoid).GeneratedBy.Identity().Column("EmisionTramoID");
			References(x => x.Emision).Column("EmisionID");
			Map(x => x.Numerotramo).Column("NumeroTramo").Not.Nullable();
			Map(x => x.Cantidadseriesportramo).Column("CantidadSeriesPorTramo");
			Map(x => x.Fechainiciocolocacion).Column("FechaInicioColocacion");
			Map(x => x.Fechadeemision).Column("FechaDeEmision");
			Map(x => x.Fechaplanvencimiento).Column("FechaPlanVencimiento");
			Map(x => x.Fecharealvencimiento).Column("FechaRealVencimiento");
			Map(x => x.Creacion).Column("Creacion");
        }
    }
}
