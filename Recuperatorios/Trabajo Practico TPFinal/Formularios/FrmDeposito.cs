using System;
using System.Data;
using System.Windows.Forms;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Archivos;
using MetodosExtension;
using System.Threading;

namespace Formularios
{
    public partial class FrmOrden : Form
    {
        private DataTable dt;
        private ListaElectrodomesticos listaElectrodomesticos = new ListaElectrodomesticos();
        public delegate void Callback();
        public event Callback depoFinished;

        /// <summary>
        /// Constructor por defecto, configura el datatable y el datagridview 
        /// </summary>
        public FrmOrden()
        {
            InitializeComponent();

            this.depoFinished += ChangeTitle;
            this.dt = new DataTable("Deposito");

            this.dt.Columns.Add("ID", typeof(int));
            this.dt.Columns.Add("Marca", typeof(string));
            this.dt.Columns.Add("Modelo", typeof(string));
            this.dt.Columns.Add("Precio", typeof(float));
            this.dt.Columns.Add("Tipo", typeof(string));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;

            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.dataGridView1.DataSource = this.dt;
        }
        
        /// <summary>
        /// Manejador de eventos para el evento agregarAlDepositoEvento del formFabrica,
        /// crea una nueva fila con los datos de la fila que recibe como parametro
        /// y lo guarda en la lista de electrodomesticos
        /// </summary>
        /// <param name="fila"></param>
        public void AgregarProdutco(DataRow fila)
        {
            try
            {
                DataRow filaNueva = this.dt.NewRow();

                filaNueva.ItemArray = fila.ItemArray;

                this.dt.Rows.Add(filaNueva);

                listaElectrodomesticos += filaNueva;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeTitle()
        {
            if (this.InvokeRequired)
            {
                Callback callback = new Callback(ChangeTitle);
                this.Invoke(callback);
            }
            else
            {
                this.Text = "Envio al deposito";
                MessageBox.Show("Enviado!");
            }
        }

        private void Loading()
        {
            Form windowDepo = new ToDepo();
            windowDepo.ShowDialog();
            this.depoFinished.Invoke();
        }

        /// <summary>
        /// Al cerrar el formulario, la instancia deposito del formulario Owner
        /// se vuelve null, para permitir que se puede abrir un nuevo deposito despues
        /// </summary>
        private void FrmOrden_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
               if (this.listaElectrodomesticos.Lista.Count > 0)
                {
                    string resumenVenta = "";

                    Listas<Electrodomestico> t = new Listas<Electrodomestico>();
                    foreach (Electrodomestico item in this.listaElectrodomesticos.Lista)
                    {
                        Listas<Electrodomestico>.imprimirHistorialVentas(item, "Lista_Deposito.log");
                        resumenVenta += t.ObtenerResumenVenta(item);
                    }
                    this.Text = "Enviando...";
                    Thread depoThread = new Thread(this.Loading);
                    depoThread.Start();
                    FrmListas ticket = new FrmListas(resumenVenta);
                    ticket.Text = "Enviado al Deposito:";
                    ticket.ShowDialog();
                }
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            FrmFabrica padre = (FrmFabrica)this.Owner;
            padre.deposito = null;
            
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmOrden_Load(object sender, EventArgs e)
        {

        }
    }
}
