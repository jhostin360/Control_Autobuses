using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Capa_Entidad;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Asignar
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Buscar_Viaje> Listar(string buscar)
        {

            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("sp_buscar_asignacion", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);
            reader = cmd.ExecuteReader();

            List<E_Buscar_Viaje> listar = new List<E_Buscar_Viaje>();
            while (reader.Read())
            {

                listar.Add(new E_Buscar_Viaje
                {

                    Id_Viaje = reader.GetInt32(0),
                    Chofer_Viaje = reader.GetString(1),
                    Autobuses_Viaje = reader.GetString(2),
                    Ruta_Viaje = reader.GetString(3)
                });

            }

            conexion.Close();
            reader.Close();
            return listar;
        }

        public void Insertar(E_Asignar asin)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_Asignacion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.Parameters.AddWithValue("@id_chofer", asin.Id_chofer);
                cmd.Parameters.AddWithValue("@id_autobus", asin.Id_autobuses);
                cmd.Parameters.AddWithValue("@id_ruta", asin.Id_ruta);

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
