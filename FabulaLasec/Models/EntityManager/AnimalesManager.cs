using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FabulaLasec.Models.ViewModels;
using FabulaLasec.Models;

namespace FabulaLasec.Models.EntityManager
{
    public class AnimalesManager
    {
        public List<Animal> getListaCarreras()
        {
            AnimalViewModel avm = new AnimalViewModel();

            using (FabulaEntities db = new FabulaEntities())
            {
                avm.listaAnimales = (from a in db.Animales
                         
                                  select new Animal
                                  {
                                      Nombre = a.Nombre,
                                      Velocidad = a.Velocidad,
                                      tiempoDeRecorrido = (int)a.TiempoRecorrido,
                                      Resultado = a.Resultado,
                                      idCarrera = a.idCarrera
                                  }


                    ).ToList();
            }
            return avm.listaAnimales;
        }


        public void insertarCarreraAnimal(Models.CarreraComenzar carrera)
        {

            using (FabulaEntities db = new FabulaEntities())
            {

                    Carrera carr = new Carrera();

                    carr.FechaHoraCarrera = DateTime.Now;

                    db.Carrera.Add(carr);
                    db.SaveChanges();

                FabulaLasec.Animales anim1 = new FabulaLasec.Animales();

                anim1.Nombre = carrera.Animal1.Nombre;
                anim1.Velocidad = carrera.Animal1.Velocidad;
                anim1.TiempoRecorrido = carrera.Animal1.tiempoDeRecorrido;
                anim1.Resultado = carrera.Animal1.Resultado;
                anim1.idCarrera = carr.idCarrera;

                db.Animales.Add(anim1);
                db.SaveChanges();

                FabulaLasec.Animales anim2 = new FabulaLasec.Animales();

                anim2.Nombre = carrera.Animal2.Nombre;
                anim2.Velocidad = carrera.Animal2.Velocidad;
                anim2.TiempoRecorrido = carrera.Animal2.tiempoDeRecorrido;
                anim2.Resultado = carrera.Animal2.Resultado;
                anim2.idCarrera = carr.idCarrera;

                db.Animales.Add(anim2);
                db.SaveChanges();

            }

        }
        
    }
    
}   
