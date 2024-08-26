using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Online_Store.CustomAttributes;

namespace Online_Store.Models
{
	public class User
	{
		[Key]
		[Required]
		public int UserId { get; set; }

		[Required]
		[StringLength(50)]
		//[UniqueUserUsername(ErrorMessage = "This username is used")]
		public string? Username { get; set; }

		[Required]
		public string? Email { get; set; }

		[Required]
		public string? Password { get; set; }

		[Required]
		public string? FirstName { get; set; }

		public string? LastName { get; set; }


		public string? City { get; set; }

		public string? State { get; set; }

		public string? Zip { get; set; }

		[Required]
		public string? Phone { get; set; }

		[DefaultValue("DateTime.Now()")]
		public DateTime? DateCreated { get; set; } = DateTime.Now;

		[Required]
		[ForeignKey("Role")]
		[DefaultValue(2)]
		public int? RoleId { get; set; }

		public Role? Role { get; set; }

		public virtual List<Cart>? Carts { get; set; }
		public virtual List<Order>? Orders { get; set; }
	}
}
