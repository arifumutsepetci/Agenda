using AgendaDataAccessLayer;

namespace Agenda
{
    public class HomeIndexModel
    {
        public List<Events> EventList { get; set; }
        public List<EventUrgency> UrgencyList { get; set; }
        public bool? IsSuccessful { get; set; } = null;
    }
}
