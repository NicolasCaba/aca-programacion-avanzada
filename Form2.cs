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
            labelIdFactura.Text = Convert.ToString(this.idFactura);
        }

    }
}
