using System;
using System.Text;

namespace Sgo.Model.Entities {

    public class Archivoimportarexportarcalendario
    {
        public virtual int Archivoimportarcalendarioid { get; set; }
        public virtual Archivoimportarexportarencabezado Archivoimportarexportarencabezado { get; set; }
        public virtual DateTime? Fechainicio { get; set; }
        public virtual DateTime? Horaejecutar { get; set; }
        public virtual bool Activo { get; set; }
    }
}
