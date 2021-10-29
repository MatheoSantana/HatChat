
namespace Hatchat.Presentacion
{
    partial class MensajesDocente
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
            this.btnEnviar = new System.Windows.Forms.Button();
            this.rtbxRespuesta = new System.Windows.Forms.RichTextBox();
            this.rtbxMensajeRecibido = new System.Windows.Forms.RichTextBox();
            this.lblFechaAlumno = new System.Windows.Forms.Label();
            this.lblHoraAlumno = new System.Windows.Forms.Label();
            this.lblConsultaAlumno = new System.Windows.Forms.Label();
            this.panelNav = new System.Windows.Forms.Panel();
            this.pbxGruposNav = new System.Windows.Forms.PictureBox();
            this.pbxCerrarSesionNav = new System.Windows.Forms.PictureBox();
            this.pbxHistorialNav = new System.Windows.Forms.PictureBox();
            this.pbxPerfilNav = new System.Windows.Forms.PictureBox();
            this.pbxMensajeNav = new System.Windows.Forms.PictureBox();
            this.pbxChatNav = new System.Windows.Forms.PictureBox();
            this.pbxFotoPerfilNav = new System.Windows.Forms.PictureBox();
            this.lblNombreAlumno = new System.Windows.Forms.Label();
            this.pbxAlumno = new System.Windows.Forms.PictureBox();
            this.lblFechaDocente = new System.Windows.Forms.Label();
            this.lblHoraDocente = new System.Windows.Forms.Label();
            this.lblConsultaDocente = new System.Windows.Forms.Label();
            this.pbxDocente = new System.Windows.Forms.PictureBox();
            this.lblNombreDocente = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelNavMensajes = new System.Windows.Forms.Panel();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).BeginInit();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(696, 449);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 14;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // rtbxRespuesta
            // 
            this.rtbxRespuesta.Location = new System.Drawing.Point(107, 320);
            this.rtbxRespuesta.Name = "rtbxRespuesta";
            this.rtbxRespuesta.Size = new System.Drawing.Size(630, 123);
            this.rtbxRespuesta.TabIndex = 11;
            this.rtbxRespuesta.Text = "";
            // 
            // rtbxMensajeRecibido
            // 
            this.rtbxMensajeRecibido.Enabled = false;
            this.rtbxMensajeRecibido.Location = new System.Drawing.Point(107, 90);
            this.rtbxMensajeRecibido.Name = "rtbxMensajeRecibido";
            this.rtbxMensajeRecibido.Size = new System.Drawing.Size(630, 123);
            this.rtbxMensajeRecibido.TabIndex = 10;
            this.rtbxMensajeRecibido.Text = "";
            // 
            // lblFechaAlumno
            // 
            this.lblFechaAlumno.AutoSize = true;
            this.lblFechaAlumno.Location = new System.Drawing.Point(696, 12);
            this.lblFechaAlumno.Name = "lblFechaAlumno";
            this.lblFechaAlumno.Size = new System.Drawing.Size(41, 15);
            this.lblFechaAlumno.TabIndex = 9;
            this.lblFechaAlumno.Text = "Fecha:";
            // 
            // lblHoraAlumno
            // 
            this.lblHoraAlumno.AutoSize = true;
            this.lblHoraAlumno.Location = new System.Drawing.Point(541, 12);
            this.lblHoraAlumno.Name = "lblHoraAlumno";
            this.lblHoraAlumno.Size = new System.Drawing.Size(36, 15);
            this.lblHoraAlumno.TabIndex = 8;
            this.lblHoraAlumno.Text = "Hora:";
            // 
            // lblConsultaAlumno
            // 
            this.lblConsultaAlumno.AutoSize = true;
            this.lblConsultaAlumno.Location = new System.Drawing.Point(352, 12);
            this.lblConsultaAlumno.Name = "lblConsultaAlumno";
            this.lblConsultaAlumno.Size = new System.Drawing.Size(57, 15);
            this.lblConsultaAlumno.TabIndex = 7;
            this.lblConsultaAlumno.Text = "Consulta:";
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.pbxGruposNav);
            this.panelNav.Controls.Add(this.pbxCerrarSesionNav);
            this.panelNav.Controls.Add(this.pbxHistorialNav);
            this.panelNav.Controls.Add(this.pbxPerfilNav);
            this.panelNav.Controls.Add(this.pbxMensajeNav);
            this.panelNav.Controls.Add(this.pbxChatNav);
            this.panelNav.Controls.Add(this.pbxFotoPerfilNav);
            this.panelNav.Location = new System.Drawing.Point(12, 6);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1240, 100);
            this.panelNav.TabIndex = 9;
            // 
            // pbxGruposNav
            // 
            this.pbxGruposNav.Location = new System.Drawing.Point(670, 3);
            this.pbxGruposNav.Name = "pbxGruposNav";
            this.pbxGruposNav.Size = new System.Drawing.Size(94, 94);
            this.pbxGruposNav.TabIndex = 6;
            this.pbxGruposNav.TabStop = false;
            // 
            // pbxCerrarSesionNav
            // 
            this.pbxCerrarSesionNav.Location = new System.Drawing.Point(1143, 3);
            this.pbxCerrarSesionNav.Name = "pbxCerrarSesionNav";
            this.pbxCerrarSesionNav.Size = new System.Drawing.Size(94, 94);
            this.pbxCerrarSesionNav.TabIndex = 5;
            this.pbxCerrarSesionNav.TabStop = false;
            this.pbxCerrarSesionNav.Click += new System.EventHandler(this.pbxCerrarSesionNav_Click);
            // 
            // pbxHistorialNav
            // 
            this.pbxHistorialNav.Location = new System.Drawing.Point(783, 3);
            this.pbxHistorialNav.Name = "pbxHistorialNav";
            this.pbxHistorialNav.Size = new System.Drawing.Size(94, 94);
            this.pbxHistorialNav.TabIndex = 4;
            this.pbxHistorialNav.TabStop = false;
            // 
            // pbxPerfilNav
            // 
            this.pbxPerfilNav.Location = new System.Drawing.Point(550, 3);
            this.pbxPerfilNav.Name = "pbxPerfilNav";
            this.pbxPerfilNav.Size = new System.Drawing.Size(94, 94);
            this.pbxPerfilNav.TabIndex = 3;
            this.pbxPerfilNav.TabStop = false;
            this.pbxPerfilNav.Click += new System.EventHandler(this.pbxPerfilNav_Click);
            // 
            // pbxMensajeNav
            // 
            this.pbxMensajeNav.Location = new System.Drawing.Point(433, 3);
            this.pbxMensajeNav.Name = "pbxMensajeNav";
            this.pbxMensajeNav.Size = new System.Drawing.Size(94, 94);
            this.pbxMensajeNav.TabIndex = 2;
            this.pbxMensajeNav.TabStop = false;
            // 
            // pbxChatNav
            // 
            this.pbxChatNav.Location = new System.Drawing.Point(317, 3);
            this.pbxChatNav.Name = "pbxChatNav";
            this.pbxChatNav.Size = new System.Drawing.Size(94, 94);
            this.pbxChatNav.TabIndex = 1;
            this.pbxChatNav.TabStop = false;
            this.pbxChatNav.Click += new System.EventHandler(this.pbxChatNav_Click);
            // 
            // pbxFotoPerfilNav
            // 
            this.pbxFotoPerfilNav.Location = new System.Drawing.Point(3, 3);
            this.pbxFotoPerfilNav.Name = "pbxFotoPerfilNav";
            this.pbxFotoPerfilNav.Size = new System.Drawing.Size(94, 94);
            this.pbxFotoPerfilNav.TabIndex = 0;
            this.pbxFotoPerfilNav.TabStop = false;
            // 
            // lblNombreAlumno
            // 
            this.lblNombreAlumno.AutoSize = true;
            this.lblNombreAlumno.Location = new System.Drawing.Point(107, 12);
            this.lblNombreAlumno.Name = "lblNombreAlumno";
            this.lblNombreAlumno.Size = new System.Drawing.Size(53, 15);
            this.lblNombreAlumno.TabIndex = 6;
            this.lblNombreAlumno.Text = "Alumno:";
            // 
            // pbxAlumno
            // 
            this.pbxAlumno.Location = new System.Drawing.Point(12, 12);
            this.pbxAlumno.Name = "pbxAlumno";
            this.pbxAlumno.Size = new System.Drawing.Size(75, 75);
            this.pbxAlumno.TabIndex = 5;
            this.pbxAlumno.TabStop = false;
            // 
            // lblFechaDocente
            // 
            this.lblFechaDocente.AutoSize = true;
            this.lblFechaDocente.Location = new System.Drawing.Point(696, 247);
            this.lblFechaDocente.Name = "lblFechaDocente";
            this.lblFechaDocente.Size = new System.Drawing.Size(41, 15);
            this.lblFechaDocente.TabIndex = 4;
            this.lblFechaDocente.Text = "Fecha:";
            // 
            // lblHoraDocente
            // 
            this.lblHoraDocente.AutoSize = true;
            this.lblHoraDocente.Location = new System.Drawing.Point(541, 247);
            this.lblHoraDocente.Name = "lblHoraDocente";
            this.lblHoraDocente.Size = new System.Drawing.Size(36, 15);
            this.lblHoraDocente.TabIndex = 3;
            this.lblHoraDocente.Text = "Hora:";
            // 
            // lblConsultaDocente
            // 
            this.lblConsultaDocente.AutoSize = true;
            this.lblConsultaDocente.Location = new System.Drawing.Point(352, 247);
            this.lblConsultaDocente.Name = "lblConsultaDocente";
            this.lblConsultaDocente.Size = new System.Drawing.Size(57, 15);
            this.lblConsultaDocente.TabIndex = 2;
            this.lblConsultaDocente.Text = "Consulta:";
            // 
            // pbxDocente
            // 
            this.pbxDocente.Location = new System.Drawing.Point(12, 247);
            this.pbxDocente.Name = "pbxDocente";
            this.pbxDocente.Size = new System.Drawing.Size(75, 75);
            this.pbxDocente.TabIndex = 1;
            this.pbxDocente.TabStop = false;
            // 
            // lblNombreDocente
            // 
            this.lblNombreDocente.AutoSize = true;
            this.lblNombreDocente.Location = new System.Drawing.Point(107, 247);
            this.lblNombreDocente.Name = "lblNombreDocente";
            this.lblNombreDocente.Size = new System.Drawing.Size(54, 15);
            this.lblNombreDocente.TabIndex = 0;
            this.lblNombreDocente.Text = "Docente:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(126, 109);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(56, 15);
            this.lblTitulo.TabIndex = 11;
            this.lblTitulo.Text = "Mensajes";
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.Controls.Add(this.btnEnviar);
            this.panelContenedor.Controls.Add(this.rtbxRespuesta);
            this.panelContenedor.Controls.Add(this.rtbxMensajeRecibido);
            this.panelContenedor.Controls.Add(this.lblFechaAlumno);
            this.panelContenedor.Controls.Add(this.lblHoraAlumno);
            this.panelContenedor.Controls.Add(this.lblConsultaAlumno);
            this.panelContenedor.Controls.Add(this.lblNombreAlumno);
            this.panelContenedor.Controls.Add(this.pbxAlumno);
            this.panelContenedor.Controls.Add(this.lblFechaDocente);
            this.panelContenedor.Controls.Add(this.lblHoraDocente);
            this.panelContenedor.Controls.Add(this.lblConsultaDocente);
            this.panelContenedor.Controls.Add(this.pbxDocente);
            this.panelContenedor.Controls.Add(this.lblNombreDocente);
            this.panelContenedor.Location = new System.Drawing.Point(389, 143);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(796, 520);
            this.panelContenedor.TabIndex = 13;
            // 
            // panelNavMensajes
            // 
            this.panelNavMensajes.AutoScroll = true;
            this.panelNavMensajes.Location = new System.Drawing.Point(15, 143);
            this.panelNavMensajes.Name = "panelNavMensajes";
            this.panelNavMensajes.Size = new System.Drawing.Size(278, 520);
            this.panelNavMensajes.TabIndex = 12;
            // 
            // MensajesDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelNavMensajes);
            this.Name = "MensajesDocente";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MensajesDocente_Load);
            this.panelNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox rtbxRespuesta;
        private System.Windows.Forms.RichTextBox rtbxMensajeRecibido;
        private System.Windows.Forms.Label lblFechaAlumno;
        private System.Windows.Forms.Label lblHoraAlumno;
        private System.Windows.Forms.Label lblConsultaAlumno;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.PictureBox pbxGruposNav;
        private System.Windows.Forms.PictureBox pbxCerrarSesionNav;
        private System.Windows.Forms.PictureBox pbxHistorialNav;
        private System.Windows.Forms.PictureBox pbxPerfilNav;
        private System.Windows.Forms.PictureBox pbxMensajeNav;
        private System.Windows.Forms.PictureBox pbxChatNav;
        private System.Windows.Forms.PictureBox pbxFotoPerfilNav;
        private System.Windows.Forms.Label lblNombreAlumno;
        private System.Windows.Forms.PictureBox pbxAlumno;
        private System.Windows.Forms.Label lblFechaDocente;
        private System.Windows.Forms.Label lblHoraDocente;
        private System.Windows.Forms.Label lblConsultaDocente;
        private System.Windows.Forms.PictureBox pbxDocente;
        private System.Windows.Forms.Label lblNombreDocente;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelNavMensajes;
    }
}