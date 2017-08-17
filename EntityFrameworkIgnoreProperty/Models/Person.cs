using System.Collections.Generic;

namespace EntityFrameworkIgnoreProperty.Models
{
    public class Person : BaseEntity
    {
        public Person()
        {
            this.Events = new HashSet<Event>();
        }

        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}