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
                {
                    var optionsBuilder = new DbContextOptionsBuilder<AgendaContext>();
                    optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Agenda;Integrated Security=True");
                    _dbContext = new AgendaContext(optionsBuilder.Options);
                }
                return _dbContext;
            }
        }
    }
}
