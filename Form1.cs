using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            
        }
    }
}
