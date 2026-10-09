namespace TiendaWinforms
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
            tb_id_producto = new TextBox();
            tb_cantidad = new TextBox();
            lb_id_prod = new Label();
            label2 = new Label();
            label3 = new Label();
            lb_nombre_producto = new Label();
            btn_guardar_venta = new Button();
            dgv_lista = new DataGridView();
            lb_total = new Label();
            btn_pagar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_lista).BeginInit();
            SuspendLayout();
            // 
            // tb_id_producto
            // 
            tb_id_producto.Location = new Point(174, 87);
            tb_id_producto.Name = "tb_id_producto";
            tb_id_producto.Size = new Size(125, 27);
            tb_id_producto.TabIndex = 0;
            // 
            // tb_cantidad
            // 
            tb_cantidad.Location = new Point(174, 214);
            tb_cantidad.Name = "tb_cantidad";
            tb_cantidad.Size = new Size(125, 27);
            tb_cantidad.TabIndex = 1;
            // 
            // lb_id_prod
            // 
            lb_id_prod.AutoSize = true;
            lb_id_prod.Location = new Point(77, 94);
            lb_id_prod.Name = "lb_id_prod";
            lb_id_prod.Size = new Size(91, 20);
            lb_id_prod.TabIndex = 2;
            lb_id_prod.Text = "ID Producto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 153);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 3;
            label2.Text = "Producto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 221);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 4;
            label3.Text = "Cantidad:";
            // 
            // lb_nombre_producto
            // 
            lb_nombre_producto.AutoSize = true;
            lb_nombre_producto.Location = new Point(226, 153);
            lb_nombre_producto.Name = "lb_nombre_producto";
            lb_nombre_producto.Size = new Size(18, 20);
            lb_nombre_producto.TabIndex = 5;
            lb_nombre_producto.Text = "...";
            // 
            // btn_guardar_venta
            // 
            btn_guardar_venta.Location = new Point(355, 144);
            btn_guardar_venta.Name = "btn_guardar_venta";
            btn_guardar_venta.Size = new Size(94, 29);
            btn_guardar_venta.TabIndex = 6;
            btn_guardar_venta.Text = "Agregar";
            btn_guardar_venta.UseVisualStyleBackColor = true;
            btn_guardar_venta.Click += btn_guardar_venta_Click;
            // 
            // dgv_lista
            // 
            dgv_lista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_lista.Location = new Point(115, 278);
            dgv_lista.Name = "dgv_lista";
            dgv_lista.RowHeadersWidth = 51;
            dgv_lista.Size = new Size(435, 244);
            dgv_lista.TabIndex = 7;
            // 
            // lb_total
            // 
            lb_total.AutoSize = true;
            lb_total.Location = new Point(479, 248);
            lb_total.Name = "lb_total";
            lb_total.Size = new Size(18, 20);
            lb_total.TabIndex = 8;
            lb_total.Text = "...";
            // 
            // btn_pagar
            // 
            btn_pagar.Location = new Point(279, 552);
            btn_pagar.Name = "btn_pagar";
            btn_pagar.Size = new Size(94, 29);
            btn_pagar.TabIndex = 9;
            btn_pagar.Text = "Pagar";
            btn_pagar.UseVisualStyleBackColor = true;
            btn_pagar.Click += btn_pagar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 609);
            Controls.Add(btn_pagar);
            Controls.Add(lb_total);
            Controls.Add(dgv_lista);
            Controls.Add(btn_guardar_venta);
            Controls.Add(lb_nombre_producto);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lb_id_prod);
            Controls.Add(tb_cantidad);
            Controls.Add(tb_id_producto);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgv_lista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_id_producto;
        private TextBox tb_cantidad;
        private Label lb_id_prod;
        private Label label2;
        private Label label3;
        private Label lb_nombre_producto;
        private Button btn_guardar_venta;
        private DataGridView dgv_lista;
        private Label lb_total;
        private Button btn_pagar;
    }
}
