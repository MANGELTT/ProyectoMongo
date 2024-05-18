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
        private Mensajes mensajeSeleccionado;


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

            // Conectar eventos
            this.dataGridViewTelefonos.CellClick += new DataGridViewCellEventHandler(this.dataGridViewTelefonos_CellContentClick);
            this.btnInsertar.Click += new EventHandler(this.btnInsertar_Click);
            this.dataGridViewDetalles.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridViewDetalles_CellContentDoubleClick);
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

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el ID de teléfono seleccionado
                var idTelefono = dataGridViewTelefonos.Rows[e.RowIndex].Cells["idTelefonoColumn"].Value.ToString();

                try
                {
                    var filtro = Builders<Mensajes>.Filter.Eq(x => x.id, idTelefono);
                    mensajeSeleccionado = await mensajesCollection.Find(filtro).FirstOrDefaultAsync();

                    if (mensajeSeleccionado != null)
                    {
                        dataGridViewDetalles.Rows.Clear();

                        // Recorre los detalles del mensaje
                        foreach (var detalle in mensajeSeleccionado.DetallesM)
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

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            AddDocument formDoc = new AddDocument(mensajesCollection);
            formDoc.Show();
        }

        private void dataGridViewDetalles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridViewDetalles.BeginEdit(true);
            }
        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            if (mensajeSeleccionado != null)
            {
                try
                {
                    // Actualizar DetallesM con los datos válidos del DataGridView
                    var detallesList = dataGridViewDetalles.Rows
                        .OfType<DataGridViewRow>()
                        .Where(row => !row.IsNewRow && row.Cells["NumeroTelefonoColumn"].Value != null && row.Cells["CompaniaColumn"].Value != null && row.Cells["MensajeColumn"].Value != null)
                        .Select(row => new Detalle_Mensaje
                        {
                            NumeroTelefono = long.Parse(row.Cells["NumeroTelefonoColumn"].Value.ToString()),
                            Compania = row.Cells["CompaniaColumn"].Value.ToString(),
                            Mensaje = row.Cells["MensajeColumn"].Value.ToString()
                        })
                        .ToArray();

                    mensajeSeleccionado.DetallesM = detallesList;

                    // Actualizar en la base de datos
                    var filtro = Builders<Mensajes>.Filter.Eq(x => x.id, mensajeSeleccionado.id);
                    var update = Builders<Mensajes>.Update.Set(x => x.DetallesM, detallesList);

                    await mensajesCollection.UpdateOneAsync(filtro, update);

                    MessageBox.Show("Cambios guardados exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar cambios: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay mensaje seleccionado.");
            }
        }
    }
}
