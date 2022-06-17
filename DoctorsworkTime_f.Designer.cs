namespace PIHO_DENTIST_SOFTWARE
{
    partial class DoctorsworkTime_f
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorsworkTime_f));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.persianDateTimePicker1 = new FreeControls.PersianDateTimePicker();
            this.ToTime_maskedit = new System.Windows.Forms.MaskedTextBox();
            this.FromTime_maskedit = new System.Windows.Forms.MaskedTextBox();
            this.Shift_comboBox = new System.Windows.Forms.ComboBox();
            this.Kind_comboBox = new System.Windows.Forms.ComboBox();
            this.doctors_comboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.persianDateTimePicker3 = new FreeControls.PersianDateTimePicker();
            this.persianDateTimePicker2 = new FreeControls.PersianDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Search_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.Del_Button = new System.Windows.Forms.Button();
            this.edit_Button = new System.Windows.Forms.Button();
            this.Ins_Button = new System.Windows.Forms.Button();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.persianDateTimePicker1);
            this.panel2.Controls.Add(this.ToTime_maskedit);
            this.panel2.Controls.Add(this.FromTime_maskedit);
            this.panel2.Controls.Add(this.Shift_comboBox);
            this.panel2.Controls.Add(this.Kind_comboBox);
            this.panel2.Controls.Add(this.doctors_comboBox);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 144);
            this.panel2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(381, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.Value = new System.DateTime(2014, 7, 8, 0, 0, 0, 0);
            this.dateTimePicker1.Visible = false;
            // 
            // persianDateTimePicker1
            // 
            this.persianDateTimePicker1.BackColor = System.Drawing.Color.White;
            this.persianDateTimePicker1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.persianDateTimePicker1.Location = new System.Drawing.Point(524, 16);
            this.persianDateTimePicker1.Name = "persianDateTimePicker1";
            this.persianDateTimePicker1.ShowTime = false;
            this.persianDateTimePicker1.Size = new System.Drawing.Size(164, 31);
            this.persianDateTimePicker1.TabIndex = 7;
            this.persianDateTimePicker1.Text = "persianDateTimePicker1";
            this.persianDateTimePicker1.Value = ((FreeControls.PersianDate)(resources.GetObject("persianDateTimePicker1.Value")));
            // 
            // ToTime_maskedit
            // 
            this.ToTime_maskedit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.ToTime_maskedit.Location = new System.Drawing.Point(39, 88);
            this.ToTime_maskedit.Mask = "00:00";
            this.ToTime_maskedit.Name = "ToTime_maskedit";
            this.ToTime_maskedit.Size = new System.Drawing.Size(164, 33);
            this.ToTime_maskedit.TabIndex = 6;
            this.ToTime_maskedit.ValidatingType = typeof(System.DateTime);
            // 
            // FromTime_maskedit
            // 
            this.FromTime_maskedit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.FromTime_maskedit.Location = new System.Drawing.Point(524, 88);
            this.FromTime_maskedit.Mask = "00:00";
            this.FromTime_maskedit.Name = "FromTime_maskedit";
            this.FromTime_maskedit.Size = new System.Drawing.Size(164, 33);
            this.FromTime_maskedit.TabIndex = 5;
            this.FromTime_maskedit.ValidatingType = typeof(System.DateTime);
            this.FromTime_maskedit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FromTime_maskedit_KeyDown);
            // 
            // Shift_comboBox
            // 
            this.Shift_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Shift_comboBox.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Shift_comboBox.FormattingEnabled = true;
            this.Shift_comboBox.Location = new System.Drawing.Point(990, 88);
            this.Shift_comboBox.Name = "Shift_comboBox";
            this.Shift_comboBox.Size = new System.Drawing.Size(164, 32);
            this.Shift_comboBox.TabIndex = 4;
            this.Shift_comboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox3_KeyDown);
            // 
            // Kind_comboBox
            // 
            this.Kind_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Kind_comboBox.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Kind_comboBox.FormattingEnabled = true;
            this.Kind_comboBox.Items.AddRange(new object[] {
            "کار",
            "استراحت"});
            this.Kind_comboBox.Location = new System.Drawing.Point(39, 16);
            this.Kind_comboBox.Name = "Kind_comboBox";
            this.Kind_comboBox.Size = new System.Drawing.Size(164, 32);
            this.Kind_comboBox.TabIndex = 3;
            this.Kind_comboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox2_KeyDown);
            // 
            // doctors_comboBox
            // 
            this.doctors_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctors_comboBox.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.doctors_comboBox.FormattingEnabled = true;
            this.doctors_comboBox.Location = new System.Drawing.Point(990, 15);
            this.doctors_comboBox.Name = "doctors_comboBox";
            this.doctors_comboBox.Size = new System.Drawing.Size(164, 32);
            this.doctors_comboBox.TabIndex = 1;
            this.doctors_comboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(226, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 24);
            this.label12.TabIndex = 5;
            this.label12.Text = "تا ساعت";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.Location = new System.Drawing.Point(1204, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 24);
            this.label11.TabIndex = 4;
            this.label11.Text = "شیفت";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(714, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 24);
            this.label10.TabIndex = 3;
            this.label10.Text = "تاریخ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(698, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "از ساعت";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(250, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "نوع";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(1184, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "نام پزشک";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.cancel_button);
            this.panel4.Controls.Add(this.Del_Button);
            this.panel4.Controls.Add(this.edit_Button);
            this.panel4.Controls.Add(this.Ins_Button);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1284, 86);
            this.panel4.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.persianDateTimePicker3);
            this.groupBox1.Controls.Add(this.persianDateTimePicker2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Search_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(734, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 82);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // persianDateTimePicker3
            // 
            this.persianDateTimePicker3.BackColor = System.Drawing.Color.White;
            this.persianDateTimePicker3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.persianDateTimePicker3.Location = new System.Drawing.Point(62, 29);
            this.persianDateTimePicker3.Name = "persianDateTimePicker3";
            this.persianDateTimePicker3.ShowTime = false;
            this.persianDateTimePicker3.Size = new System.Drawing.Size(175, 31);
            this.persianDateTimePicker3.TabIndex = 14;
            this.persianDateTimePicker3.Text = "persianDateTimePicker3";
            this.persianDateTimePicker3.Value = ((FreeControls.PersianDate)(resources.GetObject("persianDateTimePicker3.Value")));
            // 
            // persianDateTimePicker2
            // 
            this.persianDateTimePicker2.BackColor = System.Drawing.Color.White;
            this.persianDateTimePicker2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.persianDateTimePicker2.Location = new System.Drawing.Point(303, 29);
            this.persianDateTimePicker2.Name = "persianDateTimePicker2";
            this.persianDateTimePicker2.ShowTime = false;
            this.persianDateTimePicker2.Size = new System.Drawing.Size(175, 31);
            this.persianDateTimePicker2.TabIndex = 13;
            this.persianDateTimePicker2.Text = "persianDateTimePicker2";
            this.persianDateTimePicker2.Value = ((FreeControls.PersianDate)(resources.GetObject("persianDateTimePicker2.Value")));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(243, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "تا تاریخ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(484, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "از تاریخ";
            // 
            // Search_button
            // 
            this.Search_button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.arrow_icon71;
            this.Search_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search_button.Location = new System.Drawing.Point(16, 28);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(39, 35);
            this.Search_button.TabIndex = 10;
            this.Search_button.UseVisualStyleBackColor = true;
            this.Search_button.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cancel_button
            // 
            this.cancel_button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.del1;
            this.cancel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_button.Enabled = false;
            this.cancel_button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.cancel_button.Location = new System.Drawing.Point(226, 3);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 75);
            this.cancel_button.TabIndex = 4;
            this.cancel_button.Text = "انصراف";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // Del_Button
            // 
            this.Del_Button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.del4;
            this.Del_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Del_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.Del_Button.Location = new System.Drawing.Point(151, 3);
            this.Del_Button.Name = "Del_Button";
            this.Del_Button.Size = new System.Drawing.Size(75, 75);
            this.Del_Button.TabIndex = 2;
            this.Del_Button.Text = "حذف";
            this.Del_Button.UseVisualStyleBackColor = true;
            this.Del_Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // edit_Button
            // 
            this.edit_Button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.Insicons4;
            this.edit_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edit_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.edit_Button.Location = new System.Drawing.Point(78, 3);
            this.edit_Button.Name = "edit_Button";
            this.edit_Button.Size = new System.Drawing.Size(75, 75);
            this.edit_Button.TabIndex = 1;
            this.edit_Button.Text = "ویرایش";
            this.edit_Button.UseVisualStyleBackColor = true;
            this.edit_Button.Click += new System.EventHandler(this.edit_Button_Click);
            // 
            // Ins_Button
            // 
            this.Ins_Button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.Insicons2;
            this.Ins_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ins_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.Ins_Button.Location = new System.Drawing.Point(3, 3);
            this.Ins_Button.Name = "Ins_Button";
            this.Ins_Button.Size = new System.Drawing.Size(75, 75);
            this.Ins_Button.TabIndex = 0;
            this.Ins_Button.Text = "ثبت";
            this.Ins_Button.UseVisualStyleBackColor = true;
            this.Ins_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView1.Location = new System.Drawing.Point(0, 86);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(1284, 326);
            this.radGridView1.TabIndex = 4;
            this.radGridView1.Text = "radGridView1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem1.Text = "ثبت";
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem2.Text = "ویرایش";
            this.toolStripMenuItem2.Visible = false;
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem3.Text = "حذف";
            this.toolStripMenuItem3.Visible = false;
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem4.Text = "انصراف";
            this.toolStripMenuItem4.Visible = false;
            // 
            // DoctorsworkTime_f
            // 
            this.ClientSize = new System.Drawing.Size(1284, 556);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoctorsworkTime_f";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ساعات حضور وغیاب پزشک";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoctorsworkTime_f_FormClosing);
            this.Load += new System.EventHandler(this.DoctorsworkTime_f_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Shift_comboBox;
        private System.Windows.Forms.ComboBox Kind_comboBox;
        private System.Windows.Forms.ComboBox doctors_comboBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Del_Button;
        private System.Windows.Forms.Button edit_Button;
        private System.Windows.Forms.Button Ins_Button;
        private System.Windows.Forms.MaskedTextBox ToTime_maskedit;
        private System.Windows.Forms.MaskedTextBox FromTime_maskedit;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Search_button;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        public FreeControls.PersianDateTimePicker persianDateTimePicker1;
        public FreeControls.PersianDateTimePicker persianDateTimePicker3;
        public FreeControls.PersianDateTimePicker persianDateTimePicker2;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        
    }
}