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
            ((System.ComponentModel.ISupportInitialize)(this.display_table_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // display_table_datagridview
            // 
            this.display_table_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display_table_datagridview.Location = new System.Drawing.Point(18, 18);
            this.display_table_datagridview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.display_table_datagridview.Name = "display_table_datagridview";
            this.display_table_datagridview.Size = new System.Drawing.Size(692, 520);
            this.display_table_datagridview.TabIndex = 0;
            this.display_table_datagridview.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.display_table_datagridview_CellEndEdit);
            // 
            // command_line_textbox
            // 
            this.command_line_textbox.Location = new System.Drawing.Point(138, 644);
            this.command_line_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.command_line_textbox.Name = "command_line_textbox";
            this.command_line_textbox.Size = new System.Drawing.Size(491, 26);
            this.command_line_textbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(14, 646);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Command Line";
            // 
            // command_line_confirm_button
            // 
            this.command_line_confirm_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.command_line_confirm_button.Location = new System.Drawing.Point(637, 644);
            this.command_line_confirm_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.command_line_confirm_button.Name = "command_line_confirm_button";
            this.command_line_confirm_button.Size = new System.Drawing.Size(98, 26);
            this.command_line_confirm_button.TabIndex = 3;
            this.command_line_confirm_button.Text = "Execute";
            this.command_line_confirm_button.UseVisualStyleBackColor = true;
            this.command_line_confirm_button.Click += new System.EventHandler(this.command_line_confirm_button_Click);
            // 
            // display_table_combobox
            // 
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
            this.display_table_combobox.Location = new System.Drawing.Point(845, 23);
            this.display_table_combobox.Name = "display_table_combobox";
            this.display_table_combobox.Size = new System.Drawing.Size(245, 28);
            this.display_table_combobox.TabIndex = 4;
            this.display_table_combobox.SelectedIndexChanged += new System.EventHandler(this.display_table_combobox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(736, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Display Table";
            // 
            // display_table_confirm_button
            // 
            this.display_table_confirm_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.display_table_confirm_button.Location = new System.Drawing.Point(1097, 26);
            this.display_table_confirm_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.display_table_confirm_button.Name = "display_table_confirm_button";
            this.display_table_confirm_button.Size = new System.Drawing.Size(90, 26);
            this.display_table_confirm_button.TabIndex = 6;
            this.display_table_confirm_button.Text = "Execute";
            this.display_table_confirm_button.UseVisualStyleBackColor = true;
            this.display_table_confirm_button.Click += new System.EventHandler(this.display_table_confirm_button_Click);
            // 
            // add_new_row_button
            // 
            this.add_new_row_button.Location = new System.Drawing.Point(18, 542);
            this.add_new_row_button.Name = "add_new_row_button";
            this.add_new_row_button.Size = new System.Drawing.Size(185, 35);
            this.add_new_row_button.TabIndex = 7;
            this.add_new_row_button.Text = "Add new row";
            this.add_new_row_button.UseVisualStyleBackColor = true;
            this.add_new_row_button.Click += new System.EventHandler(this.add_new_row_button_Click);
            // 
            // remove_current_row_button
            // 
            this.remove_current_row_button.Location = new System.Drawing.Point(18, 583);
            this.remove_current_row_button.Name = "remove_current_row_button";
            this.remove_current_row_button.Size = new System.Drawing.Size(185, 35);
            this.remove_current_row_button.TabIndex = 8;
            this.remove_current_row_button.Text = "Remove current row";
            this.remove_current_row_button.UseVisualStyleBackColor = true;
            this.remove_current_row_button.Click += new System.EventHandler(this.remove_current_row_button_Click);
            // 
            // available_choise_listBox
            // 
            this.available_choise_listBox.FormattingEnabled = true;
            this.available_choise_listBox.ItemHeight = 20;
            this.available_choise_listBox.Location = new System.Drawing.Point(861, 224);
            this.available_choise_listBox.Name = "available_choise_listBox";
            this.available_choise_listBox.Size = new System.Drawing.Size(195, 244);
            this.available_choise_listBox.TabIndex = 9;
            this.available_choise_listBox.Visible = false;
            // 
            // available_choise_button
            // 
            this.available_choise_button.Location = new System.Drawing.Point(861, 474);
            this.available_choise_button.Name = "available_choise_button";
            this.available_choise_button.Size = new System.Drawing.Size(195, 43);
            this.available_choise_button.TabIndex = 10;
            this.available_choise_button.Text = "Show available choise";
            this.available_choise_button.UseVisualStyleBackColor = true;
            this.available_choise_button.Visible = false;
            this.available_choise_button.Click += new System.EventHandler(this.available_choise_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Form1";
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
    }
}

