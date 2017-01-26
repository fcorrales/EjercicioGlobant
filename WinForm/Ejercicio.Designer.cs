namespace Ejercicio.WinForm
{
    partial class Ejercicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCiudades = new System.Windows.Forms.Button();
            this.btnViajes = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblMensajeArchivoCiudades = new System.Windows.Forms.Label();
            this.lblMensajeArchivoViajes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCiudades
            // 
            this.btnCiudades.Location = new System.Drawing.Point(64, 95);
            this.btnCiudades.Name = "btnCiudades";
            this.btnCiudades.Size = new System.Drawing.Size(213, 51);
            this.btnCiudades.TabIndex = 0;
            this.btnCiudades.Text = "Abrir archivo de ciudades";
            this.btnCiudades.UseVisualStyleBackColor = true;
            this.btnCiudades.Click += new System.EventHandler(this.btnCiudades_Click);
            // 
            // btnViajes
            // 
            this.btnViajes.Location = new System.Drawing.Point(64, 191);
            this.btnViajes.Name = "btnViajes";
            this.btnViajes.Size = new System.Drawing.Size(213, 51);
            this.btnViajes.TabIndex = 1;
            this.btnViajes.Text = "Abrir archivo de viajes";
            this.btnViajes.UseVisualStyleBackColor = true;
            this.btnViajes.Click += new System.EventHandler(this.btnViajes_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(524, 279);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(213, 51);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblMensajeArchivoCiudades
            // 
            this.lblMensajeArchivoCiudades.AutoSize = true;
            this.lblMensajeArchivoCiudades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.lblMensajeArchivoCiudades.Location = new System.Drawing.Point(318, 110);
            this.lblMensajeArchivoCiudades.Name = "lblMensajeArchivoCiudades";
            this.lblMensajeArchivoCiudades.Size = new System.Drawing.Size(203, 20);
            this.lblMensajeArchivoCiudades.TabIndex = 3;
            this.lblMensajeArchivoCiudades.Text = "lblMensajeArchivoCiudades";
            // 
            // lblMensajeArchivoViajes
            // 
            this.lblMensajeArchivoViajes.AutoSize = true;
            this.lblMensajeArchivoViajes.Location = new System.Drawing.Point(318, 206);
            this.lblMensajeArchivoViajes.Name = "lblMensajeArchivoViajes";
            this.lblMensajeArchivoViajes.Size = new System.Drawing.Size(179, 20);
            this.lblMensajeArchivoViajes.TabIndex = 4;
            this.lblMensajeArchivoViajes.Text = "lblMensajeArchivoViajes";
            // 
            // Ejercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 383);
            this.Controls.Add(this.lblMensajeArchivoViajes);
            this.Controls.Add(this.lblMensajeArchivoCiudades);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnViajes);
            this.Controls.Add(this.btnCiudades);
            this.Name = "Ejercicio";
            this.Text = "Reporte de viajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCiudades;
        private System.Windows.Forms.Button btnViajes;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblMensajeArchivoCiudades;
        private System.Windows.Forms.Label lblMensajeArchivoViajes;
    }
}

