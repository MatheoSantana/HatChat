
namespace Hatchat.Presentacion
{
    partial class Titulo
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
            this.lblTema = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.btnListo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Location = new System.Drawing.Point(163, 54);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(104, 13);
            this.lblTema.TabIndex = 0;
            this.lblTema.Text = "Ingrese tema tratado";
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(49, 97);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(324, 20);
            this.txtTema.TabIndex = 1;
            // 
            // btnListo
            // 
            this.btnListo.Location = new System.Drawing.Point(179, 152);
            this.btnListo.Name = "btnListo";
            this.btnListo.Size = new System.Drawing.Size(75, 23);
            this.btnListo.TabIndex = 2;
            this.btnListo.Text = "Listo";
            this.btnListo.UseVisualStyleBackColor = true;
            this.btnListo.Click += new System.EventHandler(this.btnListo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 215);
            this.Controls.Add(this.btnListo);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.lblTema);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Button btnListo;
    }
}