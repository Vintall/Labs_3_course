namespace Lab_2
{
    partial class MainForm
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
            this.display_table_datagridview = new System.Windows.Forms.DataGridView();
            this.command_line_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.command_line_confirm_button = new System.Windows.Forms.Button();
            this.display_table_combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.display_table_confirm_button = new System.Windows.Forms.Button();
            this.add_new_row_button = new System.Windows.Forms.Button();
            this.remove_current_row_button = new System.Windows.Forms.Button();
            this.available_choise_listBox = new System.Windows.Forms.ListBox();
            this.available_choise_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.display_table_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // display_table_datagridview
            // 
            this.display_table_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display_table_datagridview.Location = new System.Drawing.Point(24, 21);
            this.display_table_datagridview.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.display_table_datagridview.Name = "display_table_datagridview";
            this.display_table_datagridview.Size = new System.Drawing.Size(709, 400);
            this.display_table_datagridview.TabIndex = 0;
            this.display_table_datagridview.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_table_datagridview_CellEndEdit);
            // 
            // command_line_textbox
            // 
            this.command_line_textbox.BackColor = System.Drawing.Color.SeaGreen;
            this.command_line_textbox.Location = new System.Drawing.Point(138, 427);
            this.command_line_textbox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.command_line_textbox.Name = "command_line_textbox";
            this.command_line_textbox.Size = new System.Drawing.Size(448, 30);
            this.command_line_textbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(20, 431);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Command Line";
            // 
            // command_line_confirm_button
            // 
            this.command_line_confirm_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.command_line_confirm_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.command_line_confirm_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.command_line_confirm_button.Location = new System.Drawing.Point(596, 427);
            this.command_line_confirm_button.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.command_line_confirm_button.Name = "command_line_confirm_button";
            this.command_line_confirm_button.Size = new System.Drawing.Size(131, 30);
            this.command_line_confirm_button.TabIndex = 3;
            this.command_line_confirm_button.Text = "Execute";
            this.command_line_confirm_button.UseVisualStyleBackColor = false;
            this.command_line_confirm_button.Click += new System.EventHandler(this.command_line_confirm_button_Click);
            // 
            // display_table_combobox
            // 
            this.display_table_combobox.BackColor = System.Drawing.Color.SeaGreen;
            this.display_table_combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.display_table_combobox.FormattingEnabled = true;
            this.display_table_combobox.Items.AddRange(new object[] {
            "Authors",
            "AuthorsAndBooks",
            "Books",
            "DateOfBirth",
            "DepartmentAndGroups",
            "DepartmentAndTeachers",
            "FirstNames",
            "GroupAndStudents",
            "IdentityCards",
            "LibraryCardsAndBooks",
            "LibraryEmproyees",
            "MiddleNames",
            "Passport",
            "PublisheresAndBooks",
            "Publishers",
            "SecondNames",
            "StudentCards",
            "Students",
            "TeacherCards",
            "Teachers",
            "UniversityDepartment",
            "UniversityGroup"});
            this.display_table_combobox.Location = new System.Drawing.Point(746, 56);
            this.display_table_combobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.display_table_combobox.Name = "display_table_combobox";
            this.display_table_combobox.Size = new System.Drawing.Size(320, 31);
            this.display_table_combobox.TabIndex = 4;
            this.display_table_combobox.SelectedIndexChanged += new System.EventHandler(this.display_table_combobox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(742, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Display Table";
            // 
            // display_table_confirm_button
            // 
            this.display_table_confirm_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.display_table_confirm_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.display_table_confirm_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.display_table_confirm_button.Location = new System.Drawing.Point(898, 17);
            this.display_table_confirm_button.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.display_table_confirm_button.Name = "display_table_confirm_button";
            this.display_table_confirm_button.Size = new System.Drawing.Size(120, 30);
            this.display_table_confirm_button.TabIndex = 6;
            this.display_table_confirm_button.Text = "Execute";
            this.display_table_confirm_button.UseVisualStyleBackColor = false;
            this.display_table_confirm_button.Click += new System.EventHandler(this.display_table_confirm_button_Click);
            // 
            // add_new_row_button
            // 
            this.add_new_row_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.add_new_row_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.add_new_row_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_row_button.Location = new System.Drawing.Point(24, 466);
            this.add_new_row_button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.add_new_row_button.Name = "add_new_row_button";
            this.add_new_row_button.Size = new System.Drawing.Size(260, 40);
            this.add_new_row_button.TabIndex = 7;
            this.add_new_row_button.Text = "Add new row";
            this.add_new_row_button.UseVisualStyleBackColor = false;
            this.add_new_row_button.Click += new System.EventHandler(this.add_new_row_button_Click);
            // 
            // remove_current_row_button
            // 
            this.remove_current_row_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.remove_current_row_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.remove_current_row_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove_current_row_button.Location = new System.Drawing.Point(24, 512);
            this.remove_current_row_button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.remove_current_row_button.Name = "remove_current_row_button";
            this.remove_current_row_button.Size = new System.Drawing.Size(260, 40);
            this.remove_current_row_button.TabIndex = 8;
            this.remove_current_row_button.Text = "Remove current row";
            this.remove_current_row_button.UseVisualStyleBackColor = false;
            this.remove_current_row_button.Click += new System.EventHandler(this.remove_current_row_button_Click);
            // 
            // available_choise_listBox
            // 
            this.available_choise_listBox.BackColor = System.Drawing.Color.SeaGreen;
            this.available_choise_listBox.FormattingEnabled = true;
            this.available_choise_listBox.ItemHeight = 23;
            this.available_choise_listBox.Location = new System.Drawing.Point(746, 93);
            this.available_choise_listBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.available_choise_listBox.Name = "available_choise_listBox";
            this.available_choise_listBox.Size = new System.Drawing.Size(259, 280);
            this.available_choise_listBox.TabIndex = 9;
            this.available_choise_listBox.Visible = false;
            // 
            // available_choise_button
            // 
            this.available_choise_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.available_choise_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.available_choise_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.available_choise_button.Location = new System.Drawing.Point(746, 379);
            this.available_choise_button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.available_choise_button.Name = "available_choise_button";
            this.available_choise_button.Size = new System.Drawing.Size(260, 49);
            this.available_choise_button.TabIndex = 10;
            this.available_choise_button.Text = "Show available choise";
            this.available_choise_button.UseVisualStyleBackColor = false;
            this.available_choise_button.Visible = false;
            this.available_choise_button.Click += new System.EventHandler(this.available_choise_button_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(877, 499);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 53);
            this.button1.TabIndex = 11;
            this.button1.Text = "To Main Menu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1079, 564);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.available_choise_button);
            this.Controls.Add(this.available_choise_listBox);
            this.Controls.Add(this.remove_current_row_button);
            this.Controls.Add(this.add_new_row_button);
            this.Controls.Add(this.display_table_confirm_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.display_table_combobox);
            this.Controls.Add(this.command_line_confirm_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.command_line_textbox);
            this.Controls.Add(this.display_table_datagridview);
            this.Font = new System.Drawing.Font("Verdana", 14F);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainForm";
            this.Text = "AdministrationForm";
            ((System.ComponentModel.ISupportInitialize)(this.display_table_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView display_table_datagridview;
        private System.Windows.Forms.TextBox command_line_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button command_line_confirm_button;
        private System.Windows.Forms.ComboBox display_table_combobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button display_table_confirm_button;
        private System.Windows.Forms.Button add_new_row_button;
        private System.Windows.Forms.Button remove_current_row_button;
        private System.Windows.Forms.ListBox available_choise_listBox;
        private System.Windows.Forms.Button available_choise_button;
        private System.Windows.Forms.Button button1;
    }
}

