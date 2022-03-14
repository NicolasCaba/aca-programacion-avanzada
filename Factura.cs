using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aca1
{
    public class Factura
    {
        private Usuario usuario;
        private Acueducto acueducto;
        private Alcantarillado alcantarillado;
        private Aseo aseo;
        private DateTime fechaTomo;
        private DateTime fechaPagoOportuno;
        private decimal totalAPagar;

        public Factura (Usuario usuario, Acueducto acueducto, Alcantarillado alcantarillado, Aseo aseo, DateTime fechaPagoOportuno, DateTime fechaTomo)
        {
            this.usuario = usuario;
            this.acueducto = acueducto;
            this.alcantarillado = alcantarillado;
            this.aseo = aseo;
            this.fechaTomo = fechaTomo;
            this.fechaPagoOportuno = fechaPagoOportuno;
        }

        public DateTime FechaTomo { get { return this.fechaTomo; } set { this.fechaTomo = value; } }
        public DateTime FechaPagoOportuno { get { return this.fechaPagoOportuno; } set { this.fechaPagoOportuno = value; } }
        public decimal TotalAPagar { get { return this.totalAPagar; } set { this.totalAPagar = value; } }
    }
}
