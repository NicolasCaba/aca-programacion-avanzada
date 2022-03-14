using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aca1
{
    class TarifasAseo
    {
        private double toneladasPorSuscriptor;
        private double barridoYLimpieza;
        private double limpiezaUrbana;
        private double comercializacion;
        private double recoleccionYTransporte;
        private double disposicionFinal;
        private double trataminetoDeLixiviados;
        private double tarifaDeAprovechamiento;
        private double tarifaFinal;

        public double ToneladasPorSuscriptor { get { return toneladasPorSuscriptor; } set { this.toneladasPorSuscriptor = value; } }
        public double BarridoYLimpieza { get { return barridoYLimpieza; } set { this.barridoYLimpieza = value; } }
        public double LimpiezaUrbana { get { return limpiezaUrbana; } set { this.limpiezaUrbana = value; } }
        public double Comercializacion { get { return comercializacion; } set { this.comercializacion = value; } }
        public double RecoleccionYTransporte { get { return recoleccionYTransporte; } set { this.recoleccionYTransporte = value; } }
        public double DisposicionFinal { get { return disposicionFinal; } set { this.disposicionFinal = value; } }
        public double TrataminetoDeLixiviados { get { return trataminetoDeLixiviados; } set { this.trataminetoDeLixiviados = value; } }
        public double TarifaDeAprovechamiento { get { return tarifaDeAprovechamiento; } set { this.tarifaDeAprovechamiento = value; } }
        public double TarifaFinal { get { return tarifaFinal; } set { this.tarifaFinal = value; } }
    }
}
