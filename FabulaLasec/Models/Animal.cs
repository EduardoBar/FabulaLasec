using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FabulaLasec.Models
{
    public class Animal
    {
        public string Nombre { get; set; }
        public int Velocidad { get; set; }
        public int porcentajeRecorrido { get; set; }    
        
        public int tiempoDeRecorrido { get; set; }

        public string Resultado { get; set; }

        public long idCarrera { get; set; }

    }
}