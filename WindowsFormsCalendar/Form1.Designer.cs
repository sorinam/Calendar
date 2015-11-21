using System;

namespace WindowsFormsCalendar
{
    partial class Form1
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button_Add = new System.Windows.Forms.Button();
            this.subject_label = new System.Windows.Forms.Label();
            this.descritption_label = new System.Windows.Forms.Label();
            this.richTextBox_Description = new System.Windows.Forms.RichTextBox();
            this.textbox_Subject = new System.Windows.Forms.TextBox();
            this.select_label = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_Saving = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(38, 46);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // button_Add
            // 
            this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Add.Location = new System.Drawing.Point(435, 46);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(184, 47);
            this.button_Add.TabIndex = 1;
            this.button_Add.Text = "New appointment";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.New_Click);
            // 
            // subject_label
            // 
            this.subject_label.AutoSize = true;
            this.subject_label.Location = new System.Drawing.Point(298, 31);
            this.subject_label.Name = "subject_label";
            this.subject_label.Size = new System.Drawing.Size(63, 20);
            this.subject_label.TabIndex = 2;
            this.subject_label.Text = "Subject";
            this.subject_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // descritption_label
            // 
            this.descritption_label.AutoSize = true;
            this.descritption_label.Location = new System.Drawing.Point(298, 129);
            this.descritption_label.Name = "descritption_label";
            this.descritption_label.Size = new System.Drawing.Size(89, 20);
            this.descritption_label.TabIndex = 3;
            this.descritption_label.Text = "Description";
            this.descritption_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // richTextBox_Description
            // 
            this.richTextBox_Description.Location = new System.Drawing.Point(288, 168);
            this.richTextBox_Description.Name = "richTextBox_Description";
            this.richTextBox_Description.Size = new System.Drawing.Size(224, 136);
            this.richTextBox_Description.TabIndex = 4;
            this.richTextBox_Description.Text = "";
            this.richTextBox_Description.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textbox_Subject
            // 
            this.textbox_Subject.Location = new System.Drawing.Point(288, 77);
            this.textbox_Subject.Name = "textbox_Subject";
            this.textbox_Subject.Size = new System.Drawing.Size(184, 26);
            this.textbox_Subject.TabIndex = 5;
            this.textbox_Subject.TextChanged += new System.EventHandler(this.title_textBox_TextChanged);
            // 
            // select_label
            // 
            this.select_label.AutoSize = true;
            this.select_label.Location = new System.Drawing.Point(11, 31);
            this.select_label.Name = "select_label";
            this.select_label.Size = new System.Drawing.Size(130, 20);
            this.select_label.TabIndex = 6;
            this.select_label.Text = "Plese select date";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(15, 75);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(253, 26);
            this.dateTimePicker.TabIndex = 7;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.dateTimePicker);
            this.panel2.Controls.Add(this.label_Saving);
            this.panel2.Controls.Add(this.richTextBox_Description);
            this.panel2.Controls.Add(this.descritption_label);
            this.panel2.Controls.Add(this.textbox_Subject);
            this.panel2.Controls.Add(this.select_label);
            this.panel2.Controls.Add(this.subject_label);
            this.panel2.Location = new System.Drawing.Point(62, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 320);
            this.panel2.TabIndex = 9;
            this.panel2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 278);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(15, 26);
            this.textBox1.TabIndex = 13;
            this.textBox1.Visible = false;
            // 
            // label_Saving
            // 
            this.label_Saving.AutoSize = true;
            this.label_Saving.Location = new System.Drawing.Point(11, 284);
            this.label_Saving.Name = "label_Saving";
            this.label_Saving.Size = new System.Drawing.Size(69, 20);
            this.label_Saving.TabIndex = 12;
            this.label_Saving.Text = "Saving...";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(178, 474);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(124, 39);
            this.button_Save.TabIndex = 10;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Visible = false;
            this.button_Save.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(381, 474);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(155, 39);
            this.button_Cancel.TabIndex = 11;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Visible = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 569);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Form1";
            this.Text = "Calendar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void title_textBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label subject_label;
        private System.Windows.Forms.Label descritption_label;
        private System.Windows.Forms.RichTextBox richTextBox_Description;
        private System.Windows.Forms.TextBox textbox_Subject;
        private System.Windows.Forms.Label select_label;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Saving;
        private System.Windows.Forms.TextBox textBox1;
    }
}

