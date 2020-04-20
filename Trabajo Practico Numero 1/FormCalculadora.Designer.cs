namespace MiCalculadora
{
	partial class FormCalculadora
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

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblResultado = new System.Windows.Forms.Label();
			this.txtNumero1 = new System.Windows.Forms.TextBox();
			this.cmbOperador = new System.Windows.Forms.ComboBox();
			this.txtNumero2 = new System.Windows.Forms.TextBox();
			this.btnOperar = new System.Windows.Forms.Button();
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnConvertirADecimal = new System.Windows.Forms.Button();
			this.btnConvertirABinario = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblResultado
			// 
			this.lblResultado.AutoSize = true;
			//this.lblResultado.TextAlign = 64;
			this.lblResultado.Location = new System.Drawing.Point(200, 20);
			this.lblResultado.Name = "lblResultado";
			this.lblResultado.Size = new System.Drawing.Size(60, 13);
			//this.lblResultado.Text = "Resultado";
			// 
			// txtNumero1
			// 
			this.txtNumero1.Location = new System.Drawing.Point(40, 40);
			this.txtNumero1.Name = "txtNumero1";
			this.txtNumero1.Size = new System.Drawing.Size(90, 20);
			this.txtNumero1.TabIndex = 0;
			// 
			// cmbOperador
			// 
			this.cmbOperador.Location = new System.Drawing.Point(140, 40);
			this.cmbOperador.Name = "cmbOperador";
			this.cmbOperador.Size = new System.Drawing.Size(30, 20);
			this.cmbOperador.TabIndex = 1;
			this.cmbOperador.Items.AddRange(new object[]{"+","-","/","*"});
			this.cmbOperador.SelectedIndex=0;
			this.cmbOperador.FormattingEnabled = true;
			this.cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;		
			// 
			// txtNumero2
			// 
			this.txtNumero2.Location = new System.Drawing.Point(180, 40);
			this.txtNumero2.Name = "txtNumero2";
			this.txtNumero2.Size = new System.Drawing.Size(90, 20);
			this.txtNumero2.TabIndex = 2;
			// 
			// btnOperar
			// 
			this.btnOperar.Location = new System.Drawing.Point(40, 80);
			this.btnOperar.Name = "btnOperar";
			this.btnOperar.Size = new System.Drawing.Size(70, 30);
			this.btnOperar.TabIndex = 3;
			this.btnOperar.Text = "Operar";
			this.btnOperar.UseVisualStyleBackColor = true;
			this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.Location = new System.Drawing.Point(120, 80);
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.Size = new System.Drawing.Size(70, 30);
			this.btnLimpiar.TabIndex = 4;
			this.btnLimpiar.Text = "Limpiar";
			this.btnLimpiar.UseVisualStyleBackColor = true;
			this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
			// 
			// btnCerrar
			// 
			this.btnCerrar.Location = new System.Drawing.Point(200, 80);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(70, 30);
			this.btnCerrar.TabIndex = 5;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// btnConvertirABinario
			// 
			this.btnConvertirABinario.Location = new System.Drawing.Point(40, 130);
			this.btnConvertirABinario.Name = "btnConvertirABinario";
			this.btnConvertirABinario.Size = new System.Drawing.Size(110, 30);
			this.btnConvertirABinario.TabIndex = 7;
			this.btnConvertirABinario.Text = "Convertir a Binario";
			this.btnConvertirABinario.UseVisualStyleBackColor = true;
			this.btnConvertirABinario.Click += new System.EventHandler(this.btnConvertirABinario_Click);
			// 
			// btnConvertirADecimal
			// 
			this.btnConvertirADecimal.Location = new System.Drawing.Point(155, 130);
			this.btnConvertirADecimal.Name = "btnConvertirADecimal";
			this.btnConvertirADecimal.Size = new System.Drawing.Size(115, 30);
			this.btnConvertirADecimal.TabIndex = 6;
			this.btnConvertirADecimal.Text = "Convertir a Decimal";
			this.btnConvertirADecimal.UseVisualStyleBackColor = true;
			this.btnConvertirADecimal.Click += new System.EventHandler(this.btnConvertirADecimal_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(320,200);
			this.Controls.Add(this.lblResultado);
			this.Controls.Add(this.btnConvertirABinario);
			this.Controls.Add(this.btnConvertirADecimal);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.btnLimpiar);
			this.Controls.Add(this.btnOperar);
			this.Controls.Add(this.txtNumero2);
			this.Controls.Add(this.cmbOperador);
			this.Controls.Add(this.txtNumero1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Calculadora de Matias Cardullo del curso 2ºA";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.TextBox txtNumero1;
		private System.Windows.Forms.ComboBox cmbOperador;
		private System.Windows.Forms.TextBox txtNumero2;
		private System.Windows.Forms.Button btnOperar;
		private System.Windows.Forms.Button btnLimpiar;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.Button btnConvertirADecimal;
		private System.Windows.Forms.Button btnConvertirABinario;
		private System.Windows.Forms.Label lblResultado;
	}
}

