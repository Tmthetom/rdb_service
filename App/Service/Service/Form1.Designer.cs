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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Export_Operations = new System.Windows.Forms.TextBox();
            this.textBox_Export_CheckPoints = new System.Windows.Forms.TextBox();
            this.textBox_Export_Sections = new System.Windows.Forms.TextBox();
            this.label_Export_Operations = new System.Windows.Forms.Label();
            this.label_Export_CheckPoints = new System.Windows.Forms.Label();
            this.label_Export_Sections = new System.Windows.Forms.Label();
            this.textBox_Export_Scenarios = new System.Windows.Forms.TextBox();
            this.label_Export_Scenarios = new System.Windows.Forms.Label();
            this.comboBox_Export_ExportLanguage = new System.Windows.Forms.ComboBox();
            this.label_Export_ExportLanguage = new System.Windows.Forms.Label();
            this.button_Export = new System.Windows.Forms.Button();
            this.tabPage_Language = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.groupBox_Connection = new System.Windows.Forms.GroupBox();
            this.textBox_Connection_Password = new System.Windows.Forms.TextBox();
            this.textBox_Connection_Username = new System.Windows.Forms.TextBox();
            this.textBox_Connection_DatabaseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Connection_ServerAddress = new System.Windows.Forms.TextBox();
            this.label_Connection_ServerAddress = new System.Windows.Forms.Label();
            this.comboBox_Connection_PreferedServer = new System.Windows.Forms.ComboBox();
            this.label_Connection_PreferedServer = new System.Windows.Forms.Label();
            this.button_Database_Connect = new System.Windows.Forms.Button();
            this.tabPage_Database_CreateScript = new System.Windows.Forms.TabPage();
            this.panel_CreateScript_DragAndDrop = new System.Windows.Forms.Panel();
            this.button_CreateScript = new System.Windows.Forms.Button();
            this.tabPage_Database_InsertScript = new System.Windows.Forms.TabPage();
            this.panel_InsertScript_DragAndDrop = new System.Windows.Forms.Panel();
            this.button_InsertScript = new System.Windows.Forms.Button();
            this.tabPage_Database_DropScript = new System.Windows.Forms.TabPage();
            this.panel_DropScript_DragAndDrop = new System.Windows.Forms.Panel();
            this.button_DropScript = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.backgroundWorker_Connection = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPage_Export.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_Language.SuspendLayout();
            this.tabPage_Editor.SuspendLayout();
            this.tabControl_Editor.SuspendLayout();
            this.tabPage_Scenarios.SuspendLayout();
            this.tabControl_Scenarios.SuspendLayout();
            this.tabPage_Database.SuspendLayout();
            this.tabControl_Database.SuspendLayout();
            this.tabPage_Database_Connection.SuspendLayout();
            this.groupBox_Connection.SuspendLayout();
            this.tabPage_Database_CreateScript.SuspendLayout();
            this.tabPage_Database_InsertScript.SuspendLayout();
            this.tabPage_Database_DropScript.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage_Export
            // 
            this.tabPage_Export.Controls.Add(this.groupBox1);
            this.tabPage_Export.Controls.Add(this.comboBox_Export_ExportLanguage);
            this.tabPage_Export.Controls.Add(this.label_Export_ExportLanguage);
            this.tabPage_Export.Controls.Add(this.button_Export);
            this.tabPage_Export.Location = new System.Drawing.Point(4, 36);
            this.tabPage_Export.Name = "tabPage_Export";
            this.tabPage_Export.Size = new System.Drawing.Size(597, 460);
            this.tabPage_Export.TabIndex = 4;
            this.tabPage_Export.Text = "Export";
            this.tabPage_Export.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Export_Operations);
            this.groupBox1.Controls.Add(this.textBox_Export_CheckPoints);
            this.groupBox1.Controls.Add(this.textBox_Export_Sections);
            this.groupBox1.Controls.Add(this.label_Export_Operations);
            this.groupBox1.Controls.Add(this.label_Export_CheckPoints);
            this.groupBox1.Controls.Add(this.label_Export_Sections);
            this.groupBox1.Controls.Add(this.textBox_Export_Scenarios);
            this.groupBox1.Controls.Add(this.label_Export_Scenarios);
            this.groupBox1.Location = new System.Drawing.Point(27, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 331);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail informations";
            // 
            // textBox_Export_Operations
            // 
            this.textBox_Export_Operations.Enabled = false;
            this.textBox_Export_Operations.Location = new System.Drawing.Point(267, 149);
            this.textBox_Export_Operations.Name = "textBox_Export_Operations";
            this.textBox_Export_Operations.Size = new System.Drawing.Size(232, 20);
            this.textBox_Export_Operations.TabIndex = 11;
            this.textBox_Export_Operations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Export_CheckPoints
            // 
            this.textBox_Export_CheckPoints.Enabled = false;
            this.textBox_Export_CheckPoints.Location = new System.Drawing.Point(267, 112);
            this.textBox_Export_CheckPoints.Name = "textBox_Export_CheckPoints";
            this.textBox_Export_CheckPoints.Size = new System.Drawing.Size(232, 20);
            this.textBox_Export_CheckPoints.TabIndex = 10;
            this.textBox_Export_CheckPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Export_Sections
            // 
            this.textBox_Export_Sections.Enabled = false;
            this.textBox_Export_Sections.Location = new System.Drawing.Point(267, 75);
            this.textBox_Export_Sections.Name = "textBox_Export_Sections";
            this.textBox_Export_Sections.Size = new System.Drawing.Size(232, 20);
            this.textBox_Export_Sections.TabIndex = 9;
            this.textBox_Export_Sections.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Export_Operations
            // 
            this.label_Export_Operations.AutoSize = true;
            this.label_Export_Operations.Location = new System.Drawing.Point(37, 152);
            this.label_Export_Operations.Name = "label_Export_Operations";
            this.label_Export_Operations.Size = new System.Drawing.Size(58, 13);
            this.label_Export_Operations.TabIndex = 8;
            this.label_Export_Operations.Text = "Operations";
            // 
            // label_Export_CheckPoints
            // 
            this.label_Export_CheckPoints.AutoSize = true;
            this.label_Export_CheckPoints.Location = new System.Drawing.Point(37, 115);
            this.label_Export_CheckPoints.Name = "label_Export_CheckPoints";
            this.label_Export_CheckPoints.Size = new System.Drawing.Size(67, 13);
            this.label_Export_CheckPoints.TabIndex = 7;
            this.label_Export_CheckPoints.Text = "CheckPoints";
            // 
            // label_Export_Sections
            // 
            this.label_Export_Sections.AutoSize = true;
            this.label_Export_Sections.Location = new System.Drawing.Point(37, 78);
            this.label_Export_Sections.Name = "label_Export_Sections";
            this.label_Export_Sections.Size = new System.Drawing.Size(48, 13);
            this.label_Export_Sections.TabIndex = 6;
            this.label_Export_Sections.Text = "Sections";
            // 
            // textBox_Export_Scenarios
            // 
            this.textBox_Export_Scenarios.Enabled = false;
            this.textBox_Export_Scenarios.Location = new System.Drawing.Point(267, 39);
            this.textBox_Export_Scenarios.Name = "textBox_Export_Scenarios";
            this.textBox_Export_Scenarios.Size = new System.Drawing.Size(232, 20);
            this.textBox_Export_Scenarios.TabIndex = 5;
            this.textBox_Export_Scenarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Export_Scenarios
            // 
            this.label_Export_Scenarios.AutoSize = true;
            this.label_Export_Scenarios.Location = new System.Drawing.Point(37, 42);
            this.label_Export_Scenarios.Name = "label_Export_Scenarios";
            this.label_Export_Scenarios.Size = new System.Drawing.Size(54, 13);
            this.label_Export_Scenarios.TabIndex = 4;
            this.label_Export_Scenarios.Text = "Scenarios";
            // 
            // comboBox_Export_ExportLanguage
            // 
            this.comboBox_Export_ExportLanguage.FormattingEnabled = true;
            this.comboBox_Export_ExportLanguage.Location = new System.Drawing.Point(194, 21);
            this.comboBox_Export_ExportLanguage.Name = "comboBox_Export_ExportLanguage";
            this.comboBox_Export_ExportLanguage.Size = new System.Drawing.Size(375, 21);
            this.comboBox_Export_ExportLanguage.TabIndex = 2;
            this.comboBox_Export_ExportLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Export_ExportLanguage_SelectedIndexChanged);
            // 
            // label_Export_ExportLanguage
            // 
            this.label_Export_ExportLanguage.AutoSize = true;
            this.label_Export_ExportLanguage.Location = new System.Drawing.Point(24, 24);
            this.label_Export_ExportLanguage.Name = "label_Export_ExportLanguage";
            this.label_Export_ExportLanguage.Size = new System.Drawing.Size(88, 13);
            this.label_Export_ExportLanguage.TabIndex = 1;
            this.label_Export_ExportLanguage.Text = "Export Language";
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(8, 417);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(581, 34);
            this.button_Export.TabIndex = 0;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.Button_Export_Click);
            // 
            // tabPage_Language
            // 
            this.tabPage_Language.Controls.Add(this.comboBox1);
            this.tabPage_Language.Controls.Add(this.label4);
            this.tabPage_Language.Location = new System.Drawing.Point(4, 36);
            this.tabPage_Language.Name = "tabPage_Language";
            this.tabPage_Language.Size = new System.Drawing.Size(597, 460);
            this.tabPage_Language.TabIndex = 3;
            this.tabPage_Language.Text = "Language";
            this.tabPage_Language.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(194, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(375, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selected Language";
            // 
            // tabPage_Editor
            // 
            this.tabPage_Editor.Controls.Add(this.tabControl_Editor);
            this.tabPage_Editor.Location = new System.Drawing.Point(4, 36);
            this.tabPage_Editor.Name = "tabPage_Editor";
            this.tabPage_Editor.Size = new System.Drawing.Size(597, 460);
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
            this.tabControl_Editor.Size = new System.Drawing.Size(597, 460);
            this.tabControl_Editor.TabIndex = 0;
            // 
            // tabPage_Editor_Scenario
            // 
            this.tabPage_Editor_Scenario.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Editor_Scenario.Name = "tabPage_Editor_Scenario";
            this.tabPage_Editor_Scenario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Editor_Scenario.Size = new System.Drawing.Size(589, 430);
            this.tabPage_Editor_Scenario.TabIndex = 0;
            this.tabPage_Editor_Scenario.Text = "Scenario";
            this.tabPage_Editor_Scenario.UseVisualStyleBackColor = true;
            // 
            // tabPage_Editor_Section
            // 
            this.tabPage_Editor_Section.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Editor_Section.Name = "tabPage_Editor_Section";
            this.tabPage_Editor_Section.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Editor_Section.Size = new System.Drawing.Size(589, 430);
            this.tabPage_Editor_Section.TabIndex = 1;
            this.tabPage_Editor_Section.Text = "Section";
            this.tabPage_Editor_Section.UseVisualStyleBackColor = true;
            // 
            // tabPage_Editor_CheckPoint
            // 
            this.tabPage_Editor_CheckPoint.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Editor_CheckPoint.Name = "tabPage_Editor_CheckPoint";
            this.tabPage_Editor_CheckPoint.Size = new System.Drawing.Size(589, 430);
            this.tabPage_Editor_CheckPoint.TabIndex = 2;
            this.tabPage_Editor_CheckPoint.Text = "CheckPoint";
            this.tabPage_Editor_CheckPoint.UseVisualStyleBackColor = true;
            // 
            // tabPage_Editor_Operation
            // 
            this.tabPage_Editor_Operation.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Editor_Operation.Name = "tabPage_Editor_Operation";
            this.tabPage_Editor_Operation.Size = new System.Drawing.Size(589, 430);
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
            this.tabPage_Scenarios.Size = new System.Drawing.Size(597, 460);
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
            this.tabControl_Scenarios.Size = new System.Drawing.Size(596, 460);
            this.tabControl_Scenarios.TabIndex = 0;
            // 
            // tabPage_Scenarios_Scenario
            // 
            this.tabPage_Scenarios_Scenario.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Scenarios_Scenario.Name = "tabPage_Scenarios_Scenario";
            this.tabPage_Scenarios_Scenario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Scenarios_Scenario.Size = new System.Drawing.Size(588, 430);
            this.tabPage_Scenarios_Scenario.TabIndex = 0;
            this.tabPage_Scenarios_Scenario.Text = "Scenario";
            this.tabPage_Scenarios_Scenario.UseVisualStyleBackColor = true;
            // 
            // tabPage_Scenarios_Section
            // 
            this.tabPage_Scenarios_Section.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Scenarios_Section.Name = "tabPage_Scenarios_Section";
            this.tabPage_Scenarios_Section.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Scenarios_Section.Size = new System.Drawing.Size(588, 430);
            this.tabPage_Scenarios_Section.TabIndex = 1;
            this.tabPage_Scenarios_Section.Text = "Section";
            this.tabPage_Scenarios_Section.UseVisualStyleBackColor = true;
            // 
            // tabPage_Scenarios_CheckPoint
            // 
            this.tabPage_Scenarios_CheckPoint.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Scenarios_CheckPoint.Name = "tabPage_Scenarios_CheckPoint";
            this.tabPage_Scenarios_CheckPoint.Size = new System.Drawing.Size(588, 430);
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
            this.tabPage_Database.Size = new System.Drawing.Size(597, 460);
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
            this.tabControl_Database.Size = new System.Drawing.Size(596, 461);
            this.tabControl_Database.TabIndex = 1;
            // 
            // tabPage_Database_Connection
            // 
            this.tabPage_Database_Connection.Controls.Add(this.groupBox_Connection);
            this.tabPage_Database_Connection.Controls.Add(this.comboBox_Connection_PreferedServer);
            this.tabPage_Database_Connection.Controls.Add(this.label_Connection_PreferedServer);
            this.tabPage_Database_Connection.Controls.Add(this.button_Database_Connect);
            this.tabPage_Database_Connection.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Database_Connection.Name = "tabPage_Database_Connection";
            this.tabPage_Database_Connection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Database_Connection.Size = new System.Drawing.Size(588, 431);
            this.tabPage_Database_Connection.TabIndex = 0;
            this.tabPage_Database_Connection.Text = "Connection";
            this.tabPage_Database_Connection.UseVisualStyleBackColor = true;
            // 
            // groupBox_Connection
            // 
            this.groupBox_Connection.Controls.Add(this.textBox_Connection_Password);
            this.groupBox_Connection.Controls.Add(this.textBox_Connection_Username);
            this.groupBox_Connection.Controls.Add(this.textBox_Connection_DatabaseName);
            this.groupBox_Connection.Controls.Add(this.label1);
            this.groupBox_Connection.Controls.Add(this.label2);
            this.groupBox_Connection.Controls.Add(this.label3);
            this.groupBox_Connection.Controls.Add(this.textBox_Connection_ServerAddress);
            this.groupBox_Connection.Controls.Add(this.label_Connection_ServerAddress);
            this.groupBox_Connection.Location = new System.Drawing.Point(23, 74);
            this.groupBox_Connection.Name = "groupBox_Connection";
            this.groupBox_Connection.Size = new System.Drawing.Size(542, 307);
            this.groupBox_Connection.TabIndex = 5;
            this.groupBox_Connection.TabStop = false;
            this.groupBox_Connection.Text = "Detail informations";
            // 
            // textBox_Connection_Password
            // 
            this.textBox_Connection_Password.Location = new System.Drawing.Point(267, 149);
            this.textBox_Connection_Password.Name = "textBox_Connection_Password";
            this.textBox_Connection_Password.PasswordChar = '*';
            this.textBox_Connection_Password.Size = new System.Drawing.Size(232, 20);
            this.textBox_Connection_Password.TabIndex = 11;
            this.textBox_Connection_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Connection_Username
            // 
            this.textBox_Connection_Username.Location = new System.Drawing.Point(267, 112);
            this.textBox_Connection_Username.Name = "textBox_Connection_Username";
            this.textBox_Connection_Username.Size = new System.Drawing.Size(232, 20);
            this.textBox_Connection_Username.TabIndex = 10;
            this.textBox_Connection_Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Connection_DatabaseName
            // 
            this.textBox_Connection_DatabaseName.Location = new System.Drawing.Point(267, 75);
            this.textBox_Connection_DatabaseName.Name = "textBox_Connection_DatabaseName";
            this.textBox_Connection_DatabaseName.Size = new System.Drawing.Size(232, 20);
            this.textBox_Connection_DatabaseName.TabIndex = 9;
            this.textBox_Connection_DatabaseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Database name";
            // 
            // textBox_Connection_ServerAddress
            // 
            this.textBox_Connection_ServerAddress.Location = new System.Drawing.Point(267, 39);
            this.textBox_Connection_ServerAddress.Name = "textBox_Connection_ServerAddress";
            this.textBox_Connection_ServerAddress.Size = new System.Drawing.Size(232, 20);
            this.textBox_Connection_ServerAddress.TabIndex = 5;
            this.textBox_Connection_ServerAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Connection_ServerAddress
            // 
            this.label_Connection_ServerAddress.AutoSize = true;
            this.label_Connection_ServerAddress.Location = new System.Drawing.Point(37, 42);
            this.label_Connection_ServerAddress.Name = "label_Connection_ServerAddress";
            this.label_Connection_ServerAddress.Size = new System.Drawing.Size(79, 13);
            this.label_Connection_ServerAddress.TabIndex = 4;
            this.label_Connection_ServerAddress.Text = "Server Address";
            // 
            // comboBox_Connection_PreferedServer
            // 
            this.comboBox_Connection_PreferedServer.FormattingEnabled = true;
            this.comboBox_Connection_PreferedServer.Items.AddRange(new object[] {
            "Technical University of Liberec",
            "None"});
            this.comboBox_Connection_PreferedServer.Location = new System.Drawing.Point(187, 26);
            this.comboBox_Connection_PreferedServer.Name = "comboBox_Connection_PreferedServer";
            this.comboBox_Connection_PreferedServer.Size = new System.Drawing.Size(375, 21);
            this.comboBox_Connection_PreferedServer.TabIndex = 4;
            this.comboBox_Connection_PreferedServer.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Connection_PreferedServer_SelectedIndexChanged);
            // 
            // label_Connection_PreferedServer
            // 
            this.label_Connection_PreferedServer.AutoSize = true;
            this.label_Connection_PreferedServer.Location = new System.Drawing.Point(21, 29);
            this.label_Connection_PreferedServer.Name = "label_Connection_PreferedServer";
            this.label_Connection_PreferedServer.Size = new System.Drawing.Size(87, 13);
            this.label_Connection_PreferedServer.TabIndex = 3;
            this.label_Connection_PreferedServer.Text = "Prefered servers:";
            // 
            // button_Database_Connect
            // 
            this.button_Database_Connect.Location = new System.Drawing.Point(4, 391);
            this.button_Database_Connect.Name = "button_Database_Connect";
            this.button_Database_Connect.Size = new System.Drawing.Size(581, 34);
            this.button_Database_Connect.TabIndex = 1;
            this.button_Database_Connect.Text = "Connect";
            this.button_Database_Connect.UseVisualStyleBackColor = true;
            this.button_Database_Connect.Click += new System.EventHandler(this.Button_Database_Connect_Click);
            // 
            // tabPage_Database_CreateScript
            // 
            this.tabPage_Database_CreateScript.Controls.Add(this.panel_CreateScript_DragAndDrop);
            this.tabPage_Database_CreateScript.Controls.Add(this.button_CreateScript);
            this.tabPage_Database_CreateScript.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Database_CreateScript.Name = "tabPage_Database_CreateScript";
            this.tabPage_Database_CreateScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Database_CreateScript.Size = new System.Drawing.Size(588, 431);
            this.tabPage_Database_CreateScript.TabIndex = 1;
            this.tabPage_Database_CreateScript.Text = "Create Script";
            this.tabPage_Database_CreateScript.UseVisualStyleBackColor = true;
            // 
            // panel_CreateScript_DragAndDrop
            // 
            this.panel_CreateScript_DragAndDrop.AllowDrop = true;
            this.panel_CreateScript_DragAndDrop.BackColor = System.Drawing.Color.Transparent;
            this.panel_CreateScript_DragAndDrop.BackgroundImage = global::Service.Properties.Resources.DragAndDrop;
            this.panel_CreateScript_DragAndDrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_CreateScript_DragAndDrop.Location = new System.Drawing.Point(18, 22);
            this.panel_CreateScript_DragAndDrop.Name = "panel_CreateScript_DragAndDrop";
            this.panel_CreateScript_DragAndDrop.Size = new System.Drawing.Size(547, 346);
            this.panel_CreateScript_DragAndDrop.TabIndex = 4;
            this.panel_CreateScript_DragAndDrop.Click += new System.EventHandler(this.Panel_CreateScript_DragAndDrop_Click);
            this.panel_CreateScript_DragAndDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_CreateScript_DragAndDrop_DragDrop);
            this.panel_CreateScript_DragAndDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_CreateScript_DragAndDrop_DragEnter);
            this.panel_CreateScript_DragAndDrop.DragLeave += new System.EventHandler(this.Panel_CreateScript_DragAndDrop_DragLeave);
            // 
            // button_CreateScript
            // 
            this.button_CreateScript.Enabled = false;
            this.button_CreateScript.Location = new System.Drawing.Point(4, 391);
            this.button_CreateScript.Name = "button_CreateScript";
            this.button_CreateScript.Size = new System.Drawing.Size(581, 34);
            this.button_CreateScript.TabIndex = 2;
            this.button_CreateScript.Text = "Create tables";
            this.button_CreateScript.UseVisualStyleBackColor = true;
            this.button_CreateScript.Click += new System.EventHandler(this.Button_CreateScript_Click);
            // 
            // tabPage_Database_InsertScript
            // 
            this.tabPage_Database_InsertScript.Controls.Add(this.panel_InsertScript_DragAndDrop);
            this.tabPage_Database_InsertScript.Controls.Add(this.button_InsertScript);
            this.tabPage_Database_InsertScript.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Database_InsertScript.Name = "tabPage_Database_InsertScript";
            this.tabPage_Database_InsertScript.Size = new System.Drawing.Size(588, 431);
            this.tabPage_Database_InsertScript.TabIndex = 2;
            this.tabPage_Database_InsertScript.Text = "Insert Script";
            this.tabPage_Database_InsertScript.UseVisualStyleBackColor = true;
            // 
            // panel_InsertScript_DragAndDrop
            // 
            this.panel_InsertScript_DragAndDrop.AllowDrop = true;
            this.panel_InsertScript_DragAndDrop.BackgroundImage = global::Service.Properties.Resources.DragAndDrop;
            this.panel_InsertScript_DragAndDrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_InsertScript_DragAndDrop.Location = new System.Drawing.Point(18, 22);
            this.panel_InsertScript_DragAndDrop.Name = "panel_InsertScript_DragAndDrop";
            this.panel_InsertScript_DragAndDrop.Size = new System.Drawing.Size(547, 346);
            this.panel_InsertScript_DragAndDrop.TabIndex = 5;
            this.panel_InsertScript_DragAndDrop.Click += new System.EventHandler(this.Panel_InsertScript_DragAndDrop_Click);
            this.panel_InsertScript_DragAndDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_InsertScript_DragAndDrop_DragDrop);
            this.panel_InsertScript_DragAndDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_InsertScript_DragAndDrop_DragEnter);
            this.panel_InsertScript_DragAndDrop.DragLeave += new System.EventHandler(this.Panel_InsertScript_DragAndDrop_DragLeave);
            // 
            // button_InsertScript
            // 
            this.button_InsertScript.Enabled = false;
            this.button_InsertScript.Location = new System.Drawing.Point(4, 391);
            this.button_InsertScript.Name = "button_InsertScript";
            this.button_InsertScript.Size = new System.Drawing.Size(581, 34);
            this.button_InsertScript.TabIndex = 2;
            this.button_InsertScript.Text = "Insert rows";
            this.button_InsertScript.UseVisualStyleBackColor = true;
            this.button_InsertScript.Click += new System.EventHandler(this.Button_InsertScript_Click);
            // 
            // tabPage_Database_DropScript
            // 
            this.tabPage_Database_DropScript.Controls.Add(this.panel_DropScript_DragAndDrop);
            this.tabPage_Database_DropScript.Controls.Add(this.button_DropScript);
            this.tabPage_Database_DropScript.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Database_DropScript.Name = "tabPage_Database_DropScript";
            this.tabPage_Database_DropScript.Size = new System.Drawing.Size(588, 431);
            this.tabPage_Database_DropScript.TabIndex = 3;
            this.tabPage_Database_DropScript.Text = "Drop Script";
            this.tabPage_Database_DropScript.UseVisualStyleBackColor = true;
            // 
            // panel_DropScript_DragAndDrop
            // 
            this.panel_DropScript_DragAndDrop.AllowDrop = true;
            this.panel_DropScript_DragAndDrop.BackgroundImage = global::Service.Properties.Resources.DragAndDrop;
            this.panel_DropScript_DragAndDrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_DropScript_DragAndDrop.Location = new System.Drawing.Point(18, 22);
            this.panel_DropScript_DragAndDrop.Name = "panel_DropScript_DragAndDrop";
            this.panel_DropScript_DragAndDrop.Size = new System.Drawing.Size(547, 346);
            this.panel_DropScript_DragAndDrop.TabIndex = 5;
            this.panel_DropScript_DragAndDrop.Click += new System.EventHandler(this.Panel_DropScript_DragAndDrop_Click);
            this.panel_DropScript_DragAndDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DropScript_DragAndDrop_DragDrop);
            this.panel_DropScript_DragAndDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DropScript_DragAndDrop_DragEnter);
            this.panel_DropScript_DragAndDrop.DragLeave += new System.EventHandler(this.Panel_DropScript_DragAndDrop_DragLeave);
            // 
            // button_DropScript
            // 
            this.button_DropScript.Enabled = false;
            this.button_DropScript.Location = new System.Drawing.Point(4, 391);
            this.button_DropScript.Name = "button_DropScript";
            this.button_DropScript.Size = new System.Drawing.Size(581, 34);
            this.button_DropScript.TabIndex = 2;
            this.button_DropScript.Text = "Delete tables";
            this.button_DropScript.UseVisualStyleBackColor = true;
            this.button_DropScript.Click += new System.EventHandler(this.Button_DropScript_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_Scenarios);
            this.tabControl.Controls.Add(this.tabPage_Editor);
            this.tabControl.Controls.Add(this.tabPage_Language);
            this.tabControl.Controls.Add(this.tabPage_Database);
            this.tabControl.Controls.Add(this.tabPage_Export);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(40, 10);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(605, 500);
            this.tabControl.TabIndex = 0;
            // 
            // backgroundWorker_Connection
            // 
            this.backgroundWorker_Connection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DatabaseConnection_Run);
            this.backgroundWorker_Connection.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DatabaseConnection_Completed);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Orange;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 500);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(605, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel.Text = "Connecting...";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 522);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Service";
            this.tabPage_Export.ResumeLayout(false);
            this.tabPage_Export.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_Language.ResumeLayout(false);
            this.tabPage_Language.PerformLayout();
            this.tabPage_Editor.ResumeLayout(false);
            this.tabControl_Editor.ResumeLayout(false);
            this.tabPage_Scenarios.ResumeLayout(false);
            this.tabControl_Scenarios.ResumeLayout(false);
            this.tabPage_Database.ResumeLayout(false);
            this.tabControl_Database.ResumeLayout(false);
            this.tabPage_Database_Connection.ResumeLayout(false);
            this.tabPage_Database_Connection.PerformLayout();
            this.groupBox_Connection.ResumeLayout(false);
            this.groupBox_Connection.PerformLayout();
            this.tabPage_Database_CreateScript.ResumeLayout(false);
            this.tabPage_Database_InsertScript.ResumeLayout(false);
            this.tabPage_Database_DropScript.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.ComboBox comboBox_Export_ExportLanguage;
        private System.Windows.Forms.Label label_Export_ExportLanguage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Export_Operations;
        private System.Windows.Forms.Label label_Export_CheckPoints;
        private System.Windows.Forms.Label label_Export_Sections;
        private System.Windows.Forms.TextBox textBox_Export_Scenarios;
        private System.Windows.Forms.Label label_Export_Scenarios;
        private System.Windows.Forms.TextBox textBox_Export_Operations;
        private System.Windows.Forms.TextBox textBox_Export_CheckPoints;
        private System.Windows.Forms.TextBox textBox_Export_Sections;
        private System.Windows.Forms.Button button_Database_Connect;
        private System.Windows.Forms.ComboBox comboBox_Connection_PreferedServer;
        private System.Windows.Forms.Label label_Connection_PreferedServer;
        private System.Windows.Forms.GroupBox groupBox_Connection;
        private System.Windows.Forms.TextBox textBox_Connection_Password;
        private System.Windows.Forms.TextBox textBox_Connection_Username;
        private System.Windows.Forms.TextBox textBox_Connection_DatabaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Connection_ServerAddress;
        private System.Windows.Forms.Label label_Connection_ServerAddress;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_CreateScript;
        private System.Windows.Forms.Button button_InsertScript;
        private System.Windows.Forms.Button button_DropScript;
        private System.Windows.Forms.Panel panel_CreateScript_DragAndDrop;
        private System.Windows.Forms.Panel panel_InsertScript_DragAndDrop;
        private System.Windows.Forms.Panel panel_DropScript_DragAndDrop;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

