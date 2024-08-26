using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
	public class CartItem
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CartItemId { get; set; }

		[ForeignKey("Cart")]
		public int CartId { get; set; }
		public Cart Cart { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public Product Product { get; set; }

		[Required]
		[MaxLength(100)]
		[DefaultValue(1)]
		public int Quantity { get; set; }

	}
}
