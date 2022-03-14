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
            SqlDataReader dr = conexion.DataReader(sb.ToString());

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

            // Consulta para obtener valores de tarifas

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

            // Set labels info Alcantarillado
            /*****************Cantidad*****************************/
            this.labelIdAlcantarillado.Text = Convert.ToString(this.alcantarillado.IdAlcantarillado);
            this.labelAlcantarilladoCantidadCargoFijo.Text = "1";
            this.labelAlcantarilladoCantidadConsumoBasico.Text = Convert.ToString(this.alcantarillado.ConsumoBasico);
            this.labelAlcantarilladoCantidadConsumoComplementario.Text = Convert.ToString(this.alcantarillado.ConsumoComplementario);
            this.labelAlcantarilladoCantidadConsumoSuntuario.Text = Convert.ToString(this.alcantarillado.ConsumoSuntuario);

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
    

        }

    }
}
