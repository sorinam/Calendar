using Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalendar
{
    public partial class AddAppointment : Form
    {
        Event appointment;
        public AddAppointment()
        {
            InitializeComponent();
            appointment = new Event(dateTimePicker.Value.ToShortDateString(),textBox_Subject.Text);
        }

        public Event Appointment
        { get { return appointment; } }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (IsValidTitleFiled())
            {
                label_Saving.Visible = true;
                Thread.Sleep(1000);

                string date = dateTimePicker.Value.ToString("yyyy-MM-dd");
                string title = textBox_Subject.Text;
                string description = richTextBox_Description.Text;

                appointment = new Event(date, title, description);
               // this.Close();
            }
           
        }
        private bool IsValidTitleFiled()
        {
            if (string.IsNullOrWhiteSpace(textBox_Subject.Text))
            {
                textBox_Subject.Focus();
                var fieldName = textBox_Subject.Name.Substring(8);
                MessageBox.Show(string.Format("Field '{0}' cannot be empty.", fieldName), "Validation error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {

        }
    }
}
