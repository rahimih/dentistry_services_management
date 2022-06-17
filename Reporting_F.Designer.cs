namespace PIHO_DENTIST_SOFTWARE
{
    partial class Reporting_F
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporting_F));
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark1 = new Telerik.WinControls.UI.RadPrintWatermark();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.persianDateTimePicker3 = new FreeControls.PersianDateTimePicker();
            this.persianDateTimePicker2 = new FreeControls.PersianDateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Search_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.radPrintDocument1 = new Telerik.WinControls.UI.RadPrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 520);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1271, 30);
            this.panel2.TabIndex = 19;
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView1.Location = new System.Drawing.Point(0, 59);
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
            this.radGridView1.Size = new System.Drawing.Size(1271, 491);
            this.radGridView1.TabIndex = 18;
            this.radGridView1.Text = "radGridView1";
            // 
            // persianDateTimePicker3
            // 
            this.persianDateTimePicker3.BackColor = System.Drawing.Color.White;
            this.persianDateTimePicker3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.persianDateTimePicker3.Location = new System.Drawing.Point(97, 22);
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
            this.persianDateTimePicker2.Location = new System.Drawing.Point(338, 22);
            this.persianDateTimePicker2.Name = "persianDateTimePicker2";
            this.persianDateTimePicker2.ShowTime = false;
            this.persianDateTimePicker2.Size = new System.Drawing.Size(175, 31);
            this.persianDateTimePicker2.TabIndex = 13;
            this.persianDateTimePicker2.Text = "persianDateTimePicker2";
            this.persianDateTimePicker2.Value = ((FreeControls.PersianDate)(resources.GetObject("persianDateTimePicker2.Value")));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(278, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "تا تاریخ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(519, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 24);
            this.label10.TabIndex = 11;
            this.label10.Text = "از تاریخ";
            // 
            // Search_button
            // 
            this.Search_button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.arrow_icon71;
            this.Search_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search_button.Location = new System.Drawing.Point(55, 21);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(39, 35);
            this.Search_button.TabIndex = 10;
            this.Search_button.UseVisualStyleBackColor = true;
            this.Search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.persianDateTimePicker3);
            this.groupBox1.Controls.Add(this.persianDateTimePicker2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Search_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(690, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 59);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.images5;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(17, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 35);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 59);
            this.panel1.TabIndex = 17;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // radPrintDocument1
            // 
            this.radPrintDocument1.AssociatedObject = this.radGridView1;
            this.radPrintDocument1.DocumentName = "سازمان بهداشت و درمان صنعت نفت";
            this.radPrintDocument1.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radPrintDocument1.HeaderFont = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.radPrintDocument1.Landscape = true;
            this.radPrintDocument1.PaperSize = ((System.Drawing.Printing.PaperSize)(resources.GetObject("radPrintDocument1.PaperSize")));
            this.radPrintDocument1.RightHeader = "درمانگاه دندانپزشکی";
            this.radPrintDocument1.Watermark = radPrintWatermark1;
            // 
            // Reporting_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reporting_F";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reporting_F_FormClosing);
            this.Load += new System.EventHandler(this.Reporting_F_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Search_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Telerik.WinControls.UI.RadPrintDocument radPrintDocument1;
        public FreeControls.PersianDateTimePicker persianDateTimePicker3;
        public FreeControls.PersianDateTimePicker persianDateTimePicker2;
    }
}