
namespace Hatchat.Presentacion
{
    partial class MensajesAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensajesAlumno));
            this.btnNuevoMensaje = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelNavMensajes = new System.Windows.Forms.Panel();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelMensajeDocente = new System.Windows.Forms.Panel();
            this.panelMensajeAlumno = new System.Windows.Forms.Panel();
            this.lblFechaAlumno = new System.Windows.Forms.Label();
            this.lblHoraAlumno = new System.Windows.Forms.Label();
            this.lblConsultaAlumno = new System.Windows.Forms.Label();
            this.lblNombreAlumno = new System.Windows.Forms.Label();
            this.pbxAlumno = new System.Windows.Forms.PictureBox();
            this.lblFechaDocente = new System.Windows.Forms.Label();
            this.lblHoraDocente = new System.Windows.Forms.Label();
            this.lblConsultaDocente = new System.Windows.Forms.Label();
            this.pbxDocente = new System.Windows.Forms.PictureBox();
            this.lblNombreDocente = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.panelEnviarMensaje = new System.Windows.Forms.Panel();
            this.lblBuevoMensaje = new System.Windows.Forms.Label();
            this.rtbxMensajeAEnviar = new System.Windows.Forms.RichTextBox();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.cbxDestinatario = new System.Windows.Forms.ComboBox();
            this.lblDestinatario = new System.Windows.Forms.Label();
            this.timerMensajes = new System.Windows.Forms.Timer(this.components);
            this.timerHistorial = new System.Windows.Forms.Timer(this.components);
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
            this.panelTextoChat = new System.Windows.Forms.Panel();
            this.lblMensajes = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timerCentrar = new System.Windows.Forms.Timer(this.components);
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).BeginInit();
            this.panelEnviarMensaje.SuspendLayout();
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
            this.panelTextoChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevoMensaje
            // 
            this.btnNuevoMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevoMensaje.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnNuevoMensaje.ForeColor = System.Drawing.Color.White;
            this.btnNuevoMensaje.Location = new System.Drawing.Point(10, 166);
            this.btnNuevoMensaje.Name = "btnNuevoMensaje";
            this.btnNuevoMensaje.Size = new System.Drawing.Size(321, 23);
            this.btnNuevoMensaje.TabIndex = 4;
            this.btnNuevoMensaje.Text = "Nuevo Mensaje";
            this.btnNuevoMensaje.UseVisualStyleBackColor = true;
            this.btnNuevoMensaje.Click += new System.EventHandler(this.btnNuevoChat_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(108, 100);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(52, 13);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Mensajes";
            // 
            // panelNavMensajes
            // 
            this.panelNavMensajes.AutoScroll = true;
            this.panelNavMensajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNavMensajes.Location = new System.Drawing.Point(10, 189);
            this.panelNavMensajes.Name = "panelNavMensajes";
            this.panelNavMensajes.Size = new System.Drawing.Size(321, 480);
            this.panelNavMensajes.TabIndex = 6;
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedor.Controls.Add(this.panelMensajeDocente);
            this.panelContenedor.Controls.Add(this.panelMensajeAlumno);
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
            this.panelContenedor.Controls.Add(this.lblLinea);
            this.panelContenedor.Location = new System.Drawing.Point(401, 147);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(785, 490);
            this.panelContenedor.TabIndex = 7;
            // 
            // panelMensajeDocente
            // 
            this.panelMensajeDocente.Location = new System.Drawing.Point(77, 330);
            this.panelMensajeDocente.Name = "panelMensajeDocente";
            this.panelMensajeDocente.Size = new System.Drawing.Size(647, 138);
            this.panelMensajeDocente.TabIndex = 15;
            // 
            // panelMensajeAlumno
            // 
            this.panelMensajeAlumno.Location = new System.Drawing.Point(77, 78);
            this.panelMensajeAlumno.Name = "panelMensajeAlumno";
            this.panelMensajeAlumno.Size = new System.Drawing.Size(647, 138);
            this.panelMensajeAlumno.TabIndex = 14;
            // 
            // lblFechaAlumno
            // 
            this.lblFechaAlumno.AutoSize = true;
            this.lblFechaAlumno.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblFechaAlumno.ForeColor = System.Drawing.Color.White;
            this.lblFechaAlumno.Location = new System.Drawing.Point(698, 10);
            this.lblFechaAlumno.Name = "lblFechaAlumno";
            this.lblFechaAlumno.Size = new System.Drawing.Size(40, 14);
            this.lblFechaAlumno.TabIndex = 9;
            this.lblFechaAlumno.Text = "Fecha:";
            // 
            // lblHoraAlumno
            // 
            this.lblHoraAlumno.AutoSize = true;
            this.lblHoraAlumno.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblHoraAlumno.ForeColor = System.Drawing.Color.White;
            this.lblHoraAlumno.Location = new System.Drawing.Point(595, 10);
            this.lblHoraAlumno.Name = "lblHoraAlumno";
            this.lblHoraAlumno.Size = new System.Drawing.Size(33, 14);
            this.lblHoraAlumno.TabIndex = 8;
            this.lblHoraAlumno.Text = "Hora:";
            // 
            // lblConsultaAlumno
            // 
            this.lblConsultaAlumno.AutoSize = true;
            this.lblConsultaAlumno.Font = new System.Drawing.Font("Arial", 12F);
            this.lblConsultaAlumno.ForeColor = System.Drawing.Color.White;
            this.lblConsultaAlumno.Location = new System.Drawing.Point(369, 10);
            this.lblConsultaAlumno.Name = "lblConsultaAlumno";
            this.lblConsultaAlumno.Size = new System.Drawing.Size(73, 18);
            this.lblConsultaAlumno.TabIndex = 7;
            this.lblConsultaAlumno.Text = "Consulta:";
            // 
            // lblNombreAlumno
            // 
            this.lblNombreAlumno.AutoSize = true;
            this.lblNombreAlumno.Font = new System.Drawing.Font("Arial", 18F);
            this.lblNombreAlumno.ForeColor = System.Drawing.Color.White;
            this.lblNombreAlumno.Location = new System.Drawing.Point(86, 10);
            this.lblNombreAlumno.Name = "lblNombreAlumno";
            this.lblNombreAlumno.Size = new System.Drawing.Size(101, 27);
            this.lblNombreAlumno.TabIndex = 6;
            this.lblNombreAlumno.Text = "Alumno:";
            // 
            // pbxAlumno
            // 
            this.pbxAlumno.Location = new System.Drawing.Point(3, 3);
            this.pbxAlumno.Name = "pbxAlumno";
            this.pbxAlumno.Size = new System.Drawing.Size(64, 65);
            this.pbxAlumno.TabIndex = 5;
            this.pbxAlumno.TabStop = false;
            // 
            // lblFechaDocente
            // 
            this.lblFechaDocente.AutoSize = true;
            this.lblFechaDocente.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblFechaDocente.ForeColor = System.Drawing.Color.White;
            this.lblFechaDocente.Location = new System.Drawing.Point(698, 247);
            this.lblFechaDocente.Name = "lblFechaDocente";
            this.lblFechaDocente.Size = new System.Drawing.Size(40, 14);
            this.lblFechaDocente.TabIndex = 4;
            this.lblFechaDocente.Text = "Fecha:";
            // 
            // lblHoraDocente
            // 
            this.lblHoraDocente.AutoSize = true;
            this.lblHoraDocente.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblHoraDocente.ForeColor = System.Drawing.Color.White;
            this.lblHoraDocente.Location = new System.Drawing.Point(595, 247);
            this.lblHoraDocente.Name = "lblHoraDocente";
            this.lblHoraDocente.Size = new System.Drawing.Size(33, 14);
            this.lblHoraDocente.TabIndex = 3;
            this.lblHoraDocente.Text = "Hora:";
            // 
            // lblConsultaDocente
            // 
            this.lblConsultaDocente.AutoSize = true;
            this.lblConsultaDocente.Font = new System.Drawing.Font("Arial", 12F);
            this.lblConsultaDocente.ForeColor = System.Drawing.Color.White;
            this.lblConsultaDocente.Location = new System.Drawing.Point(369, 250);
            this.lblConsultaDocente.Name = "lblConsultaDocente";
            this.lblConsultaDocente.Size = new System.Drawing.Size(73, 18);
            this.lblConsultaDocente.TabIndex = 2;
            this.lblConsultaDocente.Text = "Consulta:";
            // 
            // pbxDocente
            // 
            this.pbxDocente.Location = new System.Drawing.Point(3, 250);
            this.pbxDocente.Name = "pbxDocente";
            this.pbxDocente.Size = new System.Drawing.Size(64, 65);
            this.pbxDocente.TabIndex = 1;
            this.pbxDocente.TabStop = false;
            // 
            // lblNombreDocente
            // 
            this.lblNombreDocente.AutoSize = true;
            this.lblNombreDocente.Font = new System.Drawing.Font("Arial", 18F);
            this.lblNombreDocente.ForeColor = System.Drawing.Color.White;
            this.lblNombreDocente.Location = new System.Drawing.Point(86, 250);
            this.lblNombreDocente.Name = "lblNombreDocente";
            this.lblNombreDocente.Size = new System.Drawing.Size(108, 27);
            this.lblNombreDocente.TabIndex = 0;
            this.lblNombreDocente.Text = "Docente:";
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Font = new System.Drawing.Font("Arial", 43F);
            this.lblLinea.ForeColor = System.Drawing.Color.White;
            this.lblLinea.Location = new System.Drawing.Point(40, 179);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(700, 66);
            this.lblLinea.TabIndex = 13;
            this.lblLinea.Text = "_____________________";
            // 
            // panelEnviarMensaje
            // 
            this.panelEnviarMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEnviarMensaje.Controls.Add(this.lblBuevoMensaje);
            this.panelEnviarMensaje.Controls.Add(this.rtbxMensajeAEnviar);
            this.panelEnviarMensaje.Controls.Add(this.txtAsunto);
            this.panelEnviarMensaje.Controls.Add(this.btnCancelar);
            this.panelEnviarMensaje.Controls.Add(this.btnEnviar);
            this.panelEnviarMensaje.Controls.Add(this.lblMensaje);
            this.panelEnviarMensaje.Controls.Add(this.lblAsunto);
            this.panelEnviarMensaje.Controls.Add(this.cbxDestinatario);
            this.panelEnviarMensaje.Controls.Add(this.lblDestinatario);
            this.panelEnviarMensaje.Location = new System.Drawing.Point(401, 147);
            this.panelEnviarMensaje.Name = "panelEnviarMensaje";
            this.panelEnviarMensaje.Size = new System.Drawing.Size(785, 490);
            this.panelEnviarMensaje.TabIndex = 8;
            // 
            // lblBuevoMensaje
            // 
            this.lblBuevoMensaje.AutoSize = true;
            this.lblBuevoMensaje.Font = new System.Drawing.Font("Arial", 16F);
            this.lblBuevoMensaje.ForeColor = System.Drawing.Color.White;
            this.lblBuevoMensaje.Location = new System.Drawing.Point(86, 15);
            this.lblBuevoMensaje.Name = "lblBuevoMensaje";
            this.lblBuevoMensaje.Size = new System.Drawing.Size(162, 25);
            this.lblBuevoMensaje.TabIndex = 18;
            this.lblBuevoMensaje.Text = "Nuevo Mensaje";
            // 
            // rtbxMensajeAEnviar
            // 
            this.rtbxMensajeAEnviar.Location = new System.Drawing.Point(138, 217);
            this.rtbxMensajeAEnviar.Name = "rtbxMensajeAEnviar";
            this.rtbxMensajeAEnviar.Size = new System.Drawing.Size(536, 147);
            this.rtbxMensajeAEnviar.TabIndex = 17;
            this.rtbxMensajeAEnviar.Text = "";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Font = new System.Drawing.Font("Arial", 18F);
            this.txtAsunto.Location = new System.Drawing.Point(138, 133);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(536, 35);
            this.txtAsunto.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Location = new System.Drawing.Point(33, 442);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 28);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.White;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnviar.Location = new System.Drawing.Point(661, 442);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(99, 28);
            this.btnEnviar.TabIndex = 14;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(61, 216);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(71, 18);
            this.lblMensaje.TabIndex = 13;
            this.lblMensaje.Text = "Mensaje:";
            // 
            // lblAsunto
            // 
            this.lblAsunto.AutoSize = true;
            this.lblAsunto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblAsunto.ForeColor = System.Drawing.Color.White;
            this.lblAsunto.Location = new System.Drawing.Point(61, 150);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(60, 18);
            this.lblAsunto.TabIndex = 12;
            this.lblAsunto.Text = "Asunto:";
            // 
            // cbxDestinatario
            // 
            this.cbxDestinatario.Font = new System.Drawing.Font("Arial", 18F);
            this.cbxDestinatario.FormattingEnabled = true;
            this.cbxDestinatario.Location = new System.Drawing.Point(138, 76);
            this.cbxDestinatario.Name = "cbxDestinatario";
            this.cbxDestinatario.Size = new System.Drawing.Size(536, 35);
            this.cbxDestinatario.TabIndex = 11;
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.AutoSize = true;
            this.lblDestinatario.Font = new System.Drawing.Font("Arial", 12F);
            this.lblDestinatario.ForeColor = System.Drawing.Color.White;
            this.lblDestinatario.Location = new System.Drawing.Point(61, 93);
            this.lblDestinatario.Name = "lblDestinatario";
            this.lblDestinatario.Size = new System.Drawing.Size(46, 18);
            this.lblDestinatario.TabIndex = 10;
            this.lblDestinatario.Text = "Para:";
            // 
            // timerMensajes
            // 
            this.timerMensajes.Enabled = true;
            this.timerMensajes.Interval = 500;
            this.timerMensajes.Tick += new System.EventHandler(this.timerMensajes_Tick);
            // 
            // timerHistorial
            // 
            this.timerHistorial.Enabled = true;
            this.timerHistorial.Tick += new System.EventHandler(this.timerHistorialNav_Tick);
            // 
            // timerCargarFoto
            // 
            this.timerCargarFoto.Enabled = true;
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
            this.panelHistorialesNav.TabIndex = 15;
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
            this.panel1.TabIndex = 14;
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
            // 
            // pbxChatNav
            // 
            this.pbxChatNav.Location = new System.Drawing.Point(351, 14);
            this.pbxChatNav.Name = "pbxChatNav";
            this.pbxChatNav.Size = new System.Drawing.Size(80, 80);
            this.pbxChatNav.TabIndex = 1;
            this.pbxChatNav.TabStop = false;
            this.pbxChatNav.Click += new System.EventHandler(this.pbxChatNav_Click);
            // 
            // pbxFotoPerfilNav
            // 
            this.pbxFotoPerfilNav.Location = new System.Drawing.Point(3, 3);
            this.pbxFotoPerfilNav.Name = "pbxFotoPerfilNav";
            this.pbxFotoPerfilNav.Size = new System.Drawing.Size(100, 100);
            this.pbxFotoPerfilNav.TabIndex = 0;
            this.pbxFotoPerfilNav.TabStop = false;
            // 
            // panelTextoChat
            // 
            this.panelTextoChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(136)))), ((int)(((byte)(88)))));
            this.panelTextoChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextoChat.Controls.Add(this.lblMensajes);
            this.panelTextoChat.Location = new System.Drawing.Point(10, 118);
            this.panelTextoChat.Name = "panelTextoChat";
            this.panelTextoChat.Size = new System.Drawing.Size(321, 46);
            this.panelTextoChat.TabIndex = 17;
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Font = new System.Drawing.Font("Arial", 28.25F);
            this.lblMensajes.Location = new System.Drawing.Point(71, 0);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(179, 43);
            this.lblMensajes.TabIndex = 2;
            this.lblMensajes.Text = "Mensajes";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Arial", 45F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(633, 147);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(324, 67);
            this.lblBienvenido.TabIndex = 18;
            this.lblBienvenido.Text = "Bienvenido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(453, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(656, 67);
            this.label1.TabIndex = 19;
            this.label1.Text = "___________________";
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(599, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 244);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(330, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 552);
            this.panel2.TabIndex = 21;
            // 
            // timerCentrar
            // 
            this.timerCentrar.Enabled = true;
            this.timerCentrar.Interval = 500;
            this.timerCentrar.Tick += new System.EventHandler(this.timerCentrar_Tick);
            // 
            // MensajesAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelTextoChat);
            this.Controls.Add(this.panelHistorialesNav);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnNuevoMensaje);
            this.Controls.Add(this.panelNavMensajes);
            this.Controls.Add(this.panelEnviarMensaje);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Name = "MensajesAlumno";
            this.Text = "m";
            this.Load += new System.EventHandler(this.MensajesAlumno_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).EndInit();
            this.panelEnviarMensaje.ResumeLayout(false);
            this.panelEnviarMensaje.PerformLayout();
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
            this.panelTextoChat.ResumeLayout(false);
            this.panelTextoChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNuevoMensaje;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelNavMensajes;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.PictureBox pbxDocente;
        private System.Windows.Forms.Label lblNombreDocente;
        private System.Windows.Forms.Label lblFechaDocente;
        private System.Windows.Forms.Label lblHoraDocente;
        private System.Windows.Forms.Label lblConsultaDocente;
        private System.Windows.Forms.Label lblConsultaAlumno;
        private System.Windows.Forms.Label lblNombreAlumno;
        private System.Windows.Forms.PictureBox pbxAlumno;
        private System.Windows.Forms.Label lblFechaAlumno;
        private System.Windows.Forms.Label lblHoraAlumno;
        private System.Windows.Forms.Panel panelEnviarMensaje;
        private System.Windows.Forms.RichTextBox rtbxMensajeAEnviar;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.ComboBox cbxDestinatario;
        private System.Windows.Forms.Label lblDestinatario;
        private System.Windows.Forms.Timer timerMensajes;
        private System.Windows.Forms.Timer timerHistorial;
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
        private System.Windows.Forms.Panel panelTextoChat;
        private System.Windows.Forms.Label lblMensajes;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBuevoMensaje;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMensajeDocente;
        private System.Windows.Forms.Panel panelMensajeAlumno;
        private System.Windows.Forms.Timer timerCentrar;
    }
}