using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public User User { get; set; }

		public List<OrderItem> OrderItems { get; set; }

		[DefaultValue("DateTime.Now()")]
		public DateTime OrderDate { get; set; }

		// make dafult defalut value attribute
		public decimal Total { get; set; }

		[DefaultValue("Pending")]
		public string Status { get; set; }
	}
}
