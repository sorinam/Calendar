using Calendar;
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
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }
      
      
        private static Events GetEventsToList(string parameter)
        {
            TXTFile files = new TXTFile();
            Events eventsList = files.LoadEventsFromFile();
            string criteria = Utils.ParseFilteringCriteria(parameter);
            Events eventsToDisplay = new Calendar.Events();
            if (criteria == "all")
            {
                eventsToDisplay = eventsList;
            }
            else
            {
                eventsToDisplay = Dispenser.SimpleDateFiltering(eventsList, criteria, DateTime.Today.ToShortDateString());
            }

            return eventsToDisplay;
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string parameter = comboBox1.SelectedItem.ToString();
            Events eventsToDisplay = GetEventsToList(parameter);
            eventsToDisplay.Sort();
            foreach (Event ev in eventsToDisplay)
            {
                bindingSource_List.Add(ev);
            }
            dataGridView2.DataSource = bindingSource_List;
            dataGridView2.Visible = true;
        }

       
    }
}
