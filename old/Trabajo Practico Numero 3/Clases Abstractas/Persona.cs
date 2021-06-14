using System;
using System.Text;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        #region Propiedades
        /// <summary>
        /// Propiedad que setea y devuelve el atributo apellido.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido=this.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad que setea y devuelve el atributo DNI.
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set { this.dni=this.ValidarDni(this.Nacionalidad, value); }
        }
        /// <summary>
        /// Propiedad que setea el atributo DNI.
        /// </summary>
        public string StringToDNI
        {
            set { this.DNI = ValidarDni(this.nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad que setea y devuelve el atributo Nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad=value; }
        }

        /// <summary>
        /// Propiedad que setea y devuelve el atributo nombre.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre=this.ValidarNombreApellido(value); }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que no recibe parametros.
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Atributo de tipo string</param>
        /// <param name="apellido">Atributo de tipo string</param>
        /// <param name="nacionalidad">Atributo de tipo ENacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Atributo de tipo string</param>
        /// <param name="apellido">Atributo de tipo string</param>
        /// <param name="dni">Atributo de tipo int</param>
        /// <param name="nacionalidad">Atributo de tipo ENacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Atributo de tipo string</param>
        /// <param name="apellido">Atributo de tipo string</param>
        /// <param name="dni">Atributo de tipo string</param>
        /// <param name="nacionalidad">Atributo de tipo ENacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion
        
        #region Metodos

        

        /// <summary>
        /// Sobreecribe el metodo ToString.
        /// </summary>
        /// <returns>Los datos de la persona</returns>
        public override string ToString()
        {
            try {
                StringBuilder sb=new StringBuilder();
                sb.AppendFormat("NOMBRE COMPLETO: {1}, {0}", this.Nombre, this.Apellido);
                sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
                sb.AppendLine("");
                return sb.ToString();
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Error en el metodo ToString, no se pudieron interpretar" +
                    "los datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en el metodo ToString, no se pudieron interpretar los datos", e);
            }
        }

        /// <summary>
        /// Metodo que valida un dni. Valida que el numero este dentro del rango permitido
        /// y que se corresponda con la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad">Parametro de nacionalidad</param>
        /// <param name="dato">Parametro del dni a validar</param>
        /// <returns>Devuelve el numero pasado como dni en caso de que sea validado
        /// correctamente. En caso contrario lanza una excepcion del tipo NacionalidadInvalidaException
        /// o del tipo DniInvalidoExcepcion segun corresponda</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        { 
            int auxiliar;
            bool flag=false;
            if (dato.Length <= 8 && dato.Length >= 1 && int.TryParse(dato, out auxiliar))
            {
                if (nacionalidad == ENacionalidad.Argentino && auxiliar > 0 && auxiliar < 90000000)
                {
                    flag=true;
                }
                else if (nacionalidad == ENacionalidad.Extranjero && auxiliar > 89999999 && auxiliar < 100000000)
                {
                    flag=true;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else
            {
                throw new DniInvalidoException("Formato de DNI incorrecto");
            }    
            if (flag == false)
                auxiliar=0;

            return auxiliar;
        }

        /// <summary>
        /// Sobrecarga del metodo ValidarDni(ENacionalidad nacionalidad, string dato) para validar el numero recibido
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni a validar, de tipo string</param>
        /// <returns>El DNI en formato int</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Metodo para validar que las cadenas contengan caracteres válidos para nombres o apellidos.
        /// Caso contrario, se cargará en blanco.
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar</param>
        /// <returns>Nombre validado o una cadena vacia si no cumple los requisitos</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool isValid=true;
            foreach (char c in dato)
            {
                if (!char.IsLetter(c))
                {
                    isValid = false;
                    break;
                }
            }
            if (!isValid)
            {
                dato="";
            }
            return dato;
        }
        #endregion

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
