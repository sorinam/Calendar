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
            this.components = new System.ComponentModel.Container();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_List = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.label_Today = new System.Windows.Forms.Label();
            this.textBox_Today = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Add.Location = new System.Drawing.Point(435, 136);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(184, 47);
            this.button_Add.TabIndex = 1;
            this.button_Add.Text = "New Appointment";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.New_Click);
            // 
            // button_List
            // 
            this.button_List.Location = new System.Drawing.Point(435, 245);
            this.button_List.Name = "button_List";
            this.button_List.Size = new System.Drawing.Size(184, 44);
            this.button_List.TabIndex = 2;
            this.button_List.Text = "List Appointments";
            this.button_List.UseVisualStyleBackColor = true;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(435, 41);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(184, 40);
            this.button_Search.TabIndex = 3;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            // 
            // label_Today
            // 
            this.label_Today.AutoSize = true;
            this.label_Today.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Today.Location = new System.Drawing.Point(13, 35);
            this.label_Today.Name = "label_Today";
            this.label_Today.Size = new System.Drawing.Size(78, 22);
            this.label_Today.TabIndex = 4;
            this.label_Today.Text = "Today :";
            this.label_Today.Click += new System.EventHandler(this.label_Today_Click);
            // 
            // textBox_Today
            // 
            this.textBox_Today.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_Today.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Today.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox_Today.Location = new System.Drawing.Point(97, 31);
            this.textBox_Today.Name = "textBox_Today";
            this.textBox_Today.ReadOnly = true;
            this.textBox_Today.Size = new System.Drawing.Size(112, 26);
            this.textBox_Today.TabIndex = 5;
            this.textBox_Today.TabStop = false;
            this.textBox_Today.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Your Appointments";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(382, 240);
            this.dataGridView1.TabIndex = 10;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Subject";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = true;
            this.bindingSource1.DataSource = typeof(Calendar.Event);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 569);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Today);
            this.Controls.Add(this.label_Today);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.button_List);
            this.Controls.Add(this.button_Add);
            this.Name = "Form1";
            this.Text = "Calendar";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_List;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label_Today;
        private System.Windows.Forms.TextBox textBox_Today;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}

