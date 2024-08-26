using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace E_Commerce.Models
{
	public class User
	{
		[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? UserId { get; set; }

		[Required]
		public string? Username { get; set; }

		[Required]
		public string? Email { get; set; }

		[Required]
		public string? Password { get; set; }

		[Required(ErrorMessage = "First Name is Required")]
		public string? FirstName { get; set; }

		public string? LastName { get; set; }


		public string? City { get; set; }

		public string? State { get; set; }

		public string? Zip { get; set; }

		[Required]
		public string? Phone { get; set; }

		[DefaultValue("DateTime.Now()")]
		DateTime? DateCreated { get; set; }

		//[Required]
		[ForeignKey("Role")]
		[DisplayName("Role")]
		public int? RoleId { get; set; }
		
		[AllowNull]
		public virtual Role? Role { get; set; }

		[AllowNull]
		public virtual List<Cart>? Carts { get; set; }
		
		[AllowNull]
		public virtual List<Order>? Orders { get; set; }
	}
}
