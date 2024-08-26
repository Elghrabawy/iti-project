using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
	public class Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }

		[Required]
		[StringLength(50)]
		public string CategoryName { get; set; }

		[Required]
		public string Description { get; set; }

		public List<Product> Products { get; set; }
	}
}
