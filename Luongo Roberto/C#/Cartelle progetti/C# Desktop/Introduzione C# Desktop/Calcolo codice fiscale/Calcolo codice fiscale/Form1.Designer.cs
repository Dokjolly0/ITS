namespace Calcolo_codice_fiscale
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
            this.CognomeLabel = new System.Windows.Forms.Label();
            this.NomeLabel = new System.Windows.Forms.Label();
            this.Cognome = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.TextBox();
            this.DataDiNascitaLabel = new System.Windows.Forms.Label();
            this.SessoLabel = new System.Windows.Forms.Label();
            this.Sesso = new System.Windows.Forms.TextBox();
            this.CalcoloCodiceFiscale = new System.Windows.Forms.Button();
            this.CodiceFiscale = new System.Windows.Forms.TextBox();
            this.DatadiNascita = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // CognomeLabel
            // 
            this.CognomeLabel.AutoSize = true;
            this.CognomeLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.CognomeLabel.Location = new System.Drawing.Point(137, 30);
            this.CognomeLabel.Name = "CognomeLabel";
            this.CognomeLabel.Size = new System.Drawing.Size(69, 16);
            this.CognomeLabel.TabIndex = 0;
            this.CognomeLabel.Text = "Cognome:";
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NomeLabel.Location = new System.Drawing.Point(159, 69);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(47, 16);
            this.NomeLabel.TabIndex = 1;
            this.NomeLabel.Text = "Nome:";
            // 
            // Cognome
            // 
            this.Cognome.Location = new System.Drawing.Point(234, 27);
            this.Cognome.Name = "Cognome";
            this.Cognome.Size = new System.Drawing.Size(112, 22);
            this.Cognome.TabIndex = 2;
            // 
            // Nome
            // 
            this.Nome.Location = new System.Drawing.Point(234, 66);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(112, 22);
            this.Nome.TabIndex = 3;
            // 
            // DataDiNascitaLabel
            // 
            this.DataDiNascitaLabel.AutoSize = true;
            this.DataDiNascitaLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.DataDiNascitaLabel.Location = new System.Drawing.Point(35, 106);
            this.DataDiNascitaLabel.Name = "DataDiNascitaLabel";
            this.DataDiNascitaLabel.Size = new System.Drawing.Size(171, 16);
            this.DataDiNascitaLabel.TabIndex = 4;
            this.DataDiNascitaLabel.Text = "Data di nascita GG//MM/AA";
            // 
            // SessoLabel
            // 
            this.SessoLabel.AutoSize = true;
            this.SessoLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.SessoLabel.Location = new System.Drawing.Point(134, 153);
            this.SessoLabel.Name = "SessoLabel";
            this.SessoLabel.Size = new System.Drawing.Size(72, 16);
            this.SessoLabel.TabIndex = 6;
            this.SessoLabel.Text = "Sesso M/F";
            // 
            // Sesso
            // 
            this.Sesso.Location = new System.Drawing.Point(234, 150);
            this.Sesso.Name = "Sesso";
            this.Sesso.Size = new System.Drawing.Size(112, 22);
            this.Sesso.TabIndex = 7;
            // 
            // CalcoloCodiceFiscale
            // 
            this.CalcoloCodiceFiscale.BackColor = System.Drawing.Color.Green;
            this.CalcoloCodiceFiscale.ForeColor = System.Drawing.SystemColors.Window;
            this.CalcoloCodiceFiscale.Location = new System.Drawing.Point(20, 191);
            this.CalcoloCodiceFiscale.Name = "CalcoloCodiceFiscale";
            this.CalcoloCodiceFiscale.Size = new System.Drawing.Size(326, 23);
            this.CalcoloCodiceFiscale.TabIndex = 8;
            this.CalcoloCodiceFiscale.Text = "Calcolo codice fiscale";
            this.CalcoloCodiceFiscale.UseVisualStyleBackColor = false;
            // 
            // CodiceFiscale
            // 
            this.CodiceFiscale.Enabled = false;
            this.CodiceFiscale.Location = new System.Drawing.Point(20, 234);
            this.CodiceFiscale.Name = "CodiceFiscale";
            this.CodiceFiscale.Size = new System.Drawing.Size(326, 22);
            this.CodiceFiscale.TabIndex = 9;
            // 
            // DatadiNascita
            // 
            this.DatadiNascita.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatadiNascita.Location = new System.Drawing.Point(234, 101);
            this.DatadiNascita.MaxDate = new System.DateTime(2023, 11, 22, 0, 0, 0, 0);
            this.DatadiNascita.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DatadiNascita.Name = "DatadiNascita";
            this.DatadiNascita.Size = new System.Drawing.Size(112, 22);
            this.DatadiNascita.TabIndex = 10;
            this.DatadiNascita.Value = new System.DateTime(2023, 11, 22, 0, 0, 0, 0);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(387, 309);
            this.Controls.Add(this.DatadiNascita);
            this.Controls.Add(this.CodiceFiscale);
            this.Controls.Add(this.CalcoloCodiceFiscale);
            this.Controls.Add(this.Sesso);
            this.Controls.Add(this.SessoLabel);
            this.Controls.Add(this.DataDiNascitaLabel);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.Cognome);
            this.Controls.Add(this.NomeLabel);
            this.Controls.Add(this.CognomeLabel);
            this.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CognomeLabel;
        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.TextBox Cognome;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Label DataDiNascitaLabel;
        private System.Windows.Forms.Label SessoLabel;
        private System.Windows.Forms.TextBox Sesso;
        private System.Windows.Forms.Button CalcoloCodiceFiscale;
        private System.Windows.Forms.TextBox CodiceFiscale;
        private System.Windows.Forms.DateTimePicker DatadiNascita;
    }
}

