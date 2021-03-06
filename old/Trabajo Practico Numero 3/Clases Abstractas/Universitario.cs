﻿namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        /// <summary>
        /// Constructor por defecto que llama al constructor de la clase base
        /// </summary>
        public Universitario() : base() { }

        /// <summary>
        /// Constructor de Universitario
        /// </summary>
        /// <param name="legajo">Parametro de tipo int</param>
        /// <param name="nombre">Parametro de tipo string</param>
        /// <param name="apellido">Parametro de tipo string</param>
        /// <param name="dni">Parametro de tipo string</param>
        /// <param name="nacionalidad">Parametro de tipo ENacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retornará todos los datos del Universitario.
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + " \nLEGAJO NÚMERO: " + this.legajo + "\n";
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Valida que dos universitarios sean iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo universitario</param>
        /// <returns>(true)En caso de que sean iguales (false)Si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool flag=false;

            if (pg1.Equals(pg2) && pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                flag=true;
            }

            return flag;
        }

        /// <summary>
        /// Valida que dos universitarios sean distintos si y sólo no son del mismo Tipo y su Legajo o DNI no son iguales
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo universitario</param>
        /// <returns>(true) En caso de que sean distintios (false)Si no lo son</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Validar si dos objetos son del mismo tipo
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>(true)Si son del mismo tipo (false)Si no lo son</returns>
        public override bool Equals(object obj)
        {
            bool flag=false;

            if (this.GetType() == obj.GetType())
            {
                flag=true;
            }

            return flag;
        }
        #endregion
    }
}
