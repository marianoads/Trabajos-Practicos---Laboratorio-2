namespace MainCorreo
{
    partial class formCorreo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblIngresado = new System.Windows.Forms.Label();
            this.lvlEnViaje = new System.Windows.Forms.Label();
            this.lblEntregado = new System.Windows.Forms.Label();
            this.contextMenuStripPaquete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TBTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.lblTracking = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.TBDireccion = new System.Windows.Forms.TextBox();
            this.groupBoxEstadosPaquetes = new System.Windows.Forms.GroupBox();
            this.lstEstadoEntregado = new System.Windows.Forms.ListBox();
            this.listBoxIngresado = new System.Windows.Forms.ListBox();
            this.listBoxEnViaje = new System.Windows.Forms.ListBox();
            this.groupBoxPaquete = new System.Windows.Forms.GroupBox();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripPaquete.SuspendLayout();
            this.groupBoxEstadosPaquetes.SuspendLayout();
            this.groupBoxPaquete.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIngresado
            // 
            this.lblIngresado.AutoSize = true;
            this.lblIngresado.Location = new System.Drawing.Point(12, 43);
            this.lblIngresado.Name = "lblIngresado";
            this.lblIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblIngresado.TabIndex = 4;
            this.lblIngresado.Text = "Ingresado";
            // 
            // lvlEnViaje
            // 
            this.lvlEnViaje.AutoSize = true;
            this.lvlEnViaje.Location = new System.Drawing.Point(279, 43);
            this.lvlEnViaje.Name = "lvlEnViaje";
            this.lvlEnViaje.Size = new System.Drawing.Size(45, 13);
            this.lvlEnViaje.TabIndex = 5;
            this.lvlEnViaje.Text = "En viaje";
            // 
            // lblEntregado
            // 
            this.lblEntregado.AutoSize = true;
            this.lblEntregado.Location = new System.Drawing.Point(544, 43);
            this.lblEntregado.Name = "lblEntregado";
            this.lblEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEntregado.TabIndex = 6;
            this.lblEntregado.Text = "Entregado";
            // 
            // contextMenuStripPaquete
            // 
            this.contextMenuStripPaquete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MostrarToolStripMenuItem});
            this.contextMenuStripPaquete.Name = "contextMenuStrip1";
            this.contextMenuStripPaquete.Size = new System.Drawing.Size(116, 26);
            // 
            // MostrarToolStripMenuItem
            // 
            this.MostrarToolStripMenuItem.Name = "MostrarToolStripMenuItem";
            this.MostrarToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.MostrarToolStripMenuItem.Text = "Mostrar";
            this.MostrarToolStripMenuItem.Click += new System.EventHandler(this.MostrarToolStripMenuItem_Click);
            // 
            // TBTrackingID
            // 
            this.TBTrackingID.Location = new System.Drawing.Point(9, 43);
            this.TBTrackingID.Mask = "000-000-0000";
            this.TBTrackingID.Name = "TBTrackingID";
            this.TBTrackingID.Size = new System.Drawing.Size(156, 20);
            this.TBTrackingID.TabIndex = 8;
            // 
            // lblTracking
            // 
            this.lblTracking.AutoSize = true;
            this.lblTracking.Location = new System.Drawing.Point(6, 27);
            this.lblTracking.Name = "lblTracking";
            this.lblTracking.Size = new System.Drawing.Size(63, 13);
            this.lblTracking.TabIndex = 9;
            this.lblTracking.Text = "Tracking ID";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(6, 66);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 10;
            this.lblDireccion.Text = "Direccion";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(649, 338);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 42);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(649, 392);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(120, 42);
            this.btnMostrarTodos.TabIndex = 14;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // TBDireccion
            // 
            this.TBDireccion.Location = new System.Drawing.Point(9, 81);
            this.TBDireccion.Name = "TBDireccion";
            this.TBDireccion.Size = new System.Drawing.Size(156, 20);
            this.TBDireccion.TabIndex = 15;
            // 
            // groupBoxEstadosPaquetes
            // 
            this.groupBoxEstadosPaquetes.Controls.Add(this.lstEstadoEntregado);
            this.groupBoxEstadosPaquetes.Controls.Add(this.listBoxIngresado);
            this.groupBoxEstadosPaquetes.Controls.Add(this.listBoxEnViaje);
            this.groupBoxEstadosPaquetes.Location = new System.Drawing.Point(3, 12);
            this.groupBoxEstadosPaquetes.Name = "groupBoxEstadosPaquetes";
            this.groupBoxEstadosPaquetes.Size = new System.Drawing.Size(793, 293);
            this.groupBoxEstadosPaquetes.TabIndex = 17;
            this.groupBoxEstadosPaquetes.TabStop = false;
            this.groupBoxEstadosPaquetes.Text = "Estados Paquetes";
            // 
            // lstEstadoEntregado
            // 
            this.lstEstadoEntregado.ContextMenuStrip = this.contextMenuStripPaquete;
            this.lstEstadoEntregado.FormattingEnabled = true;
            this.lstEstadoEntregado.Location = new System.Drawing.Point(544, 55);
            this.lstEstadoEntregado.Name = "lstEstadoEntregado";
            this.lstEstadoEntregado.Size = new System.Drawing.Size(228, 212);
            this.lstEstadoEntregado.TabIndex = 21;
            // 
            // listBoxIngresado
            // 
            this.listBoxIngresado.FormattingEnabled = true;
            this.listBoxIngresado.Location = new System.Drawing.Point(12, 55);
            this.listBoxIngresado.Name = "listBoxIngresado";
            this.listBoxIngresado.Size = new System.Drawing.Size(228, 212);
            this.listBoxIngresado.TabIndex = 19;
            // 
            // listBoxEnViaje
            // 
            this.listBoxEnViaje.FormattingEnabled = true;
            this.listBoxEnViaje.Location = new System.Drawing.Point(279, 55);
            this.listBoxEnViaje.Name = "listBoxEnViaje";
            this.listBoxEnViaje.Size = new System.Drawing.Size(228, 212);
            this.listBoxEnViaje.TabIndex = 20;
            // 
            // groupBoxPaquete
            // 
            this.groupBoxPaquete.Controls.Add(this.lblTracking);
            this.groupBoxPaquete.Controls.Add(this.TBTrackingID);
            this.groupBoxPaquete.Controls.Add(this.TBDireccion);
            this.groupBoxPaquete.Controls.Add(this.lblDireccion);
            this.groupBoxPaquete.Location = new System.Drawing.Point(443, 311);
            this.groupBoxPaquete.Name = "groupBoxPaquete";
            this.groupBoxPaquete.Size = new System.Drawing.Size(345, 136);
            this.groupBoxPaquete.TabIndex = 18;
            this.groupBoxPaquete.TabStop = false;
            this.groupBoxPaquete.Text = "Paquete";
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Enabled = false;
            this.rtbMostrar.Location = new System.Drawing.Point(15, 311);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(411, 136);
            this.rtbMostrar.TabIndex = 19;
            this.rtbMostrar.Text = "";
            // 
            // formCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblEntregado);
            this.Controls.Add(this.lvlEnViaje);
            this.Controls.Add(this.lblIngresado);
            this.Controls.Add(this.groupBoxEstadosPaquetes);
            this.Controls.Add(this.groupBoxPaquete);
            this.Name = "formCorreo";
            this.Text = "Correo UTN por Yamakawa.Mariano.2C";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formCorreo_FormClosed);
            this.contextMenuStripPaquete.ResumeLayout(false);
            this.groupBoxEstadosPaquetes.ResumeLayout(false);
            this.groupBoxPaquete.ResumeLayout(false);
            this.groupBoxPaquete.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIngresado;
        private System.Windows.Forms.Label lvlEnViaje;
        private System.Windows.Forms.Label lblEntregado;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPaquete;
        private System.Windows.Forms.MaskedTextBox TBTrackingID;
        private System.Windows.Forms.Label lblTracking;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.TextBox TBDireccion;
        private System.Windows.Forms.GroupBox groupBoxEstadosPaquetes;
        private System.Windows.Forms.GroupBox groupBoxPaquete;
        private System.Windows.Forms.ListBox listBoxIngresado;
        private System.Windows.Forms.ListBox lstEstadoEntregado;
        private System.Windows.Forms.ListBox listBoxEnViaje;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.ToolStripMenuItem MostrarToolStripMenuItem;
    }
}

