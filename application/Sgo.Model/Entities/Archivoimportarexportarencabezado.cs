using System;
using System.Text;
using System.Collections.Generic;


namespace Sgo.Model.Entities {
    
    public class Archivoimportarexportarencabezado {
        public Archivoimportarexportarencabezado() { }
        public virtual int Archivoid { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Ruta { get; set; }
        public virtual string Formato { get; set; }
        public virtual string Tabladestino { get; set; }
        public virtual string Direccionftp { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool? Accion { get; set; }
    }
}
