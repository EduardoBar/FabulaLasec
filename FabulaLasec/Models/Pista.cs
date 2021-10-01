using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FabulaLasec.Models;

namespace FabulaLasec.Models
{
    public class Pista
    {
        List<Animal> listaAnimales { get; set; }

       public int LongitudPista { get; set; }

       public int metros1 { get; set; }

       public int metros2 { get; set; }


      public Animal Animal1 { get; set; }

      public Animal Animal2 { get; set; }



        public Pista()
        {

        }

        public Pista(int metros1, int metros2, int longitudPista)
        {
            this.metros1 = metros1;
            this.metros2 = metros2;
            
            this.LongitudPista = longitudPista;

        }


        public Pista(int metros1, int metros2, int longitudPista, Animal a1, Animal a2)
        {
            this.metros1 = metros1;
            this.metros2 = metros2;
            this.Animal1 = a1;
            this.Animal2 = a2;
            this.LongitudPista = longitudPista;
        }


    }
}