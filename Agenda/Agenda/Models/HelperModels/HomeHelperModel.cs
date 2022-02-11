using AgendaDataAccessLayer;

namespace Agenda.Models
{
    public class HomeHelperModel
    {
        public bool IsDone { get; set; } = false;
        public Events Event { get; set; }
    }
}
