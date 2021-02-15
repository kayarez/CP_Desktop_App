using System.Data.Entity;

namespace Rattler.Controller
{
     class MyDbInitialize: DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.SaveChanges();
        }
    }
}
