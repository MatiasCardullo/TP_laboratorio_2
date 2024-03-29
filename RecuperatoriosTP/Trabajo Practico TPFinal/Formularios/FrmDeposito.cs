﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Archivos;
using MetodosExtension;

namespace Formularios
{
    public partial class FrmDeposito : Form
    {
        private DataTable dt;
        private ListaElectrodomesticos listaElectrodomesticos = new ListaElectrodomesticos();

        /// <summary>
        /// Constructor por defecto, configura el datatable y el datagridview 
        /// </summary>
        public FrmDeposito()
        {
            InitializeComponent();

            this.dt = new DataTable("Deposito");

            this.dt.Columns.Add("ID", typeof(int));
            this.dt.Columns.Add("Marca", typeof(string));
            this.dt.Columns.Add("Modelo", typeof(string));
            this.dt.Columns.Add("Pulgadas", typeof(float));
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
        /// Manejador de eventos para el evento agregarAlDepositoEvento del formComercio,
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
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Al cerrar el formulario, el envio se muestra en un FrmTicket 
        /// (imprime los datos de todos los electrodomesticos que forman parte de la lista de electrodomesticos)
        /// Ademas imprime estos datos en el archivo que guarda el historial de
        /// productos, despues la instancia deposito del formulario Owner
        /// se vuelve null, para permitir que se puede abrir el deposito despues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDeposito_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string output = "";
                Listas<Electrodomestico> t = new Listas<Electrodomestico>();
                foreach (Electrodomestico item in this.listaElectrodomesticos.Lista)
                {
                    Listas<Electrodomestico>.imprimirHistorial(item, "Lista_Deposito.log");
                    output += t.ObtenerResumenDepo(item);
                }
                FrmTicket ticket = new FrmTicket(output);
                ticket.Text = "Enviado al Deposito";
                ticket.ShowDialog();
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            FrmFabrica padre = (FrmFabrica)this.Owner;
            padre.deposito = null;
            this.Dispose();
        }
    }
}
