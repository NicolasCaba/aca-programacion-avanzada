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
        private DateTime fechaPagoOportuno;

        public Factura (Usuario usuario, Acueducto acueducto, Alcantarillado alcantarillado, Aseo aseo, DateTime fechaPagoOportuno)
        {
            this.usuario = usuario;
            this.acueducto = acueducto;
            this.alcantarillado = alcantarillado;
            this.aseo = aseo;
            this.fechaPagoOportuno = fechaPagoOportuno;
        }
    }
}
