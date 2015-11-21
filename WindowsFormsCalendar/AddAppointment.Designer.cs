using Calendar;
using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsCalendar
{
    partial class AddAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label_Saving = new System.Windows.Forms.Label();
            this.richTextBox_Description = new System.Windows.Forms.RichTextBox();
            this.descritption_label = new System.Windows.Forms.Label();
            this.textbox_Subject = new System.Windows.Forms.TextBox();
            this.select_label = new System.Windows.Forms.Label();
            this.subject_label = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(16, 64);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(253, 26);
            this.dateTimePicker.TabIndex = 19;
            // 
            // label_Saving
            // 
            this.label_Saving.AutoSize = true;
            this.label_Saving.Location = new System.Drawing.Point(12, 273);
            this.label_Saving.Name = "label_Saving";
            this.label_Saving.Size = new System.Drawing.Size(69, 20);
            this.label_Saving.TabIndex = 22;
            this.label_Saving.Text = "Saving...";
            this.label_Saving.Visible = false;
            // 
            // richTextBox_Description
            // 
            this.richTextBox_Description.Location = new System.Drawing.Point(289, 157);
            this.richTextBox_Description.Name = "richTextBox_Description";
            this.richTextBox_Description.Size = new System.Drawing.Size(224, 136);
            this.richTextBox_Description.TabIndex = 16;
            this.richTextBox_Description.Text = "";
            // 
            // descritption_label
            // 
            this.descritption_label.AutoSize = true;
            this.descritption_label.Location = new System.Drawing.Point(299, 118);
            this.descritption_label.Name = "descritption_label";
            this.descritption_label.Size = new System.Drawing.Size(89, 20);
            this.descritption_label.TabIndex = 15;
            this.descritption_label.Text = "Description";
            // 
            // textbox_Subject
            // 
            this.textbox_Subject.Location = new System.Drawing.Point(289, 66);
            this.textbox_Subject.Name = "textbox_Subject";
            this.textbox_Subject.Size = new System.Drawing.Size(184, 26);
            this.textbox_Subject.TabIndex = 17;
            // 
            // select_label
            // 
            this.select_label.AutoSize = true;
            this.select_label.Location = new System.Drawing.Point(12, 20);
            this.select_label.Name = "select_label";
            this.select_label.Size = new System.Drawing.Size(130, 20);
            this.select_label.TabIndex = 18;
            this.select_label.Text = "Plese select date";
            // 
            // subject_label
            // 
            this.subject_label.AutoSize = true;
            this.subject_label.Location = new System.Drawing.Point(299, 20);
            this.subject_label.Name = "subject_label";
            this.subject_label.Size = new System.Drawing.Size(63, 20);
            this.subject_label.TabIndex = 14;
            this.subject_label.Text = "Subject";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(337, 332);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(155, 39);
            this.button_Cancel.TabIndex = 21;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click_1);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(134, 332);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(124, 39);
            this.button_Save.TabIndex = 20;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 403);
            this.ControlBox = false;
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label_Saving);
            this.Controls.Add(this.richTextBox_Description);
            this.Controls.Add(this.descritption_label);
            this.Controls.Add(this.textbox_Subject);
            this.Controls.Add(this.select_label);
            this.Controls.Add(this.subject_label);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAppointment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (IsValidTitleFiled())
            {
                label_Saving.Visible = true;
                string date = dateTimePicker.Value.ToString("yyyy-MM-dd");
                string title = textbox_Subject.Text;
                string description = richTextBox_Description.Text;

                IOConsole newEvent = new IOConsole();
                newEvent.AddDataFromConsole(date, title, description);
                                
                Thread.Sleep(3000);
                this.Close();
            }

        }
        private bool IsValidTitleFiled()
        {
            if (string.IsNullOrWhiteSpace(textbox_Subject.Text))
            {
                textbox_Subject.Focus();
                var fieldName = textbox_Subject.Name.Substring(8);
                MessageBox.Show(string.Format("Field '{0}' cannot be empty.", fieldName), "Validation error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label_Saving;
        private System.Windows.Forms.RichTextBox richTextBox_Description;
        private System.Windows.Forms.Label descritption_label;
        private System.Windows.Forms.TextBox textbox_Subject;
        private System.Windows.Forms.Label select_label;
        private System.Windows.Forms.Label subject_label;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
    }
}