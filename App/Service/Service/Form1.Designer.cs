namespace Service
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
            this.tabPage_Export = new System.Windows.Forms.TabPage();
            this.tabPage_Language = new System.Windows.Forms.TabPage();
            this.tabPage_Editor = new System.Windows.Forms.TabPage();
            this.tabControl_Editor = new System.Windows.Forms.TabControl();
            this.tabPage_Editor_Scenario = new System.Windows.Forms.TabPage();
            this.tabPage_Editor_Section = new System.Windows.Forms.TabPage();
            this.tabPage_Editor_CheckPoint = new System.Windows.Forms.TabPage();
            this.tabPage_Editor_Operation = new System.Windows.Forms.TabPage();
            this.tabPage_Scenarios = new System.Windows.Forms.TabPage();
            this.tabControl_Scenarios = new System.Windows.Forms.TabControl();
            this.tabPage_Scenarios_Scenario = new System.Windows.Forms.TabPage();
            this.tabPage_Scenarios_Section = new System.Windows.Forms.TabPage();
            this.tabPage_Scenarios_CheckPoint = new System.Windows.Forms.TabPage();
            this.tabPage_Database = new System.Windows.Forms.TabPage();
            this.tabControl_Database = new System.Windows.Forms.TabControl();
            this.tabPage_Database_Connection = new System.Windows.Forms.TabPage();
            this.tabPage_Database_CreateScript = new System.Windows.Forms.TabPage();
            this.tabPage_Database_InsertScript = new System.Windows.Forms.TabPage();
            this.tabPage_Database_DropScript = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.backgroundWorker_Connection = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage_Editor.SuspendLayout();
            this.tabControl_Editor.SuspendLayout();
            this.tabPage_Scenarios.SuspendLayout();
            this.tabControl_Scenarios.SuspendLayout();
            this.tabPage_Database.SuspendLayout();
            this.tabControl_Database.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage_Export
            // 
            this.tabPage_Export.Location = new System.Drawing.Point(4, 36);
            this.tabPage_Export.Name = "tabPage_Export";
            this.tabPage_Export.Size = new System.Drawing.Size(596, 482);
            this.tabPage_Export.TabIndex = 4;
            this.tabPage_Export.Text = "Export";
            this.tabPage_Export.UseVisualStyleBackColor = true;
            // 
            // tabPage_Language
            // 
            this.tabPage_Language.Location = new System.Drawing.Point(4, 36);
            this.tabPage_Language.Name = "tabPage_Language";
            this.tabPage_Language.Size = new System.Drawing.Size(596, 482);
            this.tabPage_Language.TabIndex = 3;
            this.tabPage_Language.Text = "Language";
            this.tabPage_Language.UseVisualStyleBackColor = true;
            // 
            // tabPage_Editor
            // 
            this.tabPage_Editor.Controls.Add(this.tabControl_Editor);
            this.tabPage_Editor.Location = new System.Drawing.Point(4, 36);
            this.tabPage_Editor.Name = "tabPage_Editor";
            this.tabPage_Editor.Size = new System.Drawing.Size(596, 482);
            this.tabPage_Editor.TabIndex = 2;
            this.tabPage_Editor.Text = "Editor";
            this.tabPage_Editor.UseVisualStyleBackColor = true;
            // 
            // tabControl_Editor
            // 
            this.tabControl_Editor.Controls.Add(this.tabPage_Editor_Scenario);
            this.tabControl_Editor.Controls.Add(this.tabPage_Editor_Section);
            this.tabControl_Editor.Controls.Add(this.tabPage_Editor_CheckPoint);
            this.tabControl_Editor.Controls.Add(this.tabPage_Editor_Operation);
            this.tabControl_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Editor.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Editor.Name = "tabControl_Editor";
            this.tabControl_Editor.Padding = new System.Drawing.Point(40, 5);
            this.tabControl_Editor.SelectedIndex = 0;
            this.tabControl_Editor.Size = new System.Drawing.Size(596, 482);
            this.tabControl_Editor.TabIndex = 0;
            // 
            // tabPage_Editor_Scenario
            // 
            this.tabPage_Editor_Scenario.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Editor_Scenario.Name = "tabPage_Editor_Scenario";
            this.tabPage_Editor_Scenario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Editor_Scenario.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Editor_Scenario.TabIndex = 0;
            this.tabPage_Editor_Scenario.Text = "Scenario";
            this.tabPage_Editor_Scenario.UseVisualStyleBackColor = true;
            // 
            // tabPage_Editor_Section
            // 
            this.tabPage_Editor_Section.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Editor_Section.Name = "tabPage_Editor_Section";
            this.tabPage_Editor_Section.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Editor_Section.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Editor_Section.TabIndex = 1;
            this.tabPage_Editor_Section.Text = "Section";
            this.tabPage_Editor_Section.UseVisualStyleBackColor = true;
            // 
            // tabPage_Editor_CheckPoint
            // 
            this.tabPage_Editor_CheckPoint.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Editor_CheckPoint.Name = "tabPage_Editor_CheckPoint";
            this.tabPage_Editor_CheckPoint.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Editor_CheckPoint.TabIndex = 2;
            this.tabPage_Editor_CheckPoint.Text = "CheckPoint";
            this.tabPage_Editor_CheckPoint.UseVisualStyleBackColor = true;
            // 
            // tabPage_Editor_Operation
            // 
            this.tabPage_Editor_Operation.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Editor_Operation.Name = "tabPage_Editor_Operation";
            this.tabPage_Editor_Operation.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Editor_Operation.TabIndex = 3;
            this.tabPage_Editor_Operation.Text = "Operation";
            this.tabPage_Editor_Operation.UseVisualStyleBackColor = true;
            // 
            // tabPage_Scenarios
            // 
            this.tabPage_Scenarios.Controls.Add(this.tabControl_Scenarios);
            this.tabPage_Scenarios.Location = new System.Drawing.Point(4, 36);
            this.tabPage_Scenarios.Name = "tabPage_Scenarios";
            this.tabPage_Scenarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Scenarios.Size = new System.Drawing.Size(596, 482);
            this.tabPage_Scenarios.TabIndex = 1;
            this.tabPage_Scenarios.Text = "Scenarios";
            this.tabPage_Scenarios.UseVisualStyleBackColor = true;
            // 
            // tabControl_Scenarios
            // 
            this.tabControl_Scenarios.Controls.Add(this.tabPage_Scenarios_Scenario);
            this.tabControl_Scenarios.Controls.Add(this.tabPage_Scenarios_Section);
            this.tabControl_Scenarios.Controls.Add(this.tabPage_Scenarios_CheckPoint);
            this.tabControl_Scenarios.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Scenarios.Name = "tabControl_Scenarios";
            this.tabControl_Scenarios.Padding = new System.Drawing.Point(40, 5);
            this.tabControl_Scenarios.SelectedIndex = 0;
            this.tabControl_Scenarios.Size = new System.Drawing.Size(596, 482);
            this.tabControl_Scenarios.TabIndex = 0;
            // 
            // tabPage_Scenarios_Scenario
            // 
            this.tabPage_Scenarios_Scenario.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Scenarios_Scenario.Name = "tabPage_Scenarios_Scenario";
            this.tabPage_Scenarios_Scenario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Scenarios_Scenario.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Scenarios_Scenario.TabIndex = 0;
            this.tabPage_Scenarios_Scenario.Text = "Scenario";
            this.tabPage_Scenarios_Scenario.UseVisualStyleBackColor = true;
            // 
            // tabPage_Scenarios_Section
            // 
            this.tabPage_Scenarios_Section.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Scenarios_Section.Name = "tabPage_Scenarios_Section";
            this.tabPage_Scenarios_Section.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Scenarios_Section.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Scenarios_Section.TabIndex = 1;
            this.tabPage_Scenarios_Section.Text = "Section";
            this.tabPage_Scenarios_Section.UseVisualStyleBackColor = true;
            // 
            // tabPage_Scenarios_CheckPoint
            // 
            this.tabPage_Scenarios_CheckPoint.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Scenarios_CheckPoint.Name = "tabPage_Scenarios_CheckPoint";
            this.tabPage_Scenarios_CheckPoint.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Scenarios_CheckPoint.TabIndex = 2;
            this.tabPage_Scenarios_CheckPoint.Text = "CheckPoint";
            this.tabPage_Scenarios_CheckPoint.UseVisualStyleBackColor = true;
            // 
            // tabPage_Database
            // 
            this.tabPage_Database.Controls.Add(this.tabControl_Database);
            this.tabPage_Database.Location = new System.Drawing.Point(4, 36);
            this.tabPage_Database.Name = "tabPage_Database";
            this.tabPage_Database.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Database.Size = new System.Drawing.Size(597, 470);
            this.tabPage_Database.TabIndex = 0;
            this.tabPage_Database.Text = "Database";
            this.tabPage_Database.UseVisualStyleBackColor = true;
            // 
            // tabControl_Database
            // 
            this.tabControl_Database.Controls.Add(this.tabPage_Database_Connection);
            this.tabControl_Database.Controls.Add(this.tabPage_Database_CreateScript);
            this.tabControl_Database.Controls.Add(this.tabPage_Database_InsertScript);
            this.tabControl_Database.Controls.Add(this.tabPage_Database_DropScript);
            this.tabControl_Database.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Database.Name = "tabControl_Database";
            this.tabControl_Database.Padding = new System.Drawing.Point(40, 5);
            this.tabControl_Database.SelectedIndex = 0;
            this.tabControl_Database.Size = new System.Drawing.Size(596, 482);
            this.tabControl_Database.TabIndex = 1;
            // 
            // tabPage_Database_Connection
            // 
            this.tabPage_Database_Connection.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Database_Connection.Name = "tabPage_Database_Connection";
            this.tabPage_Database_Connection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Database_Connection.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Database_Connection.TabIndex = 0;
            this.tabPage_Database_Connection.Text = "Connection";
            this.tabPage_Database_Connection.UseVisualStyleBackColor = true;
            // 
            // tabPage_Database_CreateScript
            // 
            this.tabPage_Database_CreateScript.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Database_CreateScript.Name = "tabPage_Database_CreateScript";
            this.tabPage_Database_CreateScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Database_CreateScript.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Database_CreateScript.TabIndex = 1;
            this.tabPage_Database_CreateScript.Text = "Create Script";
            this.tabPage_Database_CreateScript.UseVisualStyleBackColor = true;
            // 
            // tabPage_Database_InsertScript
            // 
            this.tabPage_Database_InsertScript.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Database_InsertScript.Name = "tabPage_Database_InsertScript";
            this.tabPage_Database_InsertScript.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Database_InsertScript.TabIndex = 2;
            this.tabPage_Database_InsertScript.Text = "Insert Script";
            this.tabPage_Database_InsertScript.UseVisualStyleBackColor = true;
            // 
            // tabPage_Database_DropScript
            // 
            this.tabPage_Database_DropScript.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Database_DropScript.Name = "tabPage_Database_DropScript";
            this.tabPage_Database_DropScript.Size = new System.Drawing.Size(588, 452);
            this.tabPage_Database_DropScript.TabIndex = 3;
            this.tabPage_Database_DropScript.Text = "Drop Script";
            this.tabPage_Database_DropScript.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_Database);
            this.tabControl.Controls.Add(this.tabPage_Scenarios);
            this.tabControl.Controls.Add(this.tabPage_Editor);
            this.tabControl.Controls.Add(this.tabPage_Language);
            this.tabControl.Controls.Add(this.tabPage_Export);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(40, 10);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(605, 510);
            this.tabControl.TabIndex = 0;
            // 
            // backgroundWorker_Connection
            // 
            this.backgroundWorker_Connection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Connection_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 522);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Car Service";
            this.tabPage_Editor.ResumeLayout(false);
            this.tabControl_Editor.ResumeLayout(false);
            this.tabPage_Scenarios.ResumeLayout(false);
            this.tabControl_Scenarios.ResumeLayout(false);
            this.tabPage_Database.ResumeLayout(false);
            this.tabControl_Database.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage_Export;
        private System.Windows.Forms.TabPage tabPage_Language;
        private System.Windows.Forms.TabPage tabPage_Editor;
        private System.Windows.Forms.TabControl tabControl_Editor;
        private System.Windows.Forms.TabPage tabPage_Editor_Scenario;
        private System.Windows.Forms.TabPage tabPage_Editor_Section;
        private System.Windows.Forms.TabPage tabPage_Editor_CheckPoint;
        private System.Windows.Forms.TabPage tabPage_Editor_Operation;
        private System.Windows.Forms.TabPage tabPage_Scenarios;
        private System.Windows.Forms.TabControl tabControl_Scenarios;
        private System.Windows.Forms.TabPage tabPage_Scenarios_Scenario;
        private System.Windows.Forms.TabPage tabPage_Scenarios_Section;
        private System.Windows.Forms.TabPage tabPage_Scenarios_CheckPoint;
        private System.Windows.Forms.TabPage tabPage_Database;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabControl tabControl_Database;
        private System.Windows.Forms.TabPage tabPage_Database_Connection;
        private System.Windows.Forms.TabPage tabPage_Database_CreateScript;
        private System.Windows.Forms.TabPage tabPage_Database_InsertScript;
        private System.Windows.Forms.TabPage tabPage_Database_DropScript;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Connection;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

