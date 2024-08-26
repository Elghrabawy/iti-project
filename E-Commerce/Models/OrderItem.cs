﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
	[PrimaryKey("OrderId", "ProductId")]
	public class OrderItem
	{
		[ForeignKey("Order")]
		public int OrderId { get; set; }
		public Order Order { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public Product Product { get; set; }

		public int Quantity { get; set; }

		public decimal Price { get; set; }
	}
}
