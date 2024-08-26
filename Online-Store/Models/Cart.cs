using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
	public class Cart
	{
		[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CartId { get; set; }

		[ForeignKey("User")]
		public int? UserId { get; set; }
		public virtual User? User { get; set; }

		public virtual List<CartItem>? CartItems { get; set; }
	}
}
