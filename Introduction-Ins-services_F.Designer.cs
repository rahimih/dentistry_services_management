namespace PIHO_DENTIST_SOFTWARE
{
    partial class Introduction_services_F
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.edit_Button = new System.Windows.Forms.Button();
            this.Ins_Button = new System.Windows.Forms.Button();
            this.Services_detail_textbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.cancel_button);
            this.panel3.Controls.Add(this.edit_Button);
            this.panel3.Controls.Add(this.Ins_Button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 86);
            this.panel3.TabIndex = 16;
            // 
            // cancel_button
            // 
            this.cancel_button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.del1;
            this.cancel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_button.Enabled = false;
            this.cancel_button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.cancel_button.Location = new System.Drawing.Point(154, 4);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 75);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "انصراف";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // edit_Button
            // 
            this.edit_Button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.Insicons4;
            this.edit_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edit_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.edit_Button.Location = new System.Drawing.Point(79, 3);
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
            this.Ins_Button.Click += new System.EventHandler(this.Ins_Button_Click);
            // 
            // Services_detail_textbox
            // 
            this.Services_detail_textbox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Services_detail_textbox.Location = new System.Drawing.Point(12, 109);
            this.Services_detail_textbox.Name = "Services_detail_textbox";
            this.Services_detail_textbox.Size = new System.Drawing.Size(279, 33);
            this.Services_detail_textbox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(313, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "نام خدمت";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(325, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "وضعیت";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "فعال",
            "غیر فعال"});
            this.comboBox1.Location = new System.Drawing.Point(156, 160);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 34);
            this.comboBox1.TabIndex = 19;
            // 
            // Introduction_services_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(385, 210);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Services_detail_textbox);
            this.Controls.Add(this.label7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Introduction_services_F";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "خدمات معرفی نامه";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Introduction_services_F_FormClosing);
            this.Load += new System.EventHandler(this.Introduction_services_F_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button cancel_button;
        public System.Windows.Forms.Button edit_Button;
        public System.Windows.Forms.Button Ins_Button;
        public System.Windows.Forms.TextBox Services_detail_textbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}