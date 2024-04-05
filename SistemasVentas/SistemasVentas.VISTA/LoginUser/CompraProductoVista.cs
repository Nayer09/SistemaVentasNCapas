using SistemasVentas.BSS;
using SistemasVentas.Modelos;
using SistemasVentas.VISTA.ClienteVistas;
using SistemasVentas.VISTA.ProductoVistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasVentas.VISTA.LoginUser
{
    public partial class CompraProductoVista : Form
    {
        public CompraProductoVista()
        {
            InitializeComponent();
            // Agrega las columnas al DataGridView
            dataGridView1.Columns.Add("IdCliente", "ID Cliente");
            dataGridView1.Columns.Add("IdProducto", "ID Producto");
            dataGridView1.Columns.Add("NombreProducto", "Nombre Producto");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
        }
        public static int IdProductoSeleccionado = 0;
        ProductoBss bssproducto = new ProductoBss();
        private void button1_Click(object sender, EventArgs e)
        {
            VendeProductoListarVista fr = new VendeProductoListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Producto producto = bssproducto.ObtenerProductoIdBss(IdProductoSeleccionado);
                textBox2.Text = producto.Nombre;
            }
        }
        public static int IdClienteSeleccionado = 0;
        ClienteBss bsscliente = new ClienteBss();
        private void button2_Click(object sender, EventArgs e)
        {
            VendeClienteListarVista fr = new VendeClienteListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Cliente cliente = bsscliente.ObtenerClienteIdBss(IdClienteSeleccionado);
                textBox1.Text = Convert.ToString(cliente.IdCliente);
            }
        }
        public void AgregarProductoSeleccionadoAlDataGridView(Producto producto, Cliente cliente, int cantidad)
        {
            if (dataGridView1 != null)
            {
                // Aquí agregas la fila con los datos seleccionados al DataGridView, incluyendo la cantidad
                dataGridView1.Rows.Add(cliente.IdCliente, producto.IdProducto, producto.Nombre, cantidad);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Cliente cliente = bsscliente.ObtenerClienteIdBss(IdClienteSeleccionado);
            Producto producto = bssproducto.ObtenerProductoIdBss(IdProductoSeleccionado);

            // Obtener la cantidad del TextBox3
            int cantidad;
            if (!int.TryParse(textBox3.Text, out cantidad))
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamas al método para agregarlos al DataGridView
            AgregarProductoSeleccionadoAlDataGridView(producto, cliente, cantidad);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
