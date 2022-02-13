using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AgendaDataAccessLayer
{
    public partial class AgendaContext : DbContext
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=Agenda;Integrated Security=True";
        public DbSet<Events> Events { get; set; }
        public DbSet<EventUrgency> EventUrgency { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public AgendaContext()
        {

        }
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }
    }
}
