using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class Estudiantes
    {
        private int ID1;
        private string Nombre1;
        private string SNombre1;
        private string Apellido1;
        private string SApellido1;
        private byte[] Foto1;
        private string Telefono1;
        private string Celular1;
        private string Direccion1;
        private string Email1;
        private DateTime FNacimiento1;
        private string Observaciones1;
        private DateTime FRegistro1;

        //VARIABLE PARA LA BUSQUEDA:
        private string busqueda;
        private string filtroYear;
        private string filtroMonth;
        private string filtroDay;

        public int ID { get => ID1; set => ID1 = value; }
        public string Nombre { get => Nombre1; set => Nombre1 = value; }
        public string SNombre { get => SNombre1; set => SNombre1 = value; }
        public string Apellido { get => Apellido1; set => Apellido1 = value; }
        public string SApellido { get => SApellido1; set => SApellido1 = value; }
        public byte[] Foto { get => Foto1; set => Foto1 = value; }
        public string Telefono { get => Telefono1; set => Telefono1 = value; }
        public string Celular { get => Celular1; set => Celular1 = value; }
        public string Direccion { get => Direccion1; set => Direccion1 = value; }
        public string Email { get => Email1; set => Email1 = value; }
        public DateTime FNacimiento { get => FNacimiento1; set => FNacimiento1 = value; }
        public string Observaciones { get => Observaciones1; set => Observaciones1 = value; }
        public DateTime FRegistro { get => FRegistro1; set => FRegistro1 = value; }


        public string Busqueda { get => busqueda; set => busqueda = value; }
        public string FiltroYear { get => filtroYear; set => filtroYear = value; }
        public string FiltroMonth { get => filtroMonth; set => filtroMonth = value; }
        public string FiltroDay { get => filtroDay; set => filtroDay = value; }
    }
}
