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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, EventArgs e)
        {
            AddAppointment newform = new AddAppointment();
            newform.Show();
        }

        public static Events GetEventsToList(string parameter)
        {
            TXTFile files = new TXTFile();
            Events eventsList = files.LoadEventsFromFile();
            Events eventsToDisplay = new Events();
            if (parameter == "all")
            {
                eventsToDisplay = eventsList;
            }
            else
            {
                string criteria = Utils.ParseFilteringCriteria(parameter);
                eventsToDisplay = Dispenser.SimpleDateFiltering(eventsList, criteria, DateTime.Today.ToShortDateString());
            }
          
            return eventsToDisplay;
        }

        private void button_List_Click(object sender, EventArgs e)
        {
            ListForm newform = new ListForm();
            newform.Show();
        }

        //private void MainForm_Activated(object sender, EventArgs e)
        //{
        //   // dataGridView1.DataSource = null;
        //   //dataGridView1.Update();
        //    //dataGridView1.Refresh();
        //    string today = DateTime.Today.ToShortDateString();
        //    textBox_Today.Text = today;
        //    string parameter = "today";
        //    Events eventsToDisplay = GetEventsToList(parameter);

        //    foreach (Event ev in eventsToDisplay)
        //    {
        //        bindingSource1.Add(ev);
        //    }
        //    dataGridView1.DataSource = bindingSource1;
        //}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataGridView1.Focus();
            dataGridView1.Refresh();
         }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string today = DateTime.Today.ToShortDateString();
            textBox_Today.Text = today;
            string parameter = "today";
            Events eventsToDisplay = GetEventsToList(parameter);

            foreach (Event ev in eventsToDisplay)
            {
                bindingSource1.Add(ev);
            }
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
