using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animales.Models
{
    public class Animal
    {
        public Animal()
        {

        }
        public Animal(int id, string name, string raza, int idTipoAnimal, TipoAnimal tipoAnimal, DateTime fechaNacimiento)
        {
            Id = id;
            Name = name;
            Raza = raza;
            RIdTipoAnimal = idTipoAnimal;
            FechaNacimiento = fechaNacimiento;
            TipoAnimal = tipoAnimal;

        }

        public int Id { get; set; }
        public string Name
        {
            get; set;

        }

        public int RIdTipoAnimal { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public TipoAnimal TipoAnimal { get; set; }
    }
}