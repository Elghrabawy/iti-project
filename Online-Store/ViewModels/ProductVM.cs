using Online_Store.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.ViewModels
{
	public class ProductVM
	{
		public int? ProductId { get; set; }

		[Required]
		[StringLength(50)]
		public string? ProductName { get; set; }
		
		public string? Description { get; set; }
		
		[Required]
		public decimal? Price { get; set; }

		[Required]
		[DefaultValue(1)]
		[Range(0, int.MaxValue, ErrorMessage = "Quantity must be positive")]
		public int? Quantity { get; set; }

		[Required]
		public int? CategoryId { get; set; }

		public string? CategoryName { get; set; }
		
		public IFormFile? ImageFile { get; set; }
	}
}
