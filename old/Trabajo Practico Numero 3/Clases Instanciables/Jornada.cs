using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades
        /// <summary>
        /// Propiedad que setea o devuelve una lista de alumnos.
        /// Valida que los valores no sean null, sino lanza una excepcion.
        /// </summary>
        public List<Alumno> Alumnos{
            get { return alumnos; }
            set{
                try { this.alumnos = value; }
                catch (ArgumentNullException e)
                {
                    throw new ArgumentNullException("El valor es nulo", e);
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException("Error al cargar la lista de alumnos", e);
                }

            }
        }


        /// <summary>
        /// Propiedad que setea o devuelve el atributo clase.
        /// Valida que los valores no sean null, sino lanza una excepcion.
        /// </summary>
        public Universidad.EClases Clase{
            get { return clase; }
            set{
                try { this.clase = value; }
                catch (ArgumentNullException e)
                {
                    throw new ArgumentNullException("El valor es nulo", e);
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException("Error al cargar la clase", e);
                }
            }
        }

        /// <summary>
        /// Propiedad que setea o devuelve el atributo instructor.
        /// Valida que los valores no sean null, sino lanza una excepcion.
        /// </summary>
        public Profesor Instructor{
            get { return instructor; }
            set{
                try{ this.instructor = value; }
                catch (ArgumentNullException e)
                {
                    throw new ArgumentNullException("El valor es nulo", e);
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException("Error al cargar la clase", e);
                }
            }
        }
        #endregion

        #region Metodos
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase=clase;
            this.Instructor=instructor;
        }

        /// <summary>
        /// Retornara los datos de la jornada leyendolos desde el archivo de texto
        /// </summary>
        /// <returns>Cadena con los datos de la jornada</returns>
        public static string Leer()
        {
            Texto leer=new Texto();
            string retorno;
            leer.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt", out retorno);
            return retorno;
        }

        /// <summary>
        /// Mostrara todos los datos de la jornada
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("");
            sb.AppendFormat("CLASE DE {0} POR {1} ", this.Clase, this.Instructor.ToString());
            sb.AppendLine("");
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            sb.AppendLine("<------------------------------------------------------------------------------->");
            return sb.ToString();
        }

        /// <summary>
        /// Una jornada será igual a un alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>(true)si participia (false) si no participa</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool flag=false;

            foreach (Alumno alumno in j.alumnos)
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
        /// Un jornada será distinta a un alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>(true)si no aprticipa (false)si participa</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregara al alumno a al jornada sólo si no está previamente cargado
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Si se pudo agregar el alumno, retornara la jornada con ese alumno agregado, sino la retornara sin él</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException(); 
            }

            return j;
        }

        /// <summary>
        /// Guardará los datos dela jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"> Jornada a guardar</param>
        /// <returns>(true)si pudo guardarse (false)caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool flag=false;

            try
            {
                Texto guardar=new Texto();
                guardar.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt", jornada.ToString());
                flag=true;
            }
            catch (Exception)
            {
                flag=false;
            }

            return flag;
        }
        #endregion
    }
}
