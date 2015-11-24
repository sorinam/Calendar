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

        }

        private void New_Click(object sender, EventArgs e)
        {
            AddAppointment newform = new AddAppointment();
            newform.ShowDialog();
            var status = newform.DialogResult;

            if (status.ToString() == "OK")
            {
                var newapp = newform.Appointment;
                SaveNewAppointment(newapp);
                AddNewAppointementToListView(newapp);
                listView1.Refresh();
            }

        }

        private void AddNewAppointementToListView(Event newapp)
        {
            string[] arr = new string[3];
            arr[0] = newapp.Date.ToShortDateString();
            arr[1] = newapp.Title;
            arr[2] = newapp.Description;
            var items = new ListViewItem(arr);
            listView1.Items.Add(items);
        }

        private void SaveNewAppointment(Event newAppointment)
        {
            eventsList.Add(newAppointment);
            TXTFile file = new TXTFile();
            file.SaveEventsToFile(eventsList);
        }
            
        private void MainForm_Load(object sender, EventArgs e)
        {   string[] arr = new string[3];
            if (eventsList.Length > 0)
            {
                ListViewItem items;
                eventsList.Sort();
                foreach (Event ev in eventsList)
                {
                    arr[0] = ev.Date.ToShortDateString();
                    arr[1] = ev.Title;
                    arr[2] = ev.Description;
                    items = new ListViewItem(arr);
                    listView1.Items.Add(items);
                }
            }
        }
    }
}
