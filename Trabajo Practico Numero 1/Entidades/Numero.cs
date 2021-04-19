using System;

namespace Entidades
{
	public class Numero
	{
		private double numero;

		public string SetNumero{
			set{
				this.numero = this.ValidarNumero(value);
			}
		}
		
		/// <summary>
		/// Constructor por defecto, asigna valor 0 al atributo numero.
		/// </summary>
		public Numero():this(0){}

		/// <summary>
		/// Constructor que recibe y carga un double
		/// </summary>
		/// <param name="numero">Valor del numero</param>
		public Numero(double numero)
		{
			this.numero= numero;
		}

		/// <summary>
		/// Constructor que recibe y carga un string
		/// </summary>
		/// <param name="strNumero">Valor del numero</param>
		public Numero(string strNumero)
		{
			this.SetNumero= strNumero;
		}

		/// <summary>
		/// Metodo privado, comprueba que el valor recibido sea numérico.
		/// </summary>
		/// <param name="strNumero">Valor a validar</param>
		/// <returns>Devuelve el numero si el valor ingresado es valido o 0 si no lo es</returns>
		private double ValidarNumero(string strNumero)
		{
			double numero;
			if(double.TryParse(strNumero, out numero)){
				return numero;
			}else{
				return 0;
			}
		}
		
		/// <summary>
		/// Convierte un numero de decimal a binario
		/// </summary>
		/// <param name="numero">Numero a ser convertido</param>
		/// <returns>Devuelve un numero binario en formato string, o "Valor invalido" en caso de no poder realizar la conversion</returns>
		public static string DecimalBinario(string numero){
			int resultado;
			if (int.TryParse(numero, out resultado)){
				return Convert.ToString(resultado,2);
			}else{
				return "Valor invalido";
			}
		}

		/// <summary>
		/// Convierte un numero de decimal a binario
		/// </summary>
		/// <param name="numero">Numero a ser convertido</param>
		/// <returns>Devuelve un numero binario en formato string, o "Valor invalido" en caso de no poder realizar la conversion</returns>
		public static string DecimalBinario(double numero){
			return DecimalBinario(numero.ToString());
		}

		/// <summary>
		/// Convierte un numero de binario a decimal
		/// </summary>
		/// <param name="binario">Numero a ser convertido</param>
		/// <returns>Devuelve un numero decimal en formato string, o "Valor invalido" en caso de no poder realizar la conversion</returns>
		public static string BinarioDecimal(string binario){
			int resultado;
			if(EsBinario(binario)){
				int.TryParse(binario, out resultado);
				return Convert.ToInt32(binario, 2).ToString();
			}else{
				return "Valor invalido";
			}
		}

		/// <summary>
		/// Valida que el string sea un numero binario 
		/// </summary>
		/// <param name="binario"></param>
		/// <returns>True si es binario, False si no lo es</returns>
		private static bool EsBinario(string binario)
		{
			for (int i = 0; i < binario.Length; i++){
				if (binario[i] != '1' && binario[i] != '0'){
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Sobrecarga de operador + para la clase numero
		/// </summary>
		/// <param name="A">Primer operando</param>
		/// <param name="B">Segundo operando</param>
		/// <returns>Devuelve la suma de ambos numeros</returns>
		public static double operator +(Numero num1, Numero num2){
			return num1.numero+num2.numero;
		}

		/// <summary>
		/// Sobrecarga de operador - para la clase numero
		/// </summary>
		/// <param name="A">Primer operando</param>
		/// <param name="B">Segundo operando</param>
		/// <returns>Devuelve la resta de ambos numeros</returns>
		public static double operator -(Numero num1, Numero num2){
			return num1.numero-num2.numero;
		}

		/// <summary>
		/// Sobrecarga de operador * para la clase numero
		/// </summary>
		/// <param name="A">Primer operando</param>
		/// <param name="B">Segundo operando</param>
		/// <returns>Devuelve la multiplicación de ambos numeros</returns>
		public static double operator *(Numero num1, Numero num2){
			return num1.numero*num2.numero;
		}

		/// <summary>
		/// Sobrecarga de operador / para la clase numero
		/// </summary>
		/// <param name="A">Primer operando</param>
		/// <param name="B">Segundo operando</param>
		/// <returns>Devuelve la división de ambos numeros o en caso de que el segundo operando sea 0 devuelve 0</returns>
		public static double operator /(Numero num1, Numero num2){
			if(num2.numero!=0){
				return num1.numero/num2.numero;
			}else{
				return 0;	
			}
		}
	}
}
