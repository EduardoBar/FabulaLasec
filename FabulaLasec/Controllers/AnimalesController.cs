using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FabulaLasec.Models;
using FabulaLasec.Models.ViewModels;
using FabulaLasec.Models.EntityManager;

namespace FabulaLasec.Controllers
{
    public class AnimalesController : Controller
    {
        Pista p;
        AnimalesManager AM = new AnimalesManager();
        // GET: Animales
        public ActionResult Index()
        {
            AnimalViewModel avm = new AnimalViewModel();
            avm.listaAnimales = new List<Animal>();
            avm.listaAnimales = AM.getListaCarreras();
           
            return View(avm);
        }

        [HttpPost]
        public async Task<ActionResult> ComenzarCarrera(CarreraComenzar carr)
        {
            List<Animal> listaAnimales = new List<Animal>();

            p = new Pista(10, 10, 10, carr.Animal1,carr.Animal2); // Se presentan los animales a la pista (Se conocen)

            var a1 = correrAnimal1(carr.Animal1);
            var a2 = correrAnimal2(carr.Animal2);

            await Task.WhenAll(a1, a2); //Correr de forma paralela

            listaAnimales.Add(a1.Result);
            listaAnimales.Add(a2.Result);

            if (listaAnimales[0].tiempoDeRecorrido < listaAnimales[1].tiempoDeRecorrido)
            {
                listaAnimales[0].Resultado = "Ganador!!!!";
                listaAnimales[1].Resultado = "Perdedor!!!!";
            }
            else
            {
                listaAnimales[0].Resultado = "Perdedor!!!!";
                listaAnimales[1].Resultado = "Gaanador!!!!";
            }

            AM.insertarCarreraAnimal(carr);

            listaAnimales = AM.getListaCarreras();

            return PartialView("_ListaAnimalesPartialView",listaAnimales);
        }


        public async Task<Animal> correrAnimal1(Animal animal)
        {
            return await  Task.Run(() =>
            {
                for (int x = 0; x < p.metros1; x++)
                {
                    Thread.Sleep(1000);
                    p.metros1 = p.metros1 - animal.Velocidad;

                    animal.tiempoDeRecorrido++;

                    if ((p.metros1 < p.metros2) && p.Animal2.Nombre.Equals("Tortuga")) //SI EL OTRO ANIMAL ES UNA TORTUGA, ME DUERMO
                    {
                        Thread.Sleep(5000);
                        animal.tiempoDeRecorrido += 10;
                    }

                }

            
               return animal;
            });

        }


        public async Task<Animal> correrAnimal2(Animal animal)
        {

            return await Task.Run( ()=>
            {
                for (int x = 0; x < p.metros2; x++)
                {
                    Thread.Sleep(1000);
                    p.metros2 = p.metros2 - animal.Velocidad;

                    animal.tiempoDeRecorrido++;

                    if((p.metros2 < p.metros1) && p.Animal1.Nombre.Equals("Tortuga")) //SI EL OTRO ANIMAL ES UNA TORTUGA, ME DUERMO
                    {
                        Thread.Sleep(10000);
                        animal.tiempoDeRecorrido += 10;
                    }

                }
                return animal;
            });
        }


        // GET: Animales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Animales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animales/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Animales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
