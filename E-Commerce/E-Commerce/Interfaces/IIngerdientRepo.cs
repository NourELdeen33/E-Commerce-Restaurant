using E_Commerce.Models;

namespace E_Commerce.Interfaces
{
    public interface IIngerdientRepo:IRepository<Ingredient>
    {
        public Task<Ingredient> GetIngredientWithProductsById(int id);
        public Task<Ingredient?> EditAsync(AddIngerdientViewModel ingredient);

    }
}
