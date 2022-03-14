using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aca1
{
    public class Usuario
    {
        private int idUsuario;
        private string nombre;
        private int estrato;
        private string claseDeUso;
        private string direccion;

        public string Nombre { get { return nombre; } set { this.nombre = value; } }
        public int Estrato { get { return estrato; } set { this.estrato = value; } }
        public string ClaseDeUso { get { return claseDeUso; } set { this.claseDeUso = value; } }
        public string Direccion { get { return direccion; } set { this.direccion = value; } }
        public int IdUsuario { get { return idUsuario; } set { this.idUsuario = value; } }
    }
}
