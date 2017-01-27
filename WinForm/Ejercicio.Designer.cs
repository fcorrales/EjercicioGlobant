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
            this.f = new System.Windows.Forms.Button();
            this.BtnViajes = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.lblMensajeArchivoCiudades = new System.Windows.Forms.Label();
            this.lblMensajeArchivoViajes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // f
            // 
            this.f.Location = new System.Drawing.Point(64, 95);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(213, 51);
            this.f.TabIndex = 0;
            this.f.Text = "Abrir archivo de ciudades";
            this.f.UseVisualStyleBackColor = true;
            this.f.Click += new System.EventHandler(this.BtnCiudades_Click);
            // 
            // BtnViajes
            // 
            this.BtnViajes.Location = new System.Drawing.Point(64, 191);
            this.BtnViajes.Name = "BtnViajes";
            this.BtnViajes.Size = new System.Drawing.Size(213, 51);
            this.BtnViajes.TabIndex = 1;
            this.BtnViajes.Text = "Abrir archivo de viajes";
            this.BtnViajes.UseVisualStyleBackColor = true;
            this.BtnViajes.Click += new System.EventHandler(this.BtnViajes_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(524, 279);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(213, 51);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // lblMensajeArchivoCiudades
            // 
            this.lblMensajeArchivoCiudades.AutoSize = true;
            this.lblMensajeArchivoCiudades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.lblMensajeArchivoCiudades.Location = new System.Drawing.Point(318, 110);
            this.lblMensajeArchivoCiudades.Name = "lblMensajeArchivoCiudades";
            this.lblMensajeArchivoCiudades.Size = new System.Drawing.Size(209, 20);
            this.lblMensajeArchivoCiudades.TabIndex = 3;
            this.lblMensajeArchivoCiudades.Text = "LblMensajeArchivoCiudades";
            // 
            // lblMensajeArchivoViajes
            // 
            this.lblMensajeArchivoViajes.AutoSize = true;
            this.lblMensajeArchivoViajes.Location = new System.Drawing.Point(318, 206);
            this.lblMensajeArchivoViajes.Name = "lblMensajeArchivoViajes";
            this.lblMensajeArchivoViajes.Size = new System.Drawing.Size(185, 20);
            this.lblMensajeArchivoViajes.TabIndex = 4;
            this.lblMensajeArchivoViajes.Text = "LblMensajeArchivoViajes";
            // 
            // Ejercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 383);
            this.Controls.Add(this.lblMensajeArchivoViajes);
            this.Controls.Add(this.lblMensajeArchivoCiudades);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnViajes);
            this.Controls.Add(this.f);
            this.Name = "Ejercicio";
            this.Text = "Reporte de viajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button f;
        private System.Windows.Forms.Button BtnViajes;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label lblMensajeArchivoCiudades;
        private System.Windows.Forms.Label lblMensajeArchivoViajes;
    }
}

