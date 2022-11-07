using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//AGREGADOS
using CAPA_ENTIDAD;
using System.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public class  CD_Estudiantes
    {
        Conexion conn = new Conexion();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        //Mostrar estudiantes
        public DataTable LeerDatos()
        {
            DataTable tabla = new DataTable();

            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "MostrarEstudiantes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conn.CerrarConexion();

            return tabla;
        }

        //Insertar Estudiante
        public void InsertarDatos(Estudiantes estudiantes)
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "InsertarNuevoEstudiante";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NOMBRE", estudiantes.Nombre);
            comando.Parameters.AddWithValue("@SNOMBRE", estudiantes.SNombre);
            comando.Parameters.AddWithValue("@APELLIDO", estudiantes.Apellido);
            comando.Parameters.AddWithValue("@SAPELLIDO", estudiantes.SApellido);
            comando.Parameters.AddWithValue("@FOTO", estudiantes.Foto);
            comando.Parameters.AddWithValue("@TELEFONO", estudiantes.Telefono);
            comando.Parameters.AddWithValue("@CELULAR", estudiantes.Celular);
            comando.Parameters.AddWithValue("@DIRECCION", estudiantes.Direccion);
            comando.Parameters.AddWithValue("@EMAIL", estudiantes.Email);
            comando.Parameters.AddWithValue("@FNACIMIENTO", estudiantes.FNacimiento);
            comando.Parameters.AddWithValue("@OBSERVACIONES", estudiantes.Observaciones);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            conn.CerrarConexion();
        }
        public void ActualizarDatos(Estudiantes estudiantes)
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "ActualizarAntiguoEstudiante";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id", estudiantes.ID);
            comando.Parameters.AddWithValue("@NOMBRE", estudiantes.Nombre);
            comando.Parameters.AddWithValue("@SNOMBRE", estudiantes.SNombre);
            comando.Parameters.AddWithValue("@APELLIDO", estudiantes.Apellido);
            comando.Parameters.AddWithValue("@SAPELLIDO", estudiantes.SApellido);
            comando.Parameters.AddWithValue("@FOTO", estudiantes.Foto);
            comando.Parameters.AddWithValue("@TELEFONO", estudiantes.Telefono);
            comando.Parameters.AddWithValue("@CELULAR", estudiantes.Celular);
            comando.Parameters.AddWithValue("@DIRECCION", estudiantes.Direccion);
            comando.Parameters.AddWithValue("@EMAIL", estudiantes.Email);
            comando.Parameters.AddWithValue("@FNACIMIENTO", estudiantes.FNacimiento);
            comando.Parameters.AddWithValue("@OBSERVACIONES", estudiantes.Observaciones);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            conn.CerrarConexion();
        }
        public void EliminarDatos(Estudiantes estudiantes)
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "EliminarEstudianteID";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", estudiantes.ID);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            conn.CerrarConexion();
        }
        public DataTable FiltroNombre(Estudiantes estudiantes)
        {
            DataTable nombre = new DataTable();

            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "FiltroPorNombre";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NOMBRE", estudiantes.Busqueda);

            SqlDataReader leer1 = comando.ExecuteReader();
            nombre.Load(leer1);
            conn.CerrarConexion();

            return nombre;
        }
        public DataTable FiltroFechaNombre(Estudiantes estudiantes)
        {
            DataTable fechaNombre = new DataTable();
            comando.Connection = conn.AbrirConexion();

            string sentenciaFiltro = "SELECT * FROM estudiantes WHERE NOMBRE+SNOMBRE+APELLIDO+SAPELLIDO LIKE '%'+@NOMBRE+'%'";

            //Condiciones para el filtro:
            if (estudiantes.FiltroYear == "" && estudiantes.FiltroMonth == "" && estudiantes.FiltroDay == "")
            {
                sentenciaFiltro += "";
            }
            else
            {
                if (estudiantes.FiltroYear != "" && estudiantes.FiltroMonth == "" && estudiantes.FiltroDay == "")
                {
                    sentenciaFiltro += "AND YEAR(FNACIMIENTO) = " + estudiantes.FiltroYear + "";
                }
                else if (estudiantes.FiltroYear == "" && estudiantes.FiltroMonth != "" && estudiantes.FiltroDay == "")
                {
                    sentenciaFiltro += "AND MONTH(FNACIMIENTO) = " + estudiantes.FiltroMonth + "";
                }
                else if (estudiantes.FiltroYear == "" && estudiantes.FiltroMonth == "" && estudiantes.FiltroDay != "")
                {
                    sentenciaFiltro += "AND DAY(FNACIMIENTO) =" + estudiantes.FiltroDay + "";
                }
                else if (estudiantes.FiltroYear == "" && estudiantes.FiltroMonth != "" && estudiantes.FiltroDay != "")
                {
                    sentenciaFiltro += "AND MONTH(FNACIMIENTO) = " + estudiantes.FiltroMonth + "AND DAY(FNACIMIENTO) =" + estudiantes.FiltroDay + "";
                }
                else if (estudiantes.FiltroYear != "" && estudiantes.FiltroMonth == "" && estudiantes.FiltroDay != "")
                {
                    sentenciaFiltro += "AND YEAR(FNACIMIENTO) = " + estudiantes.FiltroYear + " AND DAY(FNACIMIENTO) =" + estudiantes.FiltroDay + "";
                }
                else if (estudiantes.FiltroYear != "" && estudiantes.FiltroMonth != "" && estudiantes.FiltroDay == "")
                {
                    sentenciaFiltro += "AND YEAR(FNACIMIENTO) = " + estudiantes.FiltroYear + " AND MONTH(FNACIMIENTO) = " + estudiantes.FiltroMonth + "";
                }
            }

            comando.CommandText = sentenciaFiltro;
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@NOMBRE", estudiantes.Busqueda);

            SqlDataReader leer = comando.ExecuteReader();
            fechaNombre.Load(leer);
            conn.CerrarConexion();
            return fechaNombre;
        }
    }
}
