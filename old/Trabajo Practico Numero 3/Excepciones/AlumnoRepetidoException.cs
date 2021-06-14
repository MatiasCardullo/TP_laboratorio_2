using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje por defecto
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido")
        {

        }
    }
}
