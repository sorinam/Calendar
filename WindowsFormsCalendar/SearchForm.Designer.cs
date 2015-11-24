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
            this.listBoxValue = new System.Windows.Forms.ListBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            this.labelOperaor = new System.Windows.Forms.Label();
            this.labelField = new System.Windows.Forms.Label();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(192, 226);
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
            this.buttonOK.Location = new System.Drawing.Point(64, 226);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 35);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseMnemonic = false;
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // listBoxValue
            // 
            this.listBoxValue.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            this.listBoxValue.FormattingEnabled = true;
            this.listBoxValue.ItemHeight = 20;
            this.listBoxValue.Location = new System.Drawing.Point(174, 142);
            this.listBoxValue.Name = "listBoxValue";
            this.listBoxValue.Size = new System.Drawing.Size(120, 24);
            this.listBoxValue.TabIndex = 13;
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.BackColor = System.Drawing.SystemColors.MenuBar;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelValue.Location = new System.Drawing.Point(60, 142);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(54, 20);
            this.labelValue.TabIndex = 12;
            this.labelValue.Text = "Value:";
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.Location = new System.Drawing.Point(172, 84);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(121, 28);
            this.comboBoxOperator.TabIndex = 11;
            // 
            // labelOperaor
            // 
            this.labelOperaor.AutoSize = true;
            this.labelOperaor.BackColor = System.Drawing.SystemColors.MenuBar;
            this.labelOperaor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperaor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelOperaor.Location = new System.Drawing.Point(54, 84);
            this.labelOperaor.Name = "labelOperaor";
            this.labelOperaor.Size = new System.Drawing.Size(76, 20);
            this.labelOperaor.TabIndex = 10;
            this.labelOperaor.Text = "Operator:";
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.BackColor = System.Drawing.SystemColors.MenuBar;
            this.labelField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelField.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelField.Location = new System.Drawing.Point(36, 33);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(93, 20);
            this.labelField.TabIndex = 9;
            this.labelField.Text = "Field Name:";
            // 
            // comboBoxField
            // 
            this.comboBoxField.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Items.AddRange(new object[] {
            "Date",
            "Title",
            "Tag"});
            this.comboBoxField.Location = new System.Drawing.Point(173, 25);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(121, 28);
            this.comboBoxField.TabIndex = 8;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(336, 319);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxValue);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.comboBoxOperator);
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
        private System.Windows.Forms.ListBox listBoxValue;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.Label labelOperaor;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.ComboBox comboBoxField;
    }
}