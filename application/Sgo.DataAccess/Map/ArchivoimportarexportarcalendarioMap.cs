using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ArchivoimportarexportarcalendarioMap : ClassMap<Archivoimportarexportarcalendario> {
        
        public ArchivoimportarexportarcalendarioMap() {
			Table("ArchivoImportarExportarCalendario");
			LazyLoad();
			Id(x => x.Archivoimportarcalendarioid).GeneratedBy.Identity().Column("ArchivoImportarCalendarioID");
			References(x => x.Archivoimportarexportarencabezado).Column("ArchivoID");
			Map(x => x.Fechainicio).Column("FechaInicio");
			Map(x => x.Horaejecutar).Column("HoraEjecutar");
			Map(x => x.Activo).Column("Activo").Not.Nullable();
        }
    }
}
