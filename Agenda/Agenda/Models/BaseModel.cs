using Microsoft.EntityFrameworkCore;
using AgendaDataAccessLayer;
using System.Configuration;

namespace Agenda
{
    public class BaseModel
    {
        private AgendaContext _dbContext;
        internal AgendaContext DbContext
        {
            get
            {
                if (_dbContext == default(AgendaContext))
                    _dbContext = new AgendaContext();
                return _dbContext;
            }
        }
    }
}
