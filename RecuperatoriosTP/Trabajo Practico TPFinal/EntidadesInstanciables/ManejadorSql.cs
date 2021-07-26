using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EntidadesInstanciables
{
    public class ManejadorSql
    {
        public SqlDataAdapter da;

        public ManejadorSql()
        {
            ConfigurarDataAdapter();
        }

        /// <summary>
        /// Configura el atributo DATAADAPTER, para poder conectarme con la base de datos
        /// </summary>
        public void ConfigurarDataAdapter()
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=FabricaTPFinal;Integrated Security=True");

            this.da = new SqlDataAdapter();

            this.da.SelectCommand = new SqlCommand("SELECT * FROM FabricaTPFinal", cn);
            this.da.InsertCommand = new SqlCommand("INSERT INTO FabricaTPFinal (marca, modelo, pulgadas, tipo) VALUES (@marca, @modelo, @pulgadas, @tipo)", cn);
            this.da.UpdateCommand = new SqlCommand("UPDATE FabricaTPFinal SET marca=@marca, modelo=@modelo, pulgadas=@pulgadas, tipo=@tipo WHERE id=@id", cn);
            this.da.DeleteCommand = new SqlCommand("DELETE FROM FabricaTPFinal WHERE id=@id", cn);

            this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
            this.da.InsertCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
            this.da.InsertCommand.Parameters.Add("@pulgadas", SqlDbType.Float, 10, "pulgadas");
            this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");

            this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
            this.da.UpdateCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
            this.da.UpdateCommand.Parameters.Add("@pulgadas", SqlDbType.Float, 10, "pulgadas");
            this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
            this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

            this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
        }
    }
}
