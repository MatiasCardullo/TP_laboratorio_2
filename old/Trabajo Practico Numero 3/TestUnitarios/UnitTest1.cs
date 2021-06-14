using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Excepciones;
using ClasesAbstractas;
using ClasesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testea que se lance la Excepcion DniInvalidoException cuando
        /// se intenta incorporar un alumno con un dni invalido
        /// </summary>
        [TestMethod]
        public void TestDniInvalido()
        {
            try
            {
                //Arrange and Act
                Alumno a = new Alumno(2, "Juan", "Perez", "1abc5678", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                //Assert
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Testea que se lance la Excepcion AlumnoRepetidoException cuando
        /// se intenta incorporar a la lista de Alumnos de la Universidad
        /// dos alumnos con el mismo id y el mismo Dni
        /// </summary>
        [TestMethod]
        public void TestAlumnoRepetido()
        {
            //Arrange
            Universidad uni = new Universidad();
            Alumno a = new Alumno(2, "Juan", "Cruz", "35486456", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Alumno a1 = new Alumno(2, "Juan", "Cruz", "35486456", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD); 
            try
            {
                //Act
                uni += a;
                uni += a1;
            }
            catch (Exception e)
            {
                //Assert
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Testea que se lance la Excepcion SinProfesorException al querer crear un objeto Jornada  
        /// sin haber profesores que tengan el atributo EClases.SPD
        /// </summary>
        [TestMethod]
        public void TestSinProfesor()
        {
            //Arrange
            Universidad uni = new Universidad();
            //Act
            try
            {
                uni += Universidad.EClases.SPD;
            }
            catch (Exception e)
            {
                //Assert
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }

        }

    }
}
