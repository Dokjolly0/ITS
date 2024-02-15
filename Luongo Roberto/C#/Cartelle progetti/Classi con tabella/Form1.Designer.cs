namespace Classi2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            dgwArticoli = new DataGridView();
            mostraPrezzo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgwArticoli).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(330, 37);
            button1.Name = "button1";
            button1.Size = new Size(126, 29);
            button1.TabIndex = 0;
            button1.Text = "Crea articolo";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(303, 117);
            button2.Name = "button2";
            button2.Size = new Size(185, 28);
            button2.TabIndex = 1;
            button2.Text = "Crea una lista di articoli";
            button2.UseVisualStyleBackColor = true;
            // 
            // dgwArticoli
            // 
            dgwArticoli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwArticoli.Location = new Point(132, 201);
            dgwArticoli.Name = "dgwArticoli";
            dgwArticoli.RowHeadersWidth = 51;
            dgwArticoli.RowTemplate.Height = 29;
            dgwArticoli.Size = new Size(556, 188);
            dgwArticoli.TabIndex = 2;
            // 
            // mostraPrezzo
            // 
            mostraPrezzo.Location = new Point(330, 395);
            mostraPrezzo.Name = "mostraPrezzo";
            mostraPrezzo.Size = new Size(125, 27);
            mostraPrezzo.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mostraPrezzo);
            Controls.Add(dgwArticoli);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgwArticoli).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridView dgwArticoli;
        private TextBox mostraPrezzo;
    }
}