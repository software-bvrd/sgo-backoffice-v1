using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class SubastaMap : ClassMap<Subasta> {
        
        public SubastaMap() {
			Table("Subasta");
			LazyLoad();
			Id(x => x.Subastaid).GeneratedBy.Identity().Column("SubastaID");
			Map(x => x.Puestobolsacodigo).Column("PuestoBolsaCodigo");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Bono).Column("Bono");
			Map(x => x.Monto).Column("Monto");
			Map(x => x.Codigoisin).Column("CodigoISIN");
			Map(x => x.CantTit).Column("Cant_Tit");
			Map(x => x.Precio).Column("Precio");
			Map(x => x.Valortransado).Column("ValorTransado");
			Map(x => x.Ordenno).Column("OrdenNo");
			Map(x => x.Fechalinea).Column("FechaLinea");
			Map(x => x.Hora).Column("Hora");
			Map(x => x.Rtn).Column("RTN");
			Map(x => x.Noregistrolibro).Column("NoRegistroLibro");
			Map(x => x.Estado).Column("Estado");
			Map(x => x.Condicion).Column("Condicion");
        }
    }
}
