using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private const string Cartkey = "ShoppingCart";
        private readonly IProductRepo _productsRepository;
        private readonly IOrderRepo _OrderRepository;

        public CartController(IProductRepo productsRepository, IOrderRepo orderRepository
            ,UserManager<ApplicationUser> userManager)
        {
            _productsRepository = productsRepository;
            _OrderRepository = orderRepository;
            _usermanager = userManager;
        }

        public IActionResult Index()
        {
            var Cartlst = HttpContext.Session.GetObjectFromSession<List<CartItemViewModel>>(Cartkey) ?? new List<CartItemViewModel>();
            return View(Cartlst);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            // getting session's Cart Items
            var Cart = HttpContext.Session.GetObjectFromSession<List<CartItemViewModel>>(Cartkey) ?? new List<CartItemViewModel>();

            // Checking if the product is in the cart
            var existingProduct = Cart.FirstOrDefault(x => x.ProductId == id);
            if (existingProduct != null)
            {
                // exist => increment
                existingProduct.Quantity++;
            }
            else
            {
                // Not Exist => Add the new product to the cart
                Cart.Add(new CartItemViewModel
                {
                    ProductId = id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                });
            }
            // save the last update to cart in session
            HttpContext.Session.SetObjectToSession(Cartkey, Cart);
            return RedirectToAction("Index","Product");
        }
        public IActionResult RemoveFromCart(int ProductId)
        {
            var CartList = HttpContext.Session.GetObjectFromSession<List<CartItemViewModel>>(Cartkey);

            if (CartList != null)
            {
                // Variable Has THe same reference of the CartList Item
                var RemovedItemFromCArtList = CartList.FirstOrDefault(x => x.ProductId == ProductId); 
                if (RemovedItemFromCArtList != null)
                {
                    if(RemovedItemFromCArtList.Quantity > 1)
                    {
                        RemovedItemFromCArtList.Quantity--;
                    }
                    else
                        CartList.Remove(RemovedItemFromCArtList);
                }
                HttpContext.Session.SetObjectToSession(Cartkey, CartList);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CheckOut()
        {
            var CartList=HttpContext.Session.GetObjectFromSession<List<CartItemViewModel>>(Cartkey)?? new List<CartItemViewModel> ();
            return View(CartList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder()
        {
            // Get the User Id From Cookie to assign it to Order Table 
            var ClaimId = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier);
            string UserId = ClaimId.Value;
            var CartList = HttpContext.Session.GetObjectFromSession<List<CartItemViewModel>>(Cartkey);
            if (CartList != null)
            {
                // Decreasing Stock of that Dish in Menu item

                foreach (var item in CartList)
                {
                    var product = await _productsRepository.GetByIdAsync(item.ProductId);
                    if(product == null || product.Stock<0)
                    {
                        TempData["Error"] = $"Sorry {product?.Name} Is Out Of Stock";
                        return RedirectToAction("Index");
                    }
                    if (product.Stock < item.Quantity)
                    {
                        TempData["Error"] = $"Sorry, {product.Name} is out of stock (Only {product.Stock} left).";
                        return RedirectToAction("Index");
                    }
                    product.Stock -= item.Quantity;
                }



                var NewOrder = new Order
                {
                    UserId=UserId,
                    OrderDate = DateTime.Now,
                    TotalAmount = CartList.Sum(x => x.Total),
                    OrderItems = CartList.Select(x => new OrderItem
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Price = x.Price,
                    }).ToList()
                };
                await _OrderRepository.AddAsync(NewOrder);
             
                await _OrderRepository.SaveChangesAsync();
                HttpContext.Session.Remove(Cartkey);

            }
            return RedirectToAction("Orders");

        }


        public async Task<IActionResult> Orders()
        {
            Claim UserClaimId=User.Claims.FirstOrDefault(e=>e.Type== ClaimTypes.NameIdentifier);
            var UserId = UserClaimId.Value;
            // Retrive orders Information For Each USer 
            var orders = await _OrderRepository.GetOrderWithOrderItemsWithProductsAsync(UserId);
            return View(orders);
        }


    }
}
