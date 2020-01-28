using System.Diagnostics;

namespace AES
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Browse_button = new System.Windows.Forms.Button();
            this.Decrypt_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Encrypt_Button = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.C = new System.Windows.Forms.RadioButton();
            this.A = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Browse_button
            // 
            this.Browse_button.Location = new System.Drawing.Point(12, 23);
            this.Browse_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(75, 22);
            this.Browse_button.TabIndex = 0;
            this.Browse_button.Text = "Load File";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.LoadFileButton);
            // 
            // Decrypt_Button
            // 
            this.Decrypt_Button.Location = new System.Drawing.Point(200, 123);
            this.Decrypt_Button.Name = "Decrypt_Button";
            this.Decrypt_Button.Size = new System.Drawing.Size(75, 23);
            this.Decrypt_Button.TabIndex = 2;
            this.Decrypt_Button.Text = "Decrypt";
            this.Decrypt_Button.UseVisualStyleBackColor = true;
            this.Decrypt_Button.Click += new System.EventHandler(this.DecryptButton);
            // 
            // Save_Button
            // 
            this.Save_Button.Location = new System.Drawing.Point(110, 156);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(75, 23);
            this.Save_Button.TabIndex = 3;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.SaveFileButton);
            // 
            // Encrypt_Button
            // 
            this.Encrypt_Button.Location = new System.Drawing.Point(12, 123);
            this.Encrypt_Button.Name = "Encrypt_Button";
            this.Encrypt_Button.Size = new System.Drawing.Size(75, 23);
            this.Encrypt_Button.TabIndex = 4;
            this.Encrypt_Button.Text = "Encrypt";
            this.Encrypt_Button.UseVisualStyleBackColor = true;
            this.Encrypt_Button.Click += new System.EventHandler(this.EncryptButton);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(200, 23);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 22);
            this.LoadButton.TabIndex = 5;
            this.LoadButton.Text = "Load Key";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadKeyButton);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // C
            // 
            this.C.AutoSize = true;
            this.C.Location = new System.Drawing.Point(83, 88);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(39, 17);
            this.C.TabIndex = 6;
            this.C.TabStop = true;
            this.C.Text = "C#";
            this.C.UseVisualStyleBackColor = true;
            this.C.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // A
            // 
            this.A.AutoSize = true;
            this.A.Location = new System.Drawing.Point(153, 88);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(69, 17);
            this.A.TabIndex = 7;
            this.A.TabStop = true;
            this.A.Text = "Assembly";
            this.A.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::AES.Properties.Resources.matrix;
            this.ClientSize = new System.Drawing.Size(287, 191);
            this.Controls.Add(this.A);
            this.Controls.Add(this.C);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.Encrypt_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Decrypt_Button);
            this.Controls.Add(this.Browse_button);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "AES";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Browse_button;
        private System.Windows.Forms.Button Decrypt_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Encrypt_Button;
        private byte[] buffer;
        private byte[] key;
        private MyAES aes;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.RadioButton C;
        private System.Windows.Forms.RadioButton A;
        private byte[] Buffer;
        private Stopwatch sw;
    }
}

