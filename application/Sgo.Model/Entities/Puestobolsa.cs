using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Puestobolsa {
        public Puestobolsa() { }
        public virtual int Puestobolsaid { get; set; }
        public virtual string Puestobolsacodigo { get; set; }
        public virtual string Puestobolsacodigoorden { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Email { get; set; }
        public virtual string Web { get; set; }
        public virtual string Rnc { get; set; }
        public virtual string Noregistrobv { get; set; }
        public virtual string Noregistrosiv { get; set; }
        public virtual string Representantelegal { get; set; }
        public virtual DateTime? Fechaconstitucion { get; set; }
        public virtual decimal? Capitalsuscritopagado { get; set; }
        public virtual bool Activo { get; set; }
        public virtual string Presidente { get; set; }
        public virtual byte[] Logo { get; set; }
        public virtual int? Tipoparticipanteid { get; set; }
        public virtual int? Clasificacionparticipanteid { get; set; }
        public virtual string Referenciaa { get; set; }
        public virtual string Referenciab { get; set; }
    }
}
