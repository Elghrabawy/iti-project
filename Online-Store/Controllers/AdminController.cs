using Microsoft.AspNetCore.Mvc;
using Online_Store.Models;
using Online_Store.ViewModels;

namespace Online_Store.Controllers
{
    public class AdminController : Controller
    {
        StoreContext db = new StoreContext();
        private readonly IWebHostEnvironment _hostingEnvironment;

		public AdminController(IWebHostEnvironment hostingEnvironment)
        {
            
            _hostingEnvironment = hostingEnvironment;
		}

		public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            return View();
        }
        public IActionResult UserForm()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        public IActionResult UserForm(User user)
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

           if (ModelState.IsValid)
            {
                var db = new StoreContext();
                db.Users.Add(user);
                db.SaveChanges();
            }
            
            return RedirectToAction("UserForm");
        }

        public IActionResult UserTable()
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpGet]
        public IActionResult UserEdit(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            User user = db.Users.FirstOrDefault(u => u.UserId == id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult UserEdit(User user)
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            var currentUser = db.Users.Find(user.UserId);
            
            if(user.FirstName != null) currentUser.FirstName = user.FirstName;
            if(user.LastName != null) currentUser.LastName = user.LastName;
            if(user.Email != null) currentUser.Email = user.Email;
            if(user.City != null) currentUser.City = user.City;
            if(user.State != null) currentUser.State = user.State;
            if(user.Phone != null) currentUser.Phone = user.Phone;
            if (user.Zip != null) currentUser.Zip = user.Zip;

            db.SaveChanges();

            return RedirectToAction("UserTable");
        }

        public IActionResult UserDelete(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            User user = db.Users.FirstOrDefault(u => u.UserId == id);
            if(user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserTable");
        }

        public IActionResult ProductForm()
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        public IActionResult ProductForm(ProductVM productVM)
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
	        {

                string folder = "Products/Images";
                string serverFolder = _hostingEnvironment.WebRootPath;
                string filename;
                if(productVM.ImageFile != null)
                {
                    filename = Guid.NewGuid().ToString() + productVM.ImageFile.FileName;
                    var fs = new FileStream(Path.Combine(serverFolder, folder, filename), FileMode.Create);
                    productVM.ImageFile.CopyTo(fs);
                }
                else
                {
                    filename = "default.png";
                }


                Product product = new Product()
                {
                    ProductName = productVM.ProductName,
                    Description = productVM.Description,
                    Price = productVM.Price,
                    Quantity = productVM.Quantity,
                    CategoryId = productVM.CategoryId,
                };
                product.ImageUrl = folder + "/" + filename;

			    var db = new StoreContext();
			    db.Products.Add(product);
			    db.SaveChanges();
		    }
		    return RedirectToAction("productform");
        }

        public IActionResult ProductTable()
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult ProductDelete(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            Product product = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            string serverFolder = _hostingEnvironment.WebRootPath;
            string localPath = product.ImageUrl;

            db.Products.Remove(product);
            db.SaveChanges();

            //var fs = new FileStream(Path.Combine(serverFolder, localPath), FileMode.Create);


            //if(System.IO.File.Exists(fs.Name))
            //{
            //    System.IO.File.Delete(fs.Name);
            //}

            return RedirectToAction("ProductTable");
        }

        public IActionResult ProductEdit(int id)
		{
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            Product product = db.Products.FirstOrDefault(p => p.ProductId == id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

        [HttpPost]
        public IActionResult ProductEdit(Product product)
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == null) return RedirectToAction("Login", "Auth");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            
            var currentProduct = db.Products.Find(product.ProductId);

			if (product.ProductName != null) currentProduct.ProductName = product.ProductName;
			if (product.Description != null) currentProduct.Description = product.Description;
			if (product.Price != null) currentProduct.Price = product.Price;
			if (product.Quantity != null) currentProduct.Quantity = product.Quantity;
			if (product.CategoryId != null) currentProduct.CategoryId = product.CategoryId;

			db.SaveChanges();

			return RedirectToAction("ProductTable");
		}
	}
}
