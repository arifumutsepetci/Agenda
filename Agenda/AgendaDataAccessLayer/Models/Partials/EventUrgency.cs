using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDataAccessLayer
{
    public partial class EventUrgency
    {
        public const int VeryUrgent = 4;
        public const int Urgent = 5;
        public const int Normal = 6;
        public const int NotUrgent = 7;
        public const int NotUrgentAtAll = 8;
    }

    public partial class AgendaContext
    {
        public EventUrgency GetEventUrgencyByEventUrgencyId(int eventUrgencyId)
        {
            return EventUrgency.FirstOrDefault(i => i.ObjectId == eventUrgencyId);
        }
        public List<EventUrgency> GetEventUrgencyList()
        {
            return EventUrgency.Where(i => !i.IsDeleted).ToList();
        }
    }
}
