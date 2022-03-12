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
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            DatabaseConnection conexion = new DatabaseConnection();
            conexion.OpenConection();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Usuario.*, Estrato.Clasificacion, Niveles_contribucion.Porcentaje AS NVC, Niveles_subsidio.Porcentaje AS NVS FROM Usuario ");
            sb.Append("LEFT JOIN Estrato ON Usuario.idEstrato = Estrato.id ");
            sb.Append("LEFT JOIN Niveles_subsidio ON Estrato.id = Niveles_subsidio.idEstrato ");
            sb.Append("LEFT JOIN Niveles_contribucion ON Estrato.id = Niveles_contribucion.idEstrato;");

            SqlDataReader dr = conexion.DataReader(sb.ToString());

        

            while (dr.Read())
            {
                label6.Text = dr["NVC"].ToString();
                label6.Text += dr["NVS"].ToString();


            }

            
            
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            
        }
    }
}
