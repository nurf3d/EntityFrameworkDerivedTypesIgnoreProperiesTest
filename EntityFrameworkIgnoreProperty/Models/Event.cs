using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkIgnoreProperty.Models
{
    [Table("Events")]
    public abstract class Event : BaseEntity
    {
        public int PersonID { get; set; }

        public string EventName { get; set; }

        public virtual Person Person { get; set; }
    }
}