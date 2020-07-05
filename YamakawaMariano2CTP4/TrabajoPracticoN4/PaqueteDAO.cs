using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoN4
{
    static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;
        static PaqueteDAO()
        {
             comando = new SqlCommand();
             conexion = new SqlConnection(@"Server = MARIANO-PC\SQLEXPRESS; Database= correo-sp-2017; Trusted_Connection = true;");
            comando.CommandType = System.Data.CommandType.Text;

        }
        /// <summary>
        /// Metodo que inserta un "paquete" en la base de datos correo-sp-2017
        /// </summary>
        /// <param name="p">Objeto a insertar</param>
        /// <returns>true si pudo insertar el objeto , false si no</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                using(conexion = new SqlConnection(@"Server = MARIANO-PC\SQLEXPRESS; Database= correo-sp-2017; Trusted_Connection = true;"))
                {
                    comando.Connection = conexion;
                    string sql = "INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES (@direccionEntrega,@trackingID,@alumno)";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                    comando.Parameters.AddWithValue("@trackingID", p.TrackingID);
                    comando.Parameters.AddWithValue("@alumno", "Mariano");

                    comando.CommandText = sql;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al guardar paquete en base de datos");
            }
            return retorno;
        }
    }
}
