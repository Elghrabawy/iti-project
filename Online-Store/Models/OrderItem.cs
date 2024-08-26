using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
	[PrimaryKey("OrderId", "ProductId")]
	public class OrderItem
	{
		[ForeignKey("Order")]
		public int OrderId { get; set; }
		public virtual Order? Order { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public virtual Product? Product { get; set; }

		public int? Quantity { get; set; }

		public decimal? Price { get; set; }
	}
}
