using System.Data.Entity;

namespace EntityFrameworkIgnoreProperty.Models
{
    public class Context : DbContext
    {
        public Context() : base("data source = (LocalDb)\\MSSQLLocalDB; initial catalog = EFInheritanceTestDb; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public Context(string connection) : base(connection)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Types().Where(p => p.).Configure(o => o.Ignore("State"));
            //modelBuilder.Types<BaseEntity>().Configure(clazz => clazz.Ignore(prop => prop.State));

            modelBuilder.Types<BaseEntity>()
                .Where(t => t.BaseType == typeof(BaseEntity))
                .Configure(clazz => clazz.Ignore(prop => prop.State));
        }
    }
}