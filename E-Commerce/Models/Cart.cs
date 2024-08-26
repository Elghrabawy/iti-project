using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
	public class Cart
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CartId { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public User User { get; set; }

		public List<CartItem> CartItems { get; set; }
	}
}
