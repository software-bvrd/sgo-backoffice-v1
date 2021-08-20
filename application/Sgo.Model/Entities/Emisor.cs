using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Emisor {
        public Emisor() { }
        public virtual int Emisorid { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public virtual Tipoemisor Tipoemisor { get; set; }
        public virtual string Codemisorbvrd { get; set; }
        public virtual string Nombreemisor { get; set; }
        public virtual string Codensistema { get; set; }
        public virtual string Rnc { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Nombreedificio { get; set; }
        public virtual string Casaaptono { get; set; }
        public virtual string Piso { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Registrosiv { get; set; }
        public virtual string Paginaweb { get; set; }
        public virtual DateTime? Fechaconstitucion { get; set; }
        public virtual string Presidentedelaempresa { get; set; }
        public virtual decimal? Capitalsuscritopagado { get; set; }
        public virtual DateTime? Fechaingresocomoemisor { get; set; }
        public virtual byte[] Subirlogo { get; set; }
        public virtual string Estatus { get; set; }
        public virtual string Email { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int? Actividadeconomicaid { get; set; }
        public virtual DateTime? Creacion { get; set; }
        public virtual int? Sectorid { get; set; }
        public virtual int? Tipoentidadid { get; set; }
    }
}
