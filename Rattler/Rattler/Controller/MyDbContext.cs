using Rattler.Models;
using System.Data.Entity;

namespace Rattler.Controller
{
    public class MyDbContext:DbContext
    {
         public MyDbContext():base("RattlerConnection")
        {

        }
        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(new MyDbInitialize());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Trip> Trips { get; set; }

    }
}
