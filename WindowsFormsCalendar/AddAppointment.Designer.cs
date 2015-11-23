﻿using Calendar;
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
            this.dateTimePicker.Location = new System.Drawing.Point(11, 42);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(170, 20);
            this.dateTimePicker.TabIndex = 19;
            // 
            // label_Saving
            // 
            this.label_Saving.AutoSize = true;
            this.label_Saving.Location = new System.Drawing.Point(11, 199);
            this.label_Saving.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Saving.Name = "label_Saving";
            this.label_Saving.Size = new System.Drawing.Size(49, 13);
            this.label_Saving.TabIndex = 22;
            this.label_Saving.Text = "Saving...";
            this.label_Saving.Visible = false;
            // 
            // richTextBox_Description
            // 
            this.richTextBox_Description.Location = new System.Drawing.Point(193, 102);
            this.richTextBox_Description.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_Description.Name = "richTextBox_Description";
            this.richTextBox_Description.Size = new System.Drawing.Size(151, 90);
            this.richTextBox_Description.TabIndex = 16;
            this.richTextBox_Description.Text = "";
            // 
            // descritption_label
            // 
            this.descritption_label.AutoSize = true;
            this.descritption_label.Location = new System.Drawing.Point(199, 77);
            this.descritption_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descritption_label.Name = "descritption_label";
            this.descritption_label.Size = new System.Drawing.Size(60, 13);
            this.descritption_label.TabIndex = 15;
            this.descritption_label.Text = "Description";
            // 
            // textbox_Subject
            // 
            this.textbox_Subject.Location = new System.Drawing.Point(193, 43);
            this.textbox_Subject.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_Subject.Name = "textbox_Subject";
            this.textbox_Subject.Size = new System.Drawing.Size(124, 20);
            this.textbox_Subject.TabIndex = 17;
            // 
            // select_label
            // 
            this.select_label.AutoSize = true;
            this.select_label.Location = new System.Drawing.Point(8, 13);
            this.select_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.select_label.Name = "select_label";
            this.select_label.Size = new System.Drawing.Size(88, 13);
            this.select_label.TabIndex = 18;
            this.select_label.Text = "Plese select date";
            // 
            // subject_label
            // 
            this.subject_label.AutoSize = true;
            this.subject_label.Location = new System.Drawing.Point(199, 13);
            this.subject_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subject_label.Name = "subject_label";
            this.subject_label.Size = new System.Drawing.Size(43, 13);
            this.subject_label.TabIndex = 14;
            this.subject_label.Text = "Subject";
            // 
            // button_Cancel
            // 
            this.button_Cancel.CausesValidation = false;
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(229, 216);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(103, 25);
            this.button_Cancel.TabIndex = 21;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Save
            // 
            this.button_Save.CausesValidation = false;
            this.button_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Save.Location = new System.Drawing.Point(98, 216);
            this.button_Save.Margin = new System.Windows.Forms.Padding(2);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(83, 25);
            this.button_Save.TabIndex = 20;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // AddAppointment
            // 
            this.AcceptButton = this.button_Save;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(355, 262);
            this.ControlBox = false;
            this.Controls.Add(this.label_Saving);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.richTextBox_Description);
            this.Controls.Add(this.descritption_label);
            this.Controls.Add(this.textbox_Subject);
            this.Controls.Add(this.select_label);
            this.Controls.Add(this.subject_label);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Save);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.RichTextBox richTextBox_Description;
        private System.Windows.Forms.Label descritption_label;
        private System.Windows.Forms.TextBox textbox_Subject;
        private System.Windows.Forms.Label select_label;
        private System.Windows.Forms.Label subject_label;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
    }
}