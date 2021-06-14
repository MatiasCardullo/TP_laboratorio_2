using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase que implementa la interfaz IArchivo
    /// </summary>
    /// <typeparam name="T">Parametro de tipo generico</typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo que serializa y guarda los datos en archivo xml.
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a serializar</param>
        /// <returns>Retorna true en caso de haber serializado sin errores
        /// y maneja diferentes excepciones en caso de error lanzando una nueva
        /// excepcion de tipo ArchivosExcepcion</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

        }

        /// <summary>
        /// Metodo que deserializa un achivo xml y lo carga en el la variable pasada por parametro
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Variable donde almacenar el archivo leido, variable de tipo generico</param>
        /// <returns>Retorna true en caso de haberse deserializado correctamente. En caso de error
        /// maneja diferentes tipos de excepciones y lanza una excepcion de tipo ArchivosException</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException( ex);
            }

        }
    }
}
