using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Capa_Entidad;

namespace Capa_Datos
{
    public class D_Chofer
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Chofer> ListarAgenda(string buscar)
        {

            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("sp_buscar_choferes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);
            reader = cmd.ExecuteReader();

            List<E_Chofer> listar = new List<E_Chofer>();
            while (reader.Read())
            {

                listar.Add(new E_Chofer
                {

                    Id_chofer = reader.GetInt32(0),
                    Nombre_chofer = reader.GetString(1),
                    Apellido_chofer = reader.GetString(2),
                    Fecha_chofer = reader.GetString(3),
                    Cedula_chofer = reader.GetString(4),
                    Disponible = reader.GetBoolean(5)
                });

            }

            conexion.Close();
            reader.Close();
            return listar;
        }

        public void Insertar(E_Chofer chofer)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_chofer", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre_chofer);
                cmd.Parameters.AddWithValue("@Apellido", chofer.Apellido_chofer);
                cmd.Parameters.AddWithValue("@Fecha", chofer.Fecha_chofer);
                cmd.Parameters.AddWithValue("@Cedula", chofer.Cedula_chofer);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        public void Editar(E_Chofer chofer)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_editar_chofer", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.Parameters.AddWithValue("@id", chofer.Id_chofer);
                cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre_chofer);
                cmd.Parameters.AddWithValue("@Apellido", chofer.Apellido_chofer);
                cmd.Parameters.AddWithValue("@Fecha", chofer.Fecha_chofer);
                cmd.Parameters.AddWithValue("@Cedula", chofer.Cedula_chofer);

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
