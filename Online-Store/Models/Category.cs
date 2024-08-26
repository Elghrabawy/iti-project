using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
	public class Category
	{
		//[Key]
		public int CategoryId { get; set; }

		[StringLength(50)]
		public string? CategoryName { get; set; }

		public string? Description { get; set; }

		public virtual List<Product>? Products { get; set; }
	}
}
