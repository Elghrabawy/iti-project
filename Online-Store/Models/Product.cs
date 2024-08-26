using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		[Required]
		[StringLength(50)]
		public string? ProductName { get; set; }

		public string? Description { get; set; }

		[Required]
		public decimal? Price { get; set; }

		[Required]
		[DefaultValue(1)]
		[Range(0, int.MaxValue, ErrorMessage ="Quantity must be positive")]
		public int? Quantity { get; set; }

		[ForeignKey("Category")]
		[Required]
		public int? CategoryId { get; set; }

		public virtual Category? Category { get; set; }

		public virtual List<OrderItem>? OrderItems { get; set; }

		public virtual List<CartItem>? CartItems { get; set; }

		public string? ImageUrl { get; set; }

		//[NotMapped]
		//public IFormFile? ImageFile { get; set; }
	}
}
