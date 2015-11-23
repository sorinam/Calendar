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
        Events eventsList;
        public MainForm()
        {
            InitializeComponent();
            TXTFile file = new TXTFile();
            eventsList = file.LoadEventsFromFile();
            //eventsList.Add(date, title, description);
            //file.SaveEventsToFile(eventsList);
        }
            private void New_Click(object sender, EventArgs e)
        {
            AddAppointment newform = new AddAppointment();
            newform.Show();
        }
          
        private void button_List_Click(object sender, EventArgs e)
        {
            ListForm newform = new ListForm();
            newform.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
           
           
            foreach (Event ev in eventsList)
            {
                listView1.Items.Add(ev.Date.ToShortDateString());
                listView1.Items.Add(ev.Title);
                listView1.Items.Add(ev.Description);
            }
        }

        
    }
}
