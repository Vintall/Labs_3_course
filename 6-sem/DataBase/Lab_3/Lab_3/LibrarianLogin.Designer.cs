namespace Lab_2
{
    partial class LibrarianLogin
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.available_choise_button = new System.Windows.Forms.Button();
            this.available_choise_listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(146, 355);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 43);
            this.button1.TabIndex = 12;
            this.button1.Text = "To Main Menu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(15, 355);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 43);
            this.button2.TabIndex = 13;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // available_choise_button
            // 
            this.available_choise_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.available_choise_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.available_choise_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.available_choise_button.Location = new System.Drawing.Point(12, 298);
            this.available_choise_button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.available_choise_button.Name = "available_choise_button";
            this.available_choise_button.Size = new System.Drawing.Size(318, 49);
            this.available_choise_button.TabIndex = 15;
            this.available_choise_button.Text = "Show available choise";
            this.available_choise_button.UseVisualStyleBackColor = false;
            this.available_choise_button.Click += new System.EventHandler(this.available_choise_button_Click);
            // 
            // available_choise_listBox
            // 
            this.available_choise_listBox.BackColor = System.Drawing.Color.SeaGreen;
            this.available_choise_listBox.FormattingEnabled = true;
            this.available_choise_listBox.ItemHeight = 23;
            this.available_choise_listBox.Location = new System.Drawing.Point(12, 12);
            this.available_choise_listBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.available_choise_listBox.Name = "available_choise_listBox";
            this.available_choise_listBox.Size = new System.Drawing.Size(318, 280);
            this.available_choise_listBox.TabIndex = 14;
            this.available_choise_listBox.DoubleClick += new System.EventHandler(this.available_choise_listBox_DoubleClick);
            // 
            // LibrarianLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(345, 413);
            this.Controls.Add(this.available_choise_button);
            this.Controls.Add(this.available_choise_listBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Verdana", 14F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "LibrarianLogin";
            this.Text = "LibrarianLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button available_choise_button;
        private System.Windows.Forms.ListBox available_choise_listBox;
    }
}