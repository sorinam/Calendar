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
            AddAppointment newform = new AddAppointment();
            newform.Show();
          }

        private void Form1_Load(object sender, EventArgs e)
        {
            string today = DateTime.Today.ToShortDateString();
            textBox_Today.Text = today;
            TXTFile files = new TXTFile();
            Events eventsList = files.LoadEventsFromFile();
            string criteria = Utils.ParseFilteringCriteria("today");
            
            Events eventsToExport =Dispenser. SimpleDateFiltering(eventsList, criteria, DateTime.Today.ToShortDateString());
            Dispenser.ExportToHTMLFile(@"today.html", eventsToExport);
            foreach (Event ev in eventsToExport)
            { textBox1.Text = ev.Title;
                textBox2.Text = ev.Description;
            }  
        }

        private void label_Today_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
