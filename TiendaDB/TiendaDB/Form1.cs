using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TiendaDB.Models;

namespace TiendaDB
{
    public partial class Form1 : Form
    {
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
            using (var context = new TiendaContext())
            {
                if (!context.Categorias.Any())
                {
                    context.Categorias.AddRange(
                        new Categoria { Nombre = "Electrónica" },
                        new Categoria { Nombre = "Ropa" }
                    );
                    context.SaveChanges();
                }

                cmbCategorias.DataSource = context.Categorias.ToList();
                cmbCategorias.DisplayMember = "Nombre";
                cmbCategorias.ValueMember = "Id";
            }
        }

        private void CargarProductos()
        {
            using (var context = new TiendaContext())
            {
                var productos = context.Productos
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

        private int ObtenerACrearCategoriaId(TiendaContext context, string nombreCategoria)
        {
            var categoriaDb = context.Categorias.FirstOrDefault(c => c.Nombre.ToLower() == nombreCategoria.ToLower());
            if (categoriaDb != null) return categoriaDb.Id;

            var nuevaCategoria = new Categoria { Nombre = nombreCategoria };
            context.Categorias.Add(nuevaCategoria);
            context.SaveChanges();
            return nuevaCategoria.Id;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombe.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("Por favor, rellene los campos correctamente.");
                    return;
                }

                string nombreCategoria = cmbCategorias.Text.Trim();
                if (string.IsNullOrEmpty(nombreCategoria))
                {
                    MessageBox.Show("Por favor, seleccione o escriba una categoría válida.");
                    return;
                }

                using (var context = new TiendaContext())
                {
                    int categoriaId = ObtenerACrearCategoriaId(context, nombreCategoria);

                    context.Productos.Add(new Producto
                    {
                        Nombre = txtNombe.Text,
                        Precio = precio,
                        CategoriaId = categoriaId
                    });
                    context.SaveChanges();
                }

                CargarCategorias();
                CargarProductos();
                LimpiarFormulario();
                MessageBox.Show("¡Producto guardado con éxito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_productoIdSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un producto de la tabla para editar.");
                    return;
                }

                if (string.IsNullOrEmpty(txtNombe.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("Por favor, rellene los campos correctamente.");
                    return;
                }

                string nombreCategoria = cmbCategorias.Text.Trim();
                if (string.IsNullOrEmpty(nombreCategoria))
                {
                    MessageBox.Show("Por favor, seleccione o escriba una categoría válida.");
                    return;
                }

                using (var context = new TiendaContext())
                {
                    int categoriaId = ObtenerACrearCategoriaId(context, nombreCategoria);

                    var productoExistente = context.Productos.Find(_productoIdSeleccionado);
                    if (productoExistente != null)
                    {
                        productoExistente.Nombre = txtNombe.Text;
                        productoExistente.Precio = precio;
                        productoExistente.CategoriaId = categoriaId;
                        context.SaveChanges();
                    }
                }

                CargarCategorias();
                CargarProductos();
                LimpiarFormulario();
                MessageBox.Show("¡Producto actualizado con éxito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        private void dgbProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgbProductos.Rows[e.RowIndex];
                _productoIdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value ?? 0);
                txtNombe.Text = row.Cells["Producto"].Value?.ToString() ?? "";
                txtPrecio.Text = row.Cells["Precio"].Value?.ToString() ?? "";
                cmbCategorias.SelectedValue = Convert.ToInt32(row.Cells["CategoriaId"].Value ?? 0);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_productoIdSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un producto de la lista para eliminar.");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var context = new TiendaContext())
                    {
                        var producto = context.Productos.Find(_productoIdSeleccionado);
                        if (producto != null)
                        {
                            context.Productos.Remove(producto);
                            context.SaveChanges();
                        }
                    }

                    CargarProductos();
                    LimpiarFormulario();
                    MessageBox.Show("¡Producto eliminado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void txtNombe_TextChanged(object sender, EventArgs e) { }
        private void txtPrecio_TextChanged(object sender, EventArgs e) { }
        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}