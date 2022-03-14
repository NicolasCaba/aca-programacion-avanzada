using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aca1
{
    public class Acueducto
    {
        private int idAcueducto;
        private double cargoFijo;
        private int consumoBasico;
        private int consumoComplementario;
        private int consumoSuntuario;
        private double total;

        public int IdAcueducto { get { return idAcueducto; } set { this.idAcueducto = value; } }
        public double CargoFijo { get { return cargoFijo; } set { this.cargoFijo = value; } }
        public int ConsumoBasico { get { return consumoBasico; } set { this.consumoBasico = value; } }
        public int ConsumoComplementario { get { return consumoComplementario; } set { this.consumoComplementario = value; } }
        public int ConsumoSuntuario { get { return consumoSuntuario; } set { this.consumoSuntuario = value; } }
        public double Total { get { return total; } set { this.total = value; } }

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
