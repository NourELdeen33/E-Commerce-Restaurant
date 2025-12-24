
using E_Commerce.Interfaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductRepo(AppDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;

        }

        public IEnumerable<SelectListItem> LoadCategories()
        {
            var categoryList = _context.Categories
                .AsNoTracking()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            return categoryList;

        }


        public async Task CreateAsync(AddProductViewModel ProductViewModel)
        {
            var GeneratedPath = await CreatePhoto(ProductViewModel.ProductImage);


            var product = new Product
            {
                Name = ProductViewModel.Name,
                Description = ProductViewModel.Description,
                Price = ProductViewModel.Price,
                Stock = ProductViewModel.Stock,
                CategoryId = ProductViewModel.CategoryId,
                ImageUrl = GeneratedPath,
                /*  adding in productIngerdeint Table */
                ProductIngerdients = ProductViewModel.IngerdientsId.Select(x => new ProductIngerdient
                {
                    Ingerdient_Id = x
                }).ToList()
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();


        
            await _context.SaveChangesAsync();

        }

        public async Task<Product> GetProductWithIngerdients(int id)
        {
            var product = await _context.Products.AsNoTracking()
                .Include(x => x.ProductIngerdients)
                .ThenInclude(x => x.Ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);

            return product;

        }

        public IEnumerable<Ingredient> LoadIngerdients()
        {
            var ingerdients = _context
                .Ingredients.
                ToList();
            return ingerdients;
        }

        public async Task<Product?> EditAsync(EditProdcutViewModel ProductViewModel)
        {
            var productFromDB = await _context.Products
                .Include(x => x.ProductIngerdients)
                .FirstOrDefaultAsync(x => x.Id == ProductViewModel.Id);

            if (productFromDB == null) return null;

            var oldPhotoName = productFromDB.ImageUrl;
            var hasNewImage = ProductViewModel.ProductImage is not null;


            productFromDB.Name = ProductViewModel.Name;
            productFromDB.Description = ProductViewModel.Description;
            productFromDB.Price = ProductViewModel.Price;
            productFromDB.Stock = ProductViewModel.Stock;
            productFromDB.CategoryId = ProductViewModel.CategoryId;

            if (hasNewImage)
            {
                productFromDB.ImageUrl = await CreatePhoto(ProductViewModel.ProductImage!);
            }


            var existingIngredients = _context.ProductIngerdients.Where(x => x.Product_Id == productFromDB.Id);
            _context.ProductIngerdients.RemoveRange(existingIngredients);

            if (ProductViewModel.IngerdientsId != null && ProductViewModel.IngerdientsId.Length > 0)
            {
                var editIngerdientList = ProductViewModel.IngerdientsId
                    .Select(x => new ProductIngerdient { Product_Id = productFromDB.Id, Ingerdient_Id = x });
                await _context.ProductIngerdients.AddRangeAsync(editIngerdientList);
            }



            try
            {
                await _context.SaveChangesAsync();

                if (hasNewImage)
                {
                    var oldPath = Path.Combine($"{_webHostEnvironment.WebRootPath}/images", oldPhotoName);
                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }

                return productFromDB;
            }
            catch (Exception)
            {
                if (hasNewImage)
                {
                    var newPath = Path.Combine($"{_webHostEnvironment.WebRootPath}/images", productFromDB.ImageUrl);
                    if (File.Exists(newPath))
                        File.Delete(newPath);
                }
                return null;
            }
        }


        private async Task<string> CreatePhoto(IFormFile model)
        {
            var GeneratedName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.FileName)}";
            var path = Path.Combine($"{_webHostEnvironment.WebRootPath}/images", GeneratedName);
            using var stream = File.Create(path);
            await model.CopyToAsync(stream);
            return GeneratedName;
        }
    }
}
