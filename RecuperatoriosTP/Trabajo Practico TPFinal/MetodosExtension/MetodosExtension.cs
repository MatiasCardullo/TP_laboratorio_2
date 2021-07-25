using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using EntidadesAbstractas;

namespace MetodosExtension
{
    public static class MetodosExtension
    {
        /// <summary>
        /// Metodo de extension de la clase Ticket, devuelve una cadena con el 
        /// resumen de una venta
        /// </summary>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObtenerResumenVenta(this Listas<Electrodomestico> t, object obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Movimiento realizada el dia: ");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine("Productos:");
            sb.Append(obj.ToString());
            sb.AppendLine("----------------------------------");

            return sb.ToString();
        }
    }
}
