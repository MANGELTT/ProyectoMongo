﻿namespace ProyectoMongo
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTelefonos = new System.Windows.Forms.DataGridView();
            this.dataGridViewDetalles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTelefonos
            // 
            this.dataGridViewTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTelefonos.Location = new System.Drawing.Point(46, 67);
            this.dataGridViewTelefonos.Name = "dataGridViewTelefonos";
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1030, 501);
            this.Controls.Add(this.dataGridViewDetalles);
            this.Controls.Add(this.dataGridViewTelefonos);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "IdTelefono";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewTelefonos;
        private System.Windows.Forms.DataGridView dataGridViewDetalles;
    }
}

