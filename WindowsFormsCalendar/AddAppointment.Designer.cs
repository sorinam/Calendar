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
            this.descritption_label = new System.Windows.Forms.Label();
            this.select_label = new System.Windows.Forms.Label();
            this.subject_label = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.textBox_Subject = new System.Windows.Forms.TextBox();
            this.richTextBox_Description = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(16, 45);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(253, 26);
            this.dateTimePicker.TabIndex = 19;
            // 
            // label_Saving
            // 
            this.label_Saving.AutoSize = true;
            this.label_Saving.Location = new System.Drawing.Point(16, 306);
            this.label_Saving.Name = "label_Saving";
            this.label_Saving.Size = new System.Drawing.Size(69, 20);
            this.label_Saving.TabIndex = 22;
            this.label_Saving.Text = "Saving...";
            this.label_Saving.Visible = false;
            // 
            // descritption_label
            // 
            this.descritption_label.AutoSize = true;
            this.descritption_label.Location = new System.Drawing.Point(298, 98);
            this.descritption_label.Name = "descritption_label";
            this.descritption_label.Size = new System.Drawing.Size(89, 20);
            this.descritption_label.TabIndex = 15;
            this.descritption_label.Text = "Description";
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
            this.subject_label.Location = new System.Drawing.Point(298, 20);
            this.subject_label.Name = "subject_label";
            this.subject_label.Size = new System.Drawing.Size(63, 20);
            this.subject_label.TabIndex = 14;
            this.subject_label.Text = "Subject";
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(344, 332);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(154, 38);
            this.button_Cancel.TabIndex = 21;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Save
            // 
            this.button_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Save.Location = new System.Drawing.Point(91, 332);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(124, 38);
            this.button_Save.TabIndex = 20;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // textBox_Subject
            // 
            this.textBox_Subject.Location = new System.Drawing.Point(303, 45);
            this.textBox_Subject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Subject.Name = "textBox_Subject";
            this.textBox_Subject.Size = new System.Drawing.Size(210, 26);
            this.textBox_Subject.TabIndex = 23;
            // 
            // richTextBox_Description
            // 
            this.richTextBox_Description.AcceptsTab = true;
            this.richTextBox_Description.Location = new System.Drawing.Point(303, 123);
            this.richTextBox_Description.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox_Description.Name = "richTextBox_Description";
            this.richTextBox_Description.Size = new System.Drawing.Size(210, 199);
            this.richTextBox_Description.TabIndex = 24;
            this.richTextBox_Description.Text = "";
            // 
            // AddAppointment
            // 
            this.AcceptButton = this.button_Save;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(532, 403);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox_Description);
            this.Controls.Add(this.textBox_Subject);
            this.Controls.Add(this.label_Saving);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.descritption_label);
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
            this.Load += new System.EventHandler(this.AddAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label_Saving;
        private System.Windows.Forms.Label descritption_label;
        private System.Windows.Forms.Label select_label;
        private System.Windows.Forms.Label subject_label;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
        private TextBox textBox_Subject;
        private RichTextBox richTextBox_Description;
    }
}