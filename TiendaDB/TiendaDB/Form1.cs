using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TiendaDB.Models;

namespace TiendaDB
{
    public partial class Form1 : Form
    {
        private TiendaContext _context = new TiendaContext();
        private int _productoIdSeleccionado = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
        }

        private void CargarCategorias()
        {
            if (!_context.Categorias.Any())
            {
                _context.Categorias.AddRange(
                    new Categoria { Nombre = "Electrónica" },
                    new Categoria { Nombre = "Ropa" }
                );
                _context.SaveChanges();
            }

            cmbCategorias.DataSource = _context.Categorias.ToList();
            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "Id";
        }

        private void CargarProductos()
        {
            var productos = _context.Productos
                .Include(p => p.Categorias)
                .Select(p => new
                {
                    p.Id,
                    Producto = p.Nombre,
                    p.Precio,
                    Categoria = p.Categorias.Nombre,
                    p.CategoriaId
                }).ToList();

            dgbProductos.DataSource = productos;

            if (dgbProductos.Columns["CategoriaId"] != null)
                dgbProductos.Columns["CategoriaId"].Visible = false;
        }

        private void LimpiarFormulario()
        {
            txtNombe.Clear();
            txtPrecio.Clear();
            if (cmbCategorias.Items.Count > 0)
                cmbCategorias.SelectedIndex = 0;
            _productoIdSeleccionado = 0;
            btnGuardar.Text = "Guardar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombe.Text) ||
                !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Por favor, rellene los campos correctamente.");
                return;
            }

            int categoriaId = 0;
            if (cmbCategorias.SelectedValue != null)
            {
                categoriaId = Convert.ToInt32(cmbCategorias.SelectedValue);
            }

            if (_productoIdSeleccionado == 0)
            {
                var nuevoProducto = new Producto
                {
                    Nombre = txtNombe.Text,
                    Precio = precio,
                    CategoriaId = categoriaId
                };
                _context.Productos.Add(nuevoProducto);
            }
            else
            {
                var productoExistente = _context.Productos.Find(_productoIdSeleccionado);
                if (productoExistente != null)
                {
                    productoExistente.Nombre = txtNombe.Text;
                    productoExistente.Precio = precio;
                    productoExistente.CategoriaId = categoriaId;
                }
            }

            _context.SaveChanges();
            CargarProductos();
            LimpiarFormulario();
            MessageBox.Show("Operación realizada con éxito.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }

        private void dgbProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgbProductos.Rows[e.RowIndex];
                _productoIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value ?? 0);
                txtNombe.Text = row.Cells["Producto"].Value?.ToString() ?? "";
                txtPrecio.Text = row.Cells["Precio"].Value?.ToString() ?? "";
                cmbCategorias.SelectedValue = Convert.ToInt32(row.Cells["CategoriaId"].Value ?? 0);
                btnGuardar.Text = "Actualizar";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_productoIdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto de la lista para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var producto = _context.Productos.Find(_productoIdSeleccionado);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                    CargarProductos();
                    LimpiarFormulario();
                    MessageBox.Show("Producto eliminado.");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}