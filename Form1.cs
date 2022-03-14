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
    public partial class Home : Form
    {
        int idFactura;

        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            // Deseactivacion btnGenerarFacturar
            btnGenerarFactura.Enabled = false;

            // Conexion base de datos
            DatabaseConnection conexion = new DatabaseConnection();
            conexion.OpenConection();

            // String query para realizar las consultas
            StringBuilder sb = new StringBuilder();

            // Consultas SQL para tener valores de cargos fijos
            sb.Append("SELECT ");
            /*****************************************/
            sb.Append("Tarifas_acueducto.Cargo_fijo AS Cargo_fijo_Acueducto, ");
            sb.Append("Tarifas_alcantarillado.Cargo_fijo AS Cargo_fijo_Alcantarillado ");
            /*****************************************/
            sb.Append("FROM Factura ");
            /*****************************************/
            sb.Append("LEFT JOIN Usuario ON Usuario.id = Factura.idUsuario ");
            sb.Append("LEFT JOIN Estrato ON Estrato.id = Usuario.idEstrato ");
            sb.Append("LEFT JOIN Tarifas_acueducto ON Estrato.id = Tarifas_acueducto.idEstrato ");
            sb.Append("LEFT JOIN Tarifas_alcantarillado ON Estrato.id = Tarifas_alcantarillado.idEstrato;");

            // Consulta para obtener valores de cargo fijo Acueducto y Alcantarillado
            SqlDataReader drTarifas = conexion.DataReader(sb.ToString());

            // Lectura de datos y guardado en variables
            drTarifas.Read();
            decimal cargoFijoAcueducto = Convert.ToDecimal( drTarifas["Cargo_fijo_Acueducto"].ToString() );
            decimal cargoFijoAlcantarillado = Convert.ToDecimal( drTarifas["Cargo_fijo_Alcantarillado"].ToString() );

            // Cierre sqlDataReader y limpieza string para nueva query
            drTarifas.Close();
            sb.Clear();

            // Query para rellenar la dataGridView
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
            sb.Append("Niveles_subsidio.Porcentaje AS Porcentaje_subsidio ");
            /*****************************************/
            sb.Append("FROM Factura ");
            /*****************************************/
            sb.Append("LEFT JOIN Usuario ON Usuario.id = Factura.idUsuario ");
            sb.Append("LEFT JOIN Acueducto ON Acueducto.id = Factura.idAcueducto ");
            sb.Append("LEFT JOIN Alcantarillado ON Alcantarillado.id = Factura.idAlcantarillado ");
            sb.Append("LEFT JOIN Aseo ON Aseo.id = Factura.idAseo ");
            sb.Append("LEFT JOIN Estrato ON Estrato.id = Usuario.idEstrato ");
            sb.Append("LEFT JOIN Niveles_subsidio ON Estrato.id = Niveles_subsidio.idEstrato ");
            sb.Append("LEFT JOIN Niveles_contribucion ON Estrato.id = Niveles_contribucion.idEstrato;");

            // Consulta para rellenar la tabla
            SqlDataReader dr = conexion.DataReader(sb.ToString());

            // Lectura de datos
            while (dr.Read())
            {
                // Nueva fila en tabla
                int row = datosCuentaUsuario.Rows.Add();
                // Ingreso de datos de la consulta en la tabla
                datosCuentaUsuario.Rows[row].Cells[0].Value = dr["idFactura"].ToString();
                datosCuentaUsuario.Rows[row].Cells[1].Value = $"{ dr["Primer_nombre"].ToString() } { dr["Segundo_nombre"].ToString() } { dr["Primer_apellido"].ToString() } { dr["Segundo_apellido"].ToString() }";
                datosCuentaUsuario.Rows[row].Cells[2].Value = dr["Estrato"].ToString();
                datosCuentaUsuario.Rows[row].Cells[3].Value = dr["Clase_uso"].ToString();
                datosCuentaUsuario.Rows[row].Cells[4].Value = dr["Direccion"].ToString();
                datosCuentaUsuario.Rows[row].Cells[5].Value = cargoFijoAcueducto;
                datosCuentaUsuario.Rows[row].Cells[6].Value = dr["Consumo_basico_Acueducto"].ToString();
                datosCuentaUsuario.Rows[row].Cells[7].Value = dr["Consumo_complementario_Acueducto"].ToString();
                datosCuentaUsuario.Rows[row].Cells[8].Value = dr["Consumo_suntuario_Acueducto"].ToString();
                datosCuentaUsuario.Rows[row].Cells[9].Value = cargoFijoAlcantarillado;
                datosCuentaUsuario.Rows[row].Cells[10].Value = dr["Consumo_basico_Alcantarillado"].ToString();
                datosCuentaUsuario.Rows[row].Cells[11].Value = dr["Consumo_complementario_Alcantarillado"].ToString();
                datosCuentaUsuario.Rows[row].Cells[12].Value = dr["Consumo_suntuario_Alcantarillado"].ToString();
                datosCuentaUsuario.Rows[row].Cells[13].Value = dr["Toneladas_por_suscriptor"].ToString();
                datosCuentaUsuario.Rows[row].Cells[14].Value = dr["Barrido_y_limpieza"].ToString();
                datosCuentaUsuario.Rows[row].Cells[15].Value = dr["Limpieza_urbana"].ToString();
                datosCuentaUsuario.Rows[row].Cells[16].Value = dr["Comercializacion"].ToString();
                datosCuentaUsuario.Rows[row].Cells[17].Value = dr["Recoleccion_y_transporte"].ToString();
                datosCuentaUsuario.Rows[row].Cells[18].Value = dr["Disposicion_final"].ToString();
                datosCuentaUsuario.Rows[row].Cells[19].Value = dr["Tratamiento_lixiviados"].ToString();
                datosCuentaUsuario.Rows[row].Cells[20].Value = dr["Aprovechamiento"].ToString();
        
            }

            dr.Close();
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            // Instancia FormFactura
            using (FormFactura ventanaFactura = new FormFactura(idFactura))
            {
                ventanaFactura.ShowDialog();
            }
        }

        private void datosCuentaUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Index de la fila en donde se dio click
            int n = e.RowIndex;

            if (n != -1)
            {
                labelNumeroCuenta.Text = $"Número de cuenta seleccionado: { (string)datosCuentaUsuario.Rows[n].Cells[0].Value }";
                // Valor idFactura para la generacion de la factura en el FormFactura
                idFactura = Convert.ToInt32( datosCuentaUsuario.Rows[n].Cells[0].Value );
                // Activa boton verificando que exista un id seleccionado
                btnGenerarFactura.Enabled = true;
            }
        }
    }
}
