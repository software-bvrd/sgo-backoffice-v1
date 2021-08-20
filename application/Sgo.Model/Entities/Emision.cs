using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Emision {
        public Emision() { }
        public virtual int Emisionid { get; set; }
        public virtual Emisor Emisor { get; set; }
        public virtual Tipoamortizacioncapital Tipoamortizacioncapital { get; set; }
        public virtual Tipoemision Tipoemision { get; set; }
        public virtual Instrumento Instrumento { get; set; }
        public virtual Tipomoneda Tipomoneda { get; set; }
        public virtual Puestobolsa Puestobolsa { get; set; }
        public virtual Formacolocacion Formacolocacion { get; set; }
        public virtual BaseLiquidacion Baseliquidacion { get; set; }
        public virtual string Codemisionbvrd { get; set; }
        public virtual string Codensistema { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int? Cantidadtramos { get; set; }
        public virtual DateTime? Fechaaprobacionbvrd { get; set; }
        public virtual DateTime? Fechaaprobacionsiv { get; set; }
        public virtual string Finalidaddelaemision { get; set; }
        public virtual string Subiraop { get; set; }
        public virtual decimal? Montototaldelaemision { get; set; }
        public virtual decimal? Montoofertadoalpublico { get; set; }
        public virtual decimal? Montopendientedecolocaciondelaop { get; set; }
        public virtual decimal? Montopendientedeofertaralpublico { get; set; }
        public virtual string Estatus { get; set; }
        public virtual string Nota1 { get; set; }
        public virtual string Nota2 { get; set; }
        public virtual decimal? Valornominal { get; set; }
        public virtual DateTime? Creacion { get; set; }
        public virtual int? Tipoinstrumentoid { get; set; }
        public virtual string Garantiaprogramaemision { get; set; }
        public virtual bool? Calcularcomision { get; set; }
        public virtual decimal? Montototaldelaemisioncompletivo { get; set; }
        public virtual DateTime? Fechafinalcolocacion { get; set; }
        public virtual int? Tiponegociacionid { get; set; }
    }
}
