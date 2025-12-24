using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Interfaces
{
    public interface IProductRepo : IRepository<Product>
    {
        public IEnumerable<SelectListItem> LoadCategories();
        public IEnumerable<Ingredient> LoadIngerdients();
        public Task CreateAsync(AddProductViewModel Product);

        public Task<Product> GetProductWithIngerdients(int id);

        public Task<Product?> EditAsync(EditProdcutViewModel Product);
    }
}
