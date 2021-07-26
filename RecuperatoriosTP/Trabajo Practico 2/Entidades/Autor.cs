using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autor
    {
        private string _nombre;
        private string _apellido;

        public static implicit operator string(Autor a)
        {
            string retorno = a._nombre + " - " + a._apellido;
            return retorno;
        }

        public static bool operator ==(Autor a, Autor b)
        {
            return (a._nombre == b._nombre && a._apellido == b._apellido);
        }

        public static bool operator !=(Autor a, Autor b)
        {
            return !(a == b);
        }


        public Autor(string nombre, string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }
    }
}
