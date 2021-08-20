using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sgo.Model.Entities; 

namespace Sgo.DataAccess.Maps {
    
    
    public class AppointmentstatusMap : ClassMap<AppointmentStatus> {
        
        public AppointmentstatusMap() {
			Table("AppointmentStatus");
			LazyLoad();
			Id(x => x.Statusid).GeneratedBy.Assigned().Column("StatusId");
			Map(x => x.Statusdesc).Column("StatusDesc");
        }
    }
}
