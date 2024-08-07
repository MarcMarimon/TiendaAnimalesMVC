using System.Collections.Generic;
using System.Web.Mvc;
using Animales.DAL;
using Animales.Models;

namespace Animales.Controllers
{
    public class AnimalController : Controller
    {
        private AnimalDAL animalDAL = new AnimalDAL();
        private TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();

        public ActionResult Create()
        {
            ViewBag.TipoAnimalId = new SelectList(tipoAnimalDAL.GetAll(), "IdTipoAnimal", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                animalDAL.Insert(animal);
                return RedirectToAction("Index");
            }

            ViewBag.TipoAnimalId = new SelectList(tipoAnimalDAL.GetAll(), "IdTipoAnimal", "Descripcion", animal.RIdTipoAnimal);
            return View(animal);
        }
        public ActionResult Delete(int id)
        {
            animalDAL.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            List<Animal> animales = animalDAL.GetAll();
            return View(animales);
        }
    }
}
