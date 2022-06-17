namespace PIHO_DENTIST_SOFTWARE
{
    partial class Refer_view
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Refer_view));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radGridView3 = new Telerik.WinControls.UI.RadGridView();
            this.radGridView2 = new Telerik.WinControls.UI.RadGridView();
            this.cancel_button = new System.Windows.Forms.Button();
            this.persianDateTimePicker4 = new FreeControls.PersianDateTimePicker();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView3.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancel_button);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.persianDateTimePicker4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 73);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox1.Location = new System.Drawing.Point(554, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 33);
            this.textBox1.TabIndex = 36;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(761, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 26);
            this.label4.TabIndex = 38;
            this.label4.Text = "شماره پرسنلی";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.radGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 186);
            this.panel1.TabIndex = 15;
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
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
            this.radGridView1.Size = new System.Drawing.Size(857, 182);
            this.radGridView1.TabIndex = 11;
            this.radGridView1.Text = "radGridView3";
            this.radGridView1.SelectionChanging += new Telerik.WinControls.UI.GridViewSelectionCancelEventHandler(this.radGridView1_1_SelectionChanging);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radGridView3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(439, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 292);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ارجاعات";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radGridView2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 292);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "اسکرین";
            // 
            // radGridView3
            // 
            this.radGridView3.AutoScroll = true;
            this.radGridView3.AutoSizeRows = true;
            this.radGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView3.Location = new System.Drawing.Point(3, 16);
            // 
            // radGridView3
            // 
            this.radGridView3.MasterTemplate.AllowAddNewRow = false;
            this.radGridView3.MasterTemplate.AllowDeleteRow = false;
            this.radGridView3.MasterTemplate.AllowDragToGroup = false;
            this.radGridView3.MasterTemplate.AllowEditRow = false;
            this.radGridView3.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView3.MasterTemplate.EnableFiltering = true;
            this.radGridView3.MasterTemplate.EnableGrouping = false;
            this.radGridView3.Name = "radGridView3";
            this.radGridView3.Size = new System.Drawing.Size(416, 273);
            this.radGridView3.TabIndex = 12;
            this.radGridView3.Text = "radGridView3";
            // 
            // radGridView2
            // 
            this.radGridView2.AutoScroll = true;
            this.radGridView2.AutoSizeRows = true;
            this.radGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView2.Location = new System.Drawing.Point(3, 16);
            // 
            // radGridView2
            // 
            this.radGridView2.MasterTemplate.AllowAddNewRow = false;
            this.radGridView2.MasterTemplate.AllowDeleteRow = false;
            this.radGridView2.MasterTemplate.AllowDragToGroup = false;
            this.radGridView2.MasterTemplate.AllowEditRow = false;
            this.radGridView2.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView2.MasterTemplate.EnableFiltering = true;
            this.radGridView2.MasterTemplate.EnableGrouping = false;
            this.radGridView2.Name = "radGridView2";
            this.radGridView2.Size = new System.Drawing.Size(430, 273);
            this.radGridView2.TabIndex = 12;
            this.radGridView2.Text = "radGridView3";
            // 
            // cancel_button
            // 
            this.cancel_button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.arrow_icon4;
            this.cancel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_button.Font = new System.Drawing.Font("B Nazanin", 15F, System.Drawing.FontStyle.Bold);
            this.cancel_button.Location = new System.Drawing.Point(5, 10);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(71, 62);
            this.cancel_button.TabIndex = 39;
            this.cancel_button.Text = "ارجاع";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // persianDateTimePicker4
            // 
            this.persianDateTimePicker4.BackColor = System.Drawing.Color.White;
            this.persianDateTimePicker4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.persianDateTimePicker4.Location = new System.Drawing.Point(589, 27);
            this.persianDateTimePicker4.Name = "persianDateTimePicker4";
            this.persianDateTimePicker4.ShowTime = false;
            this.persianDateTimePicker4.Size = new System.Drawing.Size(167, 31);
            this.persianDateTimePicker4.TabIndex = 50;
            this.persianDateTimePicker4.Text = "persianDateTimePicker4";
            this.persianDateTimePicker4.Value = ((FreeControls.PersianDate)(resources.GetObject("persianDateTimePicker4.Value")));
            // 
            // Refer_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(861, 551);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Refer_view";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ارجاع";
            this.Load += new System.EventHandler(this.Refer_view_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView3.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadGridView radGridView3;
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadGridView radGridView2;
        private System.Windows.Forms.Button cancel_button;
        public FreeControls.PersianDateTimePicker persianDateTimePicker4;

    }
}