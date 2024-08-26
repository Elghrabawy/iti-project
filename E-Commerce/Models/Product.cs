using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
	public class Product
	{
		[Key]
		[Required]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductId { get; set; }

		[Required]
		[StringLength(50)]
		public string ProductName { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		[DefaultValue(0)]
		public int Quantity { get; set; }

		[Required]
		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		Category Category { get; set; }

		public List<OrderItem> OrderItems { get; set; }

		public List<CartItem> CartItems { get; set; }

		string ImageURL { get; set; }
	}
}
