namespace PIHO_DENTIST_SOFTWARE
{
    partial class PaientView_F
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
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark1 = new Telerik.WinControls.UI.RadPrintWatermark();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaientView_F));
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.Del_Button = new System.Windows.Forms.Button();
            this.edit_Button = new System.Windows.Forms.Button();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radPrintDocument1 = new Telerik.WinControls.UI.RadPrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.cancel_button);
            this.panel3.Controls.Add(this.Del_Button);
            this.panel3.Controls.Add(this.edit_Button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1210, 100);
            this.panel3.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.images5;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("B Nazanin", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(402, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 80);
            this.button2.TabIndex = 11;
            this.button2.Text = "چاپ لیست 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.images5;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Font = new System.Drawing.Font("B Nazanin", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(321, 8);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 80);
            this.button7.TabIndex = 10;
            this.button7.Text = "چاپ لیست 1";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.images21;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("B Nazanin", 13F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(82, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 80);
            this.button1.TabIndex = 4;
            this.button1.Text = "کنسلی پزشک";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.images5;
            this.cancel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_button.Font = new System.Drawing.Font("B Nazanin", 13F, System.Drawing.FontStyle.Bold);
            this.cancel_button.Location = new System.Drawing.Point(240, 8);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(80, 80);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "چاپ نوبت";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // Del_Button
            // 
            this.Del_Button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.del4;
            this.Del_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Del_Button.Font = new System.Drawing.Font("B Nazanin", 13F, System.Drawing.FontStyle.Bold);
            this.Del_Button.Location = new System.Drawing.Point(160, 8);
            this.Del_Button.Name = "Del_Button";
            this.Del_Button.Size = new System.Drawing.Size(80, 80);
            this.Del_Button.TabIndex = 2;
            this.Del_Button.Text = "حذف";
            this.Del_Button.UseVisualStyleBackColor = true;
            this.Del_Button.Click += new System.EventHandler(this.Del_Button_Click);
            // 
            // edit_Button
            // 
            this.edit_Button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.del2;
            this.edit_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edit_Button.Font = new System.Drawing.Font("B Nazanin", 13F, System.Drawing.FontStyle.Bold);
            this.edit_Button.ForeColor = System.Drawing.Color.Black;
            this.edit_Button.Location = new System.Drawing.Point(2, 8);
            this.edit_Button.Name = "edit_Button";
            this.edit_Button.Size = new System.Drawing.Size(80, 80);
            this.edit_Button.TabIndex = 1;
            this.edit_Button.Text = "کنسلی بیمار";
            this.edit_Button.UseVisualStyleBackColor = true;
            this.edit_Button.Click += new System.EventHandler(this.edit_Button_Click);
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView1.Location = new System.Drawing.Point(0, 100);
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
            this.radGridView1.Size = new System.Drawing.Size(1210, 507);
            this.radGridView1.TabIndex = 10;
            this.radGridView1.Text = "radGridView1";
            // 
            // radPrintDocument1
            // 
            this.radPrintDocument1.AssociatedObject = this.radGridView1;
            this.radPrintDocument1.DocumentName = "گزارش آمار مراجعین به کلینیک ها";
            this.radPrintDocument1.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radPrintDocument1.FooterHeight = 10;
            this.radPrintDocument1.HeaderFont = new System.Drawing.Font("B Titr", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radPrintDocument1.Landscape = true;
            this.radPrintDocument1.LeftHeader = "درمانگاه دندانپزشکی";
            this.radPrintDocument1.MiddleFooter = "[Page #]/[Total Pages]";
            this.radPrintDocument1.Watermark = radPrintWatermark1;
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
            // PaientView_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1210, 607);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaientView_F";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "لیست بیماران نوبت داده شده پزشک";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaientView_F_FormClosing);
            this.Load += new System.EventHandler(this.PaientView_F_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button Del_Button;
        private System.Windows.Forms.Button edit_Button;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private Telerik.WinControls.UI.RadPrintDocument radPrintDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
    }
}