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
            this.SuspendLayout();
            // 
            // turno
            // 
            this.turno.AutoSize = true;
            this.turno.Location = new System.Drawing.Point(30, 418);
            this.turno.Name = "turno";
            this.turno.Size = new System.Drawing.Size(46, 17);
            this.turno.TabIndex = 0;
            this.turno.Text = "label1";
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 467);
            this.Controls.Add(this.turno);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ventana";
            this.Text = "Ventana";
            this.Load += new System.EventHandler(this.Ventana_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label turno;
    }
}