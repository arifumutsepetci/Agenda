using Agenda.Models;
using AgendaDataAccessLayer;

namespace Agenda
{
    public class HomeIndexModel
    {
        public HomeIndexModel(List<Events> events, List<EventUrgency> eventUrgencies, bool? isSuccessful = null, bool? isDone = null)
        {
            List<HomeHelperModel> list = new List<HomeHelperModel>();
            foreach (var item in events)
                list.Add(new HomeHelperModel { Event = item, IsDone = false });

            EventList = list;
            UrgencyList = eventUrgencies;
            IsAddingSuccessful = isSuccessful;
            IsMarkAsDoneSuccessful = isDone;
        }
        public HomeIndexModel()
        {

        }

        public List<HomeHelperModel> EventList { get; set; }
        public List<EventUrgency> UrgencyList { get; set; }
        public bool? IsAddingSuccessful { get; set; } = null;
        public bool? IsMarkAsDoneSuccessful { get; set; } = null;
    }
}
