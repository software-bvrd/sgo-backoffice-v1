using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {

    public class Operaciones
    {
        public virtual int Operacionesid { get; set; }
        public virtual string Tiporegistro { get; set; }
        public virtual string Numerooperacion { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual string Codigoserie { get; set; }
        public virtual double? Yield { get; set; }
        public virtual decimal? Valorunitarionominal { get; set; }
        public virtual int? Cantidadtitulos { get; set; }
        public virtual decimal? Valornominaltotal { get; set; }
        public virtual double? Precio { get; set; }
        public virtual decimal? Montotransado { get; set; }
        public virtual DateTime? Hora { get; set; }
        public virtual Statusoperacion Statusoperacion { get; set; }
        public virtual decimal? Interesacumulado { get; set; }
        public virtual string Usuario { get; set; }
        public virtual bool Activa { get; set; }
        public virtual string Puestobolsacodigocomp { get; set; }
        public virtual string Puestobolsacodigovend { get; set; }
        public virtual string Sectorcodigo { get; set; }
        public virtual int Tipointerescodigo { get; set; }
        public virtual int Tipoperiodocodigo { get; set; }
    }
}
