using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDataAccessLayer
{
    public partial class Events
    {

    }
    public partial class AgendaContext
    {
        public Events GetEventByEventId(int eventId)
        {
            return Events.FirstOrDefault(i => i.ObjectId == eventId);
        }
        public List<Events> GetEventList()
        {
            return Events.Where(i=>!i.IsDeleted).ToList();
        }
    }
}
