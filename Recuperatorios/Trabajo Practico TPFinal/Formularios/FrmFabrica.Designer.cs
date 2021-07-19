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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrearDeposito = new System.Windows.Forms.Button();
            this.btnAgregarDeposito = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaInventario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaInventario
            // 
            this.grillaInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaInventario.Location = new System.Drawing.Point(12, 115);
            this.grillaInventario.Name = "grillaInventario";
            this.grillaInventario.Size = new System.Drawing.Size(525, 209);
            this.grillaInventario.TabIndex = 0;
            this.grillaInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaInventario_CellContentClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(6, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(95, 60);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Crear electrodomestico";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(107, 19);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(95, 60);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar electrodomestico fallido";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCrearDeposito
            // 
            this.btnCrearDeposito.Location = new System.Drawing.Point(6, 19);
            this.btnCrearDeposito.Name = "btnCrearDeposito";
            this.btnCrearDeposito.Size = new System.Drawing.Size(95, 60);
            this.btnCrearDeposito.TabIndex = 5;
            this.btnCrearDeposito.Text = "Orden para llevar al deposito";
            this.btnCrearDeposito.UseVisualStyleBackColor = true;
            this.btnCrearDeposito.Click += new System.EventHandler(this.btnCrearDeposito_Click);
            // 
            // btnAgregarDeposito
            // 
            this.btnAgregarDeposito.Location = new System.Drawing.Point(107, 19);
            this.btnAgregarDeposito.Name = "btnAgregarDeposito";
            this.btnAgregarDeposito.Size = new System.Drawing.Size(95, 60);
            this.btnAgregarDeposito.TabIndex = 6;
            this.btnAgregarDeposito.Text = "Llevar producto al deposito";
            this.btnAgregarDeposito.UseVisualStyleBackColor = true;
            this.btnAgregarDeposito.Click += new System.EventHandler(this.btnAgregarDeposito_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(208, 19);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(95, 60);
            this.btnHistorial.TabIndex = 8;
            this.btnHistorial.Text = "Ver listado del deposito";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 97);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producción";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCrearDeposito);
            this.groupBox2.Controls.Add(this.btnAgregarDeposito);
            this.groupBox2.Controls.Add(this.btnHistorial);
            this.groupBox2.Location = new System.Drawing.Point(227, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 97);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deposito";
            // 
            // FrmFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 335);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFabrica";
            this.Text = "Control Fabrica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFabrica_FormClosing);
            this.Load += new System.EventHandler(this.FrmFabrica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaInventario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaInventario;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrearDeposito;
        private System.Windows.Forms.Button btnAgregarDeposito;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

