
namespace Hatchat.Presentacion
{
    partial class HistorialChatsDocente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialChatsDocente));
            this.lblHistorialChats = new System.Windows.Forms.Label();
            this.tmrCargChat = new System.Windows.Forms.Timer(this.components);
            this.timerHistorialNav = new System.Windows.Forms.Timer(this.components);
            this.timerHistorialChats = new System.Windows.Forms.Timer(this.components);
            this.timerCargarFoto = new System.Windows.Forms.Timer(this.components);
            this.panelHistorialesNav = new System.Windows.Forms.Panel();
            this.pcbxHistorialMensajesNav = new System.Windows.Forms.PictureBox();
            this.pcbxHistorialChatNav = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbxGruposNav = new System.Windows.Forms.PictureBox();
            this.pbxCerrarSesionNav = new System.Windows.Forms.PictureBox();
            this.pbxHistorialNav = new System.Windows.Forms.PictureBox();
            this.pbxPerfilNav = new System.Windows.Forms.PictureBox();
            this.pbxMensajeNav = new System.Windows.Forms.PictureBox();
            this.pbxChatNav = new System.Windows.Forms.PictureBox();
            this.pbxFotoPerfilNav = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnFiltrarAsignatura = new System.Windows.Forms.Button();
            this.cmbxAsignatura = new System.Windows.Forms.ComboBox();
            this.dtpFiltro = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarFecha = new System.Windows.Forms.Button();
            this.lblHistrialChat = new System.Windows.Forms.Label();
            this.panelTextoChat = new System.Windows.Forms.Panel();
            this.panelChat = new System.Windows.Forms.Panel();
            this.panelDatosClase = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnParticipantes = new System.Windows.Forms.Button();
            this.lblHoras = new System.Windows.Forms.Label();
            this.pcbxMaterialDatosClase = new System.Windows.Forms.PictureBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblMateriaClaseChat = new System.Windows.Forms.Label();
            this.panelCharla = new System.Windows.Forms.Panel();
            this.panelChatsActivos = new System.Windows.Forms.Panel();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.pcbxLogo = new System.Windows.Forms.PictureBox();
            this.panelParticipantes = new System.Windows.Forms.Panel();
            this.lblParticipantes = new System.Windows.Forms.Label();
            this.panelParticipantesOrdinarios = new System.Windows.Forms.Panel();
            this.lblHostParticipantes = new System.Windows.Forms.Label();
            this.lblDocenteParticipantes = new System.Windows.Forms.Label();
            this.panelHistorialesNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialMensajesNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialChatNav)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelTextoChat.SuspendLayout();
            this.panelChat.SuspendLayout();
            this.panelDatosClase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMaterialDatosClase)).BeginInit();
            this.panelChatsActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxLogo)).BeginInit();
            this.panelParticipantes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHistorialChats
            // 
            this.lblHistorialChats.AutoSize = true;
            this.lblHistorialChats.Location = new System.Drawing.Point(74, 106);
            this.lblHistorialChats.Name = "lblHistorialChats";
            this.lblHistorialChats.Size = new System.Drawing.Size(74, 13);
            this.lblHistorialChats.TabIndex = 2;
            this.lblHistorialChats.Text = "Historial Chats";
            // 
            // tmrCargChat
            // 
            this.tmrCargChat.Interval = 500;
            this.tmrCargChat.Tick += new System.EventHandler(this.tmrCargChat_Tick);
            // 
            // timerHistorialNav
            // 
            this.timerHistorialNav.Enabled = true;
            this.timerHistorialNav.Tick += new System.EventHandler(this.timerHistorialNav_Tick);
            // 
            // timerHistorialChats
            // 
            this.timerHistorialChats.Enabled = true;
            this.timerHistorialChats.Interval = 500;
            this.timerHistorialChats.Tick += new System.EventHandler(this.timerHistorialChats_Tick);
            // 
            // timerCargarFoto
            // 
            this.timerCargarFoto.Interval = 5000;
            this.timerCargarFoto.Tick += new System.EventHandler(this.timerCargarFoto_Tick);
            // 
            // panelHistorialesNav
            // 
            this.panelHistorialesNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panelHistorialesNav.Controls.Add(this.pcbxHistorialMensajesNav);
            this.panelHistorialesNav.Controls.Add(this.pcbxHistorialChatNav);
            this.panelHistorialesNav.Location = new System.Drawing.Point(882, 104);
            this.panelHistorialesNav.Name = "panelHistorialesNav";
            this.panelHistorialesNav.Size = new System.Drawing.Size(80, 170);
            this.panelHistorialesNav.TabIndex = 19;
            this.panelHistorialesNav.Visible = false;
            this.panelHistorialesNav.MouseEnter += new System.EventHandler(this.panelHistorialesNav_MouseEnter);
            this.panelHistorialesNav.MouseLeave += new System.EventHandler(this.panelHistorialesNav_MouseLeave);
            // 
            // pcbxHistorialMensajesNav
            // 
            this.pcbxHistorialMensajesNav.Location = new System.Drawing.Point(0, 89);
            this.pcbxHistorialMensajesNav.Name = "pcbxHistorialMensajesNav";
            this.pcbxHistorialMensajesNav.Size = new System.Drawing.Size(80, 80);
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
            this.pcbxHistorialChatNav.Size = new System.Drawing.Size(80, 80);
            this.pcbxHistorialChatNav.TabIndex = 7;
            this.pcbxHistorialChatNav.TabStop = false;
            this.pcbxHistorialChatNav.MouseEnter += new System.EventHandler(this.pcbxHistorialChatNav_MouseEnter);
            this.pcbxHistorialChatNav.MouseLeave += new System.EventHandler(this.pcbxHistorialChatNav_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbxGruposNav);
            this.panel1.Controls.Add(this.pbxCerrarSesionNav);
            this.panel1.Controls.Add(this.pbxHistorialNav);
            this.panel1.Controls.Add(this.pbxPerfilNav);
            this.panel1.Controls.Add(this.pbxMensajeNav);
            this.panel1.Controls.Add(this.pbxChatNav);
            this.panel1.Controls.Add(this.pbxFotoPerfilNav);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1242, 108);
            this.panel1.TabIndex = 18;
            // 
            // pbxGruposNav
            // 
            this.pbxGruposNav.Location = new System.Drawing.Point(735, 14);
            this.pbxGruposNav.Name = "pbxGruposNav";
            this.pbxGruposNav.Size = new System.Drawing.Size(80, 80);
            this.pbxGruposNav.TabIndex = 6;
            this.pbxGruposNav.TabStop = false;
            this.pbxGruposNav.Click += new System.EventHandler(this.pbxGruposNav_Click);
            // 
            // pbxCerrarSesionNav
            // 
            this.pbxCerrarSesionNav.InitialImage = global::Hatchat.Properties.Resources.cerrar_sesion;
            this.pbxCerrarSesionNav.Location = new System.Drawing.Point(1129, 14);
            this.pbxCerrarSesionNav.Name = "pbxCerrarSesionNav";
            this.pbxCerrarSesionNav.Size = new System.Drawing.Size(80, 80);
            this.pbxCerrarSesionNav.TabIndex = 5;
            this.pbxCerrarSesionNav.TabStop = false;
            this.pbxCerrarSesionNav.Click += new System.EventHandler(this.pbxCerrarSesionNav_Click);
            // 
            // pbxHistorialNav
            // 
            this.pbxHistorialNav.Location = new System.Drawing.Point(871, 14);
            this.pbxHistorialNav.Name = "pbxHistorialNav";
            this.pbxHistorialNav.Size = new System.Drawing.Size(80, 80);
            this.pbxHistorialNav.TabIndex = 4;
            this.pbxHistorialNav.TabStop = false;
            this.pbxHistorialNav.MouseEnter += new System.EventHandler(this.pbxHistorialNav_MouseEnter);
            this.pbxHistorialNav.MouseLeave += new System.EventHandler(this.pbxHistorialNav_MouseLeave);
            // 
            // pbxPerfilNav
            // 
            this.pbxPerfilNav.Location = new System.Drawing.Point(609, 14);
            this.pbxPerfilNav.Name = "pbxPerfilNav";
            this.pbxPerfilNav.Size = new System.Drawing.Size(80, 80);
            this.pbxPerfilNav.TabIndex = 3;
            this.pbxPerfilNav.TabStop = false;
            this.pbxPerfilNav.Click += new System.EventHandler(this.pbxPerfilNav_Click);
            // 
            // pbxMensajeNav
            // 
            this.pbxMensajeNav.Location = new System.Drawing.Point(485, 14);
            this.pbxMensajeNav.Name = "pbxMensajeNav";
            this.pbxMensajeNav.Size = new System.Drawing.Size(80, 80);
            this.pbxMensajeNav.TabIndex = 2;
            this.pbxMensajeNav.TabStop = false;
            this.pbxMensajeNav.Click += new System.EventHandler(this.pbxMensajeNav_Click);
            // 
            // pbxChatNav
            // 
            this.pbxChatNav.Location = new System.Drawing.Point(351, 14);
            this.pbxChatNav.Name = "pbxChatNav";
            this.pbxChatNav.Size = new System.Drawing.Size(80, 80);
            this.pbxChatNav.TabIndex = 1;
            this.pbxChatNav.TabStop = false;
            this.pbxChatNav.Click += new System.EventHandler(this.pcbxPrincipalChatNav_Click);
            // 
            // pbxFotoPerfilNav
            // 
            this.pbxFotoPerfilNav.Location = new System.Drawing.Point(3, 3);
            this.pbxFotoPerfilNav.Name = "pbxFotoPerfilNav";
            this.pbxFotoPerfilNav.Size = new System.Drawing.Size(100, 100);
            this.pbxFotoPerfilNav.TabIndex = 0;
            this.pbxFotoPerfilNav.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnVolver);
            this.panel2.Controls.Add(this.btnFiltrarAsignatura);
            this.panel2.Controls.Add(this.cmbxAsignatura);
            this.panel2.Controls.Add(this.dtpFiltro);
            this.panel2.Controls.Add(this.btnFiltrarFecha);
            this.panel2.Location = new System.Drawing.Point(10, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 505);
            this.panel2.TabIndex = 21;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolver.Font = new System.Drawing.Font("Arial", 12F);
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVolver.Location = new System.Drawing.Point(94, 401);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(140, 40);
            this.btnVolver.TabIndex = 25;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Visible = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnFiltrarAsignatura
            // 
            this.btnFiltrarAsignatura.BackColor = System.Drawing.Color.White;
            this.btnFiltrarAsignatura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltrarAsignatura.Font = new System.Drawing.Font("Arial", 12F);
            this.btnFiltrarAsignatura.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFiltrarAsignatura.Location = new System.Drawing.Point(7, 27);
            this.btnFiltrarAsignatura.Name = "btnFiltrarAsignatura";
            this.btnFiltrarAsignatura.Size = new System.Drawing.Size(300, 40);
            this.btnFiltrarAsignatura.TabIndex = 14;
            this.btnFiltrarAsignatura.Text = "Filtrar Asignatura";
            this.btnFiltrarAsignatura.UseVisualStyleBackColor = false;
            this.btnFiltrarAsignatura.Click += new System.EventHandler(this.btnFiltrarAsignatura_Click);
            // 
            // cmbxAsignatura
            // 
            this.cmbxAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAsignatura.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbxAsignatura.FormattingEnabled = true;
            this.cmbxAsignatura.Location = new System.Drawing.Point(7, 73);
            this.cmbxAsignatura.Name = "cmbxAsignatura";
            this.cmbxAsignatura.Size = new System.Drawing.Size(300, 26);
            this.cmbxAsignatura.TabIndex = 15;
            this.cmbxAsignatura.Visible = false;
            // 
            // dtpFiltro
            // 
            this.dtpFiltro.CalendarFont = new System.Drawing.Font("Arial", 12F);
            this.dtpFiltro.Location = new System.Drawing.Point(3, 272);
            this.dtpFiltro.Name = "dtpFiltro";
            this.dtpFiltro.Size = new System.Drawing.Size(300, 20);
            this.dtpFiltro.TabIndex = 16;
            this.dtpFiltro.Visible = false;
            // 
            // btnFiltrarFecha
            // 
            this.btnFiltrarFecha.BackColor = System.Drawing.Color.White;
            this.btnFiltrarFecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltrarFecha.Font = new System.Drawing.Font("Arial", 12F);
            this.btnFiltrarFecha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFiltrarFecha.Location = new System.Drawing.Point(3, 226);
            this.btnFiltrarFecha.Name = "btnFiltrarFecha";
            this.btnFiltrarFecha.Size = new System.Drawing.Size(300, 40);
            this.btnFiltrarFecha.TabIndex = 17;
            this.btnFiltrarFecha.Text = "Filtrar Fecha";
            this.btnFiltrarFecha.UseVisualStyleBackColor = false;
            this.btnFiltrarFecha.Click += new System.EventHandler(this.btnFiltrarFecha_Click);
            // 
            // lblHistrialChat
            // 
            this.lblHistrialChat.AutoSize = true;
            this.lblHistrialChat.Font = new System.Drawing.Font("Arial", 28.25F);
            this.lblHistrialChat.Location = new System.Drawing.Point(-1, 0);
            this.lblHistrialChat.Name = "lblHistrialChat";
            this.lblHistrialChat.Size = new System.Drawing.Size(320, 43);
            this.lblHistrialChat.TabIndex = 2;
            this.lblHistrialChat.Text = "Historial de Chats";
            // 
            // panelTextoChat
            // 
            this.panelTextoChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(136)))), ((int)(((byte)(88)))));
            this.panelTextoChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextoChat.Controls.Add(this.lblHistrialChat);
            this.panelTextoChat.Location = new System.Drawing.Point(10, 118);
            this.panelTextoChat.Name = "panelTextoChat";
            this.panelTextoChat.Size = new System.Drawing.Size(321, 46);
            this.panelTextoChat.TabIndex = 26;
            // 
            // panelChat
            // 
            this.panelChat.AutoScroll = true;
            this.panelChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChat.Controls.Add(this.panelCharla);
            this.panelChat.Controls.Add(this.panelDatosClase);
            this.panelChat.Location = new System.Drawing.Point(331, 118);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(921, 551);
            this.panelChat.TabIndex = 30;
            // 
            // panelDatosClase
            // 
            this.panelDatosClase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panelDatosClase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDatosClase.Controls.Add(this.lblTitulo);
            this.panelDatosClase.Controls.Add(this.btnParticipantes);
            this.panelDatosClase.Controls.Add(this.lblHoras);
            this.panelDatosClase.Controls.Add(this.pcbxMaterialDatosClase);
            this.panelDatosClase.Controls.Add(this.lblHorario);
            this.panelDatosClase.Controls.Add(this.lblMateriaClaseChat);
            this.panelDatosClase.Location = new System.Drawing.Point(-2, -2);
            this.panelDatosClase.Name = "panelDatosClase";
            this.panelDatosClase.Size = new System.Drawing.Size(921, 100);
            this.panelDatosClase.TabIndex = 14;
            this.panelDatosClase.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 30F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(111, 54);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(101, 45);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "titulo";
            // 
            // btnParticipantes
            // 
            this.btnParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(116)))), ((int)(((byte)(110)))));
            this.btnParticipantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParticipantes.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnParticipantes.ForeColor = System.Drawing.Color.White;
            this.btnParticipantes.Location = new System.Drawing.Point(798, 70);
            this.btnParticipantes.Name = "btnParticipantes";
            this.btnParticipantes.Size = new System.Drawing.Size(115, 25);
            this.btnParticipantes.TabIndex = 11;
            this.btnParticipantes.Text = "Participantes";
            this.btnParticipantes.UseVisualStyleBackColor = false;
            this.btnParticipantes.Click += new System.EventHandler(this.btnParticipantes_Click);
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Font = new System.Drawing.Font("Arial", 8F);
            this.lblHoras.ForeColor = System.Drawing.Color.White;
            this.lblHoras.Location = new System.Drawing.Point(795, 27);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(72, 14);
            this.lblHoras.TabIndex = 10;
            this.lblHoras.Text = "hh:mm hh:mm";
            // 
            // pcbxMaterialDatosClase
            // 
            this.pcbxMaterialDatosClase.Location = new System.Drawing.Point(0, 0);
            this.pcbxMaterialDatosClase.Name = "pcbxMaterialDatosClase";
            this.pcbxMaterialDatosClase.Size = new System.Drawing.Size(100, 100);
            this.pcbxMaterialDatosClase.TabIndex = 7;
            this.pcbxMaterialDatosClase.TabStop = false;
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Font = new System.Drawing.Font("Arial", 8F);
            this.lblHorario.ForeColor = System.Drawing.Color.White;
            this.lblHorario.Location = new System.Drawing.Point(781, 8);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(106, 14);
            this.lblHorario.TabIndex = 9;
            this.lblHorario.Text = "Horario de actividad:";
            // 
            // lblMateriaClaseChat
            // 
            this.lblMateriaClaseChat.AutoSize = true;
            this.lblMateriaClaseChat.Font = new System.Drawing.Font("Arial", 30F);
            this.lblMateriaClaseChat.ForeColor = System.Drawing.Color.White;
            this.lblMateriaClaseChat.Location = new System.Drawing.Point(106, 3);
            this.lblMateriaClaseChat.Name = "lblMateriaClaseChat";
            this.lblMateriaClaseChat.Size = new System.Drawing.Size(342, 45);
            this.lblMateriaClaseChat.TabIndex = 8;
            this.lblMateriaClaseChat.Text = "Materia Año Clase";
            // 
            // panelCharla
            // 
            this.panelCharla.AutoScroll = true;
            this.panelCharla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panelCharla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCharla.Location = new System.Drawing.Point(-2, 98);
            this.panelCharla.Name = "panelCharla";
            this.panelCharla.Size = new System.Drawing.Size(921, 451);
            this.panelCharla.TabIndex = 15;
            this.panelCharla.Visible = false;
            // 
            // panelChatsActivos
            // 
            this.panelChatsActivos.AutoScroll = true;
            this.panelChatsActivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChatsActivos.Controls.Add(this.lblBienvenido);
            this.panelChatsActivos.Controls.Add(this.lblLinea);
            this.panelChatsActivos.Controls.Add(this.pcbxLogo);
            this.panelChatsActivos.Location = new System.Drawing.Point(411, 141);
            this.panelChatsActivos.Name = "panelChatsActivos";
            this.panelChatsActivos.Size = new System.Drawing.Size(740, 485);
            this.panelChatsActivos.TabIndex = 32;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Arial", 26F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(99, 96);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(503, 40);
            this.lblBienvenido.TabIndex = 16;
            this.lblBienvenido.Text = "Usted no tiene chats archivados";
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Font = new System.Drawing.Font("Arial", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinea.ForeColor = System.Drawing.Color.White;
            this.lblLinea.Location = new System.Drawing.Point(32, 82);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(656, 67);
            this.lblLinea.TabIndex = 17;
            this.lblLinea.Text = "___________________";
            // 
            // pcbxLogo
            // 
            this.pcbxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbxLogo.InitialImage")));
            this.pcbxLogo.Location = new System.Drawing.Point(178, 160);
            this.pcbxLogo.Name = "pcbxLogo";
            this.pcbxLogo.Size = new System.Drawing.Size(363, 244);
            this.pcbxLogo.TabIndex = 18;
            this.pcbxLogo.TabStop = false;
            // 
            // panelParticipantes
            // 
            this.panelParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panelParticipantes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelParticipantes.Controls.Add(this.lblParticipantes);
            this.panelParticipantes.Controls.Add(this.panelParticipantesOrdinarios);
            this.panelParticipantes.Controls.Add(this.lblHostParticipantes);
            this.panelParticipantes.Controls.Add(this.lblDocenteParticipantes);
            this.panelParticipantes.Location = new System.Drawing.Point(919, 217);
            this.panelParticipantes.Name = "panelParticipantes";
            this.panelParticipantes.Size = new System.Drawing.Size(325, 433);
            this.panelParticipantes.TabIndex = 19;
            this.panelParticipantes.Visible = false;
            // 
            // lblParticipantes
            // 
            this.lblParticipantes.AutoSize = true;
            this.lblParticipantes.Font = new System.Drawing.Font("Arial", 12F);
            this.lblParticipantes.ForeColor = System.Drawing.Color.White;
            this.lblParticipantes.Location = new System.Drawing.Point(19, 97);
            this.lblParticipantes.Name = "lblParticipantes";
            this.lblParticipantes.Size = new System.Drawing.Size(108, 18);
            this.lblParticipantes.TabIndex = 3;
            this.lblParticipantes.Text = "Participantes: ";
            // 
            // panelParticipantesOrdinarios
            // 
            this.panelParticipantesOrdinarios.AutoScroll = true;
            this.panelParticipantesOrdinarios.Location = new System.Drawing.Point(3, 130);
            this.panelParticipantesOrdinarios.Name = "panelParticipantesOrdinarios";
            this.panelParticipantesOrdinarios.Size = new System.Drawing.Size(319, 300);
            this.panelParticipantesOrdinarios.TabIndex = 2;
            // 
            // lblHostParticipantes
            // 
            this.lblHostParticipantes.AutoSize = true;
            this.lblHostParticipantes.Font = new System.Drawing.Font("Arial", 12F);
            this.lblHostParticipantes.ForeColor = System.Drawing.Color.White;
            this.lblHostParticipantes.Location = new System.Drawing.Point(19, 60);
            this.lblHostParticipantes.Name = "lblHostParticipantes";
            this.lblHostParticipantes.Size = new System.Drawing.Size(44, 18);
            this.lblHostParticipantes.TabIndex = 1;
            this.lblHostParticipantes.Text = "Host:";
            // 
            // lblDocenteParticipantes
            // 
            this.lblDocenteParticipantes.AutoSize = true;
            this.lblDocenteParticipantes.Font = new System.Drawing.Font("Arial", 12F);
            this.lblDocenteParticipantes.ForeColor = System.Drawing.Color.White;
            this.lblDocenteParticipantes.Location = new System.Drawing.Point(16, 15);
            this.lblDocenteParticipantes.Name = "lblDocenteParticipantes";
            this.lblDocenteParticipantes.Size = new System.Drawing.Size(71, 18);
            this.lblDocenteParticipantes.TabIndex = 0;
            this.lblDocenteParticipantes.Text = "Docente:";
            // 
            // HistorialChatsDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelHistorialesNav);
            this.Controls.Add(this.panelParticipantes);
            this.Controls.Add(this.panelChatsActivos);
            this.Controls.Add(this.panelChat);
            this.Controls.Add(this.panelTextoChat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHistorialChats);
            this.Name = "HistorialChatsDocente";
            this.Text = "PrincipalChatAlumno";
            this.Load += new System.EventHandler(this.PrincipalChatAlumno_Load);
            this.panelHistorialesNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialMensajesNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialChatNav)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelTextoChat.ResumeLayout(false);
            this.panelTextoChat.PerformLayout();
            this.panelChat.ResumeLayout(false);
            this.panelDatosClase.ResumeLayout(false);
            this.panelDatosClase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMaterialDatosClase)).EndInit();
            this.panelChatsActivos.ResumeLayout(false);
            this.panelChatsActivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxLogo)).EndInit();
            this.panelParticipantes.ResumeLayout(false);
            this.panelParticipantes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHistorialChats;
        private System.Windows.Forms.Timer tmrCargChat;
        private System.Windows.Forms.Timer timerHistorialNav;
        private System.Windows.Forms.Timer timerHistorialChats;
        private System.Windows.Forms.Timer timerCargarFoto;
        private System.Windows.Forms.Panel panelHistorialesNav;
        private System.Windows.Forms.PictureBox pcbxHistorialMensajesNav;
        private System.Windows.Forms.PictureBox pcbxHistorialChatNav;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbxGruposNav;
        private System.Windows.Forms.PictureBox pbxCerrarSesionNav;
        private System.Windows.Forms.PictureBox pbxHistorialNav;
        private System.Windows.Forms.PictureBox pbxPerfilNav;
        private System.Windows.Forms.PictureBox pbxMensajeNav;
        private System.Windows.Forms.PictureBox pbxChatNav;
        private System.Windows.Forms.PictureBox pbxFotoPerfilNav;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnFiltrarAsignatura;
        private System.Windows.Forms.ComboBox cmbxAsignatura;
        private System.Windows.Forms.DateTimePicker dtpFiltro;
        private System.Windows.Forms.Button btnFiltrarFecha;
        private System.Windows.Forms.Label lblHistrialChat;
        private System.Windows.Forms.Panel panelTextoChat;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.Panel panelDatosClase;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnParticipantes;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.PictureBox pcbxMaterialDatosClase;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.Label lblMateriaClaseChat;
        private System.Windows.Forms.Panel panelCharla;
        private System.Windows.Forms.Panel panelChatsActivos;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.PictureBox pcbxLogo;
        private System.Windows.Forms.Panel panelParticipantes;
        private System.Windows.Forms.Label lblParticipantes;
        private System.Windows.Forms.Panel panelParticipantesOrdinarios;
        private System.Windows.Forms.Label lblHostParticipantes;
        private System.Windows.Forms.Label lblDocenteParticipantes;
    }
}