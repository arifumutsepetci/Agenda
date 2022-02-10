using AgendaDataAccessLayer;

namespace Agenda
{
    public class AddEventModel : BaseModel
    {
        public AddEventModel()
        {
            Event = new();
            EventUrgencyList = DbContext.GetEventUrgencyList();
        }

        public Events Event { get; set; }
        public List<EventUrgency> EventUrgencyList { get; set; }
    }
}
