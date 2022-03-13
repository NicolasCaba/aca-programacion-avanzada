
namespace aca1
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.label1 = new System.Windows.Forms.Label();
            this.datosCuentaUsuario = new System.Windows.Forms.DataGridView();
            this.numeroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoFijoAcueducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumoBasicoAcueducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumoComplementarioAcueducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumoSuntuarioAcueducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoFijoAlcantarillado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumoBasicoAlcantarillado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumoComplementarioAlcantarillado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumoSuntuarioAlcantarillado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toneladasPorSuscriptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barridoYLimpieza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limpiezaUrbana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comercializacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recoleccionYTransporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disposicionFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tratamientoDeLixiviados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarifaDeAprovechamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNuevoUsuario = new System.Windows.Forms.Button();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.labelNumeroCuenta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datosCuentaUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(391, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acueducto, Alcantarillado y Aseo Generacion de factura";
            // 
            // datosCuentaUsuario
            // 
            this.datosCuentaUsuario.BackgroundColor = System.Drawing.Color.White;
            this.datosCuentaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datosCuentaUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroCuenta,
            this.nombre,
            this.estrato,
            this.uso,
            this.direccion,
            this.cargoFijoAcueducto,
            this.consumoBasicoAcueducto,
            this.consumoComplementarioAcueducto,
            this.consumoSuntuarioAcueducto,
            this.cargoFijoAlcantarillado,
            this.consumoBasicoAlcantarillado,
            this.consumoComplementarioAlcantarillado,
            this.consumoSuntuarioAlcantarillado,
            this.toneladasPorSuscriptor,
            this.barridoYLimpieza,
            this.limpiezaUrbana,
            this.comercializacion,
            this.recoleccionYTransporte,
            this.disposicionFinal,
            this.tratamientoDeLixiviados,
            this.tarifaDeAprovechamiento});
            this.datosCuentaUsuario.Location = new System.Drawing.Point(10, 189);
            this.datosCuentaUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.datosCuentaUsuario.Name = "datosCuentaUsuario";
            this.datosCuentaUsuario.ReadOnly = true;
            this.datosCuentaUsuario.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.datosCuentaUsuario.RowTemplate.Height = 25;
            this.datosCuentaUsuario.ShowEditingIcon = false;
            this.datosCuentaUsuario.Size = new System.Drawing.Size(1262, 361);
            this.datosCuentaUsuario.TabIndex = 1;
            this.datosCuentaUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datosCuentaUsuario_CellContentClick);
            // 
            // numeroCuenta
            // 
            this.numeroCuenta.HeaderText = "# Cuenta";
            this.numeroCuenta.Name = "numeroCuenta";
            this.numeroCuenta.ReadOnly = true;
            this.numeroCuenta.Width = 60;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 112;
            // 
            // estrato
            // 
            this.estrato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estrato.HeaderText = "Estrato";
            this.estrato.Name = "estrato";
            this.estrato.ReadOnly = true;
            this.estrato.Width = 55;
            // 
            // uso
            // 
            this.uso.HeaderText = "Uso";
            this.uso.Name = "uso";
            this.uso.ReadOnly = true;
            this.uso.Width = 70;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Dirección";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Width = 118;
            // 
            // cargoFijoAcueducto
            // 
            this.cargoFijoAcueducto.HeaderText = "Cargo Fijo Acueducto";
            this.cargoFijoAcueducto.Name = "cargoFijoAcueducto";
            this.cargoFijoAcueducto.ReadOnly = true;
            this.cargoFijoAcueducto.Width = 80;
            // 
            // consumoBasicoAcueducto
            // 
            this.consumoBasicoAcueducto.HeaderText = "Consumo Basico Acueducto";
            this.consumoBasicoAcueducto.Name = "consumoBasicoAcueducto";
            this.consumoBasicoAcueducto.ReadOnly = true;
            this.consumoBasicoAcueducto.Width = 80;
            // 
            // consumoComplementarioAcueducto
            // 
            this.consumoComplementarioAcueducto.HeaderText = "Consumo Complementario Acueducto";
            this.consumoComplementarioAcueducto.Name = "consumoComplementarioAcueducto";
            this.consumoComplementarioAcueducto.ReadOnly = true;
            this.consumoComplementarioAcueducto.Width = 125;
            // 
            // consumoSuntuarioAcueducto
            // 
            this.consumoSuntuarioAcueducto.HeaderText = "Consumo Suntuario Acueducto";
            this.consumoSuntuarioAcueducto.Name = "consumoSuntuarioAcueducto";
            this.consumoSuntuarioAcueducto.ReadOnly = true;
            this.consumoSuntuarioAcueducto.Width = 80;
            // 
            // cargoFijoAlcantarillado
            // 
            this.cargoFijoAlcantarillado.HeaderText = "Cargo Fijo Alcantarillado";
            this.cargoFijoAlcantarillado.Name = "cargoFijoAlcantarillado";
            this.cargoFijoAlcantarillado.ReadOnly = true;
            this.cargoFijoAlcantarillado.Width = 80;
            // 
            // consumoBasicoAlcantarillado
            // 
            this.consumoBasicoAlcantarillado.HeaderText = "Consumo Basico Alcantarillado";
            this.consumoBasicoAlcantarillado.Name = "consumoBasicoAlcantarillado";
            this.consumoBasicoAlcantarillado.ReadOnly = true;
            this.consumoBasicoAlcantarillado.Width = 80;
            // 
            // consumoComplementarioAlcantarillado
            // 
            this.consumoComplementarioAlcantarillado.HeaderText = "Consumo Complementario Alcantarillado";
            this.consumoComplementarioAlcantarillado.Name = "consumoComplementarioAlcantarillado";
            this.consumoComplementarioAlcantarillado.ReadOnly = true;
            this.consumoComplementarioAlcantarillado.Width = 125;
            // 
            // consumoSuntuarioAlcantarillado
            // 
            this.consumoSuntuarioAlcantarillado.HeaderText = "Consumo Suntuario Alcantarillado";
            this.consumoSuntuarioAlcantarillado.Name = "consumoSuntuarioAlcantarillado";
            this.consumoSuntuarioAlcantarillado.ReadOnly = true;
            this.consumoSuntuarioAlcantarillado.Width = 80;
            // 
            // toneladasPorSuscriptor
            // 
            this.toneladasPorSuscriptor.HeaderText = "Toneladas Por Suscriptor Aseo";
            this.toneladasPorSuscriptor.Name = "toneladasPorSuscriptor";
            this.toneladasPorSuscriptor.ReadOnly = true;
            this.toneladasPorSuscriptor.Width = 80;
            // 
            // barridoYLimpieza
            // 
            this.barridoYLimpieza.HeaderText = "Barrido y Limpieza Aseo";
            this.barridoYLimpieza.Name = "barridoYLimpieza";
            this.barridoYLimpieza.ReadOnly = true;
            this.barridoYLimpieza.Width = 70;
            // 
            // limpiezaUrbana
            // 
            this.limpiezaUrbana.HeaderText = "Limpieza Urbana Aseo";
            this.limpiezaUrbana.Name = "limpiezaUrbana";
            this.limpiezaUrbana.ReadOnly = true;
            // 
            // comercializacion
            // 
            this.comercializacion.HeaderText = "Comercialización Aseo";
            this.comercializacion.Name = "comercializacion";
            this.comercializacion.ReadOnly = true;
            this.comercializacion.Width = 125;
            // 
            // recoleccionYTransporte
            // 
            this.recoleccionYTransporte.HeaderText = "Recoleccion y Transporte Aseo";
            this.recoleccionYTransporte.Name = "recoleccionYTransporte";
            this.recoleccionYTransporte.ReadOnly = true;
            this.recoleccionYTransporte.Width = 98;
            // 
            // disposicionFinal
            // 
            this.disposicionFinal.HeaderText = "Disposicion Final Aseo";
            this.disposicionFinal.Name = "disposicionFinal";
            this.disposicionFinal.ReadOnly = true;
            this.disposicionFinal.Width = 98;
            // 
            // tratamientoDeLixiviados
            // 
            this.tratamientoDeLixiviados.HeaderText = "Tratamiento de Lixiviados Aseo";
            this.tratamientoDeLixiviados.Name = "tratamientoDeLixiviados";
            this.tratamientoDeLixiviados.ReadOnly = true;
            this.tratamientoDeLixiviados.Width = 98;
            // 
            // tarifaDeAprovechamiento
            // 
            this.tarifaDeAprovechamiento.HeaderText = "Tarifa de Aprovechamiento Aseo";
            this.tarifaDeAprovechamiento.Name = "tarifaDeAprovechamiento";
            this.tarifaDeAprovechamiento.ReadOnly = true;
            this.tarifaDeAprovechamiento.Width = 130;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::aca1.Properties.Resources.Acueducto_logo;
            this.pictureBox1.Location = new System.Drawing.Point(50, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 59);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::aca1.Properties.Resources.Aseo;
            this.pictureBox2.Location = new System.Drawing.Point(1137, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(135, 34);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(630, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Para generar una factura seleccione una fila de la tabla y de click en el boton \"" +
    "Generar factura\"";
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.Location = new System.Drawing.Point(162, 139);
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Size = new System.Drawing.Size(113, 23);
            this.btnNuevoUsuario.TabIndex = 10;
            this.btnNuevoUsuario.Text = "Nuevo usuario";
            this.btnNuevoUsuario.UseVisualStyleBackColor = true;
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Location = new System.Drawing.Point(352, 139);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(128, 23);
            this.btnGenerarFactura.TabIndex = 11;
            this.btnGenerarFactura.Text = "Generar factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // labelNumeroCuenta
            // 
            this.labelNumeroCuenta.AutoSize = true;
            this.labelNumeroCuenta.ForeColor = System.Drawing.Color.Red;
            this.labelNumeroCuenta.Location = new System.Drawing.Point(50, 169);
            this.labelNumeroCuenta.Name = "labelNumeroCuenta";
            this.labelNumeroCuenta.Size = new System.Drawing.Size(230, 17);
            this.labelNumeroCuenta.TabIndex = 12;
            this.labelNumeroCuenta.Text = "Número de cuenta seleccionada: ";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.labelNumeroCuenta);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.btnNuevoUsuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.datosCuentaUsuario);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acueducto y Aseo";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datosCuentaUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datosCuentaUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNuevoUsuario;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn estrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn uso;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoFijoAcueducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumoBasicoAcueducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumoComplementarioAcueducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumoSuntuarioAcueducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoFijoAlcantarillado;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumoBasicoAlcantarillado;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumoComplementarioAlcantarillado;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumoSuntuarioAlcantarillado;
        private System.Windows.Forms.DataGridViewTextBoxColumn toneladasPorSuscriptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn barridoYLimpieza;
        private System.Windows.Forms.DataGridViewTextBoxColumn limpiezaUrbana;
        private System.Windows.Forms.DataGridViewTextBoxColumn comercializacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn recoleccionYTransporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn disposicionFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tratamientoDeLixiviados;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarifaDeAprovechamiento;
        private System.Windows.Forms.Label labelNumeroCuenta;
    }
}

