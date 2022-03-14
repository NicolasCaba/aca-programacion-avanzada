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
            sb.Append($"WHERE Factura.id {idFactura};");

            // Consulta para generar datos de la factura
            SqlDataReader dr = conexion.DataReader(sb.ToString());

            // Lectura de datos
            while (dr.Read())
            {
                // Instancia Clase Usuario
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                usuario.Nombre = $"{ dr["Primer_nombre"].ToString() } { dr["Segundo_nombre"].ToString() } { dr["Primer_apellido"].ToString() } { dr["Segundo_apellido"].ToString() }";
                usuario.Estrato = Convert.ToInt32( dr["Estrato"].ToString() );
                usuario.ClaseDeUso = dr["Clase_uso"].ToString();
                usuario.Direccion = dr["Direccion"].ToString();

                // Instancia Clase Acueducto
                Acueducto acueducto = new Acueducto();
                acueducto.IdAcueducto = Convert.ToInt32(dr["idAcueducto"].ToString());
                acueducto.CargoFijo = Convert.ToDouble( dr["Cargo_fijo_Acueducto"].ToString() );
                acueducto.ConsumoBasico = Convert.ToInt32( dr["Consumo_basico_Acueducto"].ToString() );
                acueducto.ConsumoComplementario = Convert.ToInt32( dr["Consumo_complementario_Acueducto"].ToString() );
                acueducto.ConsumoSuntuario = Convert.ToInt32( dr["Consumo_suntuario_Acueducto"].ToString() );

                // Instancia Clase Alcantarillado
                Alcantarillado alcantarillado = new Alcantarillado();
                alcantarillado.IdAlcantarillado = Convert.ToInt32(dr["idAlcantarillado"].ToString());
                alcantarillado.CargoFijo = Convert.ToDouble(dr["Cargo_fijo_Alcantarillado"].ToString());
                alcantarillado.ConsumoBasico = Convert.ToInt32(dr["Consumo_basico_Alcantarillado"].ToString());
                alcantarillado.ConsumoComplementario = Convert.ToInt32(dr["Consumo_complementario_Alcantarillado"].ToString());
                alcantarillado.ConsumoSuntuario = Convert.ToInt32(dr["Consumo_suntuario_Alcantarillado"].ToString());

                // Instancio Clase Aseo
                Aseo aseo = new Aseo();


                //Factura factura = new Factura();
            }

        }

    }
}
