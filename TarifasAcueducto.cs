using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aca1
{
    class TarifasAcueducto
    {
        private double cargoFijo;
        private double consumoBasico;
        private double consumoComplementario;
        private double consumoSuntuario;

        public double CargoFijo { get { return cargoFijo; } set { this.cargoFijo = value; } }
        public double ConsumoBasico { get { return consumoBasico; } set { this.consumoBasico = value; } }
        public double ConsumoComplementario { get { return consumoComplementario; } set { this.consumoComplementario = value; } }
        public double ConsumoSuntuario { get { return consumoSuntuario; } set { this.consumoSuntuario = value; } }
    }
}
