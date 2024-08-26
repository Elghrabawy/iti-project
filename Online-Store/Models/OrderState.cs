using System.ComponentModel.DataAnnotations;

namespace Online_Store.Models
{
    public class OrderState
    {
        [Key]
        public int OrderStateId { get; set; }

        public virtual string? State { get; set; }
    }
}
