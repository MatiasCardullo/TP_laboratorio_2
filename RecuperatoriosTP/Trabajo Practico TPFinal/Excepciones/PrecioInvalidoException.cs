using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion para cuando se ingrese un pulgadas con un formato invalido
    /// a un producto
    /// </summary>
    public class PulgadasInvalidoException : Exception
    {
        public PulgadasInvalidoException()
            :base("Se intento instanciar un objeto con un tamaño invalido ")
        {

        }
    }
}
