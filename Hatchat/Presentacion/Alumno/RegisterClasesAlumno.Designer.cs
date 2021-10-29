
namespace Hatchat.Presentacion
{
    partial class RegisterClasesAlumno
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cbxOrientacion = new System.Windows.Forms.ComboBox();
            this.lblOrientacion = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelAgregadas = new System.Windows.Forms.Panel();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.panelAsignaturas = new System.Windows.Forms.Panel();
            this.lblAsignaturas = new System.Windows.Forms.Label();
            this.cbxClases = new System.Windows.Forms.ComboBox();
            this.lblClase = new System.Windows.Forms.Label();
            this.cbxAnio = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.pbxVolver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVolver)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(192, 31);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(774, 72);
            this.lblTitulo.TabIndex = 48;
            this.lblTitulo.Text = "Crea tu cuenta de alumno";
            // 
            // cbxOrientacion
            // 
            this.cbxOrientacion.FormattingEnabled = true;
            this.cbxOrientacion.Location = new System.Drawing.Point(282, 230);
            this.cbxOrientacion.Name = "cbxOrientacion";
            this.cbxOrientacion.Size = new System.Drawing.Size(310, 23);
            this.cbxOrientacion.TabIndex = 47;
            this.cbxOrientacion.SelectedIndexChanged += new System.EventHandler(this.cbxOrientacion_SelectedIndexChanged);
            // 
            // lblOrientacion
            // 
            this.lblOrientacion.AutoSize = true;
            this.lblOrientacion.Location = new System.Drawing.Point(192, 230);
            this.lblOrientacion.Name = "lblOrientacion";
            this.lblOrientacion.Size = new System.Drawing.Size(69, 15);
            this.lblOrientacion.TabIndex = 46;
            this.lblOrientacion.Text = "Orientacion";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(1143, 598);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 45;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1153, 425);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 44;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelAgregadas
            // 
            this.panelAgregadas.Location = new System.Drawing.Point(192, 549);
            this.panelAgregadas.Name = "panelAgregadas";
            this.panelAgregadas.Size = new System.Drawing.Size(902, 100);
            this.panelAgregadas.TabIndex = 43;
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Location = new System.Drawing.Point(727, 212);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(180, 15);
            this.lblAdvertencia.TabIndex = 42;
            this.lblAdvertencia.Text = "Debe ingresar un año y una clase";
            // 
            // panelAsignaturas
            // 
            this.panelAsignaturas.Location = new System.Drawing.Point(637, 230);
            this.panelAsignaturas.Name = "panelAsignaturas";
            this.panelAsignaturas.Size = new System.Drawing.Size(591, 189);
            this.panelAsignaturas.TabIndex = 41;
            // 
            // lblAsignaturas
            // 
            this.lblAsignaturas.AutoSize = true;
            this.lblAsignaturas.Location = new System.Drawing.Point(637, 212);
            this.lblAsignaturas.Name = "lblAsignaturas";
            this.lblAsignaturas.Size = new System.Drawing.Size(69, 15);
            this.lblAsignaturas.TabIndex = 40;
            this.lblAsignaturas.Text = "Asignaturas";
            // 
            // cbxClases
            // 
            this.cbxClases.FormattingEnabled = true;
            this.cbxClases.Location = new System.Drawing.Point(282, 288);
            this.cbxClases.Name = "cbxClases";
            this.cbxClases.Size = new System.Drawing.Size(121, 23);
            this.cbxClases.TabIndex = 39;
            this.cbxClases.SelectedIndexChanged += new System.EventHandler(this.cbxClases_SelectedIndexChanged);
            // 
            // lblClase
            // 
            this.lblClase.AutoSize = true;
            this.lblClase.Location = new System.Drawing.Point(192, 288);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(35, 15);
            this.lblClase.TabIndex = 38;
            this.lblClase.Text = "Clase";
            // 
            // cbxAnio
            // 
            this.cbxAnio.FormattingEnabled = true;
            this.cbxAnio.Location = new System.Drawing.Point(282, 259);
            this.cbxAnio.Name = "cbxAnio";
            this.cbxAnio.Size = new System.Drawing.Size(121, 23);
            this.cbxAnio.TabIndex = 37;
            this.cbxAnio.SelectedIndexChanged += new System.EventHandler(this.cbxAnio_SelectedIndexChanged);
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(192, 259);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(29, 15);
            this.lblAnio.TabIndex = 36;
            this.lblAnio.Text = "Año";
            // 
            // pbxVolver
            // 
            this.pbxVolver.Location = new System.Drawing.Point(37, 31);
            this.pbxVolver.Name = "pbxVolver";
            this.pbxVolver.Size = new System.Drawing.Size(100, 100);
            this.pbxVolver.TabIndex = 35;
            this.pbxVolver.TabStop = false;
            this.pbxVolver.Click += new System.EventHandler(this.pbxVolver_Click);
            // 
            // RegisterClasesAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cbxOrientacion);
            this.Controls.Add(this.lblOrientacion);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panelAgregadas);
            this.Controls.Add(this.lblAdvertencia);
            this.Controls.Add(this.panelAsignaturas);
            this.Controls.Add(this.lblAsignaturas);
            this.Controls.Add(this.cbxClases);
            this.Controls.Add(this.lblClase);
            this.Controls.Add(this.cbxAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.pbxVolver);
            this.Name = "RegisterClasesAlumno";
            this.Text = "RegisterClasesAlumno";
            this.Load += new System.EventHandler(this.RegisterClasesAlumno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxVolver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbxOrientacion;
        private System.Windows.Forms.Label lblOrientacion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelAgregadas;
        private System.Windows.Forms.Label lblAdvertencia;
        private System.Windows.Forms.Panel panelAsignaturas;
        private System.Windows.Forms.Label lblAsignaturas;
        private System.Windows.Forms.ComboBox cbxClases;
        private System.Windows.Forms.Label lblClase;
        private System.Windows.Forms.ComboBox cbxAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.PictureBox pbxVolver;
    }
}