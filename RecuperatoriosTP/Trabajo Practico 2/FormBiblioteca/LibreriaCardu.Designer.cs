
namespace FormLibreria
{
    partial class LibreriaCardu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bAgregar = new System.Windows.Forms.Button();
            this.bVender = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.money = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bAgregar
            // 
            this.bAgregar.Location = new System.Drawing.Point(12, 261);
            this.bAgregar.Name = "bAgregar";
            this.bAgregar.Size = new System.Drawing.Size(250, 49);
            this.bAgregar.TabIndex = 1;
            this.bAgregar.Text = "Agregar Libro";
            this.bAgregar.UseVisualStyleBackColor = true;
            this.bAgregar.Click += new System.EventHandler(this.bAgregar_Click);
            // 
            // bVender
            // 
            this.bVender.Location = new System.Drawing.Point(268, 261);
            this.bVender.Name = "bVender";
            this.bVender.Size = new System.Drawing.Size(250, 49);
            this.bVender.TabIndex = 2;
            this.bVender.Text = "Vender Libro";
            this.bVender.UseVisualStyleBackColor = true;
            this.bVender.Click += new System.EventHandler(this.bVender_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(506, 214);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // money
            // 
            this.money.AutoSize = true;
            this.money.Location = new System.Drawing.Point(424, 21);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(41, 15);
            this.money.TabIndex = 4;
            this.money.Text = "Cajero";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 318);
            this.Controls.Add(this.money);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bVender);
            this.Controls.Add(this.bAgregar);
            this.Name = "Form1";
            this.Text = "Libreria Cardullo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.Button bVender;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label money;
    }
}

