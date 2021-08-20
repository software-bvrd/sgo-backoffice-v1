using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class ArchivoimportarexportardetalleMap : ClassMap<Archivoimportarexportardetalle> {
        
        public ArchivoimportarexportardetalleMap() {
			Table("ArchivoImportarExportarDetalle");
			LazyLoad();
			CompositeId().KeyProperty(x => x.Archivoid, "ArchivoID")
			             .KeyProperty(x => x.Archivodetalleid, "ArchivoDetalleID");
			References(x => x.Archivoimportarexportarencabezado).Column("ArchivoID");
			Map(x => x.Numerocolumnaarchivo).Column("NumeroColumnaArchivo");
			Map(x => x.Nombrecolumnaarchivo).Column("NombreColumnaArchivo");
			Map(x => x.Nombrecolumnasql).Column("NombreColumnaSQL");
			Map(x => x.Tipodedato).Column("TipoDeDato");
			Map(x => x.Numerocolumnasql).Column("NumeroColumnaSQL");
        }
    }
}
