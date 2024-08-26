using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public virtual User? User { get; set; }

		public virtual List<OrderItem>? OrderItems { get; set; }

		[DefaultValue("DateTime.Now()")]
		public DateTime? OrderDate { get; set; }

		// make dafult defalut value attribute
		public decimal? Total { get; set; }

		public int? StateId { get; set; }
		public virtual OrderState? State { get; set; }
	}
}
