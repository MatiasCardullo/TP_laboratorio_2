namespace Formularios
{
    partial class FrmFabrica
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grillaInventario = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrearDeposito = new System.Windows.Forms.Button();
            this.btnAgregarDeposito = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.imgPublicidad = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPublicidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaInventario
            // 
            this.grillaInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaInventario.Location = new System.Drawing.Point(12, 100);
            this.grillaInventario.Name = "grillaInventario";
            this.grillaInventario.Size = new System.Drawing.Size(526, 211);
            this.grillaInventario.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(6, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 50);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Crear producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(240, 34);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(80, 50);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Corregir item seleccionado";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(112, 19);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 50);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar producto fallido";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCrearDeposito
            // 
            this.btnCrearDeposito.Location = new System.Drawing.Point(6, 19);
            this.btnCrearDeposito.Name = "btnCrearDeposito";
            this.btnCrearDeposito.Size = new System.Drawing.Size(100, 50);
            this.btnCrearDeposito.TabIndex = 5;
            this.btnCrearDeposito.Text = "Orden para llevar al deposito";
            this.btnCrearDeposito.UseVisualStyleBackColor = true;
            this.btnCrearDeposito.Click += new System.EventHandler(this.btnCrearDeposito_Click);
            // 
            // btnAgregarDeposito
            // 
            this.btnAgregarDeposito.Location = new System.Drawing.Point(112, 19);
            this.btnAgregarDeposito.Name = "btnAgregarDeposito";
            this.btnAgregarDeposito.Size = new System.Drawing.Size(100, 50);
            this.btnAgregarDeposito.TabIndex = 6;
            this.btnAgregarDeposito.Text = "Llevar producto al deposito";
            this.btnAgregarDeposito.UseVisualStyleBackColor = true;
            this.btnAgregarDeposito.Click += new System.EventHandler(this.btnAgregarDeposito_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(218, 19);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(100, 50);
            this.btnHistorial.TabIndex = 8;
            this.btnHistorial.Text = "Ver listado del deposito";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // imgPublicidad
            // 
            this.imgPublicidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgPublicidad.Location = new System.Drawing.Point(544, 100);
            this.imgPublicidad.Name = "imgPublicidad";
            this.imgPublicidad.Size = new System.Drawing.Size(210, 210);
            this.imgPublicidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPublicidad.TabIndex = 9;
            this.imgPublicidad.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 79);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producción de electrodomésticos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCrearDeposito);
            this.groupBox2.Controls.Add(this.btnAgregarDeposito);
            this.groupBox2.Controls.Add(this.btnHistorial);
            this.groupBox2.Location = new System.Drawing.Point(326, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 79);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deposito";
            // 
            // FrmFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(762, 323);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.imgPublicidad);
            this.Controls.Add(this.grillaInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFabrica";
            this.Text = "Fabrica de Electrodomesticos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFabrica_FormClosing);
            this.Load += new System.EventHandler(this.FrmFabrica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPublicidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaInventario;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrearDeposito;
        private System.Windows.Forms.Button btnAgregarDeposito;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.PictureBox imgPublicidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

