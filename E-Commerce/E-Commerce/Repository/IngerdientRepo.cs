



using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository
{
    public class IngerdientRepo : Repository<Ingredient>, IIngerdientRepo
    {
        private readonly AppDbContext _context;

        public IngerdientRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Ingredient?> EditAsync(AddIngerdientViewModel ingredientViewModel)
        {
            var ingerdient = await _context.Ingredients.FirstOrDefaultAsync(x => x.Id == ingredientViewModel.Id);
            if (ingerdient == null)
                return null;
            ingerdient.Name = ingredientViewModel.Name;
            var effectedrows = await _context.SaveChangesAsync();
            if (effectedrows > 0)
            {
                return ingerdient;
            }
            else
                return null;

        }

        public async Task<Ingredient> GetIngredientWithProductsById(int id)
        {
            var ingerdientwithdishesList = await _context.
                Ingredients
                .AsNoTracking()
                .Include(x => x.ProductIngerdients)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            return ingerdientwithdishesList;
        }
    }
}
