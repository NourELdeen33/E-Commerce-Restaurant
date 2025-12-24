
using E_Commerce.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductRepo _productsRepository;



        public ProductController(IProductRepo productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> Index(string searchDish)
        {
            var allLst = await _productsRepository.GetAllAsync();
            if(!string.IsNullOrEmpty(searchDish))
            {
                allLst = allLst.Where(x => x.Name.Contains(searchDish,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View("Index", allLst);
        }


        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _productsRepository.GetProductWithIngerdients(id);
            if (product is not null)
                return View("ProductDetails", product);
            else
                return NotFound();
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LoadCategories = _productsRepository.LoadCategories();
            ViewBag.LoadIngerdients = _productsRepository.LoadIngerdients();
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddProductViewModel product)
        {
            if (ModelState.IsValid)
            {

                await _productsRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.LoadCategories = _productsRepository.LoadCategories();
            ViewBag.LoadIngerdients = _productsRepository.LoadIngerdients();
            return View(product);


        }

        
        public IActionResult Delete(int id)
        {
            try
            {
                _productsRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
                
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Product=await _productsRepository.GetProductWithIngerdients(id);
            var EditViewModel = new EditProdcutViewModel
            {
                Id = id,
                Name = Product.Name,
                Description = Product.Description,
                CategoryId = Product.CategoryId,
                Price = Product.Price,
                Stock = Product.Stock,
                CurrentImage=Product.ImageUrl,
                IngerdientsId=Product.ProductIngerdients.Select(x=>x.Ingerdient_Id).ToArray(),

            };
            ViewBag.LoadCategories = _productsRepository.LoadCategories();
            ViewBag.LoadIngerdients = _productsRepository.LoadIngerdients();
            if (Product != null)
            {
                return View(EditViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task <IActionResult> Edit(EditProdcutViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.LoadCategories = _productsRepository.LoadCategories();
                ViewBag.LoadIngerdients = _productsRepository.LoadIngerdients();
                return View(model);
            }
            var UpdatedProduct=await _productsRepository.EditAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
    
}
