using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;

namespace Formularios
{
    public partial class FrmFabrica : Form
    {
        /// <summary>
        /// Evento para poder agregar items al deposito
        /// </summary>
        public AgregarAlDepositoDelegado agregarAlDepositoEvento;
        public FrmOrden deposito;

        public GestorSql manejadorBD;
        public DataTable dt;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FrmFabrica()
        {
            InitializeComponent();
            this.manejadorBD = new GestorSql();
            ConfigurarDataTable();
            ConfigurarGrilla();
        }

 
 
        private void FrmFabrica_Load(object sender, EventArgs e)
        {
            try
            {
                this.grillaInventario.DataSource = dt;
                this.manejadorBD.da.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Configura el control DataGridViewer
        /// </summary>
        public void ConfigurarGrilla()
        {
            this.grillaInventario.MultiSelect = false;
            this.grillaInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.grillaInventario.AllowUserToAddRows = false;
            this.grillaInventario.AllowUserToDeleteRows = false;
            this.grillaInventario.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        /// <summary>
        /// Configura el atributo DataTable, para poder manejar los datos de 
        /// las filas
        /// </summary>
        public void ConfigurarDataTable()
        {
            this.dt = new DataTable("Inventario");

            this.dt.Columns.Add("ID", typeof(int));
            this.dt.Columns.Add("Marca", typeof(string));
            this.dt.Columns.Add("Modelo", typeof(string));
            this.dt.Columns.Add("Precio", typeof(float));
            this.dt.Columns.Add("Tipo", typeof(string));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }

        /// <summary>
        /// Permite agregar un item a la tabla del stock
        /// </summary>
 
 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmABM frm = new FrmABM();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow fila = this.dt.NewRow();

                    fila["Marca"] = frm.Elec.Marca;
                    fila["Modelo"] = frm.Elec.Modelo;
                    fila["Precio"] = frm.Elec.Precio;
                    fila["Tipo"] = frm.Elec.GetType().Name;

                    this.dt.Rows.Add(fila);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Se intentaron agregar valores nulos");
            }
            catch (ModeloException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Permite eliminar un item del stock
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SacarProducto(this.grillaInventario.CurrentRow.Index);
        }

        /*public void ThreadMoverProductos()
        {
            DataTable dtAux = dt;
            while (deposito != null)
            {
                if (FrmOrden.confirm)
                {
                    list.ForEach(i => dtAux.Rows[i].Delete());
                }
            }
            list.Clear();
            dt = dtAux;
            this.manejadorBD.da.Update(dt);
        }*/
 
        private void SacarProducto(int indice)
        {
            try
            {
                this.dt.Rows[indice].Delete();
                this.manejadorBD.da.Update(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Crea y abre un form con el deposito
        /// </summary> 
        private void btnCrearDeposito_Click(object sender, EventArgs e)
        {
            try
            {
                if (deposito != null)
                {
                    throw new DepositoAbiertoException();
                }
                /*else if (ConveyorBelt.IsAlive)
                {
                    throw new ConveyorBeltException();
                }*/
                else
                {
                    this.deposito = new FrmOrden();
                    this.deposito.Show(this);
                    //ConveyorBelt.Start();
                }
            }
            catch(DepositoAbiertoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Permite añadir el item seleccionado del stock, al deposito,
        /// Asocia el manejador de eventos "AgregarProducto" al evento agregarAlDepositoEvento
        /// y lo invoca pasandole los datos de la fila seleccionada para que el formulario del
        /// deposito los pueda agregar
        /// </summary>
 
 
        private void btnAgregarDeposito_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.deposito == null)
                {
                    throw new DepositoAbiertoException("No hay un deposito abierto");
                }
                
                //Asocio el manejador
                this.agregarAlDepositoEvento += new AgregarAlDepositoDelegado(deposito.AgregarProdutco);

                //Llamo al manejador de eventos que agrega las filas al deposito
                //Y le paso la fila seleccionada
                this.agregarAlDepositoEvento(this.dt.Rows[this.grillaInventario.CurrentRow.Index]);
                SacarProducto(this.grillaInventario.CurrentRow.Index);
                //Desasocio el manejador, asi la proxima vez no se invoca varias veces
                this.agregarAlDepositoEvento -= new AgregarAlDepositoDelegado(deposito.AgregarProdutco);
            }
            catch (DepositoAbiertoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Abre una instancia de FrmListas, que imprime el contenido
        /// de un archivo de texto mostrando el historial de ventas
        /// </summary>
 
 
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                FrmListas ticket = new FrmListas(Listas<Electrodomestico>.Leer("Lista_Deposito.log"));
                ticket.Text = "Listado del Deposito";
                ticket.ShowDialog();
            }
            catch(ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// En el cierre del formulario, los datos de la tabla se sincronizan con 
        /// la base de datos y se aborta el hilo secundario
        /// </summary>
 
 
        private void FrmFabrica_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.manejadorBD.da.Update(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblAgregar_Click(object sender, EventArgs e)
        {

        }

        private void grillaInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
