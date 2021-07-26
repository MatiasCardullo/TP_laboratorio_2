using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanzara en caso de que se intente hacer alguna accion sobre
    /// el deposito mientras este ya este abierto
    /// </summary>
    public class DepositoAbiertoException : Exception
    {
        public DepositoAbiertoException()
            :base("El deposito ya esta abierto")
        {

        }
        public DepositoAbiertoException(string mensaje)
            :base(mensaje)
        {
            
        }
    }
}
