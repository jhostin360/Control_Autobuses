using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Capa_Entidad;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class D_Autobuses
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Autobuses> ListarAgenda(string buscar)
        {

            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("sp_buscar_autobuses", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);
            reader = cmd.ExecuteReader();

            List<E_Autobuses> listar = new List<E_Autobuses>();
            while (reader.Read())
            {

                listar.Add(new E_Autobuses
                {

                    Id_Auto = reader.GetInt32(0),
                    Marca = reader.GetString(1),
                    Modelo = reader.GetString(2),
                    Placa = reader.GetString(3),
                    Color = reader.GetString(4),
                    Año = reader.GetString(5),
                    Disponible = reader.GetBoolean(6)
                }) ;

            }

            conexion.Close();
            reader.Close();
            return listar;
        }

        public void Insertar(E_Autobuses bus)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_autobuses", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.Parameters.AddWithValue("@Marca", bus.Marca);
                cmd.Parameters.AddWithValue("@Modelo", bus.Modelo);
                cmd.Parameters.AddWithValue("@Placa", bus.Placa);
                cmd.Parameters.AddWithValue("@Color", bus.Color);
                cmd.Parameters.AddWithValue("@Año", bus.Año);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        public void Editar(E_Autobuses bus)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_editar_autobus", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.Parameters.AddWithValue("@id", bus.Id_Auto);
                cmd.Parameters.AddWithValue("@Marca", bus.Marca);
                cmd.Parameters.AddWithValue("@Modelo", bus.Modelo);
                cmd.Parameters.AddWithValue("@Placa", bus.Placa);
                cmd.Parameters.AddWithValue("@Color", bus.Color);
                cmd.Parameters.AddWithValue("@Año", bus.Año);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }

    }
}
