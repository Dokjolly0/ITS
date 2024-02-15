namespace Introduzione_C__Desktop
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
            this.TestoNumero1 = new System.Windows.Forms.Label();
            this.BoxNumero1 = new System.Windows.Forms.TextBox();
            this.TestoNumero2 = new System.Windows.Forms.Label();
            this.BoxNumero2 = new System.Windows.Forms.TextBox();
            this.Piu = new System.Windows.Forms.Button();
            this.TestoRisultato = new System.Windows.Forms.Label();
            this.BoxRisultato = new System.Windows.Forms.TextBox();
            this.Divisione = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Sottrazione = new System.Windows.Forms.Button();
            this.Moltiplicazione = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestoNumero1
            // 
            this.TestoNumero1.AutoSize = true;
            this.TestoNumero1.Location = new System.Drawing.Point(12, 19);
            this.TestoNumero1.Name = "TestoNumero1";
            this.TestoNumero1.Size = new System.Drawing.Size(156, 16);
            this.TestoNumero1.TabIndex = 0;
            this.TestoNumero1.Text = "Inserisci il primo numero: ";
            // 
            // BoxNumero1
            // 
            this.BoxNumero1.Location = new System.Drawing.Point(197, 16);
            this.BoxNumero1.Name = "BoxNumero1";
            this.BoxNumero1.Size = new System.Drawing.Size(68, 22);
            this.BoxNumero1.TabIndex = 1;
            // 
            // TestoNumero2
            // 
            this.TestoNumero2.AutoSize = true;
            this.TestoNumero2.Location = new System.Drawing.Point(12, 72);
            this.TestoNumero2.Name = "TestoNumero2";
            this.TestoNumero2.Size = new System.Drawing.Size(175, 16);
            this.TestoNumero2.TabIndex = 2;
            this.TestoNumero2.Text = "Inserisci il secondo numero: ";
            // 
            // BoxNumero2
            // 
            this.BoxNumero2.Location = new System.Drawing.Point(197, 72);
            this.BoxNumero2.Name = "BoxNumero2";
            this.BoxNumero2.Size = new System.Drawing.Size(68, 22);
            this.BoxNumero2.TabIndex = 3;
            // 
            // Piu
            // 
            this.Piu.Location = new System.Drawing.Point(15, 120);
            this.Piu.Name = "Piu";
            this.Piu.Size = new System.Drawing.Size(25, 23);
            this.Piu.TabIndex = 4;
            this.Piu.Text = "+";
            this.Piu.UseVisualStyleBackColor = true;
            // 
            // TestoRisultato
            // 
            this.TestoRisultato.AutoSize = true;
            this.TestoRisultato.Location = new System.Drawing.Point(12, 172);
            this.TestoRisultato.Name = "TestoRisultato";
            this.TestoRisultato.Size = new System.Drawing.Size(62, 16);
            this.TestoRisultato.TabIndex = 5;
            this.TestoRisultato.Text = "Risultato:";
            // 
            // BoxRisultato
            // 
            this.BoxRisultato.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.BoxRisultato.Enabled = false;
            this.BoxRisultato.Location = new System.Drawing.Point(80, 169);
            this.BoxRisultato.Multiline = true;
            this.BoxRisultato.Name = "BoxRisultato";
            this.BoxRisultato.Size = new System.Drawing.Size(185, 22);
            this.BoxRisultato.TabIndex = 6;
            // 
            // Divisione
            // 
            this.Divisione.Location = new System.Drawing.Point(108, 120);
            this.Divisione.Name = "Divisione";
            this.Divisione.Size = new System.Drawing.Size(25, 23);
            this.Divisione.TabIndex = 7;
            this.Divisione.Text = "/";
            this.Divisione.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(139, 120);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(61, 23);
            this.Clear.TabIndex = 8;
            this.Clear.Text = "Reset";
            this.Clear.UseVisualStyleBackColor = true;
            // 
            // Sottrazione
            // 
            this.Sottrazione.Location = new System.Drawing.Point(46, 120);
            this.Sottrazione.Name = "Sottrazione";
            this.Sottrazione.Size = new System.Drawing.Size(25, 23);
            this.Sottrazione.TabIndex = 9;
            this.Sottrazione.Text = "-";
            this.Sottrazione.UseVisualStyleBackColor = true;
            // 
            // Moltiplicazione
            // 
            this.Moltiplicazione.Location = new System.Drawing.Point(77, 120);
            this.Moltiplicazione.Name = "Moltiplicazione";
            this.Moltiplicazione.Size = new System.Drawing.Size(25, 23);
            this.Moltiplicazione.TabIndex = 10;
            this.Moltiplicazione.Text = "*";
            this.Moltiplicazione.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 380);
            this.Controls.Add(this.Moltiplicazione);
            this.Controls.Add(this.Sottrazione);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Divisione);
            this.Controls.Add(this.BoxRisultato);
            this.Controls.Add(this.TestoRisultato);
            this.Controls.Add(this.Piu);
            this.Controls.Add(this.BoxNumero2);
            this.Controls.Add(this.TestoNumero2);
            this.Controls.Add(this.BoxNumero1);
            this.Controls.Add(this.TestoNumero1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TestoNumero1;
        private System.Windows.Forms.TextBox BoxNumero1;
        private System.Windows.Forms.Label TestoNumero2;
        private System.Windows.Forms.TextBox BoxNumero2;
        private System.Windows.Forms.Button Piu;
        private System.Windows.Forms.Label TestoRisultato;
        private System.Windows.Forms.TextBox BoxRisultato;
        private System.Windows.Forms.Button Divisione;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Sottrazione;
        private System.Windows.Forms.Button Moltiplicazione;
    }
}

