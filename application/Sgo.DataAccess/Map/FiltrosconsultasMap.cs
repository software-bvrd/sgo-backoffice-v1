using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {


    public class FiltrosconsultasMap : ClassMap<FiltrosConsultas>
    {
        
        public FiltrosconsultasMap() {
			Table("FiltrosConsultas");
			LazyLoad();
			Id(x => x.Idconsulta).GeneratedBy.Identity().Column("idConsulta");
			Map(x => x.Nombreconsulta).Column("NombreConsulta");
			Map(x => x.Filtro).Column("Filtro");
			Map(x => x.Nombreconsultausuario).Column("NombreConsultaUsuario");
			Map(x => x.Idusuario).Column("IdUsuario");
			Map(x => x.Estruturagrid).Column("EstruturaGrid");
        }
    }
}
