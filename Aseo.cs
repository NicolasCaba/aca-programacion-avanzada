using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aca1
{
    public class Aseo
    {
        private double toneladasPorSuscriptor;
        private double barridoYLimpieza;
        private double comercializacion;
        private double recoleccionYTransporte;
        private double disposicionFinal;
        private double trataminetoDeLixiviados;
        private double tarifaDeAprovechamiento;
        private double total;

        public double ToneladasPorSuscriptor { get; set; }
        public double BarridoYLimpieza { get; set; }
        public double Comercializacion { get; set; }
        public double RecoleccionYTransporte { get; set; }
        public double DisposicionFinal { get; set; }
        public double TrataminetoDeLixiviados { get; set; }
        public double TarifaDeAprovechamiento { get; set; }
        public double Total { get; set; }

        public double calcular (string tipo, double tarifa, double porcentajeSubsidio, double porcentajeContribucion)
        {
            double valor = 0;

            switch (tipo)
            {
                case "toneladasPorSuscriptor":
                    valor = this.toneladasPorSuscriptor * tarifa;
                    break;
                case "barridoYLimpieza":
                    valor = this.barridoYLimpieza * tarifa;
                    break;
                case "comercializacion":
                    valor = this.comercializacion * tarifa;
                    break;
                case "recoleccionYTransporte":
                    valor = this.recoleccionYTransporte * tarifa;
                    break;
                case "disposicionFinal":
                    valor = this.disposicionFinal * tarifa;
                    break;
                case "trataminetoDeLixiviados":
                    valor = this.trataminetoDeLixiviados * tarifa;
                    break;
                case "tarifaDeAprovechamiento":
                    valor = this.tarifaDeAprovechamiento * tarifa;
                    break;
            }

            double valorSubsidio = (valor * porcentajeSubsidio) / 100;
            double valorContribucion = (valor * porcentajeContribucion) / 100;
            double valorFinal = valor - valorSubsidio + valorContribucion;

            return valorFinal;
        }
    }
}
