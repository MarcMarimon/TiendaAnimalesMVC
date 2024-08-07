using Animales.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Animales.DAL
{
    public class TipoAnimalDAL
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<TipoAnimal> GetAll()
        {
            List<TipoAnimal> tiposAnimal = new List<TipoAnimal>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT IdTipoAnimal, TipoDescripcion FROM TipoAnimal", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoAnimal tipoAnimal = new TipoAnimal
                        {
                            IdTipoAnimal = Convert.ToInt32(rdr["IdTipoAnimal"]),
                            Descripcion = rdr["TipoDescripcion"].ToString()
                        };
                        tiposAnimal.Add(tipoAnimal);
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

            return tiposAnimal;
        }

        public void Insert(TipoAnimal tipoAnimal)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO TipoAnimal (TipoDescripcion) VALUES (@TipoDescripcion)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TipoDescripcion", tipoAnimal.Descripcion);

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
                    SqlCommand cmd = new SqlCommand("DELETE FROM TipoAnimal WHERE IdTipoAnimal = @IdTipoAnimal", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdTipoAnimal", id);

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
