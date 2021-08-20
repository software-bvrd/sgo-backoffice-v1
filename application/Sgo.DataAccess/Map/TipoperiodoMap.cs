using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class TipoperiodoMap : ClassMap<TipoPeriodo> {
        
        public TipoperiodoMap() {
			Table("TipoPeriodo");
			LazyLoad();
			Id(x => x.Tipoperiodoid).GeneratedBy.Identity().Column("TipoPeriodoID");
			Map(x => x.Tipoperiodocodigo).Column("TipoPeriodoCodigo").Not.Nullable();
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Equivalenteanual).Column("EquivalenteAnual").Not.Nullable();
			Map(x => x.Activo).Column("Activo").Not.Nullable();
        }
    }
}
