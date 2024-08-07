using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animales.Models
{
    public class TipoAnimal
    {
        public TipoAnimal()
        {
            
        }
        public TipoAnimal(int idTipoAnimal, string descripcion)
        {
            IdTipoAnimal = idTipoAnimal;
            Descripcion = descripcion;
        }

        public int IdTipoAnimal { get; set; }
        public string Descripcion { get; set; }
    }
}