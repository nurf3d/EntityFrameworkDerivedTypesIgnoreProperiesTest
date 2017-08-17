namespace EntityFrameworkIgnoreProperty.Migrations
{
    using EntityFrameworkIgnoreProperty.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkIgnoreProperty.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameworkIgnoreProperty.Models.Context context)
        {
            var person = new Person() { Name = "Person1" };
            person.Events.Add(new DerivedEvent1() { EventName = "Derived1", IsDerivedEvent1 = true });
            person.Events.Add(new DerivedEvent2() { EventName = "Derived1", IsDerivedEvent2 = true });

            context.People.AddOrUpdate(person);
        }
    }
}