using Microsoft.EntityFrameworkCore;
using PruebaToDoList.Shared.Enties;

namespace PruebaToDoList.Server.DataBase
{
    public class DataContext : DbContext
    {
#nullable disable
        public DbSet<Goal> Goals { get; set; }
        public DbSet<TaskGoal> Tasks { get; set; }
#nullable enable

        public DataContext(DbContextOptions options)
            :base(options) 
        {
                
        }
    }
}
