using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa una innerException
        /// </summary>
        public ArchivosException(Exception innerException) : base("Error en el archivo", innerException)
        {

        }
    }
}
