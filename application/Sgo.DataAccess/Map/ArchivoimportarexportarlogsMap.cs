using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ArchivoimportarexportarlogsMap : ClassMap<Archivoimportarexportarlogs> {
        
        public ArchivoimportarexportarlogsMap() {
			Table("ArchivoImportarExportarLogs");
			LazyLoad();
			CompositeId().KeyProperty(x => x.Archivoid, "ArchivoID")
			             .KeyProperty(x => x.Archivoimportarexportarlogsid, "ArchivoImportarExportarLogsID");
			References(x => x.Archivoimportarexportarencabezado).Column("ArchivoID");
			Map(x => x.Fechainicio).Column("FechaInicio");
			Map(x => x.Fechafinal).Column("FechaFinal");
			Map(x => x.Realizado).Column("Realizado");
			Map(x => x.Error).Column("Error");
        }
    }
}
