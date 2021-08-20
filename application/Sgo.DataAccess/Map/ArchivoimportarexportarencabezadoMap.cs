using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ArchivoimportarexportarencabezadoMap : ClassMap<Archivoimportarexportarencabezado> {
        
        public ArchivoimportarexportarencabezadoMap() {
			Table("ArchivoImportarExportarEncabezado");
			LazyLoad();
			Id(x => x.Archivoid).GeneratedBy.Identity().Column("ArchivoID");
			Map(x => x.Nombre).Column("Nombre").Not.Nullable();
			Map(x => x.Ruta).Column("Ruta");
			Map(x => x.Formato).Column("Formato");
			Map(x => x.Tabladestino).Column("TablaDestino");
			Map(x => x.Direccionftp).Column("DireccionFTP");
			Map(x => x.Username).Column("Username");
			Map(x => x.Password).Column("Password");
			Map(x => x.Accion).Column("Accion");
        }
    }
}
