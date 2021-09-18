
namespace Hatchat.Presentacion
{
    partial class PrincipalChatDocente
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
            this.tmrCargChat = new System.Windows.Forms.Timer(this.components);
            this.btnEnviar = new System.Windows.Forms.Button();
            this.panelCharla = new System.Windows.Forms.Panel();
            this.txtMensajeChat = new System.Windows.Forms.TextBox();
            this.panelChat = new System.Windows.Forms.Panel();
            this.panelDatosClase = new System.Windows.Forms.Panel();
            this.btnParticipantes = new System.Windows.Forms.Button();
            this.lblHoras = new System.Windows.Forms.Label();
            this.pcbxMaterialDatosClase = new System.Windows.Forms.PictureBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblMateriaClaseChat = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.tmrCargChats = new System.Windows.Forms.Timer(this.components);
            this.panelAceptarChat = new System.Windows.Forms.Panel();
            this.lblChatsIngresarChats = new System.Windows.Forms.Label();
            this.lblIngresarChat = new System.Windows.Forms.Label();
            this.pbxGruposNav = new System.Windows.Forms.PictureBox();
            this.pbxCerrarSesionNav = new System.Windows.Forms.PictureBox();
            this.pbxHistorialNav = new System.Windows.Forms.PictureBox();
            this.pbxPerfilNav = new System.Windows.Forms.PictureBox();
            this.panelChatsActivos = new System.Windows.Forms.Panel();
            this.btnSolicitudes = new System.Windows.Forms.Button();
            this.pbxMensajeNav = new System.Windows.Forms.PictureBox();
            this.lblChats = new System.Windows.Forms.Label();
            this.pbxChatNav = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbxFotoPerfilNav = new System.Windows.Forms.PictureBox();
            this.panelChat.SuspendLayout();
            this.panelDatosClase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMaterialDatosClase)).BeginInit();
            this.panelAceptarChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrCargChat
            // 
            this.tmrCargChat.Interval = 500;
            this.tmrCargChat.Tick += new System.EventHandler(this.tmrCargChat_Tick);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(785, 455);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // panelCharla
            // 
            this.panelCharla.AutoScroll = true;
            this.panelCharla.Location = new System.Drawing.Point(7, 109);
            this.panelCharla.Name = "panelCharla";
            this.panelCharla.Size = new System.Drawing.Size(849, 343);
            this.panelCharla.TabIndex = 11;
            // 
            // txtMensajeChat
            // 
            this.txtMensajeChat.Location = new System.Drawing.Point(7, 458);
            this.txtMensajeChat.Name = "txtMensajeChat";
            this.txtMensajeChat.Size = new System.Drawing.Size(772, 20);
            this.txtMensajeChat.TabIndex = 0;
            // 
            // panelChat
            // 
            this.panelChat.Controls.Add(this.btnEnviar);
            this.panelChat.Controls.Add(this.panelCharla);
            this.panelChat.Controls.Add(this.txtMensajeChat);
            this.panelChat.Controls.Add(this.panelDatosClase);
            this.panelChat.Location = new System.Drawing.Point(214, 96);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(863, 488);
            this.panelChat.TabIndex = 15;
            // 
            // panelDatosClase
            // 
            this.panelDatosClase.Controls.Add(this.btnParticipantes);
            this.panelDatosClase.Controls.Add(this.lblHoras);
            this.panelDatosClase.Controls.Add(this.pcbxMaterialDatosClase);
            this.panelDatosClase.Controls.Add(this.lblHorario);
            this.panelDatosClase.Controls.Add(this.lblMateriaClaseChat);
            this.panelDatosClase.Location = new System.Drawing.Point(3, 3);
            this.panelDatosClase.Name = "panelDatosClase";
            this.panelDatosClase.Size = new System.Drawing.Size(857, 100);
            this.panelDatosClase.TabIndex = 10;
            // 
            // btnParticipantes
            // 
            this.btnParticipantes.Location = new System.Drawing.Point(760, 71);
            this.btnParticipantes.Name = "btnParticipantes";
            this.btnParticipantes.Size = new System.Drawing.Size(92, 23);
            this.btnParticipantes.TabIndex = 11;
            this.btnParticipantes.Text = "Participantes";
            this.btnParticipantes.UseVisualStyleBackColor = true;
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Location = new System.Drawing.Point(757, 35);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(72, 13);
            this.lblHoras.TabIndex = 10;
            this.lblHoras.Text = "hh:mm hh:mm";
            // 
            // pcbxMaterialDatosClase
            // 
            this.pcbxMaterialDatosClase.Location = new System.Drawing.Point(3, 3);
            this.pcbxMaterialDatosClase.Name = "pcbxMaterialDatosClase";
            this.pcbxMaterialDatosClase.Size = new System.Drawing.Size(81, 81);
            this.pcbxMaterialDatosClase.TabIndex = 7;
            this.pcbxMaterialDatosClase.TabStop = false;
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(743, 16);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(105, 13);
            this.lblHorario.TabIndex = 9;
            this.lblHorario.Text = "Horario de actividad:";
            // 
            // lblMateriaClaseChat
            // 
            this.lblMateriaClaseChat.AutoSize = true;
            this.lblMateriaClaseChat.Location = new System.Drawing.Point(90, 29);
            this.lblMateriaClaseChat.Name = "lblMateriaClaseChat";
            this.lblMateriaClaseChat.Size = new System.Drawing.Size(93, 13);
            this.lblMateriaClaseChat.TabIndex = 8;
            this.lblMateriaClaseChat.Text = "Materia Año Clase";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(626, 180);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(59, 13);
            this.lblBienvenido.TabIndex = 13;
            this.lblBienvenido.Text = "bienvenido";
            // 
            // tmrCargChats
            // 
            this.tmrCargChats.Enabled = true;
            this.tmrCargChats.Interval = 500;
            this.tmrCargChats.Tick += new System.EventHandler(this.tmrCargChats_Tick);
            // 
            // panelAceptarChat
            // 
            this.panelAceptarChat.AutoScroll = true;
            this.panelAceptarChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAceptarChat.Controls.Add(this.lblChatsIngresarChats);
            this.panelAceptarChat.Controls.Add(this.lblIngresarChat);
            this.panelAceptarChat.Location = new System.Drawing.Point(9, 158);
            this.panelAceptarChat.Name = "panelAceptarChat";
            this.panelAceptarChat.Size = new System.Drawing.Size(199, 341);
            this.panelAceptarChat.TabIndex = 16;
            // 
            // lblChatsIngresarChats
            // 
            this.lblChatsIngresarChats.AutoSize = true;
            this.lblChatsIngresarChats.Location = new System.Drawing.Point(16, 33);
            this.lblChatsIngresarChats.Name = "lblChatsIngresarChats";
            this.lblChatsIngresarChats.Size = new System.Drawing.Size(37, 13);
            this.lblChatsIngresarChats.TabIndex = 2;
            this.lblChatsIngresarChats.Text = "Chats:";
            // 
            // lblIngresarChat
            // 
            this.lblIngresarChat.AutoSize = true;
            this.lblIngresarChat.Location = new System.Drawing.Point(27, 11);
            this.lblIngresarChat.Name = "lblIngresarChat";
            this.lblIngresarChat.Size = new System.Drawing.Size(93, 13);
            this.lblIngresarChat.TabIndex = 0;
            this.lblIngresarChat.Text = "Ingresar a un chat";
            // 
            // pbxGruposNav
            // 
            this.pbxGruposNav.Location = new System.Drawing.Point(573, 3);
            this.pbxGruposNav.Name = "pbxGruposNav";
            this.pbxGruposNav.Size = new System.Drawing.Size(81, 81);
            this.pbxGruposNav.TabIndex = 6;
            this.pbxGruposNav.TabStop = false;
            this.pbxGruposNav.Click += new System.EventHandler(this.pbxGruposNav_Click);
            // 
            // pbxCerrarSesionNav
            // 
            this.pbxCerrarSesionNav.Location = new System.Drawing.Point(980, 3);
            this.pbxCerrarSesionNav.Name = "pbxCerrarSesionNav";
            this.pbxCerrarSesionNav.Size = new System.Drawing.Size(81, 81);
            this.pbxCerrarSesionNav.TabIndex = 5;
            this.pbxCerrarSesionNav.TabStop = false;
            this.pbxCerrarSesionNav.Click += new System.EventHandler(this.pbxCerrarSesionNav_Click);
            // 
            // pbxHistorialNav
            // 
            this.pbxHistorialNav.Location = new System.Drawing.Point(671, 3);
            this.pbxHistorialNav.Name = "pbxHistorialNav";
            this.pbxHistorialNav.Size = new System.Drawing.Size(81, 81);
            this.pbxHistorialNav.TabIndex = 4;
            this.pbxHistorialNav.TabStop = false;
            // 
            // pbxPerfilNav
            // 
            this.pbxPerfilNav.Location = new System.Drawing.Point(471, 3);
            this.pbxPerfilNav.Name = "pbxPerfilNav";
            this.pbxPerfilNav.Size = new System.Drawing.Size(81, 81);
            this.pbxPerfilNav.TabIndex = 3;
            this.pbxPerfilNav.TabStop = false;
            this.pbxPerfilNav.Click += new System.EventHandler(this.pbxPerfilNav_Click);
            // 
            // panelChatsActivos
            // 
            this.panelChatsActivos.AutoScroll = true;
            this.panelChatsActivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChatsActivos.Location = new System.Drawing.Point(9, 158);
            this.panelChatsActivos.Name = "panelChatsActivos";
            this.panelChatsActivos.Size = new System.Drawing.Size(199, 416);
            this.panelChatsActivos.TabIndex = 12;
            // 
            // btnSolicitudes
            // 
            this.btnSolicitudes.Location = new System.Drawing.Point(9, 129);
            this.btnSolicitudes.Name = "btnSolicitudes";
            this.btnSolicitudes.Size = new System.Drawing.Size(199, 23);
            this.btnSolicitudes.TabIndex = 11;
            this.btnSolicitudes.Text = "Solicitudes Chat";
            this.btnSolicitudes.UseVisualStyleBackColor = true;
            this.btnSolicitudes.Click += new System.EventHandler(this.btnSolicitudes_Click);
            // 
            // pbxMensajeNav
            // 
            this.pbxMensajeNav.Location = new System.Drawing.Point(371, 3);
            this.pbxMensajeNav.Name = "pbxMensajeNav";
            this.pbxMensajeNav.Size = new System.Drawing.Size(81, 81);
            this.pbxMensajeNav.TabIndex = 2;
            this.pbxMensajeNav.TabStop = false;
            this.pbxMensajeNav.Click += new System.EventHandler(this.pbxMensajeNav_Click);
            // 
            // lblChats
            // 
            this.lblChats.AutoSize = true;
            this.lblChats.Location = new System.Drawing.Point(98, 96);
            this.lblChats.Name = "lblChats";
            this.lblChats.Size = new System.Drawing.Size(34, 13);
            this.lblChats.TabIndex = 9;
            this.lblChats.Text = "Chats";
            // 
            // pbxChatNav
            // 
            this.pbxChatNav.Location = new System.Drawing.Point(272, 3);
            this.pbxChatNav.Name = "pbxChatNav";
            this.pbxChatNav.Size = new System.Drawing.Size(81, 81);
            this.pbxChatNav.TabIndex = 1;
            this.pbxChatNav.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbxGruposNav);
            this.panel1.Controls.Add(this.pbxCerrarSesionNav);
            this.panel1.Controls.Add(this.pbxHistorialNav);
            this.panel1.Controls.Add(this.pbxPerfilNav);
            this.panel1.Controls.Add(this.pbxMensajeNav);
            this.panel1.Controls.Add(this.pbxChatNav);
            this.panel1.Controls.Add(this.pbxFotoPerfilNav);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1063, 87);
            this.panel1.TabIndex = 8;
            // 
            // pbxFotoPerfilNav
            // 
            this.pbxFotoPerfilNav.Location = new System.Drawing.Point(3, 3);
            this.pbxFotoPerfilNav.Name = "pbxFotoPerfilNav";
            this.pbxFotoPerfilNav.Size = new System.Drawing.Size(81, 81);
            this.pbxFotoPerfilNav.TabIndex = 0;
            this.pbxFotoPerfilNav.TabStop = false;
            // 
            // PrincipalChatDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 590);
            this.Controls.Add(this.panelChat);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.panelAceptarChat);
            this.Controls.Add(this.panelChatsActivos);
            this.Controls.Add(this.btnSolicitudes);
            this.Controls.Add(this.lblChats);
            this.Controls.Add(this.panel1);
            this.Name = "PrincipalChatDocente";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PrincipalChatDocente_Load);
            this.panelChat.ResumeLayout(false);
            this.panelChat.PerformLayout();
            this.panelDatosClase.ResumeLayout(false);
            this.panelDatosClase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMaterialDatosClase)).EndInit();
            this.panelAceptarChat.ResumeLayout(false);
            this.panelAceptarChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrCargChat;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Panel panelCharla;
        private System.Windows.Forms.TextBox txtMensajeChat;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.Panel panelDatosClase;
        private System.Windows.Forms.Button btnParticipantes;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.PictureBox pcbxMaterialDatosClase;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.Label lblMateriaClaseChat;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Timer tmrCargChats;
        private System.Windows.Forms.Panel panelAceptarChat;
        private System.Windows.Forms.Label lblChatsIngresarChats;
        private System.Windows.Forms.Label lblIngresarChat;
        private System.Windows.Forms.PictureBox pbxGruposNav;
        private System.Windows.Forms.PictureBox pbxCerrarSesionNav;
        private System.Windows.Forms.PictureBox pbxHistorialNav;
        private System.Windows.Forms.PictureBox pbxPerfilNav;
        private System.Windows.Forms.Panel panelChatsActivos;
        private System.Windows.Forms.Button btnSolicitudes;
        private System.Windows.Forms.PictureBox pbxMensajeNav;
        private System.Windows.Forms.Label lblChats;
        private System.Windows.Forms.PictureBox pbxChatNav;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbxFotoPerfilNav;
    }
}