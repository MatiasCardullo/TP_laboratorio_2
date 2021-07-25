using System;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanzara en caso de que se intente hacer alguna accion sobre
    /// el deposito mientras este no este abierto, o si intenten abrir dos al mismo tiempo
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
