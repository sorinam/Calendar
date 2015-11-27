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
        Events displayedList;
        string[] tagsList;

        public MainForm()
        {
            InitializeComponent();

            TXTFile file = new TXTFile();
            eventsList = file.LoadEventsFromFile();
            displayedList = new Calendar.Events();
            tagsList = GetTagList();
        }
        public string[] Tags
        { get { return tagsList; } }

        private void New_Click(object sender, EventArgs e)
        {
            AddAppointment newform = new AddAppointment();
            newform.ShowDialog();

            var status = newform.ActiveControl.Text;

            if (status == "Save")
            {
                var newAppointment = newform.Appointment;
                SaveNewAppointment(newAppointment);
                AddAppointmentToListView(newAppointment);
                listView1.Refresh();
            }

        }

        private void AddAppointmentToListView(Event newapp)
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
        {
            if (eventsList.Length > 0)
            {
                eventsList.Sort();
                foreach (Event ev in eventsList)
                {
                    AddAppointmentToListView(ev);
                }
            }
        }

        private void linkLabel_ExportToHTML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = "";

            if (saveFileDialogHTML.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialogHTML.FileName;
                Dispenser.ExportToHTMLFile(path, displayedList);
            }

        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            SearchForm newform = new SearchForm();
            newform.ShowDialog();

            var status = newform.ActiveControl.Text;

            if (status == "OK")
            {
                //this.displayedList = FilterAppointmentsList(newform);
                if (this.displayedList.Length > 0)
                {
                    listView1.Items.Clear();
                    this.displayedList.Sort();
                    foreach (Event ev in this.displayedList)
                    {
                        AddAppointmentToListView(ev);
                    }
                    labelFiltered.Visible = true;
                    linkLabel_Clear.Visible = true;
                    listView1.Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("No records matching the current criteria were found!"), "No records found", MessageBoxButtons.OK);
                }
            }

        }

        //private Events FilterAppointmentsList()
        //{
        //    var field = newform.Field;
        //    var operators = newform.Operators;
        //    var values = newform.Values;
        //    return Dispenser.FilterEvents(eventsList, field, operators, values);
        //}

        private string[] GetTagList()
        {
            TagsNameList tagList = new TagsNameList(eventsList);
            return tagList.TagList;
        }

        private void linkLabel_Clear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            eventsList.Sort();
            foreach (Event ev in eventsList)
            {
                AddAppointmentToListView(ev);
            }
            labelFiltered.Visible = false;
            linkLabel_Clear.Visible = false;
            listView1.Refresh();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartSearching();
            }
        }

        private void StartSearching()
        {
            {
                var values = textBoxSearch.Text.Split(' ');
                StringFilter filteredList = new StringFilter("||", values);
                this.displayedList = filteredList.ApplyFilter(eventsList);
                if (this.displayedList.Length > 0)
                {
                    listView1.Items.Clear();
                    this.displayedList.Sort();
                    foreach (Event ev in this.displayedList)
                    {
                        AddAppointmentToListView(ev);
                    }
                    labelFiltered.Visible = true;
                    linkLabel_Clear.Visible = true;
                    listView1.Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("No records matching the current criteria were found!"), "No records found", MessageBoxButtons.OK);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StartSearching();
        }
    }
}

