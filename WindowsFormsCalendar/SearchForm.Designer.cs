namespace WindowsFormsCalendar
{
    partial class SearchForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelValue = new System.Windows.Forms.Label();
            this.comboBoxConditions = new System.Windows.Forms.ComboBox();
            this.labelOperaor = new System.Windows.Forms.Label();
            this.labelField = new System.Windows.Forms.Label();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(246, 255);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 35);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOK.Location = new System.Drawing.Point(126, 255);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 35);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseMnemonic = false;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.BackColor = System.Drawing.SystemColors.MenuBar;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelValue.Location = new System.Drawing.Point(76, 143);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(54, 20);
            this.labelValue.TabIndex = 12;
            this.labelValue.Text = "Value:";
            // 
            // comboBoxConditions
            // 
            this.comboBoxConditions.FormattingEnabled = true;
            this.comboBoxConditions.Location = new System.Drawing.Point(198, 80);
            this.comboBoxConditions.Name = "comboBoxConditions";
            this.comboBoxConditions.Size = new System.Drawing.Size(121, 28);
            this.comboBoxConditions.TabIndex = 11;
            this.comboBoxConditions.SelectedIndexChanged += new System.EventHandler(this.comboBoxConditions_SelectedIndexChanged);
            // 
            // labelOperaor
            // 
            this.labelOperaor.AutoSize = true;
            this.labelOperaor.BackColor = System.Drawing.SystemColors.MenuBar;
            this.labelOperaor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperaor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelOperaor.Location = new System.Drawing.Point(76, 85);
            this.labelOperaor.Name = "labelOperaor";
            this.labelOperaor.Size = new System.Drawing.Size(88, 20);
            this.labelOperaor.TabIndex = 10;
            this.labelOperaor.Text = "Conditions:";
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.BackColor = System.Drawing.SystemColors.MenuBar;
            this.labelField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelField.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelField.Location = new System.Drawing.Point(76, 25);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(115, 20);
            this.labelField.TabIndex = 9;
            this.labelField.Text = "Filter Property: ";
            // 
            // comboBoxField
            // 
            this.comboBoxField.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Items.AddRange(new object[] {
            "Date",
            "Description",
            "Tag"});
            this.comboBoxField.Location = new System.Drawing.Point(198, 20);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(121, 28);
            this.comboBoxField.TabIndex = 8;
            this.comboBoxField.SelectedIndexChanged += new System.EventHandler(this.comboBoxField_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(198, 143);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(170, 26);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.Visible = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(198, 197);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(170, 26);
            this.dateTimePicker2.TabIndex = 17;
            this.dateTimePicker2.Visible = false;
            // 
            // textBoxValue
            // 
            this.textBoxValue.AcceptsReturn = true;
            this.textBoxValue.Location = new System.Drawing.Point(198, 143);
            this.textBoxValue.Multiline = true;
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(170, 26);
            this.textBoxValue.TabIndex = 18;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(432, 345);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.comboBoxConditions);
            this.Controls.Add(this.labelOperaor);
            this.Controls.Add(this.labelField);
            this.Controls.Add(this.comboBoxField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Appointments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.ComboBox comboBoxConditions;
        private System.Windows.Forms.Label labelOperaor;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBoxValue;
    }
}