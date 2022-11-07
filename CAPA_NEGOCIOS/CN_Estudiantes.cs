using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//AGREGADOS
using CAPA_DATOS;
using CAPA_ENTIDAD;
using System.Data;

namespace CAPA_NEGOCIOS
{
    public class CN_Estudiantes
    {
        CD_Estudiantes objeto = new CD_Estudiantes();
        Estudiantes datos = new Estudiantes();

        public DataTable LeerDatos()
        {
            DataTable datos = new DataTable();
            datos = objeto.LeerDatos();
            return datos;
        }
        public void InsertarDatos(string nombre, string snombre, string apellido, string sapellido, byte[] foto,string telefono, string celular, string direccion, string email, DateTime fnacimiento, string observaciones)
        {
            datos.Nombre = nombre;
            datos.SNombre = snombre;
            datos.Apellido = apellido;
            datos.SApellido = sapellido;
            datos.Foto = foto;
            datos.Telefono = telefono;
            datos.Celular = celular;
            datos.Direccion = direccion;
            datos.Email = email;
            datos.FNacimiento = fnacimiento;
            datos.Observaciones = observaciones;


            objeto.InsertarDatos(datos);
        }
        public void ActualizarDatos(string id, string nombre, string snombre, string apellido, string sapellido, byte[] foto, string telefono, string celular, string direccion, string email, DateTime fnacimiento, string observaciones)
        {
            datos.ID = Convert.ToInt32(id);
            datos.Nombre = nombre;
            datos.SNombre = snombre;
            datos.Apellido = apellido;
            datos.SApellido = sapellido;
            datos.Foto = foto;
            datos.Telefono = telefono;
            datos.Celular = celular;
            datos.Direccion = direccion;
            datos.Email = email;
            datos.FNacimiento = fnacimiento;
            datos.Observaciones = observaciones;

            objeto.ActualizarDatos(datos);
        }
        public void EliminarDatos(string id)
        {
            datos.ID = Convert.ToInt32(id);

            objeto.EliminarDatos(datos);
        }
        public DataTable FiltroNombre(string busqueda)
        {
            datos.Busqueda = busqueda;

            DataTable datos1 = new DataTable();
            datos1 = objeto.FiltroNombre(datos);
            return datos1;
        }
        public DataTable FiltroFechaNombre(string busqueda, string filtroyear, string filtromonth, string filtroday)
        {
            datos.Busqueda = busqueda;
            datos.FiltroYear = filtroyear;
            datos.FiltroMonth = filtromonth;
            datos.FiltroDay = filtroday;

            DataTable datos2 = new DataTable();
            datos2 = objeto.FiltroFechaNombre(datos);
            return datos2;
        }
    }
}
