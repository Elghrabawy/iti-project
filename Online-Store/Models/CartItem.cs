using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
	public class CartItem
	{
		[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CartItemId { get; set; }

		[ForeignKey("Cart")]
		public int? CartId { get; set; }
		public virtual Cart? Cart { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public virtual Product? Product { get; set; }

		[Required]
		[MaxLength(100)]
		[DefaultValue(1)]
		public int? Quantity { get; set; }

	}
}
