
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterClasesDocente));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAsig = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cbxAnio = new System.Windows.Forms.ComboBox();
            this.cbxOrientacion = new System.Windows.Forms.ComboBox();
            this.lblClase = new System.Windows.Forms.Label();
            this.lblOrientacion = new System.Windows.Forms.Label();
            this.cbxClases = new System.Windows.Forms.ComboBox();
            this.panelAsignaturas = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelAgregadas = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblIngresarA = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAsignaturas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.pbxVolver = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timerCentrar = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblAsig);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.lblAnio);
            this.panel3.Controls.Add(this.cbxAnio);
            this.panel3.Controls.Add(this.cbxOrientacion);
            this.panel3.Controls.Add(this.lblClase);
            this.panel3.Controls.Add(this.lblOrientacion);
            this.panel3.Controls.Add(this.cbxClases);
            this.panel3.Controls.Add(this.panelAsignaturas);
            this.panel3.Location = new System.Drawing.Point(23, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(942, 286);
            this.panel3.TabIndex = 50;
            // 
            // lblAsig
            // 
            this.lblAsig.AutoSize = true;
            this.lblAsig.Font = new System.Drawing.Font("Arial", 30F);
            this.lblAsig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAsig.Location = new System.Drawing.Point(394, 21);
            this.lblAsig.Name = "lblAsig";
            this.lblAsig.Size = new System.Drawing.Size(225, 45);
            this.lblAsig.TabIndex = 50;
            this.lblAsig.Text = "Asignaturas";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Location = new System.Drawing.Point(338, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 200);
            this.panel5.TabIndex = 48;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Arial", 12F);
            this.lblAnio.Location = new System.Drawing.Point(15, 124);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(36, 18);
            this.lblAnio.TabIndex = 36;
            this.lblAnio.Text = "Año";
            // 
            // cbxAnio
            // 
            this.cbxAnio.FormattingEnabled = true;
            this.cbxAnio.Location = new System.Drawing.Point(109, 124);
            this.cbxAnio.Name = "cbxAnio";
            this.cbxAnio.Size = new System.Drawing.Size(104, 21);
            this.cbxAnio.TabIndex = 37;
            this.cbxAnio.SelectedIndexChanged += new System.EventHandler(this.cbxAnio_SelectedIndexChanged);
            // 
            // cbxOrientacion
            // 
            this.cbxOrientacion.FormattingEnabled = true;
            this.cbxOrientacion.Location = new System.Drawing.Point(109, 75);
            this.cbxOrientacion.Name = "cbxOrientacion";
            this.cbxOrientacion.Size = new System.Drawing.Size(216, 21);
            this.cbxOrientacion.TabIndex = 47;
            this.cbxOrientacion.SelectedIndexChanged += new System.EventHandler(this.cbxOrientacion_SelectedIndexChanged);
            // 
            // lblClase
            // 
            this.lblClase.AutoSize = true;
            this.lblClase.Font = new System.Drawing.Font("Arial", 12F);
            this.lblClase.Location = new System.Drawing.Point(15, 171);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(49, 18);
            this.lblClase.TabIndex = 38;
            this.lblClase.Text = "Clase";
            // 
            // lblOrientacion
            // 
            this.lblOrientacion.AutoSize = true;
            this.lblOrientacion.Font = new System.Drawing.Font("Arial", 12F);
            this.lblOrientacion.Location = new System.Drawing.Point(15, 78);
            this.lblOrientacion.Name = "lblOrientacion";
            this.lblOrientacion.Size = new System.Drawing.Size(88, 18);
            this.lblOrientacion.TabIndex = 46;
            this.lblOrientacion.Text = "Orientacion";
            // 
            // cbxClases
            // 
            this.cbxClases.FormattingEnabled = true;
            this.cbxClases.Location = new System.Drawing.Point(109, 171);
            this.cbxClases.Name = "cbxClases";
            this.cbxClases.Size = new System.Drawing.Size(104, 21);
            this.cbxClases.TabIndex = 39;
            this.cbxClases.SelectedIndexChanged += new System.EventHandler(this.cbxClases_SelectedIndexChanged);
            // 
            // panelAsignaturas
            // 
            this.panelAsignaturas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAsignaturas.Location = new System.Drawing.Point(393, 78);
            this.panelAsignaturas.Name = "panelAsignaturas";
            this.panelAsignaturas.Size = new System.Drawing.Size(507, 164);
            this.panelAsignaturas.TabIndex = 41;
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnAgregar);
            this.panel6.Controls.Add(this.panelAgregadas);
            this.panel6.Controls.Add(this.btnRegistrar);
            this.panel6.Location = new System.Drawing.Point(23, 476);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(979, 79);
            this.panel6.TabIndex = 44;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(136)))), ((int)(((byte)(88)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(663, 20);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 31);
            this.btnAgregar.TabIndex = 44;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelAgregadas
            // 
            this.panelAgregadas.AutoScroll = true;
            this.panelAgregadas.BackColor = System.Drawing.Color.White;
            this.panelAgregadas.Location = new System.Drawing.Point(0, 0);
            this.panelAgregadas.Name = "panelAgregadas";
            this.panelAgregadas.Size = new System.Drawing.Size(657, 77);
            this.panelAgregadas.TabIndex = 43;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(136)))), ((int)(((byte)(88)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(826, 20);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(150, 31);
            this.btnRegistrar.TabIndex = 45;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblIngresarA);
            this.panel4.Location = new System.Drawing.Point(42, 99);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(174, 44);
            this.panel4.TabIndex = 51;
            // 
            // lblIngresarA
            // 
            this.lblIngresarA.AutoSize = true;
            this.lblIngresarA.Font = new System.Drawing.Font("Arial", 18F);
            this.lblIngresarA.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIngresarA.Location = new System.Drawing.Point(16, 7);
            this.lblIngresarA.Name = "lblIngresarA";
            this.lblIngresarA.Size = new System.Drawing.Size(141, 27);
            this.lblIngresarA.TabIndex = 49;
            this.lblIngresarA.Text = "Ingresar a...";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 48F);
            this.lblTitulo.Location = new System.Drawing.Point(33, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(801, 72);
            this.lblTitulo.TabIndex = 48;
            this.lblTitulo.Text = "Crea tu cuenta de Docente";
            // 
            // lblAsignaturas
            // 
            this.lblAsignaturas.AutoSize = true;
            this.lblAsignaturas.Location = new System.Drawing.Point(414, 168);
            this.lblAsignaturas.Name = "lblAsignaturas";
            this.lblAsignaturas.Size = new System.Drawing.Size(62, 13);
            this.lblAsignaturas.TabIndex = 40;
            this.lblAsignaturas.Text = "Asignaturas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.lblAsignaturas);
            this.panel1.Controls.Add(this.lblAdvertencia);
            this.panel1.Location = new System.Drawing.Point(117, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 563);
            this.panel1.TabIndex = 52;
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Location = new System.Drawing.Point(491, 168);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(166, 13);
            this.lblAdvertencia.TabIndex = 42;
            this.lblAdvertencia.Text = "Debe ingresar un año y una clase";
            // 
            // pbxVolver
            // 
            this.pbxVolver.BackColor = System.Drawing.Color.White;
            this.pbxVolver.Location = new System.Drawing.Point(22, 0);
            this.pbxVolver.Name = "pbxVolver";
            this.pbxVolver.Size = new System.Drawing.Size(51, 46);
            this.pbxVolver.TabIndex = 2;
            this.pbxVolver.TabStop = false;
            this.pbxVolver.Click += new System.EventHandler(this.pbxVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1153, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pbxVolver);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 46);
            this.panel2.TabIndex = 53;
            this.panel2.Click += new System.EventHandler(this.pbxVolver_Click);
            // 
            // timerCentrar
            // 
            this.timerCentrar.Enabled = true;
            this.timerCentrar.Interval = 500;
            this.timerCentrar.Tick += new System.EventHandler(this.timerCentrar_Tick);
            // 
            // RegisterClasesDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Name = "RegisterClasesDocente";
            this.Text = "RegisterClasesDocente";
            this.Load += new System.EventHandler(this.RegisterClasesDocente_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblAsig;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cbxAnio;
        private System.Windows.Forms.ComboBox cbxOrientacion;
        private System.Windows.Forms.Label lblClase;
        private System.Windows.Forms.Label lblOrientacion;
        private System.Windows.Forms.ComboBox cbxClases;
        private System.Windows.Forms.Panel panelAsignaturas;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelAgregadas;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblIngresarA;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAsignaturas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAdvertencia;
        private System.Windows.Forms.PictureBox pbxVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timerCentrar;
    }
}