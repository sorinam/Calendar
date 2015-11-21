using Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, EventArgs e)
        {
            button_Add.Enabled = false;
            panel2.Visible = true;
            label_Saving.Visible = false;
            monthCalendar1.Visible = false;
            dateTimePicker.Visible = true;
            select_label.Visible = true;
            subject_label.Visible = true;
            textbox_Subject.Visible = true;
            descritption_label.Visible = true;
            richTextBox_Description.Visible = true;
            button_Save.Visible = true;
            button_Cancel.Visible = true;
          }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateTitleFiled())
            {
                label_Saving.Visible = true;
                string date = dateTimePicker.Value.ToString("yyyy-MM-dd");
                string title = textbox_Subject.Text;
                string description = richTextBox_Description.Text;

                IOConsole newEvent = new IOConsole();
                newEvent.AddDataFromConsole(date, title, description);

                Thread.Sleep(1000);
                panel2.Visible = false;
                button_Save.Visible = false;
                button_Cancel.Visible = false;
                monthCalendar1.Visible = true;
            }

        }

        private bool ValidateTitleFiled()
        {
            if (string.IsNullOrWhiteSpace(textbox_Subject.Text))
            {
                textbox_Subject.Focus();
                var fieldName = textbox_Subject.Name.Substring(8);
                MessageBox.Show(string.Format("Field '{0}' cannot be empty.", fieldName),"Validation error",MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button_Save.Visible = false;
            button_Cancel.Visible = false;
            monthCalendar1.Visible = true;
            button_Add.Enabled = true;
        }
    }
}
