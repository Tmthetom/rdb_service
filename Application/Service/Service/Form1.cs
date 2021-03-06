﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Service
{
    public partial class Form1 : Form
    {
        private Database_Operation.Connection myConnection;

        #region Initialization
        /// <summary>
        /// Loading of form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ControlsDisable();  // Disable all controls, except of database connection
            DatabaseConnection_Init();  // Try to connect into database
        }

        /// <summary>
        /// Initialize form when connection success
        /// </summary>
        private void Form_Initialize()
        {
            // Load languages
            Language_Init();

            // If no language selected, there are no tables or rows
            if (selectedLanguage.Text != "")
            {
                Scenarios_Init();
                Editor_Init();
                Export_Init();
                Database_Log_Init();
            }
        }

        /// <summary>
        /// Clear form when connection lost
        /// </summary>
        private void Form_Clear()
        {
            Language_Clear();
            Scenarios_Clear();
            Editor_Clear();
            Export_Clear();
            Database_Log_Clear();
        }
        #endregion Initialization

        #region Database

        #region Database_Connection
        /// <summary>
        /// Initialize database connection
        /// </summary>
        private void DatabaseConnection_Init()
        {
             // Select first item
            comboBox_Connection_PreferedServer.SelectedIndex = 0;

            // Run initial connection
            backgroundWorker_Connection.RunWorkerAsync();
        }

        /// <summary>
        /// Manual connect to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Database_Connect_Click(object sender, EventArgs e)
        {
            // Toolstrip information
            statusStrip.BackColor = Color.Orange;
            toolStripStatusLabel.ForeColor = SystemColors.ControlText;
            toolStripStatusLabel.Text = "Connecting...";

            // Try to connect
            if (!backgroundWorker_Connection.IsBusy)
            {
                backgroundWorker_Connection.RunWorkerAsync();
            }
            else
            {
                Message("Please wait for current connecting to finish...");
            }
        }

        /// <summary>
        /// Connect to database with provided informations in different thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseConnection_Run(object sender, DoWorkEventArgs e)
        {
            try
            {
                string serverAddress = textBox_Connection_ServerAddress.Text;
                string databaseName = textBox_Connection_DatabaseName.Text;
                string username = textBox_Connection_Username.Text;
                string password = textBox_Connection_Password.Text;

                // Connection without credentials
                if (username == "")
                {
                    myConnection = new Database_Operation.Connection(serverAddress, databaseName);
                }

                // Connection with credentials
                else
                {
                    myConnection = new Database_Operation.Connection(serverAddress, databaseName, username, password);
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("Login failed"))  // Not login problem
                {
                    MessageBox.Show(exception.Message);
                }
                myConnection = null;
            }
        }

        /// <summary>
        /// When database connection completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseConnection_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (DatabaseConnection_Check())  // If connection success
            {
                if (Database_Operation.Get.NumberOfTables(myConnection) > 0)  // Check if tables are here
                {
                    Form_Initialize();  // Initialize form
                }
                else
                {
                    Form_Clear();  // Clear form
                    Message("Database is empty");
                }
            }
        }

        /// <summary>
        /// Check database connection failed or success
        /// </summary>
        private bool DatabaseConnection_Check()
        {
            // Connection failed
            if (myConnection == null)
            {
                // Toolstrip information
                statusStrip.BackColor = Color.DarkRed;
                toolStripStatusLabel.ForeColor = Color.White;
                toolStripStatusLabel.Text = "Connection failed";

                // Controls lock
                ControlsDisable();
                return false;
            }

            // Connection success
            else
            {
                // Toolstrip information
                statusStrip.BackColor = Color.YellowGreen;
                toolStripStatusLabel.ForeColor = SystemColors.ControlText;
                toolStripStatusLabel.Text = "Connected to " + myConnection.GetDatabaseName() + " at " + myConnection.GetServerAddress();

                // Controls lock
                ControlsEnable();
                return true;
            }
        }

        /// <summary>
        /// Database connection selected server changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Connection_PreferedServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string preferedServer = comboBox_Connection_PreferedServer.Text;

            if (preferedServer == "Technical University of Liberec")
            {
                textBox_Connection_ServerAddress.Text = "147.230.21.34";
                textBox_Connection_DatabaseName.Text = "RDB_Moravec";
                textBox_Connection_Username.Text = "student";
                textBox_Connection_Password.Text = "student";
            }
            else if (preferedServer == "Local - Tomas Moravec")
            {
                textBox_Connection_ServerAddress.Text = "TOMASMORAVEC-PC\\SQLEXPRESS";
                textBox_Connection_DatabaseName.Text = "Autoservis";
                textBox_Connection_Username.Text = "";
                textBox_Connection_Password.Text = "";
            }
            else
            {
                textBox_Connection_ServerAddress.Text = "";
                textBox_Connection_DatabaseName.Text = "";
                textBox_Connection_Username.Text = "";
                textBox_Connection_Password.Text = "";
            }
        }
        #endregion Database_Connection

        #region Log Table
        /// <summary>
        /// Initialize tab
        /// </summary>
        private void Database_Log_Init()
        {
            try
            {
                // Clear old table
                Database_Log_Clear();

                // Get all logs objects
                List<Database_Objects.Log> logs = Database_Operation.Get.Logs(myConnection);

                // Sort list descending
                int newID = Int32.MaxValue;
                SortedList<int, Database_Objects.Log> logs_sorted = new SortedList<int, Database_Objects.Log>();
                foreach (Database_Objects.Log log in logs)
                {
                    logs_sorted.Add(newID, log);
                    newID--;
                }

                // Add them into table (sorted by ID)
                foreach (Database_Objects.Log log in logs_sorted.Values)
                {
                    dataGridView_Database_Log.Rows.Add(log.timeDate, log.tableName, log.operation, log.userName);
                }
            }
            catch
            {
                ;
            }
        }

        /// <summary>
        /// Clear tab
        /// </summary>
        private void Database_Log_Clear()
        {
            dataGridView_Database_Log.Rows.Clear();
        }
        #endregion

        #region Do Scripts
        /// <summary>
        /// When panel clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_DragAndDrop_Click(object sender, EventArgs e)
        {
            // Show file dialog
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Color panel
                Panel panel = sender as Panel;
                if (panel.Name == "panel_CreateScript_DragAndDrop")
                {
                    panel = panel_CreateScript_DragAndDrop;
                }
                else if (panel.Name == "panel_InsertScript_DragAndDrop")
                {
                    panel = panel_InsertScript_DragAndDrop;
                }
                else
                {
                    panel = panel_DropScript_DragAndDrop;
                }
                panel.BackColor = Color.GreenYellow;

                Button button;
                if (panel.Name == "panel_CreateScript_DragAndDrop")
                {
                    button = button_CreateScript;
                }
                else if (panel.Name == "panel_InsertScript_DragAndDrop")
                {
                    button = button_InsertScript;
                }
                else
                {
                    button = button_DropScript;
                }
                button.Enabled = true;
            }
        }

        /// <summary>
        /// When file enter panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_DragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            // Enable DragAndDrop
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;

            // Color panel
            Panel panel = sender as Panel;
            if (panel.Name == "panel_CreateScript_DragAndDrop")
            {
                panel = panel_CreateScript_DragAndDrop;
            }
            else if (panel.Name == "panel_InsertScript_DragAndDrop")
            {
                panel = panel_InsertScript_DragAndDrop;
            }
            else
            {
                panel = panel_DropScript_DragAndDrop;
            }
            panel.BackColor = Color.GreenYellow;
        }


        /// <summary>
        /// When file leave panel without drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_DragAndDrop_DragLeave(object sender, EventArgs e)
        {
            // Reset panel
            Panel panel = sender as Panel;
            if (panel.Name == "panel_CreateScript_DragAndDrop")
            {
                panel = panel_CreateScript_DragAndDrop;
            }
            else if (panel.Name == "panel_InsertScript_DragAndDrop")
            {
                panel = panel_InsertScript_DragAndDrop;
            }
            else
            {
                panel = panel_DropScript_DragAndDrop;
            }
            panel.BackColor = Color.Transparent;
        }

        /// <summary>
        /// When file drop into panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_DragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            // Save file path
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            openFileDialog.FileName = filePaths[0];

            // Enable button
            Panel panel = sender as Panel;
            Button button;
            if (panel.Name == "panel_CreateScript_DragAndDrop")
            {
                button = button_CreateScript;
            }
            else if (panel.Name == "panel_InsertScript_DragAndDrop")
            {
                button = button_InsertScript;
            }
            else
            {
                button = button_DropScript;
            }
            button.Enabled = true;
        }
        
        /// <summary>
        /// When do script button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_Button_Click(object sender, EventArgs e)
        {
            // Reset button
            Button button = sender as Button;
            button.Enabled = false;

            // Reset panel
            Panel panel;
            if (button.Name == "button_CreateScript")
            {
                panel = panel_CreateScript_DragAndDrop;
            }
            else if (button.Name == "button_InsertScript")
            {
                panel = panel_InsertScript_DragAndDrop;
            }
            else
            {
                panel = panel_DropScript_DragAndDrop;
            }
            panel.BackColor = Color.Transparent;

            // Do script
            try
            {
                Database_Operation.RunScript.FromFile(openFileDialog, myConnection);

                if (button.Name == "button_InsertScript")
                {
                    Form_Initialize();
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }
        #endregion Do Scripts

        #region FormControls

        /// <summary>
        /// Enable all controls, except of database connection
        /// </summary>
        private void ControlsEnable()
        {
            // Main tabs
            tabPage_Scenarios.Enabled = true;  // Scenarios
            tabPage_Editor.Enabled = true;  // Editor
            tabPage_Language.Enabled = true;  // Language
            tabPage_Export.Enabled = true;  // Export

            // Database tabs
            tabPage_Database_CreateScript.Enabled = true;  // Create script
            tabPage_Database_InsertScript.Enabled = true;  // Insert script
            tabPage_Database_DropScript.Enabled = true;  // Drop script
        }

        /// <summary>
        /// Disable all control. except of database connection
        /// </summary>
        private void ControlsDisable()
        {
            tabPage_Scenarios.Enabled = false;  // Scenarios
            tabPage_Editor.Enabled = false;  // Editor
            tabPage_Language.Enabled = false;  // Language
            tabPage_Export.Enabled = false;  // Export

            // Database tabs
            tabPage_Database_CreateScript.Enabled = false;  // Create script
            tabPage_Database_InsertScript.Enabled = false;  // Insert script
            tabPage_Database_DropScript.Enabled = false;  // Drop script

        }

        #endregion FormControls

        #endregion Database

        #region Scenarios

        #region Init
        /// <summary>
        /// Initialize scenarios tab
        /// </summary>
        private void Scenarios_Init()
        {
            Scenarios_Scenario_Init();
            Scenarios_CheckPoint_Init();
        }

        /// <summary>
        /// Clear scenarios tab
        /// </summary>
        private void Scenarios_Clear()
        {
            Scenarios_Scenario_Clear();
            Scenarios_CheckPoint_Clear();
        }
        #endregion Init

        #region Scenario - Section - CheckPoint
        /// <summary>
        /// Initialize tab
        /// </summary>
        private void Scenarios_Scenario_Init()
        {
            Scenarios_Scenario_Clear();
            Scenarios_Scenario_LoadTables();
            DataGridView_Scenarios_Scenario_SelectionChanged(this, new EventArgs());
            Database_Log_Init();
        }

        /// <summary>
        /// Clear tab
        /// </summary>
        private void Scenarios_Scenario_Clear()
        {
            dataGridView_Scenarios_Scenario_Scenarios.Rows.Clear();
            dataGridView_Scenarios_Scenario_Sections.Rows.Clear();
            dataGridView_Scenarios_Scenario_CheckPoints.Rows.Clear();
            treeView_Scenarios_Scenario.Nodes.Clear();
        }

        /// <summary>
        /// Table load in tab
        /// </summary>
        private void Scenarios_Scenario_LoadTables()
        {
            Scenarios_Scenario_LoadParents();
            Scenarios_Scenario_LoadChilds();
            Scenarios_Scenario_LoadChildsOfChild();
            Scenarios_Scenario_LoadTree();
        }

        /// <summary>
        /// Load parent tables
        /// </summary>
        private void Scenarios_Scenario_LoadParents()
        {
            // Get objects
            List<Database_Objects.Scenario_Translation> objects = Database_Operation.Get.Scenarios(selectedLanguage.Text, myConnection);

            // Add new objects
            foreach (Database_Objects.Scenario_Translation o in objects)
            {
                dataGridView_Scenarios_Scenario_Scenarios.Rows.Add(o.id_Scenario, o.name);
            }
        }

        /// <summary>
        /// Load selected parent childs table
        /// </summary>
        private void Scenarios_Scenario_LoadChilds()
        {
            // Get objects
            List<Database_Objects.Section_Translation> objects = Database_Operation.Get.Sections(selectedLanguage.Text, myConnection);

            // Add new objects
            foreach (Database_Objects.Section_Translation o in objects)
            {
                dataGridView_Scenarios_Scenario_Sections.Rows.Add(o.id_Section, o.name);
            }
        }

        /// <summary>
        /// Load selected parent childs of selected child
        /// </summary>
        private void Scenarios_Scenario_LoadChildsOfChild()
        {
            // Get objects
            List<Database_Objects.CheckPoint_Translation> objects = Database_Operation.Get.CheckPoints(selectedLanguage.Text, myConnection);

            // Add new objects
            foreach (Database_Objects.CheckPoint_Translation o in objects)
            {
                dataGridView_Scenarios_Scenario_CheckPoints.Rows.Add(o.id_CheckPoint, o.name);
            }
        }

        /// <summary>
        /// Load treeView
        /// </summary>
        private void Scenarios_Scenario_LoadTree()
        {
            // Get objects
            List<Database_Objects.Scenario_Translation> scenarios = Database_Operation.Get.Scenarios(selectedLanguage.Text, myConnection);
            List<Database_Objects.Section_Translation> sections = Database_Operation.Get.Sections(selectedLanguage.Text, myConnection);
            List<Database_Objects.CheckPoint_Translation> checkPoints = Database_Operation.Get.CheckPoints(selectedLanguage.Text, myConnection);
            List<Database_Objects.Scenarios_Sections> connections = Database_Operation.Get.Scenarios_Sections(myConnection);

            // Collect all ids
            List<int> id_Scenarios = new List<int>();
            List<int> id_Sections = new List<int>();
            foreach (Database_Objects.Scenarios_Sections connection in connections)
            {
                // Scenario ids
                int current_ScenarioID = connection.GetId_Scenario();
                if (!id_Scenarios.Contains(current_ScenarioID))
                {
                    id_Scenarios.Add(current_ScenarioID);
                }

                // Sections ids
                int current_SectionID = connection.GetId_Section();
                if (!id_Sections.Contains(current_SectionID))
                {
                    id_Sections.Add(current_SectionID);
                }
            }

            // ---------- 1. For all scenarios ----------
            foreach (Database_Objects.Scenario_Translation scenario in scenarios)
            {
                // If scenario have connections
                if (id_Scenarios.Contains(scenario.id_Scenario))
                {
                    // ---------- 2. Find all scenario - sections ----------
                    // SortedDictionary<orderNumber, KeyValuePair<sectionName, List<checkPoints>>>
                    SortedDictionary<int, KeyValuePair<string, List<string>>> scenario_Sections = new SortedDictionary<int, KeyValuePair<string, List<string>>>();  // Array of sections (with order)
                    foreach (Database_Objects.Scenarios_Sections connection in connections)
                    {
                        // If connection found (same scenario)
                        if (scenario.id_Scenario == connection.GetId_Scenario())
                        {
                            // Find sections name
                            string sectionName = "NAME NOT FOUNDED";
                            foreach (Database_Objects.Section_Translation section in sections)
                            {
                                if (connection.GetId_Section() == section.id_Section)
                                {
                                    sectionName = section.name;
                                    break;
                                }
                            }

                            // If new section (new orderNumber), add as new
                            if (!scenario_Sections.Keys.ToList().Contains(connection.GetOrder_Number()))
                            {
                                List<string> currentCheckPoints = new List<string>();
                                KeyValuePair<string, List<string>> currentSection = new KeyValuePair<string, List<string>>(sectionName, currentCheckPoints);
                                scenario_Sections.Add(connection.GetOrder_Number(), currentSection);

                                // ---------- 3. Find all section - checkPoints ----------
                                List<string> section_CheckPoints = new List<string>();  // Array of sections (no order)
                                foreach (Database_Objects.Scenarios_Sections conn in connections)
                                {
                                    // If connection found (Same scenario, section and orderNumber)
                                    if (scenario.id_Scenario == conn.GetId_Scenario() && connection.GetId_Section() == conn.GetId_Section() && connection.GetOrder_Number() == conn.GetOrder_Number())
                                    {
                                        // Find checkPoint name
                                        string checkPointName = "NAME NOT FOUNDED";
                                        foreach (Database_Objects.CheckPoint_Translation checkPoint in checkPoints)
                                        {
                                            if (conn.GetId_CheckPoint() == checkPoint.id_CheckPoint)
                                            {
                                                checkPointName = checkPoint.name;
                                                break;
                                            }
                                        }
                                        currentCheckPoints.Add(checkPointName);
                                    }
                                }
                            }
                        }
                    }

                    // Build sections
                    TreeNode[] sectionNodes = new TreeNode[scenario_Sections.Keys.Count];
                    for (int i = 0; i < sectionNodes.Length; i++)
                    {
                        // Build checkPoints
                        KeyValuePair<string, List<string>> currentSection = scenario_Sections.Values.ElementAt(i);
                        List<string> currentCheckPoints = currentSection.Value;
                        TreeNode[] checkPointsNodes = new TreeNode[currentCheckPoints.Count];
                        for (int j = 0; j < checkPointsNodes.Length; j++)
                        {
                            checkPointsNodes[j] = new TreeNode(currentCheckPoints[j]);
                        }

                        // Connect section and checkPoints
                        sectionNodes[i] = new TreeNode(currentSection.Key, checkPointsNodes);
                    }

                    // Connect scenario and section
                    TreeNode scenarioNode = new TreeNode(scenario.name, sectionNodes);

                    // Show them
                    treeView_Scenarios_Scenario.Nodes.Add(scenarioNode);
                }
            }
            treeView_Scenarios_Scenario.ExpandAll();
        }

        /// <summary>
        /// Delete selected child from selected parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Scenarios_Scenario_Delete_Click(object sender, EventArgs e)
        {
            // Get selected items rows
            int selectedRow_Scenario = dataGridView_Scenarios_Scenario_Scenarios.CurrentCell.RowIndex;
            int selectedRow_Section = dataGridView_Scenarios_Scenario_Sections.CurrentCell.RowIndex;
            int selectedRow_CheckPoint = dataGridView_Scenarios_Scenario_CheckPoints.CurrentCell.RowIndex;

            // Get selected items IDs
            int selectedScenarioID = (Int32)dataGridView_Scenarios_Scenario_Scenarios.Rows[selectedRow_Scenario].Cells[0].Value;
            int selectedSectionID = (Int32)dataGridView_Scenarios_Scenario_Sections.Rows[selectedRow_Section].Cells[0].Value;
            int selectedCheckPointID = (Int32)dataGridView_Scenarios_Scenario_CheckPoints.Rows[selectedRow_CheckPoint].Cells[0].Value;

            // Delete selected
            List<Database_Objects.Scenarios_Sections> connections = Database_Operation.Get.Scenarios_Sections(myConnection);
            foreach (Database_Objects.Scenarios_Sections o in connections)
            {
                // If row is what we want to delete
                if (o.GetId_Scenario() == selectedScenarioID && o.GetId_Section() == selectedSectionID && o.GetId_CheckPoint() == selectedCheckPointID)
                {
                    // Delete row
                    Database_Operation.Delete.Scenarios_Sections(selectedScenarioID, selectedSectionID, selectedCheckPointID, o.GetOrder_Number(), myConnection);
                }
            }

            // Refresh form
            Scenarios_Scenario_Init();
        }

        /// <summary>
        /// Add selected child into selected parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Scenarios_Scenario_Add_Click(object sender, EventArgs e)
        {
            // Get selected items rows
            int selectedRow_Scenario = dataGridView_Scenarios_Scenario_Scenarios.CurrentCell.RowIndex;
            int selectedRow_Section = dataGridView_Scenarios_Scenario_Sections.CurrentCell.RowIndex;
            int selectedRow_CheckPoint = dataGridView_Scenarios_Scenario_CheckPoints.CurrentCell.RowIndex;

            // Get selected items IDs
            int selectedScenarioID = (Int32)dataGridView_Scenarios_Scenario_Scenarios.Rows[selectedRow_Scenario].Cells[0].Value;
            int selectedSectionID = (Int32)dataGridView_Scenarios_Scenario_Sections.Rows[selectedRow_Section].Cells[0].Value;
            int selectedCheckPointID = (Int32)dataGridView_Scenarios_Scenario_CheckPoints.Rows[selectedRow_CheckPoint].Cells[0].Value;

            // Find biggest orderNumber in scenario
            int biggestScenarioOrderNumber = 0;
            List<Database_Objects.Scenarios_Sections> connections = Database_Operation.Get.Scenarios_Sections(myConnection);
            foreach (Database_Objects.Scenarios_Sections o in connections)
            {
                if (o.GetId_Scenario() == selectedScenarioID && o.GetOrder_Number() > biggestScenarioOrderNumber)
                {
                    biggestScenarioOrderNumber = o.GetOrder_Number();
                }
            }

            // Find new orderNumber
            int newOrderNumber = 0;
            foreach (Database_Objects.Scenarios_Sections o in connections)
            {
                // Last section (biggest order number)
                if (o.GetId_Scenario() == selectedScenarioID && o.GetOrder_Number() == biggestScenarioOrderNumber)
                {
                    // If this section is as new one
                    if (o.GetId_Section() == selectedSectionID)
                    {
                        // Order number will be the same
                        newOrderNumber = o.GetOrder_Number();
                    }

                    // If its different section
                    else
                    {
                        // We must add new section for this checkPoint
                        newOrderNumber = o.GetOrder_Number() + 1;
                    }
                }
            }
            
            // Add selected
            Database_Operation.Insert.Scenarios_Sections(selectedScenarioID, selectedSectionID, selectedCheckPointID, newOrderNumber, myConnection);

            // Refresh form
            Scenarios_Scenario_Init();
        }

        /// <summary>
        /// When tables selection changed, check what is possible (delete, insert)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Scenarios_Scenario_SelectionChanged(object sender, EventArgs e)
        {
            // Get selected items rows
            int selectedRow_Scenario;
            int selectedRow_Section;
            int selectedRow_CheckPoint;

            // Try to load data
            try
            {
                selectedRow_Scenario = dataGridView_Scenarios_Scenario_Scenarios.CurrentCell.RowIndex;
                selectedRow_Section = dataGridView_Scenarios_Scenario_Sections.CurrentCell.RowIndex;
                selectedRow_CheckPoint = dataGridView_Scenarios_Scenario_CheckPoints.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }

            // Get selected items IDs
            int selectedScenarioID = (Int32)dataGridView_Scenarios_Scenario_Scenarios.Rows[selectedRow_Scenario].Cells[0].Value;
            int selectedSectionID = (Int32)dataGridView_Scenarios_Scenario_Sections.Rows[selectedRow_Section].Cells[0].Value;
            int selectedCheckPointID = (Int32)dataGridView_Scenarios_Scenario_CheckPoints.Rows[selectedRow_CheckPoint].Cells[0].Value;

            // Get all connections
            List<Database_Objects.Scenarios_Sections> connections = Database_Operation.Get.Scenarios_Sections(myConnection);

            // Check delete and add button (if can be deleted, cant be added, because its already in)
            bool canBeDeleted = false;
            foreach (Database_Objects.Scenarios_Sections o in connections)
            {
                if (o.GetId_Scenario() == selectedScenarioID && o.GetId_Section() == selectedSectionID && o.GetId_CheckPoint() == selectedCheckPointID)
                {
                    canBeDeleted = true;

                    // Set delete button
                    button_Scenarios_Scenario_Delete.Enabled = true;
                    button_Scenarios_Scenario_Delete.BackColor = Color.LightCoral;

                    // Set add button
                    button_Scenarios_Scenario_Add.Enabled = false;
                    button_Scenarios_Scenario_Add.BackColor = Color.Transparent;
                    break;
                }
            }
            if (!canBeDeleted)
            {
                // Set delete button
                button_Scenarios_Scenario_Delete.Enabled = false;
                button_Scenarios_Scenario_Delete.BackColor = Color.Transparent;

                // Set add button
                button_Scenarios_Scenario_Add.Enabled = true;
                button_Scenarios_Scenario_Add.BackColor = Color.LightGreen;
            }
        }
        #endregion Scenario - Section - CheckPoint

        #region CheckPoint
        /// <summary>
        /// Initialize tab
        /// </summary>
        private void Scenarios_CheckPoint_Init()
        {
            Scenarios_CheckPoint_Clear();
            Scenarios_CheckPoint_LoadTables();
            DataGridView_Scenarios_CheckPoint_SelectionChanged(this, new EventArgs());
            Database_Log_Init();
        }

        /// <summary>
        /// Clear tab
        /// </summary>
        private void Scenarios_CheckPoint_Clear()
        {
            dataGridView_Scenarios_CheckPoint_CheckPoints.Rows.Clear();
            dataGridView_Scenarios_CheckPoint_Operations.Rows.Clear();
            treeView_Scenarios_CheckPoint.Nodes.Clear();
        }

        /// <summary>
        /// Table load in tab
        /// </summary>
        private void Scenarios_CheckPoint_LoadTables()
        {
            Scenarios_CheckPoint_LoadParents();
            Scenarios_CheckPoint_LoadChilds();
            Scenarios_CheckPoint_LoadTree();
        }

        /// <summary>
        /// Load parent tables
        /// </summary>
        private void Scenarios_CheckPoint_LoadParents()
        {
            // Get objects
            List<Database_Objects.CheckPoint_Translation> objects = Database_Operation.Get.CheckPoints(selectedLanguage.Text, myConnection);

            // Add new objects
            foreach (Database_Objects.CheckPoint_Translation o in objects)
            {
                dataGridView_Scenarios_CheckPoint_CheckPoints.Rows.Add(o.id_CheckPoint, o.name);
            }
        }

        /// <summary>
        /// Load selected parent childs table
        /// </summary>
        private void Scenarios_CheckPoint_LoadChilds()
        {
            // Get objects
            List<Database_Objects.Operation_Translation> objects = Database_Operation.Get.Operations(selectedLanguage.Text, myConnection);

            // Add new objects
            foreach (Database_Objects.Operation_Translation o in objects)
            {
                dataGridView_Scenarios_CheckPoint_Operations.Rows.Add(o.id_Operation, o.name);
            }
        }

        /// <summary>
        /// Load treeView
        /// </summary>
        private void Scenarios_CheckPoint_LoadTree()
        {
            // Get objects
            List<Database_Objects.CheckPoint_Translation> checkPoints = Database_Operation.Get.CheckPoints(selectedLanguage.Text, myConnection);
            List<Database_Objects.Operation_Translation> operations = Database_Operation.Get.Operations(selectedLanguage.Text, myConnection);
            List<Database_Objects.CheckPoints_Operations> connections = Database_Operation.Get.CheckPoints_Operations(myConnection);

            // Collect all connected checkPoints
            List<int> id_CheckPoints = new List<int>();
            foreach (Database_Objects.CheckPoints_Operations connection in connections)
            {
                int current_id = connection.GetId_CheckPoint();
                if (!id_CheckPoints.Contains(current_id))
                {
                    id_CheckPoints.Add(current_id);
                }
            }

            // Set operations for checkPoints
            foreach (Database_Objects.CheckPoint_Translation checkPoint in checkPoints)
            {
                // If checkPoint have connections
                if (id_CheckPoints.Contains(checkPoint.id_CheckPoint))
                {
                    // Create new array of his operations
                    SortedDictionary<int, string> checkPoint_Operations = new SortedDictionary<int, string>();

                    // Find all his operations
                    foreach (Database_Objects.CheckPoints_Operations connection in connections)
                    {
                        // If connection found
                        if (checkPoint.id_CheckPoint == connection.GetId_CheckPoint())
                        {
                            // Found operation name
                            string name = "NAME NOT FOUNDED";
                            foreach (Database_Objects.Operation_Translation operation in operations)
                            {
                                if (connection.GetId_Operation() == operation.id_Operation)
                                {
                                    name = operation.name;
                                    break;
                                }
                            }
                            checkPoint_Operations.Add(connection.GetOrder_Number(), name);
                        }
                    }

                    // Show them
                    TreeNode[] operationNodes = new TreeNode[checkPoint_Operations.Count];
                    for (int i = 0; i < operationNodes.Length; i++)
                    {
                        operationNodes[i] = new TreeNode(checkPoint_Operations.Values.ElementAt(i));
                    }
                    TreeNode checkPointNode = new TreeNode(checkPoint.name, operationNodes);
                    treeView_Scenarios_CheckPoint.Nodes.Add(checkPointNode);
                }
            }
            treeView_Scenarios_CheckPoint.ExpandAll();
        }

        /// <summary>
        /// Delete selected child from selected parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Scenarios_CheckPoint_Delete_Click(object sender, EventArgs e)
        {
            // Get selected items IDs
            int selectedRow_CheckPoint = dataGridView_Scenarios_CheckPoint_CheckPoints.CurrentCell.RowIndex;
            int selectedRow_Operation = dataGridView_Scenarios_CheckPoint_Operations.CurrentCell.RowIndex;
            int selectedCheckpointID = (Int32)dataGridView_Scenarios_CheckPoint_CheckPoints.Rows[selectedRow_CheckPoint].Cells[0].Value;
            int selectedOperationID = (Int32)dataGridView_Scenarios_CheckPoint_Operations.Rows[selectedRow_Operation].Cells[0].Value;

            // Delete selected
            List<Database_Objects.CheckPoints_Operations> connections = Database_Operation.Get.CheckPoints_Operations(myConnection);
            foreach (Database_Objects.CheckPoints_Operations o in connections)
            {
                if (o.GetId_CheckPoint() == selectedCheckpointID && o.GetId_Operation() == selectedOperationID)
                {
                    Database_Operation.Delete.CheckPoints_Operations(o.GetId_CheckPoint(), o.GetId_Operation(), o.GetOrder_Number(), myConnection);
                }
            }

            // Refresh form
            Scenarios_CheckPoint_Init();
        }

        /// <summary>
        /// Add selected child into selected parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Scenarios_CheckPoint_Add_Click(object sender, EventArgs e)
        {
            // Get selected items IDs
            int selectedRow_CheckPoint = dataGridView_Scenarios_CheckPoint_CheckPoints.CurrentCell.RowIndex;
            int selectedRow_Operation = dataGridView_Scenarios_CheckPoint_Operations.CurrentCell.RowIndex;
            int selectedCheckpointID = (Int32)dataGridView_Scenarios_CheckPoint_CheckPoints.Rows[selectedRow_CheckPoint].Cells[0].Value;
            int selectedOperationID = (Int32)dataGridView_Scenarios_CheckPoint_Operations.Rows[selectedRow_Operation].Cells[0].Value;

            // Find new orderNumber
            int biggestOrderNumber = 0;
            List<Database_Objects.CheckPoints_Operations> connections = Database_Operation.Get.CheckPoints_Operations(myConnection);
            foreach (Database_Objects.CheckPoints_Operations o in connections)
            {
                if (o.GetId_CheckPoint() == selectedCheckpointID && o.GetOrder_Number() > biggestOrderNumber)
                {
                    biggestOrderNumber = o.GetOrder_Number();
                }
            }
            biggestOrderNumber++;

            // Add selected
            Database_Operation.Insert.CheckPoints_Operations(selectedCheckpointID, selectedOperationID, biggestOrderNumber, myConnection);

            // Refresh form
            Scenarios_CheckPoint_Init();
        }

        /// <summary>
        /// When tables selection changed, check what is possible (delete, insert)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Scenarios_CheckPoint_SelectionChanged(object sender, EventArgs e)
        {
            // Get selected items IDs
            int selectedRow_CheckPoint;
            int selectedRow_Operation;
            try
            {
                selectedRow_CheckPoint = dataGridView_Scenarios_CheckPoint_CheckPoints.CurrentCell.RowIndex;
                selectedRow_Operation = dataGridView_Scenarios_CheckPoint_Operations.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }
            int selectedCheckpointID = (Int32)dataGridView_Scenarios_CheckPoint_CheckPoints.Rows[selectedRow_CheckPoint].Cells[0].Value;
            int selectedOperationID = (Int32)dataGridView_Scenarios_CheckPoint_Operations.Rows[selectedRow_Operation].Cells[0].Value;

            // Get all connections
            List<Database_Objects.CheckPoints_Operations> connections = Database_Operation.Get.CheckPoints_Operations(myConnection);

            // Check delete and add button (if can be deleted, cant be added, because its already in)
            bool canBeDeleted = false;
            foreach (Database_Objects.CheckPoints_Operations o in connections)
            {
                if (o.GetId_CheckPoint() == selectedCheckpointID && o.GetId_Operation() == selectedOperationID)
                {
                    canBeDeleted = true;

                    // Set delete button
                    button_Scenarios_CheckPoint_Delete.Enabled = true;
                    button_Scenarios_CheckPoint_Delete.BackColor = Color.LightCoral;

                    // Set add button
                    button_Scenarios_CheckPoint_Add.Enabled = false;
                    button_Scenarios_CheckPoint_Add.BackColor = Color.Transparent;
                    break;
                }
            }
            if (!canBeDeleted)
            {
                // Set delete button
                button_Scenarios_CheckPoint_Delete.Enabled = false;
                button_Scenarios_CheckPoint_Delete.BackColor = Color.Transparent;

                // Set add button
                button_Scenarios_CheckPoint_Add.Enabled = true;
                button_Scenarios_CheckPoint_Add.BackColor = Color.LightGreen;
            }
        }
        #endregion CheckPoint

        #endregion Scenarios

        #region Editor

        #region Init
        /// <summary>
        /// Initialize editor tab
        /// </summary>
        private void Editor_Init()
        {
            Editor_Scenario_Init();
            Editor_Section_Init();
            Editor_CheckPoint_Init();
            Editor_Operation_Init();
        }

        /// <summary>
        /// Clear editor tab
        /// </summary>
        private void Editor_Clear()
        {
            Editor_Scenario_Clear();
            Editor_Section_Clear();
            Editor_CheckPoint_Clear();
            Editor_Operation_Clear();
        }
        #endregion Init

        #region Scenario
        /// <summary>
        /// Initialize tab
        /// </summary>
        private void Editor_Scenario_Init()
        {
            Editor_Scenario_Clear();
            Editor_Scenario_LoadTable();
            Database_Log_Init();
        }

        /// <summary>
        /// Clear tab
        /// </summary>
        private void Editor_Scenario_Clear()
        {
            textBox_Editor_Scenario_SelectedName.Clear();
            textBox_Editor_Scenario_NewName.Clear();
            dataGridView_Editor_Scenario.Rows.Clear();
        }

        /// <summary>
        /// Table load in tab
        /// </summary>
        private void Editor_Scenario_LoadTable()
        {
            // Get objects
            List<Database_Objects.Scenario_Translation> objects = Database_Operation.Get.Scenarios(selectedLanguage.Text, myConnection);

            // Add new objects
            dataGridView_Editor_Scenario.Rows.Clear();
            foreach (Database_Objects.Scenario_Translation o in objects)
            {
                dataGridView_Editor_Scenario.Rows.Add(o.id_Scenario, o.language_Code, o.name, "Delete");
            }
        }

        /// <summary>
        /// Table select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Editor_Scenario_SelectionChanged(object sender, EventArgs e)
        {
            // Get row data
            DataGridView dataGridView = sender as DataGridView;
            int selectedRow = dataGridView.CurrentCell.RowIndex;
            string selectedID = dataGridView.Rows[selectedRow].Cells[0].Value.ToString();
            string selectedName = dataGridView.Rows[selectedRow].Cells[2].Value.ToString();

            // Set selected
            textBox_Editor_Scenario_ID.Text = selectedID;
            textBox_Editor_Scenario_SelectedName.Text = selectedName;
        }

        /// <summary>
        /// Add new row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editor_Scenario_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string language = "EN";
                string newName = textBox_Editor_Scenario_NewName.Text;

                if (newName != "")
                {
                    Database_Operation.Insert.Scenario(language, newName, myConnection);
                    Editor_Scenario_Init();
                }
                else
                {
                    Message("Name cannot be empty");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Update current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editor_Scenario_Update_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = dataGridView_Editor_Scenario.CurrentCell.RowIndex;
                string language = dataGridView_Editor_Scenario.Rows[selectedRow].Cells[1].Value.ToString();
                string id = textBox_Editor_Scenario_ID.Text;
                string updateName = textBox_Editor_Scenario_SelectedName.Text;

                if (updateName != "")
                {
                    Database_Operation.Update.Scenario(id, language, updateName, myConnection);
                    Editor_Scenario_Init();
                }
                else
                {
                    Message("Name cannot be empty");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Delete current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Editor_Scenario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if delete button clicked
            if (e.ColumnIndex != 3)
            {
                return;
            }

            // Delete
            try
            {
                string id = textBox_Editor_Scenario_ID.Text;
                string name = textBox_Editor_Scenario_SelectedName.Text;

                // Ask if sure about this...
                string dialog = "Are you sure you want to delete selected component? This cant be reversed." + Environment.NewLine;
                string component = "Selected component: [" + id + "] = [" + name + "]";
                DialogResult dialogResult = MessageBox.Show(dialog + component, "Deleting component", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database_Operation.Delete.Scenario(id, myConnection);
                    Editor_Scenario_Init();
                }                
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }
        #endregion Scenario

        #region Section
        /// <summary>
        /// Initialize tab
        /// </summary>
        private void Editor_Section_Init()
        {
            Editor_Section_Clear();
            Editor_Section_LoadTable();
            Database_Log_Init();
        }

        /// <summary>
        /// Clear tab
        /// </summary>
        private void Editor_Section_Clear()
        {
            textBox_Editor_Section_SelectedName.Clear();
            textBox_Editor_Section_NewName.Clear();
            dataGridView_Editor_Section.Rows.Clear();
        }

        /// <summary>
        /// Table load in tab
        /// </summary>
        private void Editor_Section_LoadTable()
        {
            // Get objects
            List<Database_Objects.Section_Translation> objects = Database_Operation.Get.Sections(selectedLanguage.Text, myConnection);

            // Add new objects
            dataGridView_Editor_Section.Rows.Clear();
            foreach (Database_Objects.Section_Translation o in objects)
            {
                dataGridView_Editor_Section.Rows.Add(o.id_Section, o.language_Code, o.name, "Delete");
            }
        }

        /// <summary>
        /// Table select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Editor_Section_SelectionChanged(object sender, EventArgs e)
        {
            // Get row data
            DataGridView dataGridView = sender as DataGridView;
            int selectedRow = dataGridView.CurrentCell.RowIndex;
            string selectedID = dataGridView.Rows[selectedRow].Cells[0].Value.ToString();
            string selectedName = dataGridView.Rows[selectedRow].Cells[2].Value.ToString();

            // Set selected
            textBox_Editor_Section_ID.Text = selectedID;
            textBox_Editor_Section_SelectedName.Text = selectedName;
        }

        /// <summary>
        /// Add new row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editor_Section_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string language = "EN";
                string newName = textBox_Editor_Section_NewName.Text;

                if (newName != "")
                {
                    Database_Operation.Insert.Section(language, newName, myConnection);
                    Editor_Section_Init();
                }
                else
                {
                    Message("Name cannot be empty");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Update current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editor_Section_Update_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = dataGridView_Editor_Section.CurrentCell.RowIndex;
                string language = dataGridView_Editor_Section.Rows[selectedRow].Cells[1].Value.ToString();
                string id = textBox_Editor_Section_ID.Text;
                string updateName = textBox_Editor_Section_SelectedName.Text;

                if (updateName != "")
                {
                    Database_Operation.Update.Section(id, language, updateName, myConnection);
                    Editor_Section_Init();
                }
                else
                {
                    Message("Name cannot be empty");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Delete current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Editor_Section_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if delete button clicked
            if (e.ColumnIndex != 3)
            {
                return;
            }

            // Delete
            try
            {
                string id = textBox_Editor_Section_ID.Text;
                string name = textBox_Editor_Section_SelectedName.Text;

                // Ask if sure about this...
                string dialog = "Are you sure you want to delete selected component? This cant be reversed." + Environment.NewLine;
                string component = "Selected component: [" + id + "] = [" + name + "]";
                DialogResult dialogResult = MessageBox.Show(dialog + component, "Deleting component", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database_Operation.Delete.Sections(id, myConnection);
                    Editor_Section_Init();
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }
        #endregion Section

        #region CheckPoint
        /// <summary>
        /// Initialize tab
        /// </summary>
        private void Editor_CheckPoint_Init()
        {
            Editor_CheckPoint_Clear();
            Editor_CheckPoint_LoadTable();
            Database_Log_Init();
        }

        /// <summary>
        /// Clear tab
        /// </summary>
        private void Editor_CheckPoint_Clear()
        {
            textBox_Editor_CheckPoint_SelectedName.Clear();
            textBox_Editor_CheckPoint_NewName.Clear();
            dataGridView_Editor_CheckPoint.Rows.Clear();
        }

        /// <summary>
        /// Table load in tab
        /// </summary>
        private void Editor_CheckPoint_LoadTable()
        {
            // Get objects
            List<Database_Objects.CheckPoint_Translation> objects = Database_Operation.Get.CheckPoints(selectedLanguage.Text, myConnection);

            // Add new objects
            dataGridView_Editor_CheckPoint.Rows.Clear();
            foreach (Database_Objects.CheckPoint_Translation o in objects)
            {
                dataGridView_Editor_CheckPoint.Rows.Add(o.id_CheckPoint, o.language_Code, o.name, "Delete");
            }
        }

        /// <summary>
        /// Table select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Editor_CheckPoint_SelectionChanged(object sender, EventArgs e)
        {
            // Get row data
            DataGridView dataGridView = sender as DataGridView;
            int selectedRow = dataGridView.CurrentCell.RowIndex;
            string selectedID = dataGridView.Rows[selectedRow].Cells[0].Value.ToString();
            string selectedName = dataGridView.Rows[selectedRow].Cells[2].Value.ToString();

            // Set selected
            textBox_Editor_CheckPoint_ID.Text = selectedID;
            textBox_Editor_CheckPoint_SelectedName.Text = selectedName;
        }

        /// <summary>
        /// Add new row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editor_CheckPoint_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string language = "EN";
                string newName = textBox_Editor_CheckPoint_NewName.Text;

                if (newName != "")
                {
                    Database_Operation.Insert.CheckPoint(language, newName, myConnection);
                    Editor_CheckPoint_Init();
                }
                else
                {
                    Message("Name cannot be empty");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Update current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editor_CheckPoint_Update_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = dataGridView_Editor_CheckPoint.CurrentCell.RowIndex;
                string language = dataGridView_Editor_CheckPoint.Rows[selectedRow].Cells[1].Value.ToString();
                string id = textBox_Editor_CheckPoint_ID.Text;
                string updateName = textBox_Editor_CheckPoint_SelectedName.Text;

                if (updateName != "")
                {
                    Database_Operation.Update.CheckPoint(id, language, updateName, myConnection);
                    Editor_CheckPoint_Init();
                }
                else
                {
                    Message("Name cannot be empty");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Delete current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Editor_CheckPoint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if delete button clicked
            if (e.ColumnIndex != 3)
            {
                return;
            }

            // Delete
            try
            {
                string id = textBox_Editor_CheckPoint_ID.Text;
                string name = textBox_Editor_CheckPoint_SelectedName.Text;

                // Ask if sure about this...
                string dialog = "Are you sure you want to delete selected component? This cant be reversed." + Environment.NewLine;
                string component = "Selected component: [" + id + "] = [" + name + "]";
                DialogResult dialogResult = MessageBox.Show(dialog + component, "Deleting component", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database_Operation.Delete.CheckPoint(id, myConnection);
                    Editor_CheckPoint_Init();
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }
        #endregion CheckPoint

        #region Operation
        /// <summary>
        /// Initialize tab
        /// </summary>
        private void Editor_Operation_Init()
        {
            Editor_Operation_Clear();
            Editor_Operation_LoadTable();
            Database_Log_Init();
        }

        /// <summary>
        /// Clear tab
        /// </summary>
        private void Editor_Operation_Clear()
        {
            textBox_Editor_Operation_SelectedName.Clear();
            textBox_Editor_Operation_NewName.Clear();
            dataGridView_Editor_Operation.Rows.Clear();
        }

        /// <summary>
        /// Table load in tab
        /// </summary>
        private void Editor_Operation_LoadTable()
        {
            // Get objects
            List<Database_Objects.Operation_Translation> objects = Database_Operation.Get.Operations(selectedLanguage.Text, myConnection);

            // Add new objects
            dataGridView_Editor_Operation.Rows.Clear();
            foreach (Database_Objects.Operation_Translation o in objects)
            {
                dataGridView_Editor_Operation.Rows.Add(o.id_Operation, o.language_Code, o.name, "Delete");
            }
        }

        /// <summary>
        /// Table select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Editor_Operation_SelectionChanged(object sender, EventArgs e)
        {
            // Get row data
            DataGridView dataGridView = sender as DataGridView;
            int selectedRow = dataGridView.CurrentCell.RowIndex;
            string selectedID = dataGridView.Rows[selectedRow].Cells[0].Value.ToString();
            string selectedName = dataGridView.Rows[selectedRow].Cells[2].Value.ToString();

            // Set selected
            textBox_Editor_Operation_ID.Text = selectedID;
            textBox_Editor_Operation_SelectedName.Text = selectedName;
        }

        /// <summary>
        /// Add new row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editor_Operation_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string language = "EN";
                string newName = textBox_Editor_Operation_NewName.Text;

                if (newName != "")
                {
                    Database_Operation.Insert.Operation(language, newName, myConnection);
                    Editor_Operation_Init();
                }
                else
                {
                    Message("Name cannot be empty");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Update current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editor_Operation_Update_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = dataGridView_Editor_Operation.CurrentCell.RowIndex;
                string language = dataGridView_Editor_Operation.Rows[selectedRow].Cells[1].Value.ToString();
                string id = textBox_Editor_Operation_ID.Text;
                string updateName = textBox_Editor_Operation_SelectedName.Text;

                if (updateName != "")
                {
                    Database_Operation.Update.Operation(id, language, updateName, myConnection);
                    Editor_Operation_Init();
                }
                else
                {
                    Message("Name cannot be empty");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Delete current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Editor_Operation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if delete button clicked
            if (e.ColumnIndex != 3)
            {
                return;
            }

            // Delete
            try
            {
                string id = textBox_Editor_Operation_ID.Text;
                string name = textBox_Editor_Operation_SelectedName.Text;

                // Ask if sure about this...
                string dialog = "Are you sure you want to delete selected component? This cant be reversed." + Environment.NewLine;
                string component = "Selected component: [" + id + "] = [" + name + "]";
                DialogResult dialogResult = MessageBox.Show(dialog + component, "Deleting component", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database_Operation.Delete.Operation(id, myConnection);
                    Editor_Operation_Init();
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }
        #endregion Operation

        #endregion Editor

        #region Language
        /// <summary>
        /// Initialize export tab
        /// </summary>
        private void Language_Init()
        {
            Language_SelectedLanguageRefresh();
            Database_Log_Init();
        }

        /// <summary>
        /// Clear export tab
        /// </summary>
        private void Language_Clear()
        {
            // Clear selected language
            selectedLanguage.Items.Clear();
            selectedLanguage.Text = "";
        }

        /// <summary>
        /// Refresh languages
        /// </summary>
        private void Language_SelectedLanguageRefresh()
        {
            try
            {
                // Load languages
                List<string> languages = Database_Operation.Get.Languages(myConnection);

                // Clear old languages
                selectedLanguage.Items.Clear();

                // Add new languages
                foreach (string language in languages)
                {
                    selectedLanguage.Items.Add(language);
                }

                // Select first item
                selectedLanguage.SelectedIndex = 0;
            }
            catch
            {
                Message("Database is empty");
            }
        }

        /// <summary>
        /// Selected language changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Scenarios_Init();
            Editor_Init();
        }
        #endregion Language

        #region Export
        /// <summary>
        /// Initialize export tab
        /// </summary>
        private void Export_Init()
        {
            Export_LanguagesRefresh();
        }

        /// <summary>
        /// Clear export tab
        /// </summary>
        private void Export_Clear()
        {
            comboBox_Export_ExportLanguage.Items.Clear();
            comboBox_Export_ExportLanguage.Text = "";
            textBox_Export_Scenarios.Clear();
            textBox_Export_Sections.Clear();
            textBox_Export_CheckPoints.Clear();
            textBox_Export_Operations.Clear();
        }

        /// <summary>
        /// Export database into JSON in selected language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Export_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Export_ExportLanguage.Text != "" || comboBox_Export_ExportLanguage.Text != null)
                {
                    Database_Export.ExportToJson.Generate(comboBox_Export_ExportLanguage.Text, myConnection);
                    Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + "export\\");
                }
                else
                {
                    Message("Database is empty.");
                }
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Refresh languages for export
        /// </summary>
        private void Export_LanguagesRefresh()
        {
            try
            {
                // Load languages
                List<string> languages = Database_Operation.Get.Languages(myConnection);

                // Clear old languages
                comboBox_Export_ExportLanguage.Items.Clear();

                // Add new languages
                foreach (string language in languages)
                {
                    comboBox_Export_ExportLanguage.Items.Add(language);
                }

                // Select first item
                comboBox_Export_ExportLanguage.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Refresh export information for selected language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Export_ExportLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, int> components = Database_Export.ExportToJson.GetNumerOfComponents(comboBox_Export_ExportLanguage.Text, myConnection);

                textBox_Export_Scenarios.Text = components["Scenarios"].ToString();
                textBox_Export_Sections.Text = components["Sections"].ToString();
                textBox_Export_CheckPoints.Text = components["CheckPoints"].ToString();
                textBox_Export_Operations.Text = components["Operations"].ToString();
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }
        #endregion Export

        #region Message
        /// <summary>
        /// Show message in messageBox
        /// </summary>
        /// <param name="message">Message to show</param>
        private void Message(string message)
        {
            MessageBox.Show(message);
        }
        #endregion Message
    }
}
