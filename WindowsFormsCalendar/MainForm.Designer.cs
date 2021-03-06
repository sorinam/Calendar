﻿using System;

namespace WindowsFormsCalendar
{
    partial class MainForm
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
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.linkLabel_ExportToHTML = new System.Windows.Forms.LinkLabel();
            this.saveFileDialogHTML = new System.Windows.Forms.SaveFileDialog();
            this.labelFiltered = new System.Windows.Forms.Label();
            this.linkLabel_Clear = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Add.Location = new System.Drawing.Point(480, 17);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(160, 48);
            this.button_Add.TabIndex = 1;
            this.button_Add.Text = "New Appointment";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.New_Click);
            // 
            // button_Search
            // 
            this.button_Search.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Search.Location = new System.Drawing.Point(48, 26);
            this.button_Search.Name = "button_Search";
            this.button_Search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_Search.Size = new System.Drawing.Size(87, 38);
            this.button_Search.TabIndex = 3;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = false;
            this.button_Search.Visible = false;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Your Appointments";
            // 
            // listView1
            // 
            this.listView1.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Title,
            this.Description});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(28, 145);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(608, 447);
            this.listView1.TabIndex = 0;
            this.listView1.Text = "Date";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Date
            // 
            this.Date.Tag = "Date";
            this.Date.Text = "Date";
            this.Date.Width = 100;
            // 
            // Title
            // 
            this.Title.Tag = "Title";
            this.Title.Text = "Subject";
            this.Title.Width = 100;
            // 
            // Description
            // 
            this.Description.Tag = "Description";
            this.Description.Text = "Description";
            this.Description.Width = 202;
            // 
            // linkLabel_ExportToHTML
            // 
            this.linkLabel_ExportToHTML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_ExportToHTML.AutoSize = true;
            this.linkLabel_ExportToHTML.Location = new System.Drawing.Point(494, 92);
            this.linkLabel_ExportToHTML.Name = "linkLabel_ExportToHTML";
            this.linkLabel_ExportToHTML.Size = new System.Drawing.Size(142, 20);
            this.linkLabel_ExportToHTML.TabIndex = 8;
            this.linkLabel_ExportToHTML.TabStop = true;
            this.linkLabel_ExportToHTML.Text = "export to HTML file";
            this.linkLabel_ExportToHTML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_ExportToHTML_LinkClicked);
            // 
            // labelFiltered
            // 
            this.labelFiltered.AutoSize = true;
            this.labelFiltered.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiltered.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelFiltered.Location = new System.Drawing.Point(24, 120);
            this.labelFiltered.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFiltered.Name = "labelFiltered";
            this.labelFiltered.Size = new System.Drawing.Size(87, 20);
            this.labelFiltered.TabIndex = 9;
            this.labelFiltered.Text = "filtered list";
            this.labelFiltered.Visible = false;
            // 
            // linkLabel_Clear
            // 
            this.linkLabel_Clear.AutoSize = true;
            this.linkLabel_Clear.Location = new System.Drawing.Point(165, 118);
            this.linkLabel_Clear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel_Clear.Name = "linkLabel_Clear";
            this.linkLabel_Clear.Size = new System.Drawing.Size(98, 20);
            this.linkLabel_Clear.TabIndex = 10;
            this.linkLabel_Clear.TabStop = true;
            this.linkLabel_Clear.Text = "clear Search";
            this.linkLabel_Clear.Visible = false;
            this.linkLabel_Clear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Clear_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsCalendar.Properties.Resources.Search_icon;
            this.pictureBox1.Location = new System.Drawing.Point(261, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(48, 29);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(206, 26);
            this.textBoxSearch.TabIndex = 13;
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
            // 
            // MainForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(668, 674);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkLabel_Clear);
            this.Controls.Add(this.labelFiltered);
            this.Controls.Add(this.linkLabel_ExportToHTML);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.button_Add);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.LinkLabel linkLabel_ExportToHTML;
        private System.Windows.Forms.SaveFileDialog saveFileDialogHTML;
        private System.Windows.Forms.Label labelFiltered;
        private System.Windows.Forms.LinkLabel linkLabel_Clear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}

