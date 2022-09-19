using Microsoft.EntityFrameworkCore;

namespace EventsProject.Model
{
    public class EventsContext: DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        {
            Database.EnsureCreated();

            if (!this.Events.Any())
            {

                var e1 = new Event { Name = "N1", Topic = "t1", Discription = "d1", Plan = "p1", DateTime = new DateTime(2022, 11, 10, 11, 0, 0), Place = "p1", Organizer = "o1", Speaker = "name1 surname1" };
                var e2 = new Event { Name = "N2", Topic = "t2", Discription = "d2", Plan = "p2", DateTime = new DateTime(2022, 10, 1, 12, 0, 0), Place = "p2", Organizer = "o2", Speaker = "name2 surname2" };
                this.Events.AddRange(e1, e2);
            }

            if (!this.Users.Any())
            {
                this.Users.Add(new User { Name = "tom", Surame = "Smit", Email = "tom@mail.ru", Password = "12345" });
                this.Users.Add(new User { Name = "bob", Surame = "Dwer", Email = "bob@mail.ru", Password = "55555" });
            }

            this.SaveChanges();
        }
    }
}
