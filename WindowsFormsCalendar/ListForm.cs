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
      
        private void ListForm_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView2.DataSource = null;
            dataGridView2.Update();
            dataGridView2.Refresh();

            string parameter = comboBox1.SelectedItem.ToString();
            Events eventsToDisplay =MainForm. GetEventsToList(parameter);
            eventsToDisplay.Sort();
            foreach (Event ev in eventsToDisplay)
            {
                bindingSource_List.Add(ev);
            }

            textBox_Total.Text = eventsToDisplay.Length.ToString();

            dataGridView2.DataSource = bindingSource_List;
            dataGridView2.Visible = true;
            label_Total.Visible = true;
            textBox_Total.Visible = true;
            dataGridView2.Update();
            dataGridView2.Refresh();
            dataGridView2.Parent.Refresh();
        }

    }
}
