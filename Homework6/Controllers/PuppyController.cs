using Homework4.Data;
using Homework6.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Puppies.Model;

namespace Homework4.Controllers
{
    public class PuppyController : Controller
    {
        //private readonly PizzaDeliveryDbContext _pizzaDeliveryDbContext;

        //public PuppyController(PizzaDeliveryDbContext pizzaDeliveryDbContext)
        //{
        //    _pizzaDeliveryDbContext = pizzaDeliveryDbContext;
        //}

        internal async Task<SelectList> GetBreadSelectList()
        {
            return new SelectList(await BreedService.GetAllAsync(), nameof(Breed.Id), nameof(Breed.Name));
        }

        private IPuppyService PuppyService { get; }
        private IBreedService BreedService { get; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var puppies = await PuppyService.GetAllAsync();
            return View(puppies);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Breeds = await GetBreadSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Puppy addPuppyRequest)
        {
            //var puppy = new Puppy()
            //{
            //    Name = addPuppyRequest.Name,
            //    Gender = addPuppyRequest.Gender,
            //    Age = addPuppyRequest.Age,
            //    Weight = addPuppyRequest.Weight,
            //    Height = addPuppyRequest.Height,
            //    FurColor = addPuppyRequest.FurColor,
            //    BreedId = addPuppyRequest.Breed.Id
            //};

            if (ModelState.IsValid)
            {
                await PuppyService.AddAsync(addPuppyRequest);
                return RedirectToAction("Index");
            }
            ViewBag.Breeds = await GetBreadSelectList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var puppy = await PuppyService.FindAsync(id);

            if (puppy == null) return RedirectToAction("Index");

            ViewBag.Breeds = await GetBreadSelectList();
            return await Task.Run(() => View("View", puppy));
        }

        [HttpPost]
        public async Task<ActionResult> View(Puppy editedPuppy)
        {
            var puppy = await PuppyService.FindAsync(editedPuppy.Id);

            if (puppy == null) return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                await PuppyService.UpdateAsync(puppy);
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
