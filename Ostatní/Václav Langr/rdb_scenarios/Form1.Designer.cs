namespace rdb_scenarios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dbFillButton = new System.Windows.Forms.Button();
            this.dbCreateButton = new System.Windows.Forms.Button();
            this.dbDeleteButton = new System.Windows.Forms.Button();
            this.dbConnectButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.dbNameBox = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ipAddressBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.scenarioLanguage = new System.Windows.Forms.TextBox();
            this.generate = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dbFillButton);
            this.panel1.Controls.Add(this.dbCreateButton);
            this.panel1.Controls.Add(this.dbDeleteButton);
            this.panel1.Controls.Add(this.dbConnectButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.dbNameBox);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.ipAddressBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 105);
            this.panel1.TabIndex = 0;
            // 
            // dbFillButton
            // 
            this.dbFillButton.Enabled = false;
            this.dbFillButton.Location = new System.Drawing.Point(165, 79);
            this.dbFillButton.Name = "dbFillButton";
            this.dbFillButton.Size = new System.Drawing.Size(75, 23);
            this.dbFillButton.TabIndex = 10;
            this.dbFillButton.Text = "Fill DB";
            this.dbFillButton.UseVisualStyleBackColor = true;
            this.dbFillButton.Click += new System.EventHandler(this.dbFillButton_Click);
            // 
            // dbCreateButton
            // 
            this.dbCreateButton.Enabled = false;
            this.dbCreateButton.Location = new System.Drawing.Point(84, 79);
            this.dbCreateButton.Name = "dbCreateButton";
            this.dbCreateButton.Size = new System.Drawing.Size(75, 23);
            this.dbCreateButton.TabIndex = 9;
            this.dbCreateButton.Text = "Create DB";
            this.dbCreateButton.UseVisualStyleBackColor = true;
            this.dbCreateButton.Click += new System.EventHandler(this.dbCreateButton_Click);
            // 
            // dbDeleteButton
            // 
            this.dbDeleteButton.Enabled = false;
            this.dbDeleteButton.Location = new System.Drawing.Point(3, 79);
            this.dbDeleteButton.Name = "dbDeleteButton";
            this.dbDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.dbDeleteButton.TabIndex = 8;
            this.dbDeleteButton.Text = "Delete DB";
            this.dbDeleteButton.UseVisualStyleBackColor = true;
            this.dbDeleteButton.Click += new System.EventHandler(this.dbDeleteButton_Click);
            // 
            // dbConnectButton
            // 
            this.dbConnectButton.Location = new System.Drawing.Point(224, 51);
            this.dbConnectButton.Name = "dbConnectButton";
            this.dbConnectButton.Size = new System.Drawing.Size(189, 23);
            this.dbConnectButton.TabIndex = 7;
            this.dbConnectButton.Text = "Připojit";
            this.dbConnectButton.UseVisualStyleBackColor = true;
            this.dbConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.passwordBox);
            this.panel2.Controls.Add(this.userNameBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 50);
            this.panel2.TabIndex = 6;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(54, 26);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(135, 20);
            this.passwordBox.TabIndex = 3;
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(54, 0);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(135, 20);
            this.userNameBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Heslo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Jméno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP adresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jméno DB";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(106, 1);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(93, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Jméno + heslo";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // dbNameBox
            // 
            this.dbNameBox.Location = new System.Drawing.Point(279, 28);
            this.dbNameBox.Name = "dbNameBox";
            this.dbNameBox.Size = new System.Drawing.Size(134, 20);
            this.dbNameBox.TabIndex = 3;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(93, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "Windows auth";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ipAddressBox
            // 
            this.ipAddressBox.Location = new System.Drawing.Point(279, 2);
            this.ipAddressBox.Name = "ipAddressBox";
            this.ipAddressBox.Size = new System.Drawing.Size(134, 20);
            this.ipAddressBox.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(440, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // scenarioLanguage
            // 
            this.scenarioLanguage.Location = new System.Drawing.Point(106, 3);
            this.scenarioLanguage.Name = "scenarioLanguage";
            this.scenarioLanguage.Size = new System.Drawing.Size(100, 20);
            this.scenarioLanguage.TabIndex = 2;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(212, 1);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 23);
            this.generate.TabIndex = 3;
            this.generate.Text = "Generovat";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.scenarioLanguage);
            this.panel3.Controls.Add(this.generate);
            this.panel3.Location = new System.Drawing.Point(12, 360);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(417, 29);
            this.panel3.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 414);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dbNameBox;
        private System.Windows.Forms.TextBox ipAddressBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button dbConnectButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button dbFillButton;
        private System.Windows.Forms.Button dbCreateButton;
        private System.Windows.Forms.Button dbDeleteButton;
        private System.Windows.Forms.TextBox scenarioLanguage;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Panel panel3;
    }
}

