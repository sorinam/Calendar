using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalendar
{
    public partial class SearchForm : Form
    {
        string field;
        string operators;
        string[] values;
        public SearchForm()
        {
            InitializeComponent();
        }

        public string Field { get { return field; } }
        public string Operators { get { return operators; } }
        public string[] Values { get { return values; } }

        private void comboBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControlItemsAccordingWithSelectedValueFromComboBox();
        }

        private void SetControlItemsAccordingWithSelectedValueFromComboBox()
        {
            object[] date = new object[] {
            "Equal",
            "Not Equal",
            "Today",
            "This Week",
            "Older",
            "Newer",
            "Between"};
            object[] description = new object[] {
            "Equal",
            "Not Equal",
            "Contains"};
            object[] tag = new object[] {
            "All",
            "Any"};

            var field = comboBoxField.Text;
            switch (field)
            {
                case "Date":
                    {
                        textBoxValue.Visible = false;
                        comboBoxConditions.Items.Clear();
                        comboBoxConditions.Items.AddRange(date);
                        comboBoxConditions.SelectedIndex = 0;
                        dateTimePicker1.Visible = true;
                        dateTimePicker2.Visible = true;
                       break;
                    }
                case "Description":
                    {
                        comboBoxConditions.Items.Clear();
                        comboBoxConditions.Items.AddRange(description);
                        comboBoxConditions.SelectedIndex = 0;
                        dateTimePicker1.Visible = false;
                        dateTimePicker2.Visible =false;
                        textBoxValue.Visible = true;
                        break;
                    }
                case "Tag":
                    {
                        comboBoxConditions.Items.Clear();
                        comboBoxConditions.Items.AddRange(tag);
                        comboBoxConditions.SelectedIndex = 0;
                        dateTimePicker1.Visible = false;
                        dateTimePicker2.Visible = false;
                        textBoxValue.Visible = true;
                        break;
                    }
            }
        }

        private void comboBoxConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBoxField.Text == "Date") && (comboBoxConditions.Text == "Between"))
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else
            if ((comboBoxField.Text == "Date") &&( (comboBoxConditions.Text == "Today")|| (comboBoxConditions.Text == "This Week")))
                {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = false;

            }

            }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxField.SelectedItem != null)
            {
                field = comboBoxField.Text.ToLower();
                switch (field)
                {
                    case "date": { SetParameterToFilteringByDate(); break; }
                    case "description": { SetParameterToFilteringByDescription(); break; }
                    case "tag": { SetParameterToSearchTags(); break; }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(string.Format("Filter Property should be selected !"), "Validation error", MessageBoxButtons.OK);
            }
       }

        private void SetParameterToSearchTags()
        {
            operators = comboBoxConditions.Text.ToLower();
           
            //var allTags = textBoxValue.Text.Split(' ');
            //values = allTags.Distinct().ToArray();

            //checkedListBoxTags new
          
        }

        private void SetParameterToFilteringByDescription()
        {
            operators = comboBoxConditions.Text.ToLower();
            values = new string[] { textBoxValue.Text };
        }

        private void SetParameterToFilteringByDate()
        {
            operators = comboBoxConditions.Text.ToLower();
            if (operators == "this week")
            {
                operators = "<>";
                string Today = DateTime.Today.ToShortDateString();
                string beginDate, endDate;
                Calendar.Utils.GetBeginEndDaysOfWeek(Today, out beginDate, out endDate);
                values = new string[] { beginDate, endDate };
            }
            else
            {
                values = new string[] { dateTimePicker1.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd") };
            };
        }
    }
    }

