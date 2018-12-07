using System.ComponentModel.DataAnnotations;

namespace Domain.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
