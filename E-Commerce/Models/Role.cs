using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
	public class Role
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RoleId { get; set; }

		[Required]
		[StringLength(50)]
		public string RoleName { get; set; }

		public List<User> Users { get; set; }
	}
}
