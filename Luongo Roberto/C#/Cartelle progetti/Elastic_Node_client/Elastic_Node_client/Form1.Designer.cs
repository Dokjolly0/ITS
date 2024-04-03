namespace Elastic_Node_client
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.view_all = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.delate = new System.Windows.Forms.Button();
            this.search_id = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(29, 74);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 51;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(735, 150);
            this.grid.TabIndex = 0;
            // 
            // view_all
            // 
            this.view_all.Location = new System.Drawing.Point(29, 39);
            this.view_all.Name = "view_all";
            this.view_all.Size = new System.Drawing.Size(144, 23);
            this.view_all.TabIndex = 1;
            this.view_all.Text = "Visualizza lista utenti";
            this.view_all.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(194, 39);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(144, 23);
            this.search.TabIndex = 2;
            this.search.Text = "Cerca utente per Id";
            this.search.UseVisualStyleBackColor = true;
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(29, 263);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(144, 23);
            this.insert.TabIndex = 3;
            this.insert.Text = "Inserisci utente";
            this.insert.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(194, 263);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(144, 23);
            this.update.TabIndex = 4;
            this.update.Text = "Update utente";
            this.update.UseVisualStyleBackColor = true;
            // 
            // delate
            // 
            this.delate.Location = new System.Drawing.Point(366, 263);
            this.delate.Name = "delate";
            this.delate.Size = new System.Drawing.Size(144, 23);
            this.delate.TabIndex = 5;
            this.delate.Text = "Elimina utente";
            this.delate.UseVisualStyleBackColor = true;
            // 
            // search_id
            // 
            this.search_id.Location = new System.Drawing.Point(366, 39);
            this.search_id.Name = "search_id";
            this.search_id.Size = new System.Drawing.Size(100, 22);
            this.search_id.TabIndex = 6;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(103, 315);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(235, 22);
            this.id.TabIndex = 7;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(103, 354);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(235, 22);
            this.email.TabIndex = 8;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(103, 394);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(235, 22);
            this.password.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.email);
            this.Controls.Add(this.id);
            this.Controls.Add(this.search_id);
            this.Controls.Add(this.delate);
            this.Controls.Add(this.update);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.search);
            this.Controls.Add(this.view_all);
            this.Controls.Add(this.grid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button view_all;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button delate;
        private System.Windows.Forms.TextBox search_id;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

