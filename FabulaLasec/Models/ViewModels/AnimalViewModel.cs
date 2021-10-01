using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FabulaLasec.Models;

namespace FabulaLasec.Models.ViewModels
{
    public class AnimalViewModel
    {
        public List<Animal> listaAnimales { get; set; }
       public CarreraComenzar Carr { get; set; }
    }
}