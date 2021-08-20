using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class DiafestivoMap : ClassMap<Diafestivo> {
        
        public DiafestivoMap() {
			Table("DiaFestivo");
			LazyLoad();
			Id(x => x.Diafestivoid).GeneratedBy.Identity().Column("DiaFestivoID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Descripcion).Column("Descripcion").Not.Nullable();
			Map(x => x.Activo).Column("Activo").Not.Nullable();
            Map(x => x.CodigoMercado).Column("CodigoMercado").Nullable();
            Map(x => x.TipoInstrumentoID).Column("TipoInstrumentoID").Nullable();

        }
    }
}
