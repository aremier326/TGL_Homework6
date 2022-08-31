using Homework6.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Puppies.Model;

namespace Homework4.Controllers
{
    public class PuppyController : Controller
    {
        private IPuppyService PuppyService { get; }
        private IBreedService BreedService { get; }

        public PuppyController(IPuppyService puppyService, IBreedService breedService)
        {
            PuppyService = puppyService;
            BreedService = breedService;
        }

        internal async Task<SelectList> GetBreedSelectList()
        {
            return new SelectList(await BreedService.GetAllAsync(), nameof(Breed.Id), nameof(Breed.Name));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var puppies = await PuppyService.GetAllAsync();
            return View(puppies);

        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Breeds = await GetBreedSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Puppy addPuppyRequest)
        {   
            ModelState.Remove("Breed");

            if (!ModelState.IsValid)
            {
                ViewBag.Breeds = await GetBreedSelectList();
                return View();
            }

            addPuppyRequest.Breed = await BreedService.FindAsync(addPuppyRequest.BreedId);

            await PuppyService.AddAsync(addPuppyRequest);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var puppy = await PuppyService.FindAsync(id);

            if (puppy == null) return RedirectToAction("Index");

            ViewBag.Breeds = await GetBreedSelectList();
            return await Task.Run(() => View("View", puppy));
        }

        [HttpPost]
        public async Task<ActionResult> View(Puppy editedPuppy)
        {
            if (await PuppyService.FindAsync(editedPuppy.Id) == null) return RedirectToAction("Index");

            ModelState.Remove("Breed");

            if (ModelState.IsValid)
            {
                editedPuppy.Breed = await BreedService.FindAsync(editedPuppy.BreedId);
                await PuppyService.UpdateAsync(editedPuppy);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Puppy editedPuppy)
        {
            var puppy = await PuppyService.FindAsync(editedPuppy.Id);

            if (puppy != null)
            {
                await PuppyService.RemoveAsync(puppy);
            }
            return RedirectToAction("Index");
        }
    }
}
