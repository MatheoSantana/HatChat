
namespace Hatchat.Presentacion
{
    partial class HistorialMensajesAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialMensajesAlumno));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.timerHistorialMensajes = new System.Windows.Forms.Timer(this.components);
            this.timerHistrotial = new System.Windows.Forms.Timer(this.components);
            this.timerCargarFoto = new System.Windows.Forms.Timer(this.components);
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
            this.panelNavMensajes = new System.Windows.Forms.Panel();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbxLogo = new System.Windows.Forms.PictureBox();
            this.lblLinea = new System.Windows.Forms.Label();
            this.lblNombreDocente = new System.Windows.Forms.Label();
            this.pbxDocente = new System.Windows.Forms.PictureBox();
            this.lblConsultaDocente = new System.Windows.Forms.Label();
            this.lblHoraDocente = new System.Windows.Forms.Label();
            this.lblFechaDocente = new System.Windows.Forms.Label();
            this.pbxAlumno = new System.Windows.Forms.PictureBox();
            this.lblNombreAlumno = new System.Windows.Forms.Label();
            this.lblConsultaAlumno = new System.Windows.Forms.Label();
            this.lblHoraAlumno = new System.Windows.Forms.Label();
            this.lblFechaAlumno = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelMensajeDocente = new System.Windows.Forms.Panel();
            this.panelMensajeAlumno = new System.Windows.Forms.Panel();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnFiltrarDocente = new System.Windows.Forms.Button();
            this.cmbxDocentes = new System.Windows.Forms.ComboBox();
            this.dtpFiltro = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarFecha = new System.Windows.Forms.Button();
            this.panelTextoChat = new System.Windows.Forms.Panel();
            this.lblHistrialMensajes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerCentrar = new System.Windows.Forms.Timer(this.components);
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
            this.panelNavMensajes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).BeginInit();
            this.panelContenedor.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panelTextoChat.SuspendLayout();
            this.SuspendLayout();
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
            // timerHistorialMensajes
            // 
            this.timerHistorialMensajes.Enabled = true;
            this.timerHistorialMensajes.Interval = 500;
            this.timerHistorialMensajes.Tick += new System.EventHandler(this.timerHistorialMensajes_Tick);
            // 
            // timerHistrotial
            // 
            this.timerHistrotial.Enabled = true;
            this.timerHistrotial.Tick += new System.EventHandler(this.timerHistorialNav_Tick);
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
            this.panelHistorialesNav.Location = new System.Drawing.Point(882, 103);
            this.panelHistorialesNav.Name = "panelHistorialesNav";
            this.panelHistorialesNav.Size = new System.Drawing.Size(80, 170);
            this.panelHistorialesNav.TabIndex = 23;
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
            this.panelNav.TabIndex = 22;
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
            // panelNavMensajes
            // 
            this.panelNavMensajes.AutoScroll = true;
            this.panelNavMensajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNavMensajes.Controls.Add(this.lblBienvenido);
            this.panelNavMensajes.Controls.Add(this.label1);
            this.panelNavMensajes.Controls.Add(this.pcbxLogo);
            this.panelNavMensajes.Location = new System.Drawing.Point(401, 147);
            this.panelNavMensajes.Name = "panelNavMensajes";
            this.panelNavMensajes.Size = new System.Drawing.Size(740, 485);
            this.panelNavMensajes.TabIndex = 25;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Arial", 26F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(87, 112);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(567, 40);
            this.lblBienvenido.TabIndex = 19;
            this.lblBienvenido.Text = "Usted no tiene mensajes archivados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(656, 67);
            this.label1.TabIndex = 20;
            this.label1.Text = "___________________";
            // 
            // pcbxLogo
            // 
            this.pcbxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbxLogo.InitialImage")));
            this.pcbxLogo.Location = new System.Drawing.Point(187, 168);
            this.pcbxLogo.Name = "pcbxLogo";
            this.pcbxLogo.Size = new System.Drawing.Size(363, 244);
            this.pcbxLogo.TabIndex = 21;
            this.pcbxLogo.TabStop = false;
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
            // pbxDocente
            // 
            this.pbxDocente.Location = new System.Drawing.Point(3, 250);
            this.pbxDocente.Name = "pbxDocente";
            this.pbxDocente.Size = new System.Drawing.Size(64, 65);
            this.pbxDocente.TabIndex = 1;
            this.pbxDocente.TabStop = false;
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
            // pbxAlumno
            // 
            this.pbxAlumno.Location = new System.Drawing.Point(3, 3);
            this.pbxAlumno.Name = "pbxAlumno";
            this.pbxAlumno.Size = new System.Drawing.Size(64, 65);
            this.pbxAlumno.TabIndex = 5;
            this.pbxAlumno.TabStop = false;
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
            this.panelContenedor.TabIndex = 24;
            // 
            // panelMensajeDocente
            // 
            this.panelMensajeDocente.Location = new System.Drawing.Point(77, 330);
            this.panelMensajeDocente.Name = "panelMensajeDocente";
            this.panelMensajeDocente.Size = new System.Drawing.Size(647, 138);
            this.panelMensajeDocente.TabIndex = 17;
            // 
            // panelMensajeAlumno
            // 
            this.panelMensajeAlumno.Location = new System.Drawing.Point(77, 78);
            this.panelMensajeAlumno.Name = "panelMensajeAlumno";
            this.panelMensajeAlumno.Size = new System.Drawing.Size(647, 138);
            this.panelMensajeAlumno.TabIndex = 16;
            // 
            // panelFiltros
            // 
            this.panelFiltros.AutoScroll = true;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.btnVolver);
            this.panelFiltros.Controls.Add(this.btnFiltrarDocente);
            this.panelFiltros.Controls.Add(this.cmbxDocentes);
            this.panelFiltros.Controls.Add(this.dtpFiltro);
            this.panelFiltros.Controls.Add(this.btnFiltrarFecha);
            this.panelFiltros.Location = new System.Drawing.Point(10, 164);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(321, 505);
            this.panelFiltros.TabIndex = 26;
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
            // btnFiltrarDocente
            // 
            this.btnFiltrarDocente.BackColor = System.Drawing.Color.White;
            this.btnFiltrarDocente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltrarDocente.Font = new System.Drawing.Font("Arial", 12F);
            this.btnFiltrarDocente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFiltrarDocente.Location = new System.Drawing.Point(7, 27);
            this.btnFiltrarDocente.Name = "btnFiltrarDocente";
            this.btnFiltrarDocente.Size = new System.Drawing.Size(300, 40);
            this.btnFiltrarDocente.TabIndex = 14;
            this.btnFiltrarDocente.Text = "Filtrar Docente";
            this.btnFiltrarDocente.UseVisualStyleBackColor = false;
            this.btnFiltrarDocente.Click += new System.EventHandler(this.btnFiltrarDocente_Click);
            // 
            // cmbxDocentes
            // 
            this.cmbxDocentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxDocentes.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbxDocentes.FormattingEnabled = true;
            this.cmbxDocentes.Location = new System.Drawing.Point(7, 73);
            this.cmbxDocentes.Name = "cmbxDocentes";
            this.cmbxDocentes.Size = new System.Drawing.Size(300, 26);
            this.cmbxDocentes.TabIndex = 15;
            this.cmbxDocentes.Visible = false;
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
            // panelTextoChat
            // 
            this.panelTextoChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(136)))), ((int)(((byte)(88)))));
            this.panelTextoChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextoChat.Controls.Add(this.lblHistrialMensajes);
            this.panelTextoChat.Location = new System.Drawing.Point(10, 118);
            this.panelTextoChat.Name = "panelTextoChat";
            this.panelTextoChat.Size = new System.Drawing.Size(321, 46);
            this.panelTextoChat.TabIndex = 27;
            // 
            // lblHistrialMensajes
            // 
            this.lblHistrialMensajes.AutoSize = true;
            this.lblHistrialMensajes.Font = new System.Drawing.Font("Arial", 24.25F);
            this.lblHistrialMensajes.Location = new System.Drawing.Point(-1, 1);
            this.lblHistrialMensajes.Name = "lblHistrialMensajes";
            this.lblHistrialMensajes.Size = new System.Drawing.Size(323, 38);
            this.lblHistrialMensajes.TabIndex = 3;
            this.lblHistrialMensajes.Text = "Historial de Mensajes";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(324, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 551);
            this.panel1.TabIndex = 28;
            // 
            // timerCentrar
            // 
            this.timerCentrar.Enabled = true;
            this.timerCentrar.Interval = 500;
            this.timerCentrar.Tick += new System.EventHandler(this.timerCentrar_Tick);
            // 
            // HistorialMensajesAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelTextoChat);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelHistorialesNav);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelNavMensajes);
            this.Controls.Add(this.panel1);
            this.Name = "HistorialMensajesAlumno";
            this.Text = "MensajesAlumno";
            this.Load += new System.EventHandler(this.MensajesAlumno_Load);
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
            this.panelNavMensajes.ResumeLayout(false);
            this.panelNavMensajes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDocente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlumno)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelTextoChat.ResumeLayout(false);
            this.panelTextoChat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Timer timerHistorialMensajes;
        private System.Windows.Forms.Timer timerHistrotial;
        private System.Windows.Forms.Timer timerCargarFoto;
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
        private System.Windows.Forms.Panel panelNavMensajes;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Label lblNombreDocente;
        private System.Windows.Forms.PictureBox pbxDocente;
        private System.Windows.Forms.Label lblConsultaDocente;
        private System.Windows.Forms.Label lblHoraDocente;
        private System.Windows.Forms.Label lblFechaDocente;
        private System.Windows.Forms.PictureBox pbxAlumno;
        private System.Windows.Forms.Label lblNombreAlumno;
        private System.Windows.Forms.Label lblConsultaAlumno;
        private System.Windows.Forms.Label lblHoraAlumno;
        private System.Windows.Forms.Label lblFechaAlumno;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnFiltrarDocente;
        private System.Windows.Forms.ComboBox cmbxDocentes;
        private System.Windows.Forms.DateTimePicker dtpFiltro;
        private System.Windows.Forms.Button btnFiltrarFecha;
        private System.Windows.Forms.Panel panelTextoChat;
        private System.Windows.Forms.Label lblHistrialMensajes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pcbxLogo;
        private System.Windows.Forms.Panel panelMensajeDocente;
        private System.Windows.Forms.Panel panelMensajeAlumno;
        private System.Windows.Forms.Timer timerCentrar;
    }
}