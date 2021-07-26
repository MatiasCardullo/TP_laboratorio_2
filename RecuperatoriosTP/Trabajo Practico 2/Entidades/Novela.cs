using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Novela : Libro
    {
        public EGenero genero;

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine((string)this);
            retorno.AppendFormat("Tipo: {0}\n", this.genero);
            return retorno.ToString();
        }

        public static bool operator ==(Novela a, Novela b)
        {
            return ((Libro)a == b && a.genero == b.genero);
        }

        public static bool operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }

        public static implicit operator double(Novela m)
        {
            return m._precio;
        }

        public Novela(string titulo, float precio, Autor autor, EGenero genero) : base(titulo, autor, precio)
        {
            this.genero = genero;
        }
    }
}
