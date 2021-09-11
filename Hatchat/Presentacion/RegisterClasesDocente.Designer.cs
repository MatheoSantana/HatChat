
namespace Hatchat.Presentacion
{
    partial class RegisterClasesDocente
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
            this.pbxVolver = new System.Windows.Forms.PictureBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cbxAnio = new System.Windows.Forms.ComboBox();
            this.cbxClases = new System.Windows.Forms.ComboBox();
            this.lblClase = new System.Windows.Forms.Label();
            this.lblAsignaturas = new System.Windows.Forms.Label();
            this.panelAsignaturas = new System.Windows.Forms.Panel();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.panelAgregadas = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.cbxOrientacion = new System.Windows.Forms.ComboBox();
            this.lblOrientacion = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVolver)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxVolver
            // 
            this.pbxVolver.Location = new System.Drawing.Point(12, 12);
            this.pbxVolver.Name = "pbxVolver";
            this.pbxVolver.Size = new System.Drawing.Size(100, 100);
            this.pbxVolver.TabIndex = 21;
            this.pbxVolver.TabStop = false;
            this.pbxVolver.Click += new System.EventHandler(this.pbxVolver_Click);
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(167, 240);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(29, 15);
            this.lblAnio.TabIndex = 22;
            this.lblAnio.Text = "Año";
            // 
            // cbxAnio
            // 
            this.cbxAnio.FormattingEnabled = true;
            this.cbxAnio.Location = new System.Drawing.Point(257, 240);
            this.cbxAnio.Name = "cbxAnio";
            this.cbxAnio.Size = new System.Drawing.Size(121, 23);
            this.cbxAnio.TabIndex = 23;
            this.cbxAnio.SelectedIndexChanged += new System.EventHandler(this.cbxAnio_SelectedIndexChanged);
            // 
            // cbxClases
            // 
            this.cbxClases.FormattingEnabled = true;
            this.cbxClases.Location = new System.Drawing.Point(257, 269);
            this.cbxClases.Name = "cbxClases";
            this.cbxClases.Size = new System.Drawing.Size(121, 23);
            this.cbxClases.TabIndex = 25;
            this.cbxClases.SelectedIndexChanged += new System.EventHandler(this.cbxClases_SelectedIndexChanged);
            // 
            // lblClase
            // 
            this.lblClase.AutoSize = true;
            this.lblClase.Location = new System.Drawing.Point(167, 269);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(35, 15);
            this.lblClase.TabIndex = 24;
            this.lblClase.Text = "Clase";
            // 
            // lblAsignaturas
            // 
            this.lblAsignaturas.AutoSize = true;
            this.lblAsignaturas.Location = new System.Drawing.Point(612, 193);
            this.lblAsignaturas.Name = "lblAsignaturas";
            this.lblAsignaturas.Size = new System.Drawing.Size(69, 15);
            this.lblAsignaturas.TabIndex = 26;
            this.lblAsignaturas.Text = "Asignaturas";
            // 
            // panelAsignaturas
            // 
            this.panelAsignaturas.Location = new System.Drawing.Point(612, 211);
            this.panelAsignaturas.Name = "panelAsignaturas";
            this.panelAsignaturas.Size = new System.Drawing.Size(591, 189);
            this.panelAsignaturas.TabIndex = 27;
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Location = new System.Drawing.Point(702, 193);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(180, 15);
            this.lblAdvertencia.TabIndex = 28;
            this.lblAdvertencia.Text = "Debe ingresar un año y una clase";
            // 
            // panelAgregadas
            // 
            this.panelAgregadas.Location = new System.Drawing.Point(167, 530);
            this.panelAgregadas.Name = "panelAgregadas";
            this.panelAgregadas.Size = new System.Drawing.Size(902, 100);
            this.panelAgregadas.TabIndex = 29;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1128, 406);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 30;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(1118, 579);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 31;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // cbxOrientacion
            // 
            this.cbxOrientacion.FormattingEnabled = true;
            this.cbxOrientacion.Location = new System.Drawing.Point(257, 211);
            this.cbxOrientacion.Name = "cbxOrientacion";
            this.cbxOrientacion.Size = new System.Drawing.Size(310, 23);
            this.cbxOrientacion.TabIndex = 33;
            this.cbxOrientacion.SelectedIndexChanged += new System.EventHandler(this.cbxOrientacion_SelectedIndexChanged);
            // 
            // lblOrientacion
            // 
            this.lblOrientacion.AutoSize = true;
            this.lblOrientacion.Location = new System.Drawing.Point(167, 211);
            this.lblOrientacion.Name = "lblOrientacion";
            this.lblOrientacion.Size = new System.Drawing.Size(69, 15);
            this.lblOrientacion.TabIndex = 32;
            this.lblOrientacion.Text = "Orientacion";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(167, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(791, 72);
            this.lblTitulo.TabIndex = 34;
            this.lblTitulo.Text = "Crea tu cuenta de docente";
            // 
            // RegisterClasesDocente
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
            this.Name = "RegisterClasesDocente";
            this.Text = "RegisterClasesDocente";
            this.Load += new System.EventHandler(this.RegisterClasesDocente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxVolver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxVolver;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cbxAnio;
        private System.Windows.Forms.ComboBox cbxClases;
        private System.Windows.Forms.Label lblClase;
        private System.Windows.Forms.Label lblAsignaturas;
        private System.Windows.Forms.Panel panelAsignaturas;
        private System.Windows.Forms.Label lblAdvertencia;
        private System.Windows.Forms.Panel panelAgregadas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ComboBox cbxOrientacion;
        private System.Windows.Forms.Label lblOrientacion;
        private System.Windows.Forms.Label lblTitulo;
    }
}