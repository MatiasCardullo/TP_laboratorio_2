using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EntidadesAbstractas
{
    public abstract class Electrodomestico
    {
        /// <summary>
        /// Enumerado con los posibles marcas de los electrodomesticos
        /// </summary>
        public enum EMarcas
        {
            Samsung,
            LG
        }
        /// <summary>
        /// Enumerado con los diferentes modelos 
        /// </summary>
        public enum EModelos
        {
            ModeloTV1 ,
            ModeloTV2 ,
            ModeloCelular1 ,
            ModeloCelular2 
        }

        protected EMarcas marca;
        protected EModelos modelo;
        protected double pulgadas;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Electrodomestico()
        {
        }

        /// <summary>
        /// Constructor con parametros,
        /// inicializa los atributos de electrodomestico
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="pulgadas"></param>
        public Electrodomestico(EMarcas marca, EModelos modelo, double pulgadas)
            :this()
        {
            this.marca = marca;
            this.Modelo = modelo;
            this.pulgadas = pulgadas;
        }

        /// <summary>
        /// Propiedad abstracta de lectura y escritura para el 
        /// atributo modelo
        /// </summary>
        public abstract EModelos Modelo { get; set; }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo marca
        /// </summary>
        public EMarcas Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        /// <summary>
        /// propiedad de lectura y escritura para el pulgadas
        /// </summary>
        public double Pulgadas
        {
            get { return this.pulgadas; }
            set { this.pulgadas = value; }
        }

        /// <summary>
        /// Override de tostring, devuelve los datos del electrofomestico 
        /// en una cadena
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Marca: ");
            sb.AppendLine(this.marca.ToString());
            sb.Append("Modelo: ");
            sb.AppendLine(this.modelo.ToString());
            sb.Append("Pulgadas: ");
            sb.AppendLine(this.pulgadas.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Recibe una cadena indicando la marca, y la devuelve como un enumerado
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static EMarcas StringAMarca(string cadena)
        {
            EMarcas retorno = 0;
            switch (cadena)
            {
                case "Samsung":
                    retorno = EMarcas.Samsung;
                    break;
                case "LG":
                    retorno = EMarcas.LG;
                    break;
            }
            return retorno;
        }
        /// <summary>
        /// Recibe una cadena indicando el modelo, y la devuelve como un enumerado
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static EModelos StringAModelo(string cadena)
        {
            EModelos retorno = 0;
            switch (cadena)
            {
                case "ModeloTV1":
                    retorno = EModelos.ModeloTV1;
                    break;
                case "ModeloTV2":
                    retorno = EModelos.ModeloTV2;
                    break;
                case "ModeloCelular1":
                    retorno = EModelos.ModeloCelular1;
                    break;
                case "ModeloCelular2":
                    retorno = EModelos.ModeloCelular2;
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Compara los datos de un electrodomestico con los de una fila de
        /// tipo DATAROW, si son iguales devuelve true
        /// </summary>
        /// <param name="e"></param>
        /// <param name="fila"></param>
        /// <returns></returns>
        public static bool operator ==(Electrodomestico e, DataRow fila)
        {
            if (e.Marca.ToString() == fila["Marca"].ToString() &&
                e.Modelo.ToString() == fila["Modelo"].ToString() &&
                e.Pulgadas == float.Parse(fila["pulgadas"].ToString()))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara los datos de un electrodomestico con los de una fila de
        /// tipo DATAROW, si son distintos devuelve true
        /// </summary>
        /// <param name="e"></param>
        /// <param name="fila"></param>
        /// <returns></returns>
        public static bool operator !=(Electrodomestico e, DataRow fila)
        {
            return !(e == fila);
        }
    }
}
