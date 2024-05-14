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

            // Columnas DetallesMensajes
            dataGridViewDetalles.Columns.Add("NumeroTelefonoColumn", "Número de Teléfono");
            dataGridViewDetalles.Columns.Add("CompaniaColumn", "Compañía");
            dataGridViewDetalles.Columns.Add("MensajeColumn", "Mensaje");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Columna Id
            dataGridViewTelefonos.Columns.Add("idTelefonoColumn", "ID Teléfono");

            await MostrarMensajes();
        }

        private async Task MostrarMensajes()
        {
            try
            {
                var mensajes = await mensajesCollection.Find(_ => true).ToListAsync();

                dataGridViewTelefonos.Rows.Clear();

                // Agregar los ID de teléfono al DataGridView
                foreach (var mensaje in mensajes)
                {
                    dataGridViewTelefonos.Rows.Add(mensaje.id);
                }
                dataGridViewTelefonos.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar mensajes: " + ex.Message);
            }
        }

        private async void dataGridViewTelefonos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener el ID de teléfono seleccionado
            var idTelefono = dataGridViewTelefonos.Rows[e.RowIndex].Cells["idTelefonoColumn"].Value.ToString();

            try
            {
                var filtro = Builders<Mensajes>.Filter.Eq(x => x.id, idTelefono);
                var mensaje = await mensajesCollection.Find(filtro).FirstOrDefaultAsync();

                if (mensaje != null)
                {
                    dataGridViewDetalles.Rows.Clear();

                    // Recorre los detalles del mensaje
                    foreach (var detalle in mensaje.DetallesM)
                    {
                        dataGridViewDetalles.Rows.Add(detalle.NumeroTelefono, detalle.Compania, detalle.Mensaje);
                    }
                }
                else
                {
                    MessageBox.Show("Mensaje no encontrado para el ID de Teléfono seleccionado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar detalles del mensaje: " + ex.Message);
            }
        }
    }
}
