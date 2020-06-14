using System;
using System.Collections.Generic;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Propiedades
        public List<Alumno> Alumnos { get; set; }

        public List<Profesor> Instructores { get; set; }

        public List<Jornada> Jornadas { get; set; }

        public Jornada this[int i]
        {
            get { return this.Jornadas[i]; }
            set { this.Jornadas[i]=value; }
        }
        #endregion

        #region Metodos
        public Universidad()
        {
            this.Alumnos=new List<Alumno>();
            this.Instructores=new List<Profesor>();
            this.Jornadas=new List<Jornada>();
        }

        /// <summary>
        /// Serializará los datos de la universidad en un XML, incluyendo todos los datos de sus
        /// profesores, alumnos y jornadas
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>(true)si se pudo serializar (false)caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            bool saved=false;
            Xml<Universidad> file=new Xml<Universidad>();
            if (file.Guardar("Universidad.xml", uni))
            {
                saved=true;
            }
            return saved;
        }

        /// <summary>
        ///  retornará una universidad con todos los datos previamente serializados
        /// </summary>
        /// <returns>Universidad con todos los datos cargados</returns>
        public Universidad Leer()
        {
            Universidad u=new Universidad();
            Xml<Universidad> file=new Xml<Universidad>();
            file.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.txt", out u);
            return u;
        }

        /// <summary>
        /// Retornara todos los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Cadena con los datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            string retorno="JORNADA:";
            foreach (Jornada jornada in uni.Jornadas)
            {
                retorno += jornada.ToString();
            }
            return retorno;
        }

        /// <summary>
        /// Devolvera los datos de la universidad
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Una universidad será igual a un alumno si el mismo está inscripto en ella
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>(true)si esta inscripto (false)si no esta inscripto</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool flag=false;

            foreach (Alumno alumno in u.Alumnos)
            {
                if (alumno == a)
                {
                    flag=true;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// Una universidad será distinta a un alumno si el mismo no esta inscripto en ella
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>(true)si no esta inscripto (false)si esta inscripto</returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Una universidad será igual a un profesor si el mismo está dando clases en ella
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="p">Profesor</param>
        /// <returns>(true)si esta dando clases (false)si no esta dando clases</returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            bool flag=false;

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == p)
                {
                    flag=true;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// Una universidad será distinta a un profesor si el mismo no está dando clases en ella
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="p">Profesor</param>
        /// <returns>(true)si no esta dando clases (false)si esta dando clases</returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        ///  Retornará el primer profesor capaz de dar esa clase.
        ///  Sino, lanzará la Excepción SinProfesorException
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor capaz de dar la clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesorRetorno=null;
            bool flag=false;

            foreach (Profesor p in u.Instructores)

            {
                if (p == clase)
                {
                    profesorRetorno=p;
                    flag=true;
                    break;
                }
            }

            if (!flag)
                throw new SinProfesorException();

            return profesorRetorno;
        }

        /// <summary>
        /// Retornará el primer profesor que no pueda dar la clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor que no puede dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesorRetorno=null;
            bool flag=false;

            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    profesorRetorno=p;
                    flag=true;
                    break;
                }
            }

            if (!flag)
                throw new SinProfesorException();

            return profesorRetorno;
        }

        /// <summary>
        ///  Genera y agrega una nueva Jornada indicando la clase, 
        ///  un profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la toman
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Universidad con la nueva jornada</returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Profesor profesor;

            profesor= u==clase;

            Jornada nuevaJornada=new Jornada(clase, profesor);
            foreach (Alumno alumno in u.Alumnos)
            {
                if (alumno == clase)
                {
                   nuevaJornada += alumno;
                }
            }

            u.Jornadas.Add(nuevaJornada);

            return u;
        }

        /// <summary>
        /// Agregara al alumno a la universidad validando que no esté previamente
        /// cargado
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad con el alumno agregado</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
                if (u != a)
                {
                    u.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }

            return u;
        }

        /// <summary>
        /// Agregara el profesor a la universidad validando que no esté previamente
        /// cargado
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="p">Profesor</param>
        /// <returns>Universidad con el profesor agregado</returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
                if (u != p)
                {
                    u.Instructores.Add(p);
                }

            return u;
        }
        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }
    }
}
