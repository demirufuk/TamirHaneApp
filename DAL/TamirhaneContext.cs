using Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TamirhaneContext:DbContext
    {
        public TamirhaneContext(): base("TamirhaneDbContext")
        {
            //Database.SetInitializer(new TamirhaneDBInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
