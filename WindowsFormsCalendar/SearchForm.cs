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
        public SearchForm()
        {
            InitializeComponent();
        }

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
                    {   comboBoxConditions.Items.Clear();
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
                        listBoxValue.Visible = true;
                        break;
                    }
                case "Tag":
                    {
                        comboBoxConditions.Items.Clear();
                        comboBoxConditions.Items.AddRange(tag);
                        comboBoxConditions.SelectedIndex = 0;
                        dateTimePicker1.Visible = false;
                        dateTimePicker2.Visible = false;
                        listBoxValue.Visible = true;
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
        }
    }

