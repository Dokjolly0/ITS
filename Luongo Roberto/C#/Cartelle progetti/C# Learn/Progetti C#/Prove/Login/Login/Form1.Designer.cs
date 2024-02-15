namespace Login
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
            Email = new TextBox();
            Password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Log_in = new Button();
            SuspendLayout();
            // 
            // Email
            // 
            Email.Location = new Point(120, 46);
            Email.Name = "Email";
            Email.Size = new Size(125, 27);
            Email.TabIndex = 0;
            // 
            // Password
            // 
            Password.Location = new Point(120, 101);
            Password.Name = "Password";
            Password.Size = new Size(125, 27);
            Password.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 44);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 101);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // Log_in
            // 
            Log_in.Location = new Point(36, 147);
            Log_in.Name = "Log_in";
            Log_in.Size = new Size(209, 29);
            Log_in.TabIndex = 4;
            Log_in.Text = "Accedi";
            Log_in.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Log_in);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Password);
            Controls.Add(Email);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Email;
        private TextBox Password;
        private Label label1;
        private Label label2;
        private Button Log_in;
    }
}
