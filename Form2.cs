using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace aca1
{
    public partial class FormFactura : Form
    {
        int idFactura;
        Factura factura;
        Usuario usuario;
        Acueducto acueducto;
        Alcantarillado alcantarillado;
        Aseo aseo;
        int porcentajeContribucion;
        int porcentajeSubsidio;
        TarifasAcueducto tarifasAcueducto;
        TarifasAlcantarillado tarifasAlcantarillado;
        TarifasAseo tarifasAseo;
        double totalAPagar;

        public FormFactura(int idFactura)
        {
            InitializeComponent();
            this.idFactura = idFactura;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            // Label idFactura
            labelIdFactura.Text = Convert.ToString(this.idFactura);

            // Conexion base de datos
            DatabaseConnection conexion = new DatabaseConnection();
            conexion.OpenConection();

            // String query para realizar las consultas
            StringBuilder sb = new StringBuilder();

            // Query para obtener tarifas de Acueducto, Alcantarilaldo, Aseo
            sb.Append("SELECT ");
            /*****************************************/
            sb.Append("Factura.id AS idFactura, ");
            sb.Append("Tarifas_acueducto.Cargo_fijo AS Cargo_fijo_Acueducto, ");
            sb.Append("Tarifas_acueducto.Consumo_basico AS Consumo_basico_Acueducto, ");
            sb.Append("Tarifas_acueducto.Consumo_complementario AS Consumo_complementario_Acueducto, ");
            sb.Append("Tarifas_acueducto.Consumo_suntuario AS Consumo_suntuario_Acueducto, ");
            sb.Append("Tarifas_alcantarillado.Cargo_fijo AS Cargo_fijo_Alcantarillado, ");
            sb.Append("Tarifas_alcantarillado.Consumo_basico AS Consumo_basico_Alcantarillado, ");
            sb.Append("Tarifas_alcantarillado.Consumo_complementario AS Consumo_complementario_Alcantarillado, ");
            sb.Append("Tarifas_alcantarillado.Consumo_suntuario AS Consumo_suntuario_Alcantarillado, ");
            sb.Append("Tarifas_aseo.Toneladas_por_suscriptor, ");
            sb.Append("Tarifas_aseo.Barrido_y_limpieza, ");
            sb.Append("Tarifas_aseo.Limpieza_urbana, ");
            sb.Append("Tarifas_aseo.Comercializacion, ");
            sb.Append("Tarifas_aseo.Recoleccion_y_transporte, ");
            sb.Append("Tarifas_aseo.Disposicion_final, ");
            sb.Append("Tarifas_aseo.Tratamiento_lixiviados, ");
            sb.Append("Tarifas_aseo.Aprovechamiento, ");
            sb.Append("Tarifas_aseo.Tarifa_final ");
            /*****************************************/
            sb.Append("FROM Factura ");
            /*****************************************/
            sb.Append("LEFT JOIN Usuario ON Usuario.id = Factura.idUsuario ");
            sb.Append("LEFT JOIN Estrato ON Estrato.id = Usuario.idEstrato ");
            sb.Append("LEFT JOIN Tarifas_acueducto ON Estrato.id = Tarifas_acueducto.idEstrato ");
            sb.Append("LEFT JOIN Tarifas_alcantarillado ON Estrato.id = Tarifas_alcantarillado.idEstrato ");
            sb.Append("LEFT JOIN Tarifas_aseo ON Estrato.id = Tarifas_aseo.idEstrato ");
            /*****************************************/
            sb.Append($"WHERE Factura.id = {idFactura};");

            // Consulta para generar datos de tarifas
            SqlDataReader dr = conexion.DataReader(sb.ToString());

            while (dr.Read())
            {
                // Instancia TarifasAcueducto
                this.tarifasAcueducto = new TarifasAcueducto();
                this.tarifasAcueducto.CargoFijo = Convert.ToDouble(dr["Cargo_fijo_Acueducto"].ToString());
                this.tarifasAcueducto.ConsumoBasico = Convert.ToDouble(dr["Consumo_basico_Acueducto"].ToString());
                this.tarifasAcueducto.ConsumoComplementario = Convert.ToDouble(dr["Consumo_complementario_Acueducto"].ToString());
                this.tarifasAcueducto.ConsumoSuntuario = Convert.ToDouble(dr["Consumo_suntuario_Acueducto"].ToString());

                // Instancia TarifasAlcantarillado
                this.tarifasAlcantarillado = new TarifasAlcantarillado();
                this.tarifasAlcantarillado.CargoFijo = Convert.ToDouble(dr["Cargo_fijo_Alcantarillado"].ToString());
                this.tarifasAlcantarillado.ConsumoBasico = Convert.ToDouble(dr["Consumo_basico_Alcantarillado"].ToString());
                this.tarifasAlcantarillado.ConsumoComplementario = Convert.ToDouble(dr["Consumo_complementario_Alcantarillado"].ToString());
                this.tarifasAlcantarillado.ConsumoSuntuario = Convert.ToDouble(dr["Consumo_suntuario_Alcantarillado"].ToString());

                // Instancia TarifasAseo
                this.tarifasAseo = new TarifasAseo();
                this.tarifasAseo.ToneladasPorSuscriptor = Convert.ToDouble(dr["Toneladas_por_suscriptor"].ToString());
                this.tarifasAseo.BarridoYLimpieza = Convert.ToDouble(dr["Barrido_y_limpieza"].ToString());
                this.tarifasAseo.LimpiezaUrbana = Convert.ToDouble(dr["Limpieza_urbana"].ToString());
                this.tarifasAseo.Comercializacion = Convert.ToDouble(dr["Comercializacion"].ToString());
                this.tarifasAseo.RecoleccionYTransporte = Convert.ToDouble(dr["Recoleccion_y_transporte"].ToString());
                this.tarifasAseo.DisposicionFinal = Convert.ToDouble(dr["Disposicion_final"].ToString());
                this.tarifasAseo.TrataminetoDeLixiviados = Convert.ToDouble(dr["Tratamiento_lixiviados"].ToString());
                this.tarifasAseo.TarifaDeAprovechamiento = Convert.ToDouble(dr["Aprovechamiento"].ToString());
                this.tarifasAseo.TarifaFinal = Convert.ToDouble(dr["Tarifa_final"].ToString());
            }

            dr.Close();
            sb.Clear();

            // Query para obtener datos de Factura, Usuario, Acueducto, Alcantarillado, Aseo
            sb.Append("SELECT ");
            /*****************************************/
            sb.Append("Factura.id AS idFactura, ");
            sb.Append("Factura.Numero_servicio_publico, ");
            sb.Append("Factura.Fecha_tomo, ");
            sb.Append("Factura.Fecha_pago, ");
            sb.Append("Usuario.id AS idUsuario, ");
            sb.Append("Usuario.Primer_nombre, ");
            sb.Append("Usuario.Segundo_nombre, ");
            sb.Append("Usuario.Primer_apellido, ");
            sb.Append("Usuario.Segundo_apellido, ");
            sb.Append("Usuario.Clase_uso, ");
            sb.Append("Usuario.Direccion, ");
            sb.Append("Estrato.Clasificacion AS Estrato, ");
            sb.Append("Acueducto.id AS idAcueducto, ");
            sb.Append("Acueducto.Consumo_basico AS Consumo_basico_Acueducto, ");
            sb.Append("Acueducto.Consumo_complementario AS Consumo_complementario_Acueducto, ");
            sb.Append("Acueducto.Consumo_suntuario AS Consumo_suntuario_Acueducto, ");
            sb.Append("Alcantarillado.id AS idAlcantarillado, ");
            sb.Append("Alcantarillado.Consumo_basico AS Consumo_basico_Alcantarillado, ");
            sb.Append("Alcantarillado.Consumo_complementario AS Consumo_complementario_Alcantarillado, ");
            sb.Append("Alcantarillado.Consumo_suntuario AS Consumo_suntuario_Alcantarillado, ");
            sb.Append("Aseo.id AS idAseo, ");
            sb.Append("Aseo.Toneladas_por_suscriptor, ");
            sb.Append("Aseo.Barrido_y_limpieza, ");
            sb.Append("Aseo.Limpieza_urbana, ");
            sb.Append("Aseo.Comercializacion, ");
            sb.Append("Aseo.Recoleccion_y_transporte, ");
            sb.Append("Aseo.Disposicion_final, ");
            sb.Append("Aseo.Tratamiento_lixiviados, ");
            sb.Append("Aseo.Aprovechamiento, ");
            sb.Append("Niveles_contribucion.Porcentaje AS Porcentaje_contribucion, ");
            sb.Append("Niveles_subsidio.Porcentaje AS Porcentaje_subsidio, ");
            sb.Append("Tarifas_acueducto.Cargo_fijo AS Cargo_fijo_Acueducto, ");
            sb.Append("Tarifas_alcantarillado.Cargo_fijo AS Cargo_fijo_Alcantarillado ");
            /*****************************************/
            sb.Append("FROM Factura ");
            /*****************************************/
            sb.Append("LEFT JOIN Usuario ON Usuario.id = Factura.idUsuario ");
            sb.Append("LEFT JOIN Acueducto ON Acueducto.id = Factura.idAcueducto ");
            sb.Append("LEFT JOIN Alcantarillado ON Alcantarillado.id = Factura.idAlcantarillado ");
            sb.Append("LEFT JOIN Aseo ON Aseo.id = Factura.idAseo ");
            sb.Append("LEFT JOIN Estrato ON Estrato.id = Usuario.idEstrato ");
            sb.Append("LEFT JOIN Niveles_subsidio ON Estrato.id = Niveles_subsidio.idEstrato ");
            sb.Append("LEFT JOIN Niveles_contribucion ON Estrato.id = Niveles_contribucion.idEstrato ");
            sb.Append("LEFT JOIN Tarifas_acueducto ON Estrato.id = Tarifas_acueducto.idEstrato ");
            sb.Append("LEFT JOIN Tarifas_alcantarillado ON Estrato.id = Tarifas_alcantarillado.idEstrato ");
            /*****************************************/
            sb.Append($"WHERE Factura.id = {idFactura};");

            // Consulta para generar datos de la factura
            dr = conexion.DataReader(sb.ToString());

            // Lectura de datos
            while (dr.Read())
            {
                // Instancia Clase Usuario
                this.usuario = new Usuario();
                this.usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                this.usuario.Nombre = $"{ dr["Primer_nombre"].ToString() } { dr["Segundo_nombre"].ToString() } { dr["Primer_apellido"].ToString() } { dr["Segundo_apellido"].ToString() }";
                this.usuario.Estrato = Convert.ToInt32( dr["Estrato"].ToString() );
                this.usuario.ClaseDeUso = dr["Clase_uso"].ToString();
                this.usuario.Direccion = dr["Direccion"].ToString();

                // Instancia Clase Acueducto
                this.acueducto = new Acueducto();
                this.acueducto.IdAcueducto = Convert.ToInt32(dr["idAcueducto"].ToString());
                this.acueducto.CargoFijo = Convert.ToDouble( dr["Cargo_fijo_Acueducto"].ToString() );
                this.acueducto.ConsumoBasico = Convert.ToDouble( dr["Consumo_basico_Acueducto"].ToString() );
                this.acueducto.ConsumoComplementario = Convert.ToDouble( dr["Consumo_complementario_Acueducto"].ToString() );
                this.acueducto.ConsumoSuntuario = Convert.ToDouble( dr["Consumo_suntuario_Acueducto"].ToString() );

                // Instancia Clase Alcantarillado
                this.alcantarillado = new Alcantarillado();
                this.alcantarillado.IdAlcantarillado = Convert.ToInt32(dr["idAlcantarillado"].ToString());
                this.alcantarillado.CargoFijo = Convert.ToDouble(dr["Cargo_fijo_Alcantarillado"].ToString());
                this.alcantarillado.ConsumoBasico = Convert.ToDouble(dr["Consumo_basico_Alcantarillado"].ToString());
                this.alcantarillado.ConsumoComplementario = Convert.ToDouble(dr["Consumo_complementario_Alcantarillado"].ToString());
                this.alcantarillado.ConsumoSuntuario = Convert.ToDouble(dr["Consumo_suntuario_Alcantarillado"].ToString());

                // Instancio Clase Aseo
                this.aseo = new Aseo();
                this.aseo.IdAseo = Convert.ToInt32(dr["idAseo"].ToString());
                this.aseo.ToneladasPorSuscriptor = Convert.ToDouble(dr["Toneladas_por_suscriptor"].ToString());
                this.aseo.BarridoYLimpieza = Convert.ToDouble(dr["Barrido_y_limpieza"].ToString());
                this.aseo.LimpiezaUrbana = Convert.ToDouble(dr["Limpieza_urbana"].ToString());
                this.aseo.Comercializacion = Convert.ToDouble(dr["Comercializacion"].ToString());
                this.aseo.RecoleccionYTransporte = Convert.ToDouble(dr["Recoleccion_y_transporte"].ToString());
                this.aseo.DisposicionFinal = Convert.ToDouble(dr["Disposicion_final"].ToString());
                this.aseo.TrataminetoDeLixiviados = Convert.ToDouble(dr["Tratamiento_lixiviados"].ToString());
                this.aseo.TarifaDeAprovechamiento = Convert.ToDouble(dr["Aprovechamiento"].ToString());

                // Porcentajes de subsidio y contribucion
                this.porcentajeContribucion = Convert.ToInt32(dr["Porcentaje_contribucion"].ToString());
                this.porcentajeSubsidio = Convert.ToInt32(dr["Porcentaje_subsidio"].ToString());

                // Instancia Clase Factura
                DateTime fechaPagoOportuno = Convert.ToDateTime(dr["Fecha_pago"].ToString());
                DateTime fechaTomo = Convert.ToDateTime(dr["Fecha_tomo"].ToString());
                this.factura = new Factura(usuario, acueducto, alcantarillado, aseo, fechaPagoOportuno, fechaTomo);
            }

            dr.Close();
            sb.Clear();

            string caracter;
            if (this.usuario.Estrato < 4)
            {
                caracter = "-";
            }
            else if (this.usuario.Estrato > 4)
            {
                caracter = "+";
            }
            else
            {
                caracter = "~";
            }

            // Set labels info Usuario
            this.labelIdUsuario.Text = Convert.ToString(this.usuario.IdUsuario);
            this.labelUsuarioNombre.Text = this.usuario.Nombre;
            this.labelUsuarioEstrato.Text = Convert.ToString(this.usuario.Estrato);
            this.labelUsuarioDireccion.Text = this.usuario.Direccion;
            this.labelUsuarioClaseUso.Text = this.usuario.ClaseDeUso;

            // Set labels info subsudio contribucion
            this.labelPorcentajeContribucion.Text = $"{this.porcentajeContribucion}%";
            this.labelPorcentajeSubsidio.Text = $"{this.porcentajeSubsidio}%";

            // Set labels info Factura
            this.labelFacturaFechaTomo.Text = this.factura.FechaTomo.Date.ToShortDateString();
            this.labelFacturaFechaPago.Text = this.factura.FechaPagoOportuno.Date.ToShortDateString();

            // Set labels info Acueducto
            /*****************Cantidad*****************************/
            this.labelIdAcueducto.Text = Convert.ToString(this.acueducto.IdAcueducto);
            this.labelAcueductoCantidadCargoFijo.Text = "1";
            this.labelAcueductoCantidadConsumoBasico.Text = Convert.ToString(this.acueducto.ConsumoBasico);
            this.labelAcueductoCantidadConsumoComplementario.Text = Convert.ToString(this.acueducto.ConsumoComplementario);
            this.labelAcueductoCantidadConsumoSuntuario.Text = Convert.ToString(this.acueducto.ConsumoSuntuario);
            /*****************Valor Unitario*****************************/
            this.labelAcueductoVUCargoFijo.Text = Convert.ToString(this.tarifasAcueducto.CargoFijo);
            this.labelAcueductoVUConsumoBasico.Text = Convert.ToString(this.tarifasAcueducto.ConsumoBasico);
            this.labelAcueductoVUConsumoComplementario.Text = Convert.ToString(this.tarifasAcueducto.ConsumoComplementario);
            this.labelAcueductoVUConsumoSuntuario.Text = Convert.ToString(this.tarifasAcueducto.ConsumoSuntuario);
            /*****************Valor Total*****************************/
            double valorTotalCargoFijoAceuducto = this.acueducto.calcularVT(1, this.tarifasAcueducto.CargoFijo);
            double valorTotalConsumoBasicoAceuducto = this.acueducto.calcularVT(this.acueducto.ConsumoBasico, this.tarifasAcueducto.ConsumoBasico);
            double valorTotalConsumoComplementarioAceuducto = this.acueducto.calcularVT(this.acueducto.ConsumoComplementario, this.tarifasAcueducto.ConsumoComplementario);
            double valorTotalConsumoSuntuarioAceuducto = this.acueducto.calcularVT(this.acueducto.ConsumoSuntuario, this.tarifasAcueducto.ConsumoSuntuario);
            this.labelAcueductoVTCargoFijo.Text = Convert.ToString(valorTotalCargoFijoAceuducto);
            this.labelAcueductoVTConsumoBasico.Text = Convert.ToString(valorTotalConsumoBasicoAceuducto);
            this.labelAcueductoVTConsumoComplementario.Text = Convert.ToString(valorTotalConsumoComplementarioAceuducto);
            this.labelAcueductoVTConsumoSuntuario.Text = Convert.ToString(valorTotalConsumoSuntuarioAceuducto);
            /*****************Subsidio Contribucion*****************************/
            this.labelAcueductoSCCargoFijo.Text = $"{caracter}{this.acueducto.calcularValorPorcentaje(valorTotalCargoFijoAceuducto, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAcueductoSCConsumoBasico.Text = $"{caracter}{this.acueducto.calcularValorPorcentaje(valorTotalConsumoBasicoAceuducto, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAcueductoSCConsumoComplementario.Text = $"{caracter}{this.acueducto.calcularValorPorcentaje(valorTotalConsumoComplementarioAceuducto, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAcueductoSCConsumoSuntuario.Text = $"{caracter}{this.acueducto.calcularValorPorcentaje(valorTotalConsumoSuntuarioAceuducto, porcentajeSubsidio, porcentajeContribucion)}";
            /*****************Subtotal*****************************/
            double subtotalCargoFijoAcueducto = this.acueducto.calcularSubtotal(valorTotalCargoFijoAceuducto, porcentajeSubsidio, porcentajeContribucion);
            double subtotalConsumoBasicoAcueducto = this.acueducto.calcularSubtotal(valorTotalConsumoBasicoAceuducto, porcentajeSubsidio, porcentajeContribucion);
            double subtotalConsumoComplementarioAcueducto = this.acueducto.calcularSubtotal(valorTotalConsumoComplementarioAceuducto, porcentajeSubsidio, porcentajeContribucion);
            double subtotalConsumoSuntuarioAcueducto = this.acueducto.calcularSubtotal(valorTotalConsumoSuntuarioAceuducto, porcentajeSubsidio, porcentajeContribucion);
            this.labelAcueductoTotalCargoFijo.Text = Convert.ToString(subtotalCargoFijoAcueducto);
            this.labelAcueductoTotalConsumoBasico.Text = Convert.ToString(subtotalConsumoBasicoAcueducto);
            this.labelAcueductoTotalConsumoComplementario.Text = Convert.ToString(subtotalConsumoComplementarioAcueducto);
            this.labelAcueductoTotalConsumoSuntuario.Text = Convert.ToString(subtotalConsumoSuntuarioAcueducto);
            this.acueducto.Total = subtotalCargoFijoAcueducto + subtotalConsumoBasicoAcueducto + subtotalConsumoComplementarioAcueducto + subtotalConsumoSuntuarioAcueducto;
            this.labelAcueductoTotalSubtotal.Text = Convert.ToString(this.acueducto.Total);


            // Set labels info Alcantarillado
            /*****************Cantidad*****************************/
            this.labelIdAlcantarillado.Text = Convert.ToString(this.alcantarillado.IdAlcantarillado);
            this.labelAlcantarilladoCantidadCargoFijo.Text = "1";
            this.labelAlcantarilladoCantidadConsumoBasico.Text = Convert.ToString(this.alcantarillado.ConsumoBasico);
            this.labelAlcantarilladoCantidadConsumoComplementario.Text = Convert.ToString(this.alcantarillado.ConsumoComplementario);
            this.labelAlcantarilladoCantidadConsumoSuntuario.Text = Convert.ToString(this.alcantarillado.ConsumoSuntuario);
            /*****************Valor Unitario*****************************/
            this.labelAlcantarilladoVUCargoFijo.Text = Convert.ToString(this.tarifasAlcantarillado.CargoFijo);
            this.labelAlcantarilladoVUConsumoBasico.Text = Convert.ToString(this.tarifasAlcantarillado.ConsumoBasico);
            this.labelAlcantarilladoVUConsumoComplementario.Text = Convert.ToString(this.tarifasAlcantarillado.ConsumoComplementario);
            this.labelAlcantarilladoVUConsumoSuntuario.Text = Convert.ToString(this.tarifasAlcantarillado.ConsumoSuntuario);
            /*****************Valor Total*****************************/
            double valorTotalCargoFijoAlcantarillado = this.alcantarillado.calcularVT(1, this.tarifasAlcantarillado.CargoFijo);
            double valorTotalConsumoBasicoAlcantarillado = this.alcantarillado.calcularVT(this.alcantarillado.ConsumoBasico, this.tarifasAlcantarillado.ConsumoBasico);
            double valorTotalConsumoComplementarioAlcantarillado = this.alcantarillado.calcularVT(this.alcantarillado.ConsumoComplementario, this.tarifasAlcantarillado.ConsumoComplementario);
            double valorTotalConsumoSuntuarioAlcantarillado = this.alcantarillado.calcularVT(this.alcantarillado.ConsumoSuntuario, this.tarifasAlcantarillado.ConsumoSuntuario);
            this.labelAlcantarilladoVTCargoFijo.Text = Convert.ToString(valorTotalCargoFijoAlcantarillado);
            this.labelAlcantarilladoVTConsumoBasico.Text = Convert.ToString(valorTotalConsumoBasicoAlcantarillado);
            this.labelAlcantarilladoVTConsumoComplementario.Text = Convert.ToString(valorTotalConsumoComplementarioAlcantarillado);
            this.labelAlcantarilladoVTConsumoSuntuario.Text = Convert.ToString(valorTotalConsumoSuntuarioAlcantarillado);
            /*****************Subsidio Contribucion*****************************/
            this.labelAlcantarilladoSCCargoFijo.Text = $"{caracter}{this.alcantarillado.calcularValorPorcentaje(valorTotalCargoFijoAlcantarillado, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAlcantarilladoSCConsumoBasico.Text = $"{caracter}{this.alcantarillado.calcularValorPorcentaje(valorTotalConsumoBasicoAlcantarillado, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAlcantarilladoSCConsumoComplementario.Text = $"{caracter}{this.alcantarillado.calcularValorPorcentaje(valorTotalConsumoComplementarioAlcantarillado, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAlcantarilladoSCConsumoSuntuario.Text = $"{caracter}{this.alcantarillado.calcularValorPorcentaje(valorTotalConsumoSuntuarioAlcantarillado, porcentajeSubsidio, porcentajeContribucion)}";
            /*****************Subtotal*****************************/
            double subtotalCargoFijoAlcantarillado = this.alcantarillado.calcularSubtotal(valorTotalCargoFijoAlcantarillado, porcentajeSubsidio, porcentajeContribucion);
            double subtotalConsumoBasicoAlcantarillado = this.alcantarillado.calcularSubtotal(valorTotalConsumoBasicoAlcantarillado, porcentajeSubsidio, porcentajeContribucion);
            double subtotalConsumoComplementarioAlcantarillado = this.alcantarillado.calcularSubtotal(valorTotalConsumoComplementarioAlcantarillado, porcentajeSubsidio, porcentajeContribucion);
            double subtotalConsumoSuntuarioAlcantarillado = this.alcantarillado.calcularSubtotal(valorTotalConsumoSuntuarioAlcantarillado, porcentajeSubsidio, porcentajeContribucion);
            this.labelAlcantarilladoTotalCargoFijo.Text = Convert.ToString(subtotalCargoFijoAlcantarillado);
            this.labelAlcantarilladoTotalConsumoBasico.Text = Convert.ToString(subtotalConsumoBasicoAlcantarillado);
            this.labelAlcantarilladoTotalConsumoComplementario.Text = Convert.ToString(subtotalConsumoComplementarioAlcantarillado);
            this.labelAlcantarilladoTotalConsumoSuntuario.Text = Convert.ToString(subtotalConsumoSuntuarioAlcantarillado);
            this.alcantarillado.Total = subtotalCargoFijoAlcantarillado + subtotalConsumoBasicoAlcantarillado + subtotalConsumoComplementarioAlcantarillado + subtotalConsumoSuntuarioAlcantarillado;
            this.labelAlcantarilladoTotalSubtotal.Text = Convert.ToString(this.alcantarillado.Total);


            // Set labels info Aseo
            /*****************Cantidad*****************************/
            this.labelIdAseo.Text = Convert.ToString(this.aseo.IdAseo);
            this.labelAseoCantidadToneladasPorSuscriptor.Text = Convert.ToString(this.aseo.ToneladasPorSuscriptor);
            this.labelAseoCantidadBarridoYLimpieza.Text = Convert.ToString(this.aseo.BarridoYLimpieza);
            this.labelAseoCantidadLimpiezaUrbana.Text = Convert.ToString(this.aseo.LimpiezaUrbana);
            this.labelAseoCantidadComercializacion.Text = Convert.ToString(this.aseo.Comercializacion);
            this.labelAseoCantidadRecoleccionYTransporte.Text = Convert.ToString(this.aseo.RecoleccionYTransporte);
            this.labelAseoCantidadDisposicionFinal.Text = Convert.ToString(this.aseo.DisposicionFinal);
            this.labelAseoCantidadTratamientoLixiviados.Text = Convert.ToString(this.aseo.TrataminetoDeLixiviados);
            this.labelAseoCantidadAprovechamiento.Text = Convert.ToString(this.aseo.TarifaDeAprovechamiento);
            /*****************Valor Unitario*****************************/
            this.labelAseoVUToneladasPorSuscriptor.Text = Convert.ToString(this.tarifasAseo.ToneladasPorSuscriptor);
            this.labelAseoVUBarridoYLimpieza.Text = Convert.ToString(this.tarifasAseo.BarridoYLimpieza);
            this.labelAseoVULimpiezaUrbana.Text = Convert.ToString(this.tarifasAseo.LimpiezaUrbana);
            this.labelAseoVUComercializacion.Text = Convert.ToString(this.tarifasAseo.Comercializacion);
            this.labelAseoVURecoleccionYTransporte.Text = Convert.ToString(this.tarifasAseo.RecoleccionYTransporte);
            this.labelAseoVUDisposicionFinal.Text = Convert.ToString(this.tarifasAseo.DisposicionFinal);
            this.labelAseoVUTratamientoLixiviados.Text = Convert.ToString(this.tarifasAseo.TrataminetoDeLixiviados);
            this.labelAseoVUAprovechamiento.Text = Convert.ToString(this.tarifasAseo.TarifaDeAprovechamiento);
            /*****************Valor Total*****************************/
            double valorTotalToneladasPorSuscriptor = this.aseo.calcularVT(this.aseo.ToneladasPorSuscriptor, this.tarifasAseo.ToneladasPorSuscriptor);
            double valorTotalBarridoYLimpieza = this.aseo.calcularVT(this.aseo.BarridoYLimpieza, this.tarifasAseo.BarridoYLimpieza);
            double valorTotalLimpiezaUrbana = this.aseo.calcularVT(this.aseo.LimpiezaUrbana, this.tarifasAseo.LimpiezaUrbana);
            double valorTotalComercializacion = this.aseo.calcularVT(this.aseo.Comercializacion, this.tarifasAseo.Comercializacion);
            double valorTotalRecoleccionYTransporte = this.aseo.calcularVT(this.aseo.RecoleccionYTransporte, this.tarifasAseo.RecoleccionYTransporte);
            double valorTotalDisposicionFinal = this.aseo.calcularVT(this.aseo.DisposicionFinal, this.tarifasAseo.DisposicionFinal);
            double valorTotalTratamientoLixiviados = this.aseo.calcularVT(this.aseo.TrataminetoDeLixiviados, this.tarifasAseo.TrataminetoDeLixiviados);
            double valorTotalAprovechamiento = this.aseo.calcularVT(this.aseo.TarifaDeAprovechamiento, this.tarifasAseo.TarifaDeAprovechamiento);
            this.labelAseoVTToneladasPorSuscriptor.Text = Convert.ToString(valorTotalToneladasPorSuscriptor);
            this.labelAseoVTBarridoYLimpieza.Text = Convert.ToString(valorTotalBarridoYLimpieza);
            this.labelAseoVTLimpiezaUrbana.Text = Convert.ToString(valorTotalLimpiezaUrbana);
            this.labelAseoVTComercializacion.Text = Convert.ToString(valorTotalComercializacion);
            this.labelAseoVTRecoleccionYTransporte.Text = Convert.ToString(valorTotalRecoleccionYTransporte);
            this.labelAseoVTDisposicionFinal.Text = Convert.ToString(valorTotalDisposicionFinal);
            this.labelAseoVTTratamientoLixiviados.Text = Convert.ToString(valorTotalTratamientoLixiviados);
            this.labelAseoVTAprovechamiento.Text = Convert.ToString(valorTotalAprovechamiento);
            /*****************Subsidio Contribucion*****************************/
            this.labelAseoSCToneladasPorSuscriptor.Text = $"{caracter}{this.aseo.calcularValorPorcentaje(valorTotalToneladasPorSuscriptor, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAseoSCBarridoYLimpieza.Text = $"{caracter}{this.aseo.calcularValorPorcentaje(valorTotalBarridoYLimpieza, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAseoSCLimpiezaUrbana.Text = $"{caracter}{this.aseo.calcularValorPorcentaje(valorTotalLimpiezaUrbana, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAseoSCComercializacion.Text = $"{caracter}{this.aseo.calcularValorPorcentaje(valorTotalComercializacion, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAseoSCRecoleccionYTransporte.Text = $"{caracter}{this.aseo.calcularValorPorcentaje(valorTotalRecoleccionYTransporte, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAseoSCDisposicionFinal.Text = $"{caracter}{this.aseo.calcularValorPorcentaje(valorTotalDisposicionFinal, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAseoSCTratamientoLixiviados.Text = $"{caracter}{this.aseo.calcularValorPorcentaje(valorTotalTratamientoLixiviados, porcentajeSubsidio, porcentajeContribucion)}";
            this.labelAseoSCAprovechamiento.Text = $"{caracter}{this.aseo.calcularValorPorcentaje(valorTotalAprovechamiento, porcentajeSubsidio, porcentajeContribucion)}";
            /*****************Subtotal*****************************/
            double subtotalToneladasPorSuscriptor = this.aseo.calcularSubtotal(valorTotalToneladasPorSuscriptor, porcentajeSubsidio, porcentajeContribucion);
            double subtotalBarridoYLimpieza = this.aseo.calcularSubtotal(valorTotalBarridoYLimpieza, porcentajeSubsidio, porcentajeContribucion);
            double subtotalLimpiezaUrbana = this.aseo.calcularSubtotal(valorTotalLimpiezaUrbana, porcentajeSubsidio, porcentajeContribucion);
            double subtotalComercializacion = this.aseo.calcularSubtotal(valorTotalComercializacion, porcentajeSubsidio, porcentajeContribucion);
            double subtotalRecoleccionYTransporte = this.aseo.calcularSubtotal(valorTotalRecoleccionYTransporte, porcentajeSubsidio, porcentajeContribucion);
            double subtotalDisposicionFinal = this.aseo.calcularSubtotal(valorTotalDisposicionFinal, porcentajeSubsidio, porcentajeContribucion);
            double subtotalTratamientoLixiviados = this.aseo.calcularSubtotal(valorTotalTratamientoLixiviados, porcentajeSubsidio, porcentajeContribucion);
            double subtotalAprovechamiento = this.aseo.calcularSubtotal(valorTotalAprovechamiento, porcentajeSubsidio, porcentajeContribucion);
            this.labelAseoTotalToneladasPorSuscriptor.Text = Convert.ToString(subtotalToneladasPorSuscriptor);
            this.labelAseoTotalBarridoYLimpieza.Text = Convert.ToString(subtotalBarridoYLimpieza);
            this.labelAseoTotalLimpiezaUrbana.Text = Convert.ToString(subtotalLimpiezaUrbana);
            this.labelAseoTotalComercializacion.Text = Convert.ToString(subtotalComercializacion);
            this.labelAseoTotalRecoleccionYTransporte.Text = Convert.ToString(subtotalRecoleccionYTransporte);
            this.labelAseoTotalDisposicionFinal.Text = Convert.ToString(subtotalDisposicionFinal);
            this.labelAseoTotalTratamientoLixiviados.Text = Convert.ToString(subtotalTratamientoLixiviados);
            this.labelAseoTotalAprovechamiento.Text = Convert.ToString(subtotalAprovechamiento);
            this.aseo.Total = subtotalToneladasPorSuscriptor + subtotalBarridoYLimpieza + subtotalLimpiezaUrbana + subtotalComercializacion + subtotalRecoleccionYTransporte + subtotalDisposicionFinal + subtotalTratamientoLixiviados + subtotalAprovechamiento;
            this.labelAseoTotalSubtotal.Text = Convert.ToString(this.aseo.Total);

            // Total a pagar
            this.totalAPagar = this.acueducto.Total + this.alcantarillado.Total + this.aseo.Total;
            this.labelFacturaTotalAPagar.Text = $"{this.totalAPagar} $";

        }

    }
}
