using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngerdientRepo _Ingerdientrepository;

        public IngredientController(IIngerdientRepo ingerdientrepository)
        {
            _Ingerdientrepository = ingerdientrepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _Ingerdientrepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var ingerdientDet = await _Ingerdientrepository.GetIngredientWithProductsById(id);
            return View(ingerdientDet);
        }





        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddIngerdientViewModel model)
        {
            var entity = new Ingredient
            {
                Name = model.Name

            };
            await _Ingerdientrepository.AddAsync(entity);
            await _Ingerdientrepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Ingerdient = await _Ingerdientrepository.GetByIdAsync(id);
            var ingerdientviewmodel = new AddIngerdientViewModel { Name = Ingerdient.Name };
            return View(ingerdientviewmodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddIngerdientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updatedingerdient = await _Ingerdientrepository.EditAsync(model);
            _Ingerdientrepository.Update(updatedingerdient);
            return RedirectToAction(nameof(Index));
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _Ingerdientrepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
