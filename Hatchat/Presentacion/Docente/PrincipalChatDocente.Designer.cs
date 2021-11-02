
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalChatDocente));
            this.tmrCargChat = new System.Windows.Forms.Timer(this.components);
            this.tmrCargChats = new System.Windows.Forms.Timer(this.components);
            this.timerCargarFoto = new System.Windows.Forms.Timer(this.components);
            this.timerHistorialNav = new System.Windows.Forms.Timer(this.components);
            this.panelHistorialesNav = new System.Windows.Forms.Panel();
            this.pcbxHistorialMensajesNav = new System.Windows.Forms.PictureBox();
            this.pcbxHistorialChatNav = new System.Windows.Forms.PictureBox();
            this.panelNav = new System.Windows.Forms.Panel();
            this.pbxGruposNav = new System.Windows.Forms.PictureBox();
            this.pbxCerrarSesionNav = new System.Windows.Forms.PictureBox();
            this.pbxHistorialNav = new System.Windows.Forms.PictureBox();
            this.pbxPerfilNav = new System.Windows.Forms.PictureBox();
            this.pbxMensajeNav = new System.Windows.Forms.PictureBox();
            this.pbxChatNav = new System.Windows.Forms.PictureBox();
            this.pbxFotoPerfilNav = new System.Windows.Forms.PictureBox();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelChat = new System.Windows.Forms.Panel();
            this.pcbxBotonEnviar = new System.Windows.Forms.PictureBox();
            this.panelDatosClase = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnParticipantes = new System.Windows.Forms.Button();
            this.lblHoras = new System.Windows.Forms.Label();
            this.pcbxMaterialDatosClase = new System.Windows.Forms.PictureBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblMateriaClaseChat = new System.Windows.Forms.Label();
            this.panelCharla = new System.Windows.Forms.Panel();
            this.txtMensajeChat = new System.Windows.Forms.TextBox();
            this.panelParticipantes = new System.Windows.Forms.Panel();
            this.lblParticipantes = new System.Windows.Forms.Label();
            this.panelParticipantesOrdinarios = new System.Windows.Forms.Panel();
            this.lblHostParticipantes = new System.Windows.Forms.Label();
            this.lblDocenteParticipantes = new System.Windows.Forms.Label();
            this.panelTextoChat = new System.Windows.Forms.Panel();
            this.lblChats = new System.Windows.Forms.Label();
            this.panelDesplegarSolicitudes = new System.Windows.Forms.Panel();
            this.pcbxDesplegarSolicitudes = new System.Windows.Forms.PictureBox();
            this.pcbxNotificacion = new System.Windows.Forms.PictureBox();
            this.lblSolicitudes = new System.Windows.Forms.Label();
            this.panelChatsActivos = new System.Windows.Forms.Panel();
            this.panelChatsAIngresar = new System.Windows.Forms.Panel();
            this.timerSolicitudes = new System.Windows.Forms.Timer(this.components);
            this.panelHistorialesNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialMensajesNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialChatNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxBotonEnviar)).BeginInit();
            this.panelDatosClase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMaterialDatosClase)).BeginInit();
            this.panelParticipantes.SuspendLayout();
            this.panelTextoChat.SuspendLayout();
            this.panelDesplegarSolicitudes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDesplegarSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxNotificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrCargChat
            // 
            this.tmrCargChat.Interval = 500;
            this.tmrCargChat.Tick += new System.EventHandler(this.tmrCargChat_Tick);
            // 
            // tmrCargChats
            // 
            this.tmrCargChats.Enabled = true;
            this.tmrCargChats.Interval = 500;
            this.tmrCargChats.Tick += new System.EventHandler(this.tmrActChats_Tick);
            // 
            // timerCargarFoto
            // 
            this.timerCargarFoto.Enabled = true;
            this.timerCargarFoto.Interval = 5000;
            this.timerCargarFoto.Tick += new System.EventHandler(this.timerCargarFoto_Tick);
            // 
            // timerHistorialNav
            // 
            this.timerHistorialNav.Enabled = true;
            this.timerHistorialNav.Tick += new System.EventHandler(this.timerHistorialNav_Tick);
            // 
            // panelHistorialesNav
            // 
            this.panelHistorialesNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panelHistorialesNav.Controls.Add(this.pcbxHistorialMensajesNav);
            this.panelHistorialesNav.Controls.Add(this.pcbxHistorialChatNav);
            this.panelHistorialesNav.Location = new System.Drawing.Point(977, 8);
            this.panelHistorialesNav.Name = "panelHistorialesNav";
            this.panelHistorialesNav.Size = new System.Drawing.Size(80, 170);
            this.panelHistorialesNav.TabIndex = 29;
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
            this.pcbxHistorialChatNav.Click += new System.EventHandler(this.pcbxHistorialChatNav_Click);
            this.pcbxHistorialChatNav.MouseEnter += new System.EventHandler(this.pcbxHistorialChatNav_MouseEnter);
            this.pcbxHistorialChatNav.MouseLeave += new System.EventHandler(this.pcbxHistorialChatNav_MouseLeave);
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panelNav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNav.Controls.Add(this.panelHistorialesNav);
            this.panelNav.Controls.Add(this.pbxGruposNav);
            this.panelNav.Controls.Add(this.pbxCerrarSesionNav);
            this.panelNav.Controls.Add(this.pbxHistorialNav);
            this.panelNav.Controls.Add(this.pbxPerfilNav);
            this.panelNav.Controls.Add(this.pbxMensajeNav);
            this.panelNav.Controls.Add(this.pbxChatNav);
            this.panelNav.Controls.Add(this.pbxFotoPerfilNav);
            this.panelNav.Location = new System.Drawing.Point(10, 10);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1242, 108);
            this.panelNav.TabIndex = 28;
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
            // 
            // pbxFotoPerfilNav
            // 
            this.pbxFotoPerfilNav.Location = new System.Drawing.Point(3, 3);
            this.pbxFotoPerfilNav.Name = "pbxFotoPerfilNav";
            this.pbxFotoPerfilNav.Size = new System.Drawing.Size(100, 100);
            this.pbxFotoPerfilNav.TabIndex = 0;
            this.pbxFotoPerfilNav.TabStop = false;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Arial", 45F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(633, 147);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(324, 67);
            this.lblBienvenido.TabIndex = 30;
            this.lblBienvenido.Text = "Bienvenido";
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Font = new System.Drawing.Font("Arial", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinea.ForeColor = System.Drawing.Color.White;
            this.lblLinea.Location = new System.Drawing.Point(453, 166);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(656, 67);
            this.lblLinea.TabIndex = 31;
            this.lblLinea.Text = "___________________";
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(599, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 244);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(330, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 552);
            this.panel2.TabIndex = 33;
            // 
            // panelChat
            // 
            this.panelChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panelChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChat.Controls.Add(this.pcbxBotonEnviar);
            this.panelChat.Controls.Add(this.panelDatosClase);
            this.panelChat.Controls.Add(this.panelCharla);
            this.panelChat.Controls.Add(this.txtMensajeChat);
            this.panelChat.Location = new System.Drawing.Point(330, 118);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(922, 552);
            this.panelChat.TabIndex = 34;
            // 
            // pcbxBotonEnviar
            // 
            this.pcbxBotonEnviar.InitialImage = global::Hatchat.Properties.Resources.enviar;
            this.pcbxBotonEnviar.Location = new System.Drawing.Point(885, 516);
            this.pcbxBotonEnviar.Name = "pcbxBotonEnviar";
            this.pcbxBotonEnviar.Size = new System.Drawing.Size(30, 30);
            this.pcbxBotonEnviar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxBotonEnviar.TabIndex = 14;
            this.pcbxBotonEnviar.TabStop = false;
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
            this.panelDatosClase.Location = new System.Drawing.Point(0, 0);
            this.panelDatosClase.Name = "panelDatosClase";
            this.panelDatosClase.Size = new System.Drawing.Size(921, 100);
            this.panelDatosClase.TabIndex = 10;
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
            this.btnParticipantes.Location = new System.Drawing.Point(799, 70);
            this.btnParticipantes.Name = "btnParticipantes";
            this.btnParticipantes.Size = new System.Drawing.Size(115, 25);
            this.btnParticipantes.TabIndex = 11;
            this.btnParticipantes.Text = "Participantes";
            this.btnParticipantes.UseVisualStyleBackColor = false;
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
            this.panelCharla.Location = new System.Drawing.Point(0, 100);
            this.panelCharla.Name = "panelCharla";
            this.panelCharla.Size = new System.Drawing.Size(921, 410);
            this.panelCharla.TabIndex = 11;
            // 
            // txtMensajeChat
            // 
            this.txtMensajeChat.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMensajeChat.Location = new System.Drawing.Point(4, 518);
            this.txtMensajeChat.Name = "txtMensajeChat";
            this.txtMensajeChat.Size = new System.Drawing.Size(875, 26);
            this.txtMensajeChat.TabIndex = 0;
            // 
            // panelParticipantes
            // 
            this.panelParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panelParticipantes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelParticipantes.Controls.Add(this.lblParticipantes);
            this.panelParticipantes.Controls.Add(this.panelParticipantesOrdinarios);
            this.panelParticipantes.Controls.Add(this.lblHostParticipantes);
            this.panelParticipantes.Controls.Add(this.lblDocenteParticipantes);
            this.panelParticipantes.Location = new System.Drawing.Point(920, 219);
            this.panelParticipantes.Name = "panelParticipantes";
            this.panelParticipantes.Size = new System.Drawing.Size(325, 433);
            this.panelParticipantes.TabIndex = 35;
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
            // panelTextoChat
            // 
            this.panelTextoChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(136)))), ((int)(((byte)(88)))));
            this.panelTextoChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextoChat.Controls.Add(this.lblChats);
            this.panelTextoChat.Location = new System.Drawing.Point(10, 118);
            this.panelTextoChat.Name = "panelTextoChat";
            this.panelTextoChat.Size = new System.Drawing.Size(321, 46);
            this.panelTextoChat.TabIndex = 36;
            // 
            // lblChats
            // 
            this.lblChats.AutoSize = true;
            this.lblChats.Font = new System.Drawing.Font("Arial", 30.25F);
            this.lblChats.Location = new System.Drawing.Point(100, -1);
            this.lblChats.Name = "lblChats";
            this.lblChats.Size = new System.Drawing.Size(127, 47);
            this.lblChats.TabIndex = 2;
            this.lblChats.Text = "Chats";
            // 
            // panelDesplegarSolicitudes
            // 
            this.panelDesplegarSolicitudes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.panelDesplegarSolicitudes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDesplegarSolicitudes.Controls.Add(this.pcbxDesplegarSolicitudes);
            this.panelDesplegarSolicitudes.Controls.Add(this.pcbxNotificacion);
            this.panelDesplegarSolicitudes.Controls.Add(this.lblSolicitudes);
            this.panelDesplegarSolicitudes.Location = new System.Drawing.Point(10, 164);
            this.panelDesplegarSolicitudes.Name = "panelDesplegarSolicitudes";
            this.panelDesplegarSolicitudes.Size = new System.Drawing.Size(321, 46);
            this.panelDesplegarSolicitudes.TabIndex = 37;
            this.panelDesplegarSolicitudes.Click += new System.EventHandler(this.btnSolicitudes_Click);
            // 
            // pcbxDesplegarSolicitudes
            // 
            this.pcbxDesplegarSolicitudes.Location = new System.Drawing.Point(246, 1);
            this.pcbxDesplegarSolicitudes.Name = "pcbxDesplegarSolicitudes";
            this.pcbxDesplegarSolicitudes.Size = new System.Drawing.Size(67, 40);
            this.pcbxDesplegarSolicitudes.TabIndex = 4;
            this.pcbxDesplegarSolicitudes.TabStop = false;
            this.pcbxDesplegarSolicitudes.Click += new System.EventHandler(this.btnSolicitudes_Click);
            // 
            // pcbxNotificacion
            // 
            this.pcbxNotificacion.Location = new System.Drawing.Point(200, 0);
            this.pcbxNotificacion.Name = "pcbxNotificacion";
            this.pcbxNotificacion.Size = new System.Drawing.Size(46, 46);
            this.pcbxNotificacion.TabIndex = 3;
            this.pcbxNotificacion.TabStop = false;
            this.pcbxNotificacion.Click += new System.EventHandler(this.btnSolicitudes_Click);
            // 
            // lblSolicitudes
            // 
            this.lblSolicitudes.AutoSize = true;
            this.lblSolicitudes.Font = new System.Drawing.Font("Arial", 25.25F);
            this.lblSolicitudes.ForeColor = System.Drawing.Color.White;
            this.lblSolicitudes.Location = new System.Drawing.Point(27, -1);
            this.lblSolicitudes.Name = "lblSolicitudes";
            this.lblSolicitudes.Size = new System.Drawing.Size(177, 39);
            this.lblSolicitudes.TabIndex = 2;
            this.lblSolicitudes.Text = "Solicitudes";
            this.lblSolicitudes.Click += new System.EventHandler(this.btnSolicitudes_Click);
            // 
            // panelChatsActivos
            // 
            this.panelChatsActivos.AutoScroll = true;
            this.panelChatsActivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChatsActivos.Location = new System.Drawing.Point(10, 209);
            this.panelChatsActivos.Name = "panelChatsActivos";
            this.panelChatsActivos.Size = new System.Drawing.Size(321, 461);
            this.panelChatsActivos.TabIndex = 38;
            // 
            // panelChatsAIngresar
            // 
            this.panelChatsAIngresar.AutoScroll = true;
            this.panelChatsAIngresar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChatsAIngresar.Location = new System.Drawing.Point(10, 209);
            this.panelChatsAIngresar.Name = "panelChatsAIngresar";
            this.panelChatsAIngresar.Size = new System.Drawing.Size(321, 461);
            this.panelChatsAIngresar.TabIndex = 39;
            // 
            // timerSolicitudes
            // 
            this.timerSolicitudes.Enabled = true;
            this.timerSolicitudes.Interval = 500;
            this.timerSolicitudes.Tick += new System.EventHandler(this.timerSolicitudes_Tick);
            // 
            // PrincipalChatDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelChatsAIngresar);
            this.Controls.Add(this.panelChatsActivos);
            this.Controls.Add(this.panelDesplegarSolicitudes);
            this.Controls.Add(this.panelTextoChat);
            this.Controls.Add(this.panelParticipantes);
            this.Controls.Add(this.panelChat);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.panel2);
            this.Name = "PrincipalChatDocente";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PrincipalChatDocente_Load);
            this.panelHistorialesNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialMensajesNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxHistorialChatNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGruposNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrarSesionNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHistorialNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfilNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMensajeNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfilNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelChat.ResumeLayout(false);
            this.panelChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxBotonEnviar)).EndInit();
            this.panelDatosClase.ResumeLayout(false);
            this.panelDatosClase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMaterialDatosClase)).EndInit();
            this.panelParticipantes.ResumeLayout(false);
            this.panelParticipantes.PerformLayout();
            this.panelTextoChat.ResumeLayout(false);
            this.panelTextoChat.PerformLayout();
            this.panelDesplegarSolicitudes.ResumeLayout(false);
            this.panelDesplegarSolicitudes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxDesplegarSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxNotificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrCargChat;
        private System.Windows.Forms.Timer tmrCargChats;
        private System.Windows.Forms.Timer timerCargarFoto;
        private System.Windows.Forms.Timer timerHistorialNav;
        private System.Windows.Forms.Panel panelHistorialesNav;
        private System.Windows.Forms.PictureBox pcbxHistorialMensajesNav;
        private System.Windows.Forms.PictureBox pcbxHistorialChatNav;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.PictureBox pbxGruposNav;
        private System.Windows.Forms.PictureBox pbxCerrarSesionNav;
        private System.Windows.Forms.PictureBox pbxHistorialNav;
        private System.Windows.Forms.PictureBox pbxPerfilNav;
        private System.Windows.Forms.PictureBox pbxMensajeNav;
        private System.Windows.Forms.PictureBox pbxChatNav;
        private System.Windows.Forms.PictureBox pbxFotoPerfilNav;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.PictureBox pcbxBotonEnviar;
        private System.Windows.Forms.Panel panelDatosClase;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnParticipantes;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.PictureBox pcbxMaterialDatosClase;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.Label lblMateriaClaseChat;
        private System.Windows.Forms.Panel panelCharla;
        private System.Windows.Forms.TextBox txtMensajeChat;
        private System.Windows.Forms.Panel panelParticipantes;
        private System.Windows.Forms.Label lblParticipantes;
        private System.Windows.Forms.Panel panelParticipantesOrdinarios;
        private System.Windows.Forms.Label lblHostParticipantes;
        private System.Windows.Forms.Label lblDocenteParticipantes;
        private System.Windows.Forms.Panel panelTextoChat;
        private System.Windows.Forms.Label lblChats;
        private System.Windows.Forms.Panel panelDesplegarSolicitudes;
        private System.Windows.Forms.PictureBox pcbxDesplegarSolicitudes;
        private System.Windows.Forms.PictureBox pcbxNotificacion;
        private System.Windows.Forms.Label lblSolicitudes;
        private System.Windows.Forms.Panel panelChatsActivos;
        private System.Windows.Forms.Panel panelChatsAIngresar;
        private System.Windows.Forms.Timer timerSolicitudes;
    }
}