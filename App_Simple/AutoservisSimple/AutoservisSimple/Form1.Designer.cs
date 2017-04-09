namespace AutoservisSimple
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
            this.button_CreateTables = new System.Windows.Forms.Button();
            this.button_InsertRows = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.panel_CreateTables = new System.Windows.Forms.Panel();
            this.panel_InsertRows = new System.Windows.Forms.Panel();
            this.panel_SelectLanguage = new System.Windows.Forms.Panel();
            this.panel_Export = new System.Windows.Forms.Panel();
            this.panel_Clear = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button_CreateTables
            // 
            this.button_CreateTables.Location = new System.Drawing.Point(12, 12);
            this.button_CreateTables.Name = "button_CreateTables";
            this.button_CreateTables.Size = new System.Drawing.Size(262, 37);
            this.button_CreateTables.TabIndex = 0;
            this.button_CreateTables.Text = "Create Tables";
            this.button_CreateTables.UseVisualStyleBackColor = true;
            this.button_CreateTables.Click += new System.EventHandler(this.Button_CreateTables_Click);
            // 
            // button_InsertRows
            // 
            this.button_InsertRows.Location = new System.Drawing.Point(12, 55);
            this.button_InsertRows.Name = "button_InsertRows";
            this.button_InsertRows.Size = new System.Drawing.Size(262, 37);
            this.button_InsertRows.TabIndex = 1;
            this.button_InsertRows.Text = "Insert Rows";
            this.button_InsertRows.UseVisualStyleBackColor = true;
            this.button_InsertRows.Click += new System.EventHandler(this.Button_InsertRows_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(12, 184);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(262, 37);
            this.button_Clear.TabIndex = 2;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(12, 141);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(262, 37);
            this.button_Export.TabIndex = 3;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.Button_Export_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Language";
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "EN"});
            this.comboBox.Location = new System.Drawing.Point(102, 108);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(146, 21);
            this.comboBox.TabIndex = 5;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // panel_CreateTables
            // 
            this.panel_CreateTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_CreateTables.Location = new System.Drawing.Point(280, 12);
            this.panel_CreateTables.Name = "panel_CreateTables";
            this.panel_CreateTables.Size = new System.Drawing.Size(37, 37);
            this.panel_CreateTables.TabIndex = 6;
            // 
            // panel_InsertRows
            // 
            this.panel_InsertRows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_InsertRows.Location = new System.Drawing.Point(280, 55);
            this.panel_InsertRows.Name = "panel_InsertRows";
            this.panel_InsertRows.Size = new System.Drawing.Size(37, 37);
            this.panel_InsertRows.TabIndex = 7;
            // 
            // panel_SelectLanguage
            // 
            this.panel_SelectLanguage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_SelectLanguage.Location = new System.Drawing.Point(280, 98);
            this.panel_SelectLanguage.Name = "panel_SelectLanguage";
            this.panel_SelectLanguage.Size = new System.Drawing.Size(37, 37);
            this.panel_SelectLanguage.TabIndex = 7;
            // 
            // panel_Export
            // 
            this.panel_Export.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Export.Location = new System.Drawing.Point(280, 141);
            this.panel_Export.Name = "panel_Export";
            this.panel_Export.Size = new System.Drawing.Size(37, 37);
            this.panel_Export.TabIndex = 7;
            // 
            // panel_Clear
            // 
            this.panel_Clear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Clear.Location = new System.Drawing.Point(280, 184);
            this.panel_Clear.Name = "panel_Clear";
            this.panel_Clear.Size = new System.Drawing.Size(37, 37);
            this.panel_Clear.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 232);
            this.Controls.Add(this.panel_Clear);
            this.Controls.Add(this.panel_Export);
            this.Controls.Add(this.panel_SelectLanguage);
            this.Controls.Add(this.panel_InsertRows);
            this.Controls.Add(this.panel_CreateTables);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Export);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_InsertRows);
            this.Controls.Add(this.button_CreateTables);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autoservis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_CreateTables;
        private System.Windows.Forms.Button button_InsertRows;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Panel panel_CreateTables;
        private System.Windows.Forms.Panel panel_InsertRows;
        private System.Windows.Forms.Panel panel_SelectLanguage;
        private System.Windows.Forms.Panel panel_Export;
        private System.Windows.Forms.Panel panel_Clear;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

