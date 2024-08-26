using Microsoft.EntityFrameworkCore;

namespace Online_Store.Models
{
	public class StoreContext : DbContext
	{
		public  DbSet<Product> Products { get; set; }
		public  DbSet<Category> Categories { get; set; }
		public  DbSet<Cart> Carts { get; set; }
		public  DbSet<CartItem> CartItems { get; set; }
		public  DbSet<Order> Orders { get; set; }
		public  DbSet<OrderItem> OrderItems { get; set; }
		public  DbSet<OrderState> OrderStates { get; set; }
		public  DbSet<User> Users { get; set; }
		public  DbSet<Role> Roles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=EBRAHIMMOHMED;Database=Store;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
		}
	}
}
