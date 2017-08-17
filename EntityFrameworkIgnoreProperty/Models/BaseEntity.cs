using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkIgnoreProperty.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }

        //[Required]
        //[Column(TypeName = "datetime2")]
        //public DateTime Created { get; set; }

        //[Required]
        //[Column(TypeName = "datetime2")]
        //public DateTime Modified { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }

        public State State { get; set; }
    }
}