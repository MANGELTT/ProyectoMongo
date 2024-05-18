using MongoDB.Driver;
using ProyectoMongo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMongo
{
    public partial class AddDocument : Form
    {
        private IMongoCollection<Mensajes> mensajesCollection;
        public AddDocument(IMongoCollection<Mensajes> collection)
        {
            InitializeComponent();
            mensajesCollection = collection;
        }

        private void AddDocument_Load(object sender, EventArgs e)
        {

        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                var detalleMensaje = new Detalle_Mensaje
                {
                    NumeroTelefono = long.TryParse(txtTelefono.Text, out long numeroTelefono) ? numeroTelefono : 0,
                    Compania = txtCompania.Text ?? string.Empty,
                    Mensaje = txtMensaje.Text ?? string.Empty
                };

                var nuevoMensaje = new Mensajes
                {
                    DetallesM = new[] { detalleMensaje }
                };

                await mensajesCollection.InsertOneAsync(nuevoMensaje);
                MessageBox.Show("Documento agregado exitosamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar documento: " + ex.Message);
            }
        }
    }
}
