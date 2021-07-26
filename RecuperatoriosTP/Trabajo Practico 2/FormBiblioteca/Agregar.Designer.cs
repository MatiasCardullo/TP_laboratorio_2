
using System;

namespace FormLibreria
{
    partial class Agregar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.autor = new System.Windows.Forms.TextBox();
            this.tipo1 = new System.Windows.Forms.ComboBox();
            this.tipo2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.precio = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.precio)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Libro:";
            // 
            // titulo
            // 
            this.titulo.Location = new System.Drawing.Point(58, 12);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(100, 23);
            this.titulo.TabIndex = 3;
            this.titulo.TextChanged += new System.EventHandler(this.titulo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Autor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo:";
            // 
            // autor
            // 
            this.autor.Location = new System.Drawing.Point(58, 41);
            this.autor.Name = "autor";
            this.autor.Size = new System.Drawing.Size(100, 23);
            this.autor.TabIndex = 6;
            this.autor.TextChanged += new System.EventHandler(this.autor_TextChanged);
            // 
            // tipo1
            // 
            this.tipo1.FormattingEnabled = true;
            this.tipo1.Location = new System.Drawing.Point(51, 70);
            this.tipo1.Name = "tipo1";
            this.tipo1.Size = new System.Drawing.Size(77, 23);
            this.tipo1.TabIndex = 7;
            this.tipo1.SelectedIndexChanged += new System.EventHandler(this.tipo1_SelectedIndexChanged);
            this.tipo1.Click += new System.EventHandler(this.tipo1_Click);
            // 
            // tipo2
            // 
            this.tipo2.FormattingEnabled = true;
            this.tipo2.Location = new System.Drawing.Point(134, 70);
            this.tipo2.Name = "tipo2";
            this.tipo2.Size = new System.Drawing.Size(95, 23);
            this.tipo2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Precio:";
            // 
            // precio
            // 
            this.precio.DecimalPlaces = 2;
            this.precio.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.precio.Location = new System.Drawing.Point(58, 99);
            this.precio.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(120, 23);
            this.precio.TabIndex = 11;
            this.precio.ValueChanged += new System.EventHandler(this.precio_ValueChanged);
            // 
            // Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 223);
            this.Controls.Add(this.precio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tipo2);
            this.Controls.Add(this.tipo1);
            this.Controls.Add(this.autor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Agregar";
            this.Text = "Agregar";
            this.Load += new System.EventHandler(this.Agregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.precio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox titulo;
        public System.Windows.Forms.TextBox autor;
        public System.Windows.Forms.ComboBox tipo1;
        public System.Windows.Forms.ComboBox tipo2;
        public System.Windows.Forms.NumericUpDown precio;
    }
}