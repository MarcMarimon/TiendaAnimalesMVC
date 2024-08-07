using Animales.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Animales.DAL
{
    public class AnimalDAL
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Animal> GetAll()
        {
            List<Animal> animales = new List<Animal>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT a.IdAnimal, a.NombreAnimal, a.Raza, a.FechaNacimiento, a.RIdTipoAnimal, t.TipoDescripcion FROM Animal a JOIN TipoAnimal t ON a.RIdTipoAnimal = t.IdTipoAnimal", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Animal animal = new Animal();

                        animal.Id = Convert.ToInt32(rdr["IdAnimal"]);
                        animal.Name = rdr["NombreAnimal"].ToString();
                        animal.Raza = rdr["Raza"].ToString();
                        animal.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                        animal.RIdTipoAnimal = Convert.ToInt32(rdr["RIdTipoAnimal"]);
                        animal.TipoAnimal = new TipoAnimal
                        {
                            IdTipoAnimal = animal.RIdTipoAnimal, 
                            Descripcion = rdr["TipoDescripcion"].ToString()
                        };


                        animales.Add(animal);
                    }
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return animales;
        }

        public void Insert(Animal animal)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Animal (NombreAnimal, Raza, FechaNacimiento, RIdTipoAnimal) VALUES (@Nombre,@Raza, @FechaNacimiento, @RIdTipoAnimal)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Nombre", animal.Name);
                    cmd.Parameters.AddWithValue("@Raza", animal.Raza);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", animal.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@RIdTipoAnimal", animal.RIdTipoAnimal);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Animal WHERE IdAnimal = @IdAnimal", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdAnimal", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
