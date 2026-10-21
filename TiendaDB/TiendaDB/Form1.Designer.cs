namespace TiendaDB
{
    partial class Form1
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
            dgbProductos = new DataGridView();
            txtNombe = new TextBox();
            txtPrecio = new TextBox();
            cmbCategorias = new ComboBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblNombre = new Label();
            lblPrecio = new Label();
            lblCategorias = new Label();
            ((System.ComponentModel.ISupportInitialize)dgbProductos).BeginInit();
            SuspendLayout();
            // 
            // dgbProductos
            // 
            dgbProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgbProductos.Location = new Point(65, 12);
            dgbProductos.Name = "dgbProductos";
            dgbProductos.Size = new Size(689, 205);
            dgbProductos.TabIndex = 0;
            // 
            // txtNombe
            // 
            txtNombe.Location = new Point(197, 270);
            txtNombe.Name = "txtNombe";
            txtNombe.Size = new Size(256, 23);
            txtNombe.TabIndex = 1;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(197, 315);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(256, 23);
            txtPrecio.TabIndex = 2;
            // 
            // cmbCategorias
            // 
            cmbCategorias.FormattingEnabled = true;
            cmbCategorias.Location = new Point(197, 367);
            cmbCategorias.Name = "cmbCategorias";
            cmbCategorias.Size = new Size(256, 23);
            cmbCategorias.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(74, 399);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(96, 39);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(222, 399);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(96, 39);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(363, 399);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 39);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(522, 399);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(86, 39);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(74, 270);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(73, 21);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "Nombre";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecio.Location = new Point(74, 323);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(58, 21);
            lblPrecio.TabIndex = 9;
            lblPrecio.Text = "Precio";
            // 
            // lblCategorias
            // 
            lblCategorias.AutoSize = true;
            lblCategorias.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategorias.Location = new Point(74, 375);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new Size(91, 21);
            lblCategorias.TabIndex = 10;
            lblCategorias.Text = "Categorias";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCategorias);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbCategorias);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombe);
            Controls.Add(dgbProductos);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgbProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgbProductos;
        private TextBox txtNombe;
        private TextBox txtPrecio;
        private ComboBox cmbCategorias;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblCategorias;
    }
}
