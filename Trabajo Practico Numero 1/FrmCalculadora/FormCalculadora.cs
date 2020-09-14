using System;
using System.Windows.Forms;
using Entidades;

namespace Program
{
	public partial class FormCalculadora : Form
	{
		public FormCalculadora(){
			InitializeComponent();
			/*cmbOperador.Items.Add("+");
			cmbOperador.Items.Add("-");
			cmbOperador.Items.Add("*");
			cmbOperador.Items.Add("/");*/
			btnConvertirABinario.Enabled = false;
			btnConvertirADecimal.Enabled = false;
		}

		private void btnLimpiar_Click(object sender, EventArgs e){
			this.Limpiar();
		}

		private void btnCerrar_Click(object sender, EventArgs e){
			FormCalculadora.ActiveForm.Close();
		}

		private void btnOperar_Click(object sender, EventArgs e){
			lblResultado.Text = Convert.ToString(FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
			btnConvertirABinario.Enabled = true;
			btnConvertirADecimal.Enabled = false;
		}

		private void btnConvertirABinario_Click(object sender, EventArgs e){
			lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
			btnConvertirABinario.Enabled = false;
			btnConvertirADecimal.Enabled = true;
		}

		private void btnConvertirADecimal_Click(object sender, EventArgs e){
			lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
			btnConvertirABinario.Enabled = true;
			btnConvertirADecimal.Enabled = false;
		}

		/// <summary>
		/// Limpia el formulario colocando los valores por defecto donde corresponda
		/// </summary>
		private void Limpiar(){
			this.txtNumero1.Text = "";
			this.txtNumero2.Text = "";
			this.cmbOperador.Text = "";
			this.lblResultado.Text = "Resultado";
			btnConvertirABinario.Enabled = false;
			btnConvertirADecimal.Enabled = false;
		}

		/// <summary>
		/// Realiza la operacion deseada y devuelve un resultado
		/// </summary>
		/// <param name="numero1">Numero correspondiente al primer textbox</param>
		/// <param name="numero2">Numero correspondiente al segundo textbox</param>
		/// <param name="operador">Operador correspondiente al combobox</param>
		/// <returns>Devuelve el resultado de la operacion realizada</returns>
		private static double Operar(string numero1, string numero2, string operador){
			Numero num1 = new Numero(numero1);
			Numero num2 = new Numero(numero2);
			Calculadora calculadora = new Calculadora();
			return calculadora.Operar(num1, num2, operador);
		}
	}
}
