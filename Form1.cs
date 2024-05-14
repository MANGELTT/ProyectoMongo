using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using ProyectoMongo.Models;


namespace ProyectoMongo
{
    public partial class Form1 : Form
    {
        private ConectarMondoDB conexionMongo;
        private IMongoCollection<Mensajes> mensajesCollection;


        public Form1()
        {
            InitializeComponent();
            try
            {
                conexionMongo = new ConectarMondoDB();
                mensajesCollection = conexionMongo.MensajesCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Define las columnas del DataGridView
            dataGridViewTelefonos.Columns.Add("idTelefonoColumn", "ID Teléfono");

            await MostrarMensajes();
        }

        private async Task MostrarMensajes()
        {
            try
            {
                // Recuperar todos los documentos de la colección Mensajes
                List<Mensajes> mensajesList = await mensajesCollection.Find(_ => true).ToListAsync();

                // Limpia el DataGridView antes de agregar los nuevos datos
                dataGridViewTelefonos.Rows.Clear();

                // Agrega los ID de teléfono al DataGridView
                foreach (var mensaje in mensajesList)
                {
                    dataGridViewTelefonos.Rows.Add(mensaje._id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar mensajes: " + ex.Message);
            }
        }
    }
}
