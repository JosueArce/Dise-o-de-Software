namespace PruebaJuegoConsola
{
    partial class Ventana
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
            this.turno = new System.Windows.Forms.Label();
            this.fichasJ1 = new System.Windows.Forms.Label();
            this.fichasJ2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // turno
            // 
            this.turno.AutoSize = true;
            this.turno.Location = new System.Drawing.Point(22, 340);
            this.turno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.turno.Name = "turno";
            this.turno.Size = new System.Drawing.Size(35, 13);
            this.turno.TabIndex = 0;
            this.turno.Text = "label1";
            // 
            // fichasJ1
            // 
            this.fichasJ1.AutoSize = true;
            this.fichasJ1.Location = new System.Drawing.Point(408, 340);
            this.fichasJ1.Name = "fichasJ1";
            this.fichasJ1.Size = new System.Drawing.Size(35, 13);
            this.fichasJ1.TabIndex = 1;
            this.fichasJ1.Text = "label1";
            // 
            // fichasJ2
            // 
            this.fichasJ2.AutoSize = true;
            this.fichasJ2.Location = new System.Drawing.Point(531, 340);
            this.fichasJ2.Name = "fichasJ2";
            this.fichasJ2.Size = new System.Drawing.Size(35, 13);
            this.fichasJ2.TabIndex = 2;
            this.fichasJ2.Text = "label1";
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 379);
            this.Controls.Add(this.fichasJ2);
            this.Controls.Add(this.fichasJ1);
            this.Controls.Add(this.turno);
            this.Name = "Ventana";
            this.Text = "Ventana";
            this.Load += new System.EventHandler(this.Ventana_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label turno;
        private System.Windows.Forms.Label fichasJ1;
        private System.Windows.Forms.Label fichasJ2;
    }
}