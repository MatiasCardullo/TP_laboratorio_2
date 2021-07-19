using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancio un par de objetos
            Tv tv1 = new Tv(Electrodomestico.EMarcas.Samsung, Electrodomestico.EModelos.ModeloTV1, 30000);
            Tv tv2 = new Tv(Electrodomestico.EMarcas.Samsung, Electrodomestico.EModelos.ModeloTV2, 70000);
            Celular cel1 = new Celular(Electrodomestico.EMarcas.Alcatel, Electrodomestico.EModelos.ModeloCelular1, 19000);
            Celular cel2 = new Celular(Electrodomestico.EMarcas.Alcatel, Electrodomestico.EModelos.ModeloCelular1, 22113);

            //Instancio un par de objetos esperando excepciones
            try
            {
                Tv tv3 = new Tv(Electrodomestico.EMarcas.Samsung, Electrodomestico.EModelos.ModeloCelular1, 30000);
            }
            catch(ModeloException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Celular cel3 = new Celular(Electrodomestico.EMarcas.Alcatel, Electrodomestico.EModelos.ModeloTV1, 19000);
            }
            catch (ModeloException e)
            {
                Console.WriteLine(e.Message);
            }

            //Muestro los objetos
            Console.WriteLine(tv1.ToString());
            Console.WriteLine(cel1.ToString());
            Console.WriteLine(tv2.ToString());
            Console.WriteLine(cel2.ToString());

            Console.ReadLine();
            Console.Clear();

            try
            {
                //Imprimo un par de tickets
                Listas<Tv>.imprimirHistorialVentas(tv1, "Lista_Deposito.log");
                Listas<Celular>.imprimirHistorialVentas(cel1, "Lista_Deposito.log");
                Listas<Tv>.imprimirHistorialVentas(tv2, "Lista_Deposito.log");
                Listas<Celular>.imprimirHistorialVentas(cel2, "Lista_Deposito.log");

                //Muestro los tickets
                Console.WriteLine(Listas<Electrodomestico>.Leer("Lista_Deposito.log"));
            }
            catch(ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
