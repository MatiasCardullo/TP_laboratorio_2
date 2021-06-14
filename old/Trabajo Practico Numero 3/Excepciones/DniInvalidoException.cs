using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje por defecto
        /// </summary>
        public DniInvalidoException() : base("Error de Dni invalido")
        {

        }
        
        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa una excepcion
        /// </summary>
        public DniInvalidoException(Exception e) : base(e.Message)
        {

        }
        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje
        /// </summary>
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
           
        }

        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje y una excepcion
        /// </summary>
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e.InnerException)
        {

        }
    }
}
