using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
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
        public FrmDeposito deposito;

        public ManejadorSql manejadorBD;
        public DataTable dt;

        Thread hilo;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FrmFabrica()
        {
            InitializeComponent();
            this.manejadorBD = new ManejadorSql();
            ConfigurarDataTable();
            ConfigurarGrilla();

            //instancio el hilo y lo asocio con el metodo MostrarImagenes para que lo invoque
            this.hilo = new Thread(this.MostrarImagenes);
        }
        /// <summary>
        /// En el load del formulario, se comienza a ejecutar el hilo secundario,
        /// Los datos cargados en el DataTable los muestra la grilla,
        /// y se ejecuta el Metodo Fill del SqlDataAdapter, para cargar el stock 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFabrica_Load(object sender, EventArgs e)
        {
            try
            {
                this.hilo.Start();
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
        /// Configura el atributo DataTable, para poder manejar los datos de las filas
        /// </summary>
        public void ConfigurarDataTable()
        {
            this.dt = new DataTable("Inventario");

            this.dt.Columns.Add("ID", typeof(int));
            this.dt.Columns.Add("Marca", typeof(string));
            this.dt.Columns.Add("Modelo", typeof(string));
            this.dt.Columns.Add("Pulgadas", typeof(float));
            this.dt.Columns.Add("Tipo", typeof(string));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }

        /// <summary>
        /// Permite modificar los datos del item seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = this.grillaInventario.CurrentRow.Index;

                FrmABM frm = new FrmABM(this.dt.Rows[indice]["Marca"].ToString(),
                                        this.dt.Rows[indice]["tipo"].ToString(),
                                        this.dt.Rows[indice]["Modelo"].ToString(),
                                        this.dt.Rows[indice]["Pulgadas"].ToString());

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.dt.Rows[indice]["Marca"] = frm.Elec.Marca;
                    this.dt.Rows[indice]["Modelo"] = frm.Elec.Modelo;
                    this.dt.Rows[indice]["Pulgadas"] = frm.Elec.Pulgadas;
                    this.dt.Rows[indice]["Tipo"] = frm.Elec.GetType().Name;
                }
            }
            catch(ModeloException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Permite agregar un item a la tabla del stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    fila["Pulgadas"] = frm.Elec.Pulgadas;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = this.grillaInventario.CurrentRow.Index;
                this.dt.Rows[indice].Delete();
                this.manejadorBD.da.Update(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Crea y abre un form de orden para el deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrearDeposito_Click(object sender, EventArgs e)
        {
            try
            {
                if (deposito == null)
                {
                    this.deposito = new FrmDeposito();
                    this.deposito.Show(this);
                }
                else
                {
                    throw new DepositoAbiertoException();
                }
            }
            catch(DepositoAbiertoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Permite añadir el item seleccionado del stock al deposito,
        /// Asocia el manejador de eventos "AgregarProducto" al evento agregarAlDepositoEvento
        /// y lo invoca pasandole los datos de la fila seleccionada para que el formulario del
        /// deposito los pueda agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarDeposito_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.deposito == null)
                {
                    throw new DepositoAbiertoException("El deposito no esta abierto");
                }

                //Asocio el manejador
                this.agregarAlDepositoEvento += new AgregarAlDepositoDelegado(deposito.AgregarProdutco);

                //Llamo al manejador de eventos que agrega las filas al deposito
                //Y le paso la fila seleccionada
                DataRow fila = this.dt.Rows[this.grillaInventario.CurrentRow.Index];
                this.agregarAlDepositoEvento(fila);

                //Desasocio el manejador, asi la proxima vez no se invoca varias veces
                this.agregarAlDepositoEvento -= new AgregarAlDepositoDelegado(deposito.AgregarProdutco);

                int indice = this.grillaInventario.CurrentRow.Index;
                this.dt.Rows[indice].Delete();
                this.manejadorBD.da.Update(dt);
            }
            catch(DepositoAbiertoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Abre una instancia de FrmTicket, que imprime el contenido
        /// de un archivo de texto mostrando el historial de movimientos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTicket ticket = new FrmTicket(Listas<Electrodomestico>.Leer("Lista_Deposito.log"));
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFabrica_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.hilo.Abort();
                this.manejadorBD.da.Update(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Metodo que se ejecuta en el hilo secundario para mostrar
        /// un array con imagenes que va cambiando en el tiempo
        /// </summary>
        /// <param name="param"></param>
        private void MostrarImagenes(object param)
        {
            if (this.imgPublicidad.InvokeRequired)
            {

                int imagenPos = 0;
                Random random = new Random();

                DelegadoThreadConParam delegado = new DelegadoThreadConParam(this.MostrarImagenes);

                object[] imagen = new object[6];

                imagen[0] = "tvSamsung.jpg";
                imagen[1] = "tvLG.jpg";
                imagen[2] = "celuSamsung.jpg";
                imagen[3] = "celuLG.jpg";
                imagen[4] = "logoSamsung.jpg";
                imagen[5] = "logoLG.jpg";

                do
                {
                    object[] parametro = new object[] { imagen[imagenPos] };

                    imagenPos = random.Next(0, 6);

                    this.Invoke(delegado, (object)parametro);

                    Thread.Sleep(3000);

                } while(true);
            }
            else
            {
                this.imgPublicidad.ImageLocation = ((object[])param)[0].ToString();
            }
        }
    }
}
