using System;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor de la clase base y tiene un mensaje por defecto
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {

        }
    }
}
