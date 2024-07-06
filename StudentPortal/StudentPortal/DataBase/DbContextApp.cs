using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Entites;

namespace StudentPortal.DataBase
{
    public class DbContextApp : DbContext

    {
        public DbContextApp(DbContextOptions<DbContextApp>options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
