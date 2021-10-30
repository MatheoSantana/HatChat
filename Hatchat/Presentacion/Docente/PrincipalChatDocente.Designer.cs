
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
            this.txtMensajeChat = new System.Windows.Forms.TextBox();
            this.tmrCargChat = new System.Windows.Forms.Timer(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnParticipantes = new System.Windows.Forms.Button();
            this.lblHoras = new System.Windows.Forms.Label();
            this.pcbxMaterialDatosClase = new System.Windows.Forms.PictureBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.panelHistorialesNav = new System.Windows.Forms.Panel();
            this.pcbxHistorialMensajesNav = new System.Windows.Forms.PictureBox();
            this.pcbxHistorialChatNav = new System.Windows.Forms.PictureBox();
            this.tmrCargChats = new System.Windows.Forms.Timer(this.components);
            this.panelParticipantesOrdinarios = new System.Windows.Forms.Panel();
            this.lblHostParticipantes = new System.Windows.Forms.Label();
            this.lblDocenteParticipantes = new System.Windows.Forms.Label();
            this.panelParticipantes = new System.Windows.Forms.Panel();
            this.lblParticipantes = new System.Windows.Forms.Label();
            this.timerCargarFoto = new System.Windows.Forms.Timer(this.components);
            this.panelAceptarChat = new System.Windows.Forms.Panel();
            this.lblChatsIngresarChats = new System.Windows.Forms.Label();
            this.lblIngresarChat = new System.Windows.Forms.Label();
            this.timerHistorialNav = new System.Windows.Forms.Timer(this.components);
            this.btnSolicitudes = new System.Windows.Forms.Button();
            this.lblMateriaClaseChat = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.panelDatosClase = new System.Windows.Forms.Panel();
            this.panelChatsActivos = new System.Windows.Forms.Panel();
            this.lblChats = new System.Windows.Forms.Label();
            this.panelChat = new System.Windows.Forms.Panel();
            this.panelCharla = new System.Windows.Forms.Panel();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.pbxGruposNav = new System.Windows.Forms.PictureBox();
            this.pbxCerrarSesionNav = new System.Windows.Forms.PictureBox();
            this.pbxHistorialNav = new System.Windows.Forms.PictureBox();
            this.pbxPerfilNav = new System.Windows.Forms.PictureBox();
            this.pbxMensajeNav = new System.Windows.Forms.PictureBox();
            this.pbxChatNav = new System.Windows.Forms.PictureBox();
            this.pbxFotoPerfilNav = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMaterialDatosClase)).BeginInit();
            this.panelHistorialesNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialMensajesNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialChatNav)).BeginInit();
            this.panelParticipantes.SuspendLayout();
            this.panelAceptarChat.SuspendLayout();
            this.panelDatosClase.SuspendLayout();
            this.panelChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMensajeChat
            // 
            this.txtMensajeChat.Location = new System.Drawing.Point(7, 458);
            this.txtMensajeChat.Name = "txtMensajeChat";
            this.txtMensajeChat.Size = new System.Drawing.Size(772, 20);
            this.txtMensajeChat.TabIndex = 0;
            // 
            // tmrCargChat
            // 
            this.tmrCargChat.Interval = 500;
            this.tmrCargChat.Tick += new System.EventHandler(this.tmrCargChat_Tick);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(90, 71);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(29, 13);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "titulo";
            // 
            // btnParticipantes
            // 
            this.btnParticipantes.Location = new System.Drawing.Point(754, 71);
            this.btnParticipantes.Name = "btnParticipantes";
            this.btnParticipantes.Size = new System.Drawing.Size(92, 23);
            this.btnParticipantes.TabIndex = 11;
            this.btnParticipantes.Text = "Participantes";
            this.btnParticipantes.UseVisualStyleBackColor = true;
            this.btnParticipantes.Click += new System.EventHandler(this.btnParticipantes_Click);
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
            // panelHistorialesNav
            // 
            this.panelHistorialesNav.Controls.Add(this.pcbxHistorialMensajesNav);
            this.panelHistorialesNav.Controls.Add(this.pcbxHistorialChatNav);
            this.panelHistorialesNav.Location = new System.Drawing.Point(683, 95);
            this.panelHistorialesNav.Name = "panelHistorialesNav";
            this.panelHistorialesNav.Size = new System.Drawing.Size(81, 170);
            this.panelHistorialesNav.TabIndex = 25;
            this.panelHistorialesNav.Visible = false;
            this.panelHistorialesNav.MouseEnter += new System.EventHandler(this.panelHistorialesNav_MouseEnter);
            this.panelHistorialesNav.MouseLeave += new System.EventHandler(this.panelHistorialesNav_MouseLeave);
            // 
            // pcbxHistorialMensajesNav
            // 
            this.pcbxHistorialMensajesNav.Location = new System.Drawing.Point(0, 87);
            this.pcbxHistorialMensajesNav.Name = "pcbxHistorialMensajesNav";
            this.pcbxHistorialMensajesNav.Size = new System.Drawing.Size(81, 81);
            this.pcbxHistorialMensajesNav.TabIndex = 8;
            this.pcbxHistorialMensajesNav.TabStop = false;
            this.pcbxHistorialMensajesNav.Click += new System.EventHandler(this.pcbxHistorialMensajesNav_Click);
            this.pcbxHistorialMensajesNav.MouseEnter += new System.EventHandler(this.pcbxHistorialMensajesNav_MouseEnter);
            this.pcbxHistorialMensajesNav.MouseLeave += new System.EventHandler(this.pcbxHistorialMensajesNav_MouseLeave);
            // 
            // pcbxHistorialChatNav
            // 
            this.pcbxHistorialChatNav.Location = new System.Drawing.Point(0, 0);
            this.pcbxHistorialChatNav.Name = "pcbxHistorialChatNav";
            this.pcbxHistorialChatNav.Size = new System.Drawing.Size(81, 81);
            this.pcbxHistorialChatNav.TabIndex = 7;
            this.pcbxHistorialChatNav.TabStop = false;
            this.pcbxHistorialChatNav.Click += new System.EventHandler(this.pcbxHistorialChatNav_Click);
            this.pcbxHistorialChatNav.MouseEnter += new System.EventHandler(this.pcbxHistorialChatNav_MouseEnter);
            this.pcbxHistorialChatNav.MouseLeave += new System.EventHandler(this.pcbxHistorialChatNav_MouseLeave);
            // 
            // tmrCargChats
            // 
            this.tmrCargChats.Enabled = true;
            this.tmrCargChats.Interval = 500;
            this.tmrCargChats.Tick += new System.EventHandler(this.tmrActChats_Tick);
            // 
            // panelParticipantesOrdinarios
            // 
            this.panelParticipantesOrdinarios.AutoScroll = true;
            this.panelParticipantesOrdinarios.Location = new System.Drawing.Point(3, 130);
            this.panelParticipantesOrdinarios.Name = "panelParticipantesOrdinarios";
            this.panelParticipantesOrdinarios.Size = new System.Drawing.Size(319, 206);
            this.panelParticipantesOrdinarios.TabIndex = 2;
            // 
            // lblHostParticipantes
            // 
            this.lblHostParticipantes.AutoSize = true;
            this.lblHostParticipantes.Location = new System.Drawing.Point(19, 77);
            this.lblHostParticipantes.Name = "lblHostParticipantes";
            this.lblHostParticipantes.Size = new System.Drawing.Size(32, 13);
            this.lblHostParticipantes.TabIndex = 1;
            this.lblHostParticipantes.Text = "Host:";
            // 
            // lblDocenteParticipantes
            // 
            this.lblDocenteParticipantes.AutoSize = true;
            this.lblDocenteParticipantes.Location = new System.Drawing.Point(16, 32);
            this.lblDocenteParticipantes.Name = "lblDocenteParticipantes";
            this.lblDocenteParticipantes.Size = new System.Drawing.Size(51, 13);
            this.lblDocenteParticipantes.TabIndex = 0;
            this.lblDocenteParticipantes.Text = "Docente:";
            // 
            // panelParticipantes
            // 
            this.panelParticipantes.BackColor = System.Drawing.Color.Yellow;
            this.panelParticipantes.Controls.Add(this.lblParticipantes);
            this.panelParticipantes.Controls.Add(this.panelParticipantesOrdinarios);
            this.panelParticipantes.Controls.Add(this.lblHostParticipantes);
            this.panelParticipantes.Controls.Add(this.lblDocenteParticipantes);
            this.panelParticipantes.Location = new System.Drawing.Point(743, 200);
            this.panelParticipantes.Name = "panelParticipantes";
            this.panelParticipantes.Size = new System.Drawing.Size(325, 339);
            this.panelParticipantes.TabIndex = 19;
            this.panelParticipantes.Visible = false;
            // 
            // lblParticipantes
            // 
            this.lblParticipantes.AutoSize = true;
            this.lblParticipantes.Location = new System.Drawing.Point(19, 114);
            this.lblParticipantes.Name = "lblParticipantes";
            this.lblParticipantes.Size = new System.Drawing.Size(74, 13);
            this.lblParticipantes.TabIndex = 3;
            this.lblParticipantes.Text = "Participantes: ";
            // 
            // timerCargarFoto
            // 
            this.timerCargarFoto.Enabled = true;
            this.timerCargarFoto.Interval = 5000;
            this.timerCargarFoto.Tick += new System.EventHandler(this.timerCargarFoto_Tick);
            // 
            // panelAceptarChat
            // 
            this.panelAceptarChat.AutoScroll = true;
            this.panelAceptarChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAceptarChat.Controls.Add(this.lblChatsIngresarChats);
            this.panelAceptarChat.Controls.Add(this.lblIngresarChat);
            this.panelAceptarChat.Location = new System.Drawing.Point(15, 164);
            this.panelAceptarChat.Name = "panelAceptarChat";
            this.panelAceptarChat.Size = new System.Drawing.Size(199, 341);
            this.panelAceptarChat.TabIndex = 27;
            // 
            // lblChatsIngresarChats
            // 
            this.lblChatsIngresarChats.AutoSize = true;
            this.lblChatsIngresarChats.Location = new System.Drawing.Point(27, 27);
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
            // timerHistorialNav
            // 
            this.timerHistorialNav.Enabled = true;
            this.timerHistorialNav.Tick += new System.EventHandler(this.timerHistorialNav_Tick);
            // 
            // btnSolicitudes
            // 
            this.btnSolicitudes.Location = new System.Drawing.Point(15, 135);
            this.btnSolicitudes.Name = "btnSolicitudes";
            this.btnSolicitudes.Size = new System.Drawing.Size(199, 23);
            this.btnSolicitudes.TabIndex = 26;
            this.btnSolicitudes.Text = "Solicitudes Chat";
            this.btnSolicitudes.UseVisualStyleBackColor = true;
            this.btnSolicitudes.Click += new System.EventHandler(this.btnSolicitudes_Click);
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
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(785, 455);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // panelDatosClase
            // 
            this.panelDatosClase.Controls.Add(this.lblTitulo);
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
            // panelChatsActivos
            // 
            this.panelChatsActivos.AutoScroll = true;
            this.panelChatsActivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChatsActivos.Location = new System.Drawing.Point(15, 164);
            this.panelChatsActivos.Name = "panelChatsActivos";
            this.panelChatsActivos.Size = new System.Drawing.Size(199, 416);
            this.panelChatsActivos.TabIndex = 22;
            // 
            // lblChats
            // 
            this.lblChats.AutoSize = true;
            this.lblChats.Location = new System.Drawing.Point(104, 102);
            this.lblChats.Name = "lblChats";
            this.lblChats.Size = new System.Drawing.Size(34, 13);
            this.lblChats.TabIndex = 21;
            this.lblChats.Text = "Chats";
            // 
            // panelChat
            // 
            this.panelChat.Controls.Add(this.panelDatosClase);
            this.panelChat.Controls.Add(this.btnEnviar);
            this.panelChat.Controls.Add(this.panelCharla);
            this.panelChat.Controls.Add(this.txtMensajeChat);
            this.panelChat.Location = new System.Drawing.Point(220, 102);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(863, 488);
            this.panelChat.TabIndex = 24;
            // 
            // panelCharla
            // 
            this.panelCharla.AutoScroll = true;
            this.panelCharla.Location = new System.Drawing.Point(7, 109);
            this.panelCharla.Name = "panelCharla";
            this.panelCharla.Size = new System.Drawing.Size(849, 343);
            this.panelCharla.TabIndex = 11;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(632, 186);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(59, 13);
            this.lblBienvenido.TabIndex = 23;
            this.lblBienvenido.Text = "bienvenido";
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
            this.pbxHistorialNav.MouseEnter += new System.EventHandler(this.pbxHistorialNav_MouseEnter);
            this.pbxHistorialNav.MouseLeave += new System.EventHandler(this.pbxHistorialNav_MouseLeave);
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
            // pbxMensajeNav
            // 
            this.pbxMensajeNav.Location = new System.Drawing.Point(371, 3);
            this.pbxMensajeNav.Name = "pbxMensajeNav";
            this.pbxMensajeNav.Size = new System.Drawing.Size(81, 81);
            this.pbxMensajeNav.TabIndex = 2;
            this.pbxMensajeNav.TabStop = false;
            this.pbxMensajeNav.Click += new System.EventHandler(this.pbxMensajeNav_Click);
            // 
            // pbxChatNav
            // 
            this.pbxChatNav.Location = new System.Drawing.Point(272, 3);
            this.pbxChatNav.Name = "pbxChatNav";
            this.pbxChatNav.Size = new System.Drawing.Size(81, 81);
            this.pbxChatNav.TabIndex = 1;
            this.pbxChatNav.TabStop = false;
            // 
            // pbxFotoPerfilNav
            // 
            this.pbxFotoPerfilNav.Location = new System.Drawing.Point(3, 3);
            this.pbxFotoPerfilNav.Name = "pbxFotoPerfilNav";
            this.pbxFotoPerfilNav.Size = new System.Drawing.Size(81, 81);
            this.pbxFotoPerfilNav.TabIndex = 0;
            this.pbxFotoPerfilNav.TabStop = false;
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1063, 87);
            this.panel1.TabIndex = 20;
            // 
            // PrincipalChatDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelHistorialesNav);
            this.Controls.Add(this.panelParticipantes);
            this.Controls.Add(this.panelAceptarChat);
            this.Controls.Add(this.btnSolicitudes);
            this.Controls.Add(this.panelChatsActivos);
            this.Controls.Add(this.lblChats);
            this.Controls.Add(this.panelChat);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.panel1);
            this.Name = "PrincipalChatDocente";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PrincipalChatDocente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMaterialDatosClase)).EndInit();
            this.panelHistorialesNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialMensajesNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialChatNav)).EndInit();
            this.panelParticipantes.ResumeLayout(false);
            this.panelParticipantes.PerformLayout();
            this.panelAceptarChat.ResumeLayout(false);
            this.panelAceptarChat.PerformLayout();
            this.panelDatosClase.ResumeLayout(false);
            this.panelDatosClase.PerformLayout();
            this.panelChat.ResumeLayout(false);
            this.panelChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMensajeChat;
        private System.Windows.Forms.Timer tmrCargChat;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnParticipantes;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.PictureBox pcbxMaterialDatosClase;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.Panel panelHistorialesNav;
        private System.Windows.Forms.PictureBox pcbxHistorialMensajesNav;
        private System.Windows.Forms.PictureBox pcbxHistorialChatNav;
        private System.Windows.Forms.Timer tmrCargChats;
        private System.Windows.Forms.Panel panelParticipantesOrdinarios;
        private System.Windows.Forms.Label lblHostParticipantes;
        private System.Windows.Forms.Label lblDocenteParticipantes;
        private System.Windows.Forms.Panel panelParticipantes;
        private System.Windows.Forms.Label lblParticipantes;
        private System.Windows.Forms.Timer timerCargarFoto;
        private System.Windows.Forms.Panel panelAceptarChat;
        private System.Windows.Forms.Label lblChatsIngresarChats;
        private System.Windows.Forms.Label lblIngresarChat;
        private System.Windows.Forms.Timer timerHistorialNav;
        private System.Windows.Forms.Button btnSolicitudes;
        private System.Windows.Forms.Label lblMateriaClaseChat;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Panel panelDatosClase;
        private System.Windows.Forms.Panel panelChatsActivos;
        private System.Windows.Forms.Label lblChats;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.Panel panelCharla;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.PictureBox pbxGruposNav;
        private System.Windows.Forms.PictureBox pbxCerrarSesionNav;
        private System.Windows.Forms.PictureBox pbxHistorialNav;
        private System.Windows.Forms.PictureBox pbxPerfilNav;
        private System.Windows.Forms.PictureBox pbxMensajeNav;
        private System.Windows.Forms.PictureBox pbxChatNav;
        private System.Windows.Forms.PictureBox pbxFotoPerfilNav;
        private System.Windows.Forms.Panel panel1;
    }
}