using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//AGREGADOS
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public class Conexion
    {
        public static string StrinfoConexion = ConfigurationManager.ConnectionStrings["conexionConfig"].ToString();

        SqlConnection conexion = new SqlConnection(Conexion.StrinfoConexion);

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}
