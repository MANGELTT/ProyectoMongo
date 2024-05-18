namespace ProyectoMongo
{
    partial class Form1
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridViewTelefonos = new System.Windows.Forms.DataGridView();
            this.dataGridViewDetalles = new System.Windows.Forms.DataGridView();
            this.btnInsertar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(46, 335);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(89, 51);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridViewTelefonos
            // 
            this.dataGridViewTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTelefonos.Location = new System.Drawing.Point(46, 67);
            this.dataGridViewTelefonos.Name = "dataGridViewTelefonos";
            this.dataGridViewTelefonos.ReadOnly = true;
            this.dataGridViewTelefonos.RowHeadersWidth = 51;
            this.dataGridViewTelefonos.RowTemplate.Height = 24;
            this.dataGridViewTelefonos.Size = new System.Drawing.Size(273, 236);
            this.dataGridViewTelefonos.TabIndex = 1;
            this.dataGridViewTelefonos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTelefonos_CellContentClick);
            // 
            // dataGridViewDetalles
            // 
            this.dataGridViewDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalles.Location = new System.Drawing.Point(490, 67);
            this.dataGridViewDetalles.Name = "dataGridViewDetalles";
            this.dataGridViewDetalles.RowHeadersWidth = 51;
            this.dataGridViewDetalles.RowTemplate.Height = 24;
            this.dataGridViewDetalles.Size = new System.Drawing.Size(495, 236);
            this.dataGridViewDetalles.TabIndex = 2;
            this.dataGridViewDetalles.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetalles_CellContentDoubleClick);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(490, 320);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(89, 51);
            this.btnInsertar.TabIndex = 3;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1030, 501);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.dataGridViewDetalles);
            this.Controls.Add(this.dataGridViewTelefonos);
            this.Controls.Add(this.btnAgregar);
            this.Name = "Form1";
            this.Text = "IdTelefono";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataGridViewTelefonos;
        private System.Windows.Forms.DataGridView dataGridViewDetalles;
        private System.Windows.Forms.Button btnInsertar;
    }
}

