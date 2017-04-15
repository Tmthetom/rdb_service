using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace rdb_scenarios
{
    public partial class AdministrationForm : Form
    {
        private SqlConnection myConnection;

        public AdministrationForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.TextChanged += toolStripStatusLabel1_TextChanged;
        }
        public AdministrationForm(SqlConnection myConnection) : this()
        {
            this.myConnection = myConnection;

            operationDao = new DB_operations.OperationDao(myConnection);
            operationAttributeDao = new DB_operations.OperationAttributeDao(myConnection);
            checkDao = new DB_operations.CheckDao(myConnection);
            checkAttributeDao = new DB_operations.CheckAttributeDao(myConnection);
            sectionDao = new DB_operations.SectionDao(myConnection);
            sectionAttributeDao = new DB_operations.SectionAttributeDao(myConnection);
            scenarioDao = new DB_operations.ScenarioDao(myConnection);
            scenarioAttributeDao = new DB_operations.ScenarioAttributeDao(myConnection);
            fillOperations();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            timer1.Stop();
        }

        private void toolStripStatusLabel1_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    fillOperations();
                    break;
                case 1:
                    fillChecks();
                    break;
                case 2:
                    fillSections();
                    break;
                case 3:
                    fillScenarios();
                    break;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        #region OperationTab - completed

        private DB_operations.OperationDao operationDao;
        private DB_operations.OperationAttributeDao operationAttributeDao;

        private int selectedOperationView;
        private int selectedOperationAttributeView;

        private void fillOperations()
        {
            operationView.Rows.Clear();
            List<DB_objects.Operation> operations = operationDao.retrieve();
            foreach (DB_objects.Operation o in operations)
            {
                operationView.Rows.Add(o.operation_code, o.name, o.description);
            }
            selectedOperationView = -1;
            operationName.Text = operationDesc.Text = "";
            if (operationView.Rows.Count > 0) {
                selectedOperationView = Int32.Parse(operationView.Rows[0].Cells[0].Value.ToString());
                operationName.Text = operationView.Rows[0].Cells[1].Value.ToString();
                operationDesc.Text = operationView.Rows[0].Cells[2].Value.ToString();
            }

            fillOperationAttributes(selectedOperationView);
        }

        private void fillOperationAttributes(int selectedOperationView)
        {
            operationAttributeView.Rows.Clear();
            List<DB_objects.Attribute> attributes = operationAttributeDao.retrieve(selectedOperationView);
            foreach(DB_objects.Attribute a in attributes)
            {
                operationAttributeView.Rows.Add(a.attribute_code, a.type, a.value, a.language);
            }
            selectedOperationAttributeView = -1;
            operationAttributeType.Text = operationAttributeValue.Text = operationAttributeLanguage.Text = "";
            if (operationAttributeView.Rows.Count > 0)
            {
                selectedOperationAttributeView = Int32.Parse(operationAttributeView.Rows[0].Cells[0].Value.ToString());
                operationAttributeType.Text = operationAttributeView.Rows[0].Cells[1].Value.ToString();
                operationAttributeValue.Text = operationAttributeView.Rows[0].Cells[2].Value.ToString();
                operationAttributeLanguage.Text = operationAttributeView.Rows[0].Cells[3].Value.ToString();
            }
        }

        private void operationNewButton_Click(object sender, EventArgs e)
        {
            selectedOperationView = -1;
            operationName.Text = operationDesc.Text = "";
            tableLayoutPanel2.Enabled = false;
        }

        private void operationView_SelectionChanged(object sender, EventArgs e)
        {
            if (operationView.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow row = operationView.SelectedRows[0];
            selectedOperationView = Int32.Parse(row.Cells[0].Value.ToString());
            operationName.Text = row.Cells[1].Value.ToString();
            operationDesc.Text = row.Cells[2].Value.ToString();
            tableLayoutPanel2.Enabled = true;
            fillOperationAttributes(selectedOperationView);
        }

        private void operationSaveButton_Click(object sender, EventArgs e)
        {
            DB_objects.Operation o = new DB_objects.Operation(operationName.Text, operationDesc.Text);
            if (selectedOperationView == -1)
            {
                operationDao.create(o);
            }
            else
            {
                o.operation_code = selectedOperationView;
                operationDao.update(o);
            }
            fillOperations();
        }

        private void operationDeleteButton_Click(object sender, EventArgs e)
        {
            DB_objects.Operation o = new DB_objects.Operation(operationName.Text, operationDesc.Text);
            o.operation_code = selectedOperationView;
            try
            {
                operationDao.delete(o);
                fillOperations();
            }
            catch (SqlException ex)
            {
                toolStripStatusLabel1.Text = "Unable to delete operation, would destroy check point(s)!";
            }
        }

        private void operationAttributeView_SelectionChanged(object sender, EventArgs e)
        {
            if (operationAttributeView.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow row = operationAttributeView.SelectedRows[0];
            selectedOperationAttributeView = Int32.Parse(row.Cells[0].Value.ToString());
            operationAttributeType.Text = row.Cells[1].Value.ToString();
            operationAttributeValue.Text = row.Cells[2].Value.ToString();
            operationAttributeLanguage.Text = row.Cells[3].Value.ToString();
        }

        private void operationAttrNewButton_Click(object sender, EventArgs e)
        {
            selectedOperationAttributeView = -1;
            operationAttributeType.Text = operationAttributeValue.Text = operationAttributeLanguage.Text = "";
        }

        private void operationAttrSaveButton_Click(object sender, EventArgs e)
        {
            DB_objects.Attribute a = new DB_objects.Attribute();
            a.type = operationAttributeType.Text;
            a.value = operationAttributeValue.Text;
            a.language = operationAttributeLanguage.Text;

            if (selectedOperationAttributeView == -1)
            {
                DB_objects.Operation o = new DB_objects.Operation();
                o.operation_code = selectedOperationView;
                o.name = operationName.Text;
                o.description = operationDesc.Text;

                operationAttributeDao.create(o,a);
            } else
            {
                a.attribute_code = selectedOperationAttributeView;
                operationAttributeDao.update(a);
            }
            fillOperationAttributes(selectedOperationView);
        }

        private void operationAttrDeleteButton_Click(object sender, EventArgs e)
        {
            DB_objects.Attribute a = new DB_objects.Attribute(operationAttributeType.Text, operationAttributeValue.Text, operationAttributeLanguage.Text);
            a.attribute_code = selectedOperationAttributeView;
            try
            {
                operationAttributeDao.delete(a);
                fillOperationAttributes(selectedOperationView);
            }
            catch (SqlException ex)
            {
                toolStripStatusLabel1.Text = "Unable to delete attribute!";
            }
        }

        #endregion

        #region CheckTab - completed
        private DB_operations.CheckDao checkDao;
        private DB_operations.CheckAttributeDao checkAttributeDao;

        private int selectedCheckView;
        private int selectedCheckAttributeView;
        private void fillChecks()
        {
            checkView.Rows.Clear();
            List<DB_objects.CheckPoint> checks = checkDao.retrieve();
            foreach(DB_objects.CheckPoint c in checks)
            {
                checkView.Rows.Add(c.check_code, c.name, c.description);
            }
            selectedCheckView = -1;
            operationName.Text = operationDesc.Text = "";
            if (checkView.Rows.Count > 0)
            {
                selectedCheckView = Int32.Parse(checkView.Rows[0].Cells[0].Value.ToString());
                checkName.Text = checkView.Rows[0].Cells[1].Value.ToString();
                checkDesc.Text = checkView.Rows[0].Cells[2].Value.ToString();
            }
            tableLayoutPanel6.Enabled = splitContainer1.Enabled = checkAvailableOperation.Enabled = true;
            fillCheckAttributes(selectedCheckView);
            fillAvailableOperations(selectedCheckView);
            fillCheckOperations(selectedCheckView);
        }
        private void fillCheckAttributes(int selectedCheckView)
        {
            checkAttributeView.Rows.Clear();
            List<DB_objects.Attribute> attributes = checkAttributeDao.retrieve(selectedCheckView);
            foreach (DB_objects.Attribute a in attributes)
            {
                checkAttributeView.Rows.Add(a.attribute_code, a.type, a.value, a.language);
            }
            selectedCheckAttributeView = -1;
            checkAttributeType.Text = checkAttributeValue.Text = checkAttributeLanguage.Text = "";
            if (checkAttributeView.Rows.Count > 0)
            {
                selectedCheckAttributeView = Int32.Parse(checkAttributeView.Rows[0].Cells[0].Value.ToString());
                checkAttributeType.Text = checkAttributeView.Rows[0].Cells[1].Value.ToString();
                checkAttributeValue.Text = checkAttributeView.Rows[0].Cells[2].Value.ToString();
                checkAttributeLanguage.Text = checkAttributeView.Rows[0].Cells[3].Value.ToString();
            }
        }
        private void checkView_SelectionChanged(object sender, EventArgs e)
        {
            if (checkView.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow row = checkView.SelectedRows[0];
            selectedCheckView = Int32.Parse(row.Cells[0].Value.ToString());
            checkName.Text = row.Cells[1].Value.ToString();
            checkDesc.Text = row.Cells[2].Value.ToString();
            tableLayoutPanel6.Enabled = splitContainer1.Enabled = checkAvailableOperation.Enabled = true;
            fillCheckAttributes(selectedCheckView);
            fillAvailableOperations(selectedCheckView);
            fillCheckOperations(selectedCheckView);
        }
        private void fillCheckOperations(int selectedCheckView)
        {
            checkOperations.Items.Clear();
            SortedList<int, DB_objects.Operation> operations = checkDao.getOperations(selectedCheckView);
            DB_objects.Operation o;
            for(int i = 0; i < operations.Keys.Count; i++)
            {
                o = operations[operations.Keys[i]];
                checkOperations.Items.Add("Operation(" + o.operation_code + "): " + o.name + "[" + o.description + "]");
            }
        }
        private void fillAvailableOperations(int selectedCheckView)
        {
            checkAvailableOperation.Rows.Clear();
            List<DB_objects.Operation> operations = checkDao.getAvailable(selectedCheckView);
            foreach(DB_objects.Operation o in operations)
            {
                checkAvailableOperation.Rows.Add(o.operation_code, o.name, o.description, "Add");
            }
        }
        private void checkAvailableOperation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != checkAvailableOperation.ColumnCount -1)
            {
                return;
            }
            DataGridViewRow row = checkAvailableOperation.Rows[e.RowIndex];
            checkAvailableOperation.Rows.Remove(row);
            checkOperations.Items.Add("Operation(" + Int32.Parse(row.Cells[0].Value.ToString()) + "): " + row.Cells[1].Value.ToString() + "[" + row.Cells[2].Value.ToString() + "]");
        }
        private void checkOperations_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.checkOperations.SelectedItem == null) return;
            this.checkOperations.DoDragDrop(this.checkOperations.SelectedItem, DragDropEffects.Move);
        }
        private void checkOperations_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void checkOperations_DragDrop(object sender, DragEventArgs e)
        {
            Point point = checkOperations.PointToClient(new Point(e.X, e.Y));
            int index = this.checkOperations.IndexFromPoint(point);
            if (index < 0) index = this.checkOperations.Items.Count - 1;
            object data = e.Data.GetData(typeof(String));
            this.checkOperations.Items.Remove(data);
            this.checkOperations.Items.Insert(index, data);
        }
        private void checkNewButton_Click(object sender, EventArgs e)
        {
            selectedCheckView = -1;
            checkName.Text = checkDesc.Text = "";
            tableLayoutPanel6.Enabled = splitContainer1.Enabled = checkAvailableOperation.Enabled = false;
        }
        private void checkSaveButton_Click(object sender, EventArgs e)
        {
            DB_objects.CheckPoint c = new DB_objects.CheckPoint();
            c.name = checkName.Text;
            c.description = checkDesc.Text;
            if (selectedCheckView == -1)
            {
                checkDao.create(c);
            }
            else
            {
                c.check_code = selectedCheckView;
                checkDao.update(c);
            }
            fillChecks();
        }
        private void checkDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCheckView == -1)
            {
                return;
            }
            try
            {
                checkDao.delete(selectedCheckView);
            } catch(SqlException ex)
            {
                toolStripStatusLabel1.Text = "Unable to delete check point, would destroy scenario(s)!";
            }
            fillChecks();
        }
        private void checkAttrNewButton_Click(object sender, EventArgs e)
        {
            selectedCheckAttributeView = -1;
            checkAttributeType.Text = checkAttributeValue.Text = checkAttributeLanguage.Text = "";
        }
        private void checkAttrSaveButton_Click(object sender, EventArgs e)
        {
            DB_objects.Attribute a = new DB_objects.Attribute();
            a.type = checkAttributeType.Text;
            a.value = checkAttributeValue.Text;
            a.language = checkAttributeLanguage.Text;
            if (selectedCheckAttributeView == -1)
            {
                checkAttributeDao.create(selectedCheckView, a);
            }
            else
            {
                a.attribute_code = selectedCheckAttributeView;
                checkAttributeDao.update(a);
            }
            fillCheckAttributes(selectedCheckView);
        }
        private void checkAttrDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCheckAttributeView == -1)
            {
                return;
            }
            checkAttributeDao.delete(selectedCheckAttributeView);
            fillCheckAttributes(selectedCheckView);
        }
        private void checkAttributeView_SelectionChanged(object sender, EventArgs e)
        {
            if (checkAttributeView.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow row = checkAttributeView.SelectedRows[0];
            selectedCheckAttributeView = Int32.Parse(row.Cells[0].Value.ToString());
            checkAttributeType.Text = row.Cells[1].Value.ToString();
            checkAttributeValue.Text = row.Cells[2].Value.ToString();
            checkAttributeLanguage.Text = row.Cells[3].Value.ToString();
        }
        private void checkDeleteOperation_Click(object sender, EventArgs e)
        {
            if (checkOperations.SelectedIndex < 0)
            {
                return;
            }
            string operation = checkOperations.SelectedItem.ToString();
            checkOperations.Items.Remove(checkOperations.SelectedItem);

            Regex regex = new Regex("^Operation\\((.*?)\\): (.*?)\\[(.*?)\\]$");
            Match match = regex.Match(operation);
            string arg0 = match.Groups[1].Value;
            string arg1 = match.Groups[2].Value;
            string arg2 = match.Groups[3].Value;

            checkAvailableOperation.Rows.Add(arg0, arg1, arg2, "Add");
        }
        private void checkSaveOperations_Click(object sender, EventArgs e)
        {
            SortedList<int, DB_objects.Operation> operations = new SortedList<int, DB_objects.Operation>();
            string operation, arg0, arg1, arg2;
            Regex regex = new Regex("^Operation\\((.*?)\\): (.*?)\\[(.*?)\\]$");
            Match match;
            DB_objects.Operation o;
            for (int i = 0; i < checkOperations.Items.Count; i++)
            {
                o = new DB_objects.Operation();
                operation = checkOperations.Items[i].ToString();
                match = regex.Match(operation);
                arg0 = match.Groups[1].Value;
                arg1 = match.Groups[2].Value;
                arg2 = match.Groups[3].Value;

                o.operation_code = Int32.Parse(arg0);
                o.name = arg1;
                o.description = arg2;

                operations.Add(i + 1, o);
            }
            checkDao.updateOperations(selectedCheckView, operations);
        }
        #endregion

        #region SectionTab - completed
        private DB_operations.SectionDao sectionDao;
        private DB_operations.SectionAttributeDao sectionAttributeDao;

        private int selectedSectionView;
        private int selectedSectionAttributeView;
        private void fillSections()
        {
            sectionView.Rows.Clear();
            List<DB_objects.Section> sections = sectionDao.retrieve();
            foreach(DB_objects.Section s in sections)
            {
                sectionView.Rows.Add(s.section_code, s.name, s.description);
            }
            selectedSectionView = -1;
            sectionName.Text = sectionDesc.Text = "";
            if(sectionView.Rows.Count > 0)
            {
                selectedSectionView = Int32.Parse(sectionView.Rows[0].Cells[0].Value.ToString());
                sectionName.Text = sectionView.Rows[0].Cells[1].Value.ToString();
                sectionDesc.Text = sectionView.Rows[0].Cells[2].Value.ToString();
            }
            fillSectionAttributes(selectedSectionView);
        }
        private void fillSectionAttributes(int selectedSectionView)
        {
            sectionAttributeView.Rows.Clear();
            List<DB_objects.Attribute> attributes = sectionAttributeDao.retrieve(selectedSectionView);
            foreach(DB_objects.Attribute a in attributes)
            {
                sectionAttributeView.Rows.Add(a.attribute_code, a.type, a.value, a.language);
            }
            selectedSectionAttributeView = -1;
            sectionAttributeType.Text = sectionAttributeValue.Text = sectionAttributeLanguage.Text = "";
            if(sectionAttributeView.Rows.Count > 0)
            {
                selectedSectionAttributeView = Int32.Parse(sectionAttributeView.Rows[0].Cells[0].Value.ToString());
                sectionAttributeType.Text = sectionAttributeView.Rows[0].Cells[1].Value.ToString();
                sectionAttributeValue.Text = sectionAttributeView.Rows[0].Cells[2].Value.ToString();
                sectionAttributeLanguage.Text = sectionAttributeView.Rows[0].Cells[3].Value.ToString();
            }
        }
        private void sectionView_SelectionChanged(object sender, EventArgs e)
        {
            if (sectionView.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow row = sectionView.SelectedRows[0];
            selectedSectionView = Int32.Parse(row.Cells[0].Value.ToString());
            sectionName.Text = row.Cells[1].Value.ToString();
            sectionDesc.Text = row.Cells[2].Value.ToString();
            tableLayoutPanel9.Enabled = true;
            fillSectionAttributes(selectedSectionView);
        }
        private void sectionNewButton_Click(object sender, EventArgs e)
        {
            selectedSectionView = -1;
            sectionName.Text = sectionDesc.Text = "";
            tableLayoutPanel9.Enabled = false;
        }
        private void sectionSaveButton_Click(object sender, EventArgs e)
        {
            DB_objects.Section s = new DB_objects.Section();
            s.name = sectionName.Text;
            s.description = sectionDesc.Text;
            if (selectedSectionView == -1)
            {
                sectionDao.create(s);
            }
            else
            {
                s.section_code = selectedSectionView;
                sectionDao.update(s);
            }
            fillSections();
        }
        private void sectionDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedSectionView == -1)
            {
                return;
            }
            try
            {
                sectionDao.delete(selectedSectionView);
            } catch(SqlException ex)
            {
                toolStripStatusLabel1.Text = "Unable to delete section, would destroy scenario(s)!";
            }
            fillSections();
        }
        private void sectionAttrNewButton_Click(object sender, EventArgs e)
        {
            selectedSectionAttributeView = -1;
            sectionAttributeType.Text = sectionAttributeValue.Text = sectionAttributeLanguage.Text = "";
        }
        private void sectionAttrSaveButton_Click(object sender, EventArgs e)
        {
            DB_objects.Attribute a = new DB_objects.Attribute();
            a.type = sectionAttributeType.Text;
            a.value = sectionAttributeValue.Text;
            a.language = sectionAttributeLanguage.Text;
            if (selectedSectionAttributeView == -1)
            {
                sectionAttributeDao.create(selectedSectionView, a);
            }
            else
            {
                a.attribute_code = selectedSectionAttributeView;
                sectionAttributeDao.update(a);
            }
            fillSectionAttributes(selectedSectionView);
        }
        private void sectionAttrDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedSectionAttributeView != -1)
            {
                sectionAttributeDao.delete(selectedSectionAttributeView);
            }
            fillSectionAttributes(selectedSectionView);
        }
        private void sectionAttributeView_SelectionChanged(object sender, EventArgs e)
        {
            if (sectionAttributeView.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow row = sectionAttributeView.SelectedRows[0];
            selectedSectionAttributeView = Int32.Parse(row.Cells[0].Value.ToString());
            sectionAttributeType.Text = row.Cells[1].Value.ToString();
            sectionAttributeValue.Text = row.Cells[2].Value.ToString();
            sectionAttributeLanguage.Text = row.Cells[3].Value.ToString();
        }
        #endregion

        #region ScenarioTab - completed
        private DB_operations.ScenarioDao scenarioDao;
        private DB_operations.ScenarioAttributeDao scenarioAttributeDao;

        private int selectedScenarioView;
        private int selectedScenarioAttributeView;
        private void fillScenarios()
        {
            scenarioView.Rows.Clear();
            List<DB_objects.Scenario> scenarios = scenarioDao.retrieve();
            foreach(DB_objects.Scenario s in scenarios)
            {
                scenarioView.Rows.Add(s.scenario_code, s.name, s.description);
            }
            selectedScenarioView = -1;
            scenarioName.Text = scenarioDesc.Text = scenarioAttributeType.Text = scenarioAttributeValue.Text = scenarioAttributeLanguage.Text = "";
            if(scenarioView.Rows.Count > 0)
            {
                selectedScenarioView = Int32.Parse(scenarioView.Rows[0].Cells[0].Value.ToString());
                scenarioName.Text = scenarioView.Rows[0].Cells[1].Value.ToString();
                scenarioDesc.Text = scenarioView.Rows[0].Cells[2].Value.ToString();
            }
            fillScenarioAttributes(selectedScenarioView);
            fillScenarioSections();
        }
        private void fillScenarioSections()
        {
            scenarioAvailableSection.Rows.Clear();
            List<DB_objects.Section> sections = sectionDao.retrieve();
            foreach(DB_objects.Section s in sections)
            {
                scenarioAvailableSection.Rows.Add(s.section_code, s.name, s.description, "Add");
            }
        }
        private void fillScenarioAttributes(int selectedScenarioView)
        {
            scenarioAttributeView.Rows.Clear();
            List<DB_objects.Attribute> attributes = scenarioAttributeDao.retrieve(selectedScenarioView);
            foreach(DB_objects.Attribute a in attributes)
            {
                scenarioAttributeView.Rows.Add(a.attribute_code, a.type, a.value, a.language);
            }
            selectedScenarioAttributeView = -1;
            scenarioAttributeType.Text = scenarioAttributeValue.Text = scenarioAttributeLanguage.Text = "";
            if (scenarioAttributeView.Rows.Count > 0)
            {
                selectedScenarioAttributeView = Int32.Parse(scenarioAttributeView.Rows[0].Cells[0].Value.ToString());
                scenarioAttributeType.Text = scenarioAttributeView.Rows[0].Cells[1].Value.ToString();
                scenarioAttributeValue.Text = scenarioAttributeView.Rows[0].Cells[2].Value.ToString();
                scenarioAttributeLanguage.Text = scenarioAttributeView.Rows[0].Cells[3].Value.ToString();
            }
        }
        private void scenarioView_SelectionChanged(object sender, EventArgs e)
        {
            if (scenarioView.SelectedRows.Count <= 0)
            {
                return;
            }
            scenarioTree.Nodes.Clear();
            DataGridViewRow row = scenarioView.SelectedRows[0];
            selectedScenarioView = Int32.Parse(row.Cells[0].Value.ToString());
            scenarioName.Text = row.Cells[1].Value.ToString();
            scenarioDesc.Text = row.Cells[2].Value.ToString();
            tableLayoutPanel13.Enabled = true;
            fillScenarioAttributes(selectedScenarioView);

            TreeNode t = scenarioDao.getScenario(selectedScenarioView);
            for(int i = 0; i < t.Nodes.Count; i++)
            {
                scenarioTree.Nodes.Add(t.Nodes[i]);
            }
            scenarioTree.CollapseAll();
        }
        private void scenarioAttributeView_SelectionChanged(object sender, EventArgs e)
        {
            if(scenarioAttributeView.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewRow row = scenarioAttributeView.SelectedRows[0];
            selectedScenarioAttributeView = Int32.Parse(row.Cells[0].Value.ToString());
            scenarioAttributeType.Text = row.Cells[1].Value.ToString();
            scenarioAttributeValue.Text = row.Cells[2].Value.ToString();
            scenarioAttributeLanguage.Text = row.Cells[3].Value.ToString();
        }
        private void scenarioNewButton_Click(object sender, EventArgs e)
        {
            selectedScenarioView = -1;
            scenarioName.Text = scenarioDesc.Text = "";
            tableLayoutPanel13.Enabled = false;
        }
        private void scenarioSaveButton_Click(object sender, EventArgs e)
        {
            DB_objects.Scenario s = new DB_objects.Scenario();
            s.name = scenarioName.Text;
            s.description = scenarioDesc.Text;
            if (selectedScenarioView == -1)
            {
                scenarioDao.create(s);
            }
            else
            {
                s.scenario_code = selectedScenarioView;
                scenarioDao.update(s);
            }
            fillScenarios();
        }
        private void scenarioDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedScenarioView == -1)
            {
                return;
            }
            try
            {
                scenarioDao.delete(selectedScenarioView);
            }catch(SqlException ex)
            {
                toolStripStatusLabel1.Text = "Unable to delete scenario. Scenario is not empty.";
            }
            fillScenarios();
        }
        private void scenarioAttrNewButton_Click(object sender, EventArgs e)
        {
            selectedScenarioAttributeView = -1;
            scenarioAttributeType.Text = scenarioAttributeValue.Text = scenarioAttributeLanguage.Text = "";
        }
        private void scenarioAttrSaveButton_Click(object sender, EventArgs e)
        {
            DB_objects.Attribute a = new DB_objects.Attribute();
            a.type = scenarioAttributeType.Text;
            a.value = scenarioAttributeValue.Text;
            a.language = scenarioAttributeLanguage.Text;
            if (selectedScenarioAttributeView == -1)
            {
                scenarioAttributeDao.create(selectedScenarioView, a);
            }
            else
            {
                a.attribute_code = selectedScenarioAttributeView;
                scenarioAttributeDao.update(a);
            }
            fillScenarioAttributes(selectedScenarioView);
        }
        private void scenarioAttrDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedScenarioAttributeView == -1)
            {
                return;
            }
            scenarioAttributeDao.delete(selectedScenarioAttributeView);
            fillScenarioAttributes(selectedScenarioView);
        }
        private void scenarioAvailableSection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != scenarioAvailableSection.ColumnCount - 1)
            {
                return;
            }
            DataGridViewRow row = scenarioAvailableSection.Rows[e.RowIndex];
            scenarioTree.Nodes.Add("Section(" + Int32.Parse(row.Cells[0].Value.ToString()) + "): " + row.Cells[1].Value.ToString() + "[" + row.Cells[2].Value.ToString() + "]");
        }
        private void scenarioTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!e.Node.Text.StartsWith("Section"))
            {
                return;
            }
            List<DB_objects.CheckPoint> checks;
            Regex regex = new Regex("^Check\\((.*?)\\): (.*?)\\[(.*?)\\]$");
            Match match;
            string arg0, selection = "";
            foreach (TreeNode n in e.Node.Nodes)
            {
                match = regex.Match(n.Text);
                arg0 = match.Groups[1].Value;
                selection += (arg0 + ",");
            }
            if(selection.Length > 0)
            {
                selection = "(" + selection.Remove(selection.LastIndexOf(',')) + ")";
                checks = scenarioDao.getAvailableChecks(selectedScenarioView, selection);
            } else
            {
                checks = checkDao.retrieve();
            }

            scenarioAvailableCheck.Rows.Clear();
            foreach(DB_objects.CheckPoint cp in checks)
            {
                scenarioAvailableCheck.Rows.Add(cp.check_code, cp.name, cp.description, "Add");
            }
        }
        private void scenarioSectionsDeleteButton_Click(object sender, EventArgs e)
        {
            if (scenarioTree.SelectedNode == null)
            {
                return;
            }
            scenarioTree.Nodes.Remove(scenarioTree.SelectedNode);
            scenarioTree.SelectedNode = null;
            scenarioAvailableCheck.Rows.Clear();
        }
        private void scenarioAvailableCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != scenarioAvailableCheck.ColumnCount - 1)
            {
                return;
            }
            if (scenarioTree.SelectedNode == null)
            {
                return;
            }
            if (!scenarioTree.SelectedNode.Text.StartsWith("Section"))
            {
                return;
            }
            DataGridViewRow row = scenarioAvailableCheck.Rows[e.RowIndex];
            scenarioAvailableCheck.Rows.Remove(row);
            scenarioTree.SelectedNode.Nodes.Add("Check(" + row.Cells[0].Value.ToString() + "): " + row.Cells[1].Value.ToString() + "[" + row.Cells[2].Value.ToString() + "]");
        }
        private void scenarioSectionsSaveButton_Click(object sender, EventArgs e)
        {
            scenarioDao.insertSections(selectedScenarioView, scenarioTree.Nodes);
        }
        #endregion
    }
}
