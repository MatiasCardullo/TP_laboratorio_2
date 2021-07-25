using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Celular : Electrodomestico
    {
        /// <summary>
        /// Enumerado con los tipos de celular
        /// </summary>
        public enum ETipoCelular
        {
            Iphone,
            Android
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Celular():this(0, (EModelos)2, 0)
        {
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        public Celular(EMarcas marca, EModelos modelo, double precio)
            :base(marca, modelo, precio)
        {
        }

        /// <summary>
        /// implementacion de la propiedad abstracta Modelo
        /// GET: devuelve el modelo de la celular
        /// SET: establece el modelo a la celular, validando que este coincida con un modelo de celular
        /// De no coincidir, lanza ModeloException
        /// </summary>
        public override EModelos Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                if (value == EModelos.ModeloCelular1 || value == EModelos.ModeloCelular2)
                {
                    this.modelo = value;
                }
                else
                {
                    throw new ModeloException();
                }
            }
        }

        /// <summary>
        /// Propiedad de lectura, Dependiendo el modelo de la celular, devuelve
        /// un valor de tipo ETipoCelular, indicando su tipo
        /// </summary>
        public ETipoCelular Tipo
        {
            get 
            {
                ETipoCelular ret;
                switch (this.modelo)
                {
                    case EModelos.ModeloCelular1:
                        ret = ETipoCelular.Iphone;
                        break;
                    case EModelos.ModeloCelular2:
                        ret = ETipoCelular.Android;
                        break;
                    default:
                        throw new ModeloException();
                }
                return ret;
            }
        }

        /// <summary>
        /// override de tostring, Devuelve una cadena con todos los datos de la celular
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("Tipo: ");
            sb.AppendLine(this.Tipo.ToString());

            return sb.ToString();
        }
    }
}
