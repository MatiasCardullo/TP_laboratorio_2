using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libreria
    {
        private int _capacidad;
        private List<Libro> _libros;

        public int Capacidad
        {
            get
            {
                return _capacidad;
            }

        }
        public double PrecioDeManuales
        {
            get
            {
                return ObtenerPrecio(ELibro.Manual);
            }

        }

        public double PrecioDeNovelas
        {
            get
            {
                return ObtenerPrecio(ELibro.Novela);
            }

        }

        public double PrecioTotal
        {
            get
            {
                return ObtenerPrecio(ELibro.Novela)+ ObtenerPrecio(ELibro.Manual);
            }

        }
        public List<Libro> Libros
        {
            get { return _libros; }
            set { _libros = value; }
        }

        public static string Mostrar(Libreria e)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Capacidad de la biblioteca: {0}\n", e._capacidad);
            retorno.AppendFormat("Total por Manuales: ${0:0.##}\n", e.PrecioDeManuales);
            retorno.AppendFormat("Total por Novelas: ${0:0.##}\n", e.PrecioDeNovelas);
            retorno.AppendFormat("Valor Total: ${0:0.##}\n", e.PrecioTotal);
            retorno.AppendLine("**************************************************");
            retorno.AppendLine("Listado de Libros");
            retorno.AppendLine("**************************************************");
            foreach (Libro item in e._libros)
            {
                retorno.AppendLine("__________________________________________________");
                retorno.AppendLine((string)item);
                /*
                if (item is Manual)
                    retorno.AppendLine(((Manual)item).Mostrar());
                if (item is Novela)
                    retorno.AppendLine(((Novela)item).Mostrar());
                */
            }
            return retorno.ToString();
        }
        public static Libro GetLibro(Libreria e, int id)
        {
            return e.Libros[id];
        }
        public static string MostrarLibro(Libreria e, int id)
        {
            return ((string)GetLibro(e,id));
        }

        public static implicit operator Libreria(int capacidad)
        {
            return new Libreria(capacidad);
        }

        public static bool operator ==(Libreria e, Libro l)
        {
            bool retorno = false;
            foreach (Libro item in e._libros)
            {
                if(item == l)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Libreria e, Libro l)
        {
            return !(e == l);
        }

        public static Libreria operator +(Libreria e, Libro l)
        {
            if(e._libros.Count < e._capacidad)
            {
                foreach (Libro item in e._libros)
                {
                    if (l is Manual && item is Manual)
                    {
                        if((Manual) item == (Manual) l)
                        {
                            return e;
                        }
                    }
                    if (l is Novela && item is Novela)
                    {
                        if ((Novela) item == (Novela)l)
                        {
                            return e;
                        }
                    }              
                }
                e._libros.Add(l);
            }
            return e;
        }

        public static Libreria operator -(Libreria e, int id)
        {
            e._libros.RemoveAt(id);
            return e;
        }

        private double ObtenerPrecio(ELibro tipo)
        {
            double retorno = 0;
            double sumaManuales = 0;
            double sumaNovelas = 0;
            foreach (Libro item in this._libros)
            {
                if (item is Manual)
                    sumaManuales += (Manual)item;
                if (item is Novela)
                    sumaNovelas += (Novela)item;
            }
            switch (tipo)
            {
                case ELibro.Manual:
                    retorno = sumaManuales;
                    break;
                case ELibro.Novela:
                    retorno =  sumaNovelas;
                    break;
                /*case ELibro.Ambos:
                    retorno = sumaManuales + sumaNovelas;
                    break;*/
                default:
                    retorno = sumaManuales + sumaNovelas;
                    break;
            }
            return retorno;
        }

        public string[] Nombres()
        {
            string[] output=new string[_libros.Count];
            for (int i = 0; i < _libros.Count; i++)
            {
                output[i] = _libros[i].Nombre;
            }
            return output;
        }

        private Libreria()
        {
            _libros = new List<Libro>();
        }

        private Libreria(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }
    }
}
