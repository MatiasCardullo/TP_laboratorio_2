using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Libro
    {
        protected Autor _autor;
        protected int _cantidadDePaginas;
        protected static Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;

        public string Nombre
        {
            get
            {
                return this._titulo;
            }
        }
        public float Precio
        {
            get
            {
                return this._precio;
            }
        }
        public int CantidadDePaginas
        {
            get
            {
                if(this._cantidadDePaginas == 0)
                    this._cantidadDePaginas = _generadorDePaginas.Next(10, 580);
                return this._cantidadDePaginas;
            }
        }

        private static string Mostrar(Libro l)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("TITULO: {0} \nCANTIDAD DE PAGINAS: {1} \nAUTOR: {2} \nPRECIO: {3}", l._titulo, l.CantidadDePaginas, (string) l._autor, l._precio);
            return retorno.ToString();
        }

        public static bool operator ==(Libro a, Libro b)
        {
            return (a._autor == b._autor && a._titulo == b._titulo);
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }

        public static explicit operator string(Libro l)
        {
            return Libro.Mostrar(l);
        }

        static Libro()
        {
            _generadorDePaginas = new Random();
        }

        public Libro(float precio, string titulo, string nombre, string apellido) : this(titulo, new Autor(nombre,apellido), precio)
        {
        }

        public Libro(string titulo, Autor autor, float precio)
        {
            this._precio = precio;
            this._titulo = titulo;
            this._autor = autor;
        }
    }
}
