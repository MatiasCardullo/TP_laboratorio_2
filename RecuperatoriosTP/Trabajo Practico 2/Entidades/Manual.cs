using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Manual : Libro
    {
        public ETipo tipo;

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine((string) this);
            retorno.AppendFormat("Tipo: {0}\n", this.tipo);
            return retorno.ToString();
        }

        public static bool operator ==(Manual a, Manual b)
        {
            return ((Libro) a == b && a.tipo == b.tipo);
        }

        public static bool operator !=(Manual a, Manual b)
        {
            return !(a == b);
        }

        public static implicit operator double(Manual m)
        {
            return m._precio;
        }

        public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo) : base(precio, titulo, nombre, apellido)
        {
            this.tipo = tipo;
        }
    }
}
