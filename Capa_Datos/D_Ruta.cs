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
    public class D_Ruta
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Ruta> ListarAgenda(string buscar)
        {

            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("sp_buscar_rutas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);
            reader = cmd.ExecuteReader();

            List<E_Ruta> listar = new List<E_Ruta>();
            while (reader.Read())
            {

                listar.Add(new E_Ruta
                {

                    Id_ruta = reader.GetInt32(0),
                    Nombre_ruta = reader.GetString(1),
                    Disponible = reader.GetBoolean(2)
                });

            }

            conexion.Close();
            reader.Close();
            return listar;
        }

        public void Insertar(E_Ruta ruta)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_rutas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.Parameters.AddWithValue("@Nombre_ruta", ruta.Nombre_ruta);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        public void Editar(E_Ruta ruta)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_editar_ruta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.Parameters.AddWithValue("@id", ruta.Id_ruta);
                cmd.Parameters.AddWithValue("@Nombre_ruta", ruta.Nombre_ruta);

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
