using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;

namespace Testsunitarios
{
    [TestClass]
    public class TestsUnitarios
    {
        /// <summary>
        /// Metodo Test que valida que se instancie bien un objeto Tv
        /// </summary>
        [TestMethod]
        public void Validar_Instancia_Tv()
        {
            Tv tv1 = new Tv(Electrodomestico.EMarcas.Samsung, Electrodomestico.EModelos.ModeloTV1, 30000);
            Tv tv2 = new Tv(Electrodomestico.EMarcas.Samsung, Electrodomestico.EModelos.ModeloTV2, 70000);
            Tv tv3 = new Tv();

            Assert.IsNotNull(tv1);
            Assert.IsNotNull(tv2);
            Assert.IsNotNull(tv3);
        }
        /// <summary>
        /// Metodo test prueba que se instancien objetos Celular
        /// </summary>
        [TestMethod]
        public void Validar_Instancia_Celular()
        {
            Celular cel1 = new Celular(Electrodomestico.EMarcas.Alcatel, Electrodomestico.EModelos.ModeloCelular1, 19000);
            Celular cel2 = new Celular(Electrodomestico.EMarcas.Alcatel, Electrodomestico.EModelos.ModeloCelular2, 22113);
            Celular cel3 = new Celular();


            Assert.IsNotNull(cel1);
            Assert.IsNotNull(cel2);
            Assert.IsNotNull(cel3);
        }

        /// <summary>
        /// Prueba que se lance correctamente la excepcion 
        /// ModeloException al crear un objeto con un modelo invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ModeloException))]
        public void ModeloException_Prueba_Tv()
        {
            Tv tv = new Tv(Electrodomestico.EMarcas.Samsung, Electrodomestico.EModelos.ModeloCelular1, 30000);
        }

        /// <summary>
        /// Prueba que se lance correctamente la excepcion 
        /// ModeloException al crear un objeto con un modelo invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ModeloException))]
        public void ModeloException_Prueba_Celular()
        {
            Celular cel3 = new Celular(Electrodomestico.EMarcas.Alcatel, Electrodomestico.EModelos.ModeloTV1, 19000);
        }

        /// <summary>
        /// Prueba que se imprima correctamente un archivo de texto
        /// </summary>
        [TestMethod]
        public void Prueba_ImprimirTicket()
        {
            Tv tv = new Tv(Electrodomestico.EMarcas.Samsung, Electrodomestico.EModelos.ModeloTV1, 30000);

            Assert.IsTrue(Listas<Tv>.imprimirHistorialVentas(tv, "Lista_Deposito.log")); 
        }
        /// <summary>
        /// Prueba que se lea correctamente de un archivo de texto
        /// </summary>
        [TestMethod]
        public void Prueba_LeerTicket()
        {
            Tv tv = new Tv(Electrodomestico.EMarcas.Samsung, Electrodomestico.EModelos.ModeloTV1, 30000);

            Listas<Tv>.imprimirHistorialVentas(tv, "Lista_Deposito.log");
            string resultado = Listas<Electrodomestico>.Leer("Lista_Deposito.log");

            Assert.IsNotNull(resultado);
        }
    }
}
