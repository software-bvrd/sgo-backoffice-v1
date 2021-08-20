using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ListaarchivosoperacionesMap : ClassMap<Listaarchivosoperaciones> {
        
        public ListaarchivosoperacionesMap() {
			Table("ListaArchivosOperaciones");
			LazyLoad();
			Id(x => x.Idarchivos).GeneratedBy.Identity().Column("IdArchivos");
			Map(x => x.Nombre).Column("Nombre");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Lineasvalidas).Column("LineasValidas");
			Map(x => x.Lineasnovalidas).Column("LineasNoValidas");
        }
    }
}
