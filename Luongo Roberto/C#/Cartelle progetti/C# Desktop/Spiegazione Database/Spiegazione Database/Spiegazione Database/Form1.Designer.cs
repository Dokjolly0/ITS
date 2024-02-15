namespace Spiegazione_Database
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
            this.Email = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Accedi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CreaPassword = new System.Windows.Forms.TextBox();
            this.CreaEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ConfermaCreaPassword = new System.Windows.Forms.TextBox();
            this.CReaAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(160, 34);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(192, 22);
            this.Email.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(160, 79);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(192, 22);
            this.Password.TabIndex = 1;
            // 
            // Accedi
            // 
            this.Accedi.Location = new System.Drawing.Point(60, 124);
            this.Accedi.Name = "Accedi";
            this.Accedi.Size = new System.Drawing.Size(292, 23);
            this.Accedi.TabIndex = 2;
            this.Accedi.Text = "Accedi";
            this.Accedi.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email:";
            // 
            // CreaPassword
            // 
            this.CreaPassword.Location = new System.Drawing.Point(575, 81);
            this.CreaPassword.Name = "CreaPassword";
            this.CreaPassword.Size = new System.Drawing.Size(192, 22);
            this.CreaPassword.TabIndex = 6;
            // 
            // CreaEmail
            // 
            this.CreaEmail.Location = new System.Drawing.Point(575, 36);
            this.CreaEmail.Name = "CreaEmail";
            this.CreaEmail.Size = new System.Drawing.Size(192, 22);
            this.CreaEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Conferma password:";
            // 
            // ConfermaCreaPassword
            // 
            this.ConfermaCreaPassword.Location = new System.Drawing.Point(575, 125);
            this.ConfermaCreaPassword.Name = "ConfermaCreaPassword";
            this.ConfermaCreaPassword.Size = new System.Drawing.Size(192, 22);
            this.ConfermaCreaPassword.TabIndex = 9;
            // 
            // CReaAccount
            // 
            this.CReaAccount.Location = new System.Drawing.Point(439, 177);
            this.CReaAccount.Name = "CReaAccount";
            this.CReaAccount.Size = new System.Drawing.Size(328, 23);
            this.CReaAccount.TabIndex = 11;
            this.CReaAccount.Text = "Crea account";
            this.CReaAccount.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 621);
            this.Controls.Add(this.CReaAccount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ConfermaCreaPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CreaPassword);
            this.Controls.Add(this.CreaEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Accedi);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Email);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button Accedi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CreaPassword;
        private System.Windows.Forms.TextBox CreaEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ConfermaCreaPassword;
        private System.Windows.Forms.Button CReaAccount;
    }
}

