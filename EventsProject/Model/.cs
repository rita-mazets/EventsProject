using Microsoft.EntityFrameworkCore;

namespace EventsProject.Model
{
    public class PersonContext:DbContext
    {
        public DbSet<User> People { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
            Database.EnsureCreated();

            if (!this.People.Any())
            {
                var people = new List<User>
                {
                    new User{ Name = "tom", Password = "12345" },
                    new User{ Name = "bob", Password = "55555" }
                };

                this.People.AddRange(people);
                this.SaveChanges();
            }           
        }
    }
}
