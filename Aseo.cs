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
        private double limpiezaUrbana;
        private double comercializacion;
        private double recoleccionYTransporte;
        private double disposicionFinal;
        private double trataminetoDeLixiviados;
        private double tarifaDeAprovechamiento;
        private double total;

        public double ToneladasPorSuscriptor { get { return toneladasPorSuscriptor; } set { this.toneladasPorSuscriptor = value; } }
        public double BarridoYLimpieza { get { return barridoYLimpieza; } set { this.barridoYLimpieza = value; } }
        public double LimpiezaUrbana { get { return limpiezaUrbana; } set { this.limpiezaUrbana = value; } }
        public double Comercializacion { get { return comercializacion; } set { this.comercializacion = value; } }
        public double RecoleccionYTransporte { get { return recoleccionYTransporte; } set { this.recoleccionYTransporte = value; } }
        public double DisposicionFinal { get { return disposicionFinal; } set { this.disposicionFinal = value; } }
        public double TrataminetoDeLixiviados { get { return trataminetoDeLixiviados; } set { this.trataminetoDeLixiviados = value; } }
        public double TarifaDeAprovechamiento { get { return tarifaDeAprovechamiento; } set { this.tarifaDeAprovechamiento = value; } }
        public double Total { get { return total; } set { this.total = value; } }

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
