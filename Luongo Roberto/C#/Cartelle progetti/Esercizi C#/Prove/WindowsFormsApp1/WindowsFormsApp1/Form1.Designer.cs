namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.calcolo = new System.Windows.Forms.Button();
            this.Visualizza = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Visualizza)).BeginInit();
            this.SuspendLayout();
            // 
            // calcolo
            // 
            this.calcolo.Location = new System.Drawing.Point(26, 53);
            this.calcolo.Name = "calcolo";
            this.calcolo.Size = new System.Drawing.Size(1088, 23);
            this.calcolo.TabIndex = 0;
            this.calcolo.Text = "Calcolo";
            this.calcolo.UseVisualStyleBackColor = true;
            // 
            // Visualizza
            // 
            this.Visualizza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Visualizza.Location = new System.Drawing.Point(26, 111);
            this.Visualizza.Name = "Visualizza";
            this.Visualizza.RowHeadersWidth = 51;
            this.Visualizza.RowTemplate.Height = 24;
            this.Visualizza.Size = new System.Drawing.Size(1088, 150);
            this.Visualizza.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 450);
            this.Controls.Add(this.Visualizza);
            this.Controls.Add(this.calcolo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Visualizza)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button calcolo;
        private System.Windows.Forms.DataGridView Visualizza;
    }
}

