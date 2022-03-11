using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aca1
{
    public class Acueducto
    {
        private double cargoFijo;
        private int consumoBasico;
        private int consumoComplementario;
        private int consumoSuntuario;
        private double total;

        public double CargoFijo { get; set; }
        public int ConsumoBasico { get; set; }
        public int ConsumoComplementario { get; set; }
        public int ConsumoSuntuario { get; set; }
        public double Total { get; set; }

        public double calcularCargoFijo(double porcentajesubsidio, double porcentajecontribucion)
        {
            double valorSubsidio = (this.cargoFijo * porcentajesubsidio) / 100;
            double valorContribucion = (this.cargoFijo * porcentajecontribucion) / 100;
            double totalCargoFijo = this.cargoFijo - valorSubsidio + valorContribucion;

            return totalCargoFijo;
        }

        public double calcularConsumo(string tipo, double porcentajesubsidio, double porcentajecontribucion, double tarifa)
        {
            double valorConsumo = 0;
            double valor = 0;

            switch (tipo)
            {
                case "consumoBasico":
                    valor = tarifa * this.consumoBasico;
                    double valorSubsidio = (valor * porcentajesubsidio) / 100;
                    double valorContribucion = (valor * porcentajecontribucion) / 100;
                    valorConsumo = valor - valorSubsidio + valorContribucion;
                    break;

                case "consumoComplementario":
                    valorConsumo = tarifa * this.consumoComplementario;
                    break;

                case "consumoSuntuario":
                    valorConsumo = tarifa * this.consumoSuntuario;
                    break;
            }

            return valorConsumo;
        }
    }
}
