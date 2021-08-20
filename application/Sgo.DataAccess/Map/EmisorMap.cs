using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisorMap : ClassMap<Emisor> {
        
        public EmisorMap() {
			Table("Emisor");
			LazyLoad();
			Id(x => x.Emisorid).GeneratedBy.Identity().Column("EmisorID");
			References(x => x.Pais).Column("PaisID");
			References(x => x.Ciudad).Column("CiudadID");
			References(x => x.Tipoemisor).Column("TipoEmisorID");
			Map(x => x.Codemisorbvrd).Column("CodEmisorBVRD");
			Map(x => x.Nombreemisor).Column("NombreEmisor");
			Map(x => x.Codensistema).Column("CodEnSistema");
			Map(x => x.Rnc).Column("RNC");
			Map(x => x.Direccion).Column("Direccion");
			Map(x => x.Nombreedificio).Column("NombreEdificio");
			Map(x => x.Casaaptono).Column("CasaAptoNo");
			Map(x => x.Piso).Column("Piso");
			Map(x => x.Telefono).Column("Telefono");
			Map(x => x.Registrosiv).Column("RegistroSIV");
			Map(x => x.Paginaweb).Column("PaginaWeb");
			Map(x => x.Fechaconstitucion).Column("FechaConstitucion");
			Map(x => x.Presidentedelaempresa).Column("PresidentedelaEmpresa");
			Map(x => x.Capitalsuscritopagado).Column("CapitalSuscritoPagado");
			Map(x => x.Fechaingresocomoemisor).Column("FechaIngresoComoEmisor");
			Map(x => x.Subirlogo).Column("SubirLogo");
			Map(x => x.Estatus).Column("Estatus");
			Map(x => x.Email).Column("Email");
			Map(x => x.Descripcion).Column("Descripcion");
			Map(x => x.Actividadeconomicaid).Column("ActividadEconomicaID");
			Map(x => x.Creacion).Column("Creacion");
			Map(x => x.Sectorid).Column("SectorID");
			Map(x => x.Tipoentidadid).Column("TipoEntidadID");
        }
    }
}
