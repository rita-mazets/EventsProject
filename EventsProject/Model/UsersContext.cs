using Microsoft.EntityFrameworkCore;

namespace EventsProject.Model
{
    public class UsersContext : DbContext
    {
        public DbSet<User> ProfUsers { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureCreated();

            if (!this.ProfUsers.Any())
            {
                this.ProfUsers.Add(new User { Name = "tom", Surame = "Smit", Email = "tom@mail.ru", Password = "12345" });
                this.ProfUsers.Add(new User { Name = "bob", Surame = "Dwer", Email = "bob@mail.ru", Password = "55555" });

                this.SaveChanges();
            }
        }
    }
}
