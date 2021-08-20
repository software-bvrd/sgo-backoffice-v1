using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class EmisionseriecalendariocambiotasasMap : ClassMap<EmisionSerieCalendarioCambioTasas> {
        
        public EmisionseriecalendariocambiotasasMap() {
			Table("EmisionSerieCalendarioCambioTasas");
			LazyLoad();
			Id(x => x.Emisionseriecalendariocambiotasasid).GeneratedBy.Identity().Column("EmisionSerieCalendarioCambioTasasID");
			References(x => x.Emisionserie).Column("EmisionSerieID");
			Map(x => x.Fecha).Column("Fecha");
			Map(x => x.Tasa).Column("Tasa");
			Map(x => x.Activo).Column("Activo");
			Map(x => x.Description).Column("Description");
			Map(x => x.Fechaend).Column("FechaEnd");
			Map(x => x.Fechastart).Column("FechaStart");
			Map(x => x.Recurrenceparentid).Column("RecurrenceParentID");
			Map(x => x.Recurrencerule).Column("RecurrenceRule");
			Map(x => x.Reminder).Column("Reminder");
			Map(x => x.Statusid).Column("StatusId");
			Map(x => x.Subject).Column("Subject");
			Map(x => x.Emisionid).Column("EmisionID");
			Map(x => x.Emisorid).Column("EmisorID");
        }
    }
}
