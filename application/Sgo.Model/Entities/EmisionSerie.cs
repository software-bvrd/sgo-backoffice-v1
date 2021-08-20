using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class EmisionSerie {
        public EmisionSerie() { }
        public virtual int Emisionserieid { get; set; }
        public virtual Tipoliquidacion Tipoliquidacion { get; set; }
        public virtual TipoPeriodo Tipoperiodo { get; set; }
        public virtual int Emisiontramoid { get; set; }
        public virtual string Serie { get; set; }
        public virtual string Codigoserie { get; set; }
        public virtual int Idtipotasa { get; set; }
        public virtual string Codigoisin { get; set; }
        public virtual DateTime? Fechaemision { get; set; }
        public virtual DateTime? Fechavencimiento { get; set; }
        public virtual DateTime Fechaliquidacion { get; set; }
        public virtual decimal? Valorunitarionominal { get; set; }
        public virtual decimal? Inversionminima { get; set; }
        public virtual decimal? Tasa { get; set; }
        public virtual decimal? Inversionmaxima { get; set; }
        public virtual int? Baseliquidacionid { get; set; }
        public virtual DateTime? Fechafinalcolocacion { get; set; }
        public virtual DateTime? Fechainiciocolocacion { get; set; }
        public virtual DateTime? Creacion { get; set; }
        public virtual decimal? Spread { get; set; }
        public virtual string Nobloomberg { get; set; }
        public virtual decimal? Valornominalunitarioserie { get; set; }
        public virtual int? Cantidadtitulos { get; set; }
        public virtual DateTime? Fecharedencion { get; set; }
        public virtual string Notaredencion { get; set; }
        public virtual decimal? Valorredencion { get; set; }
    }
}
