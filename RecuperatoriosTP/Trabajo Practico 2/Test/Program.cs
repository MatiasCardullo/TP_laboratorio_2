using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Libreria miLibreria = 5;

            Autor a = new Autor("Esteban", "Rey");
            Autor b = new Autor("Joe", "Mayo");

            Manual m1 = new Manual("Economia", 25.66f, "Domingo", "Caballo", ETipo.Finanzas);
            Novela n1 = new Novela("Miseria", 63.88f, a, EGenero.Romantica);
            Manual m2 = new Manual("C#", 29.95f, "Joe", "Mayo", ETipo.Tecnico);
            Novela n2 = new Novela("Miseria", 203.00f, a, EGenero.Accion);
            Novela n3 = new Novela("Miseria", 98.00f, a, EGenero.CienciaFiccion);
            Novela n4 = new Novela("Miseria", 103.50f, b, EGenero.Accion);

            miLibreria += m1;
            miLibreria += m1;
            miLibreria += n1;
            miLibreria += m2;
            miLibreria += n2;
            miLibreria += n3;
            miLibreria += n4;

            Console.WriteLine(Libreria.Mostrar(miLibreria));

            Console.ReadLine();
        }
    }
}
