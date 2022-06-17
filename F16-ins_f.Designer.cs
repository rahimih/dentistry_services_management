namespace PIHO_DENTIST_SOFTWARE
{
    partial class F16_ins_f
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
            this.Comment_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Code_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Code_numericUpDown)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(361, 95);
            this.panel3.TabIndex = 6;
            // 
            // cancel_button
            // 
            this.cancel_button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.del1;
            this.cancel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_button.Enabled = false;
            this.cancel_button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.cancel_button.Location = new System.Drawing.Point(155, 8);
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
            this.edit_Button.Location = new System.Drawing.Point(78, 8);
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
            this.Ins_Button.Location = new System.Drawing.Point(3, 8);
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
            this.Services_detail_textbox.Location = new System.Drawing.Point(12, 101);
            this.Services_detail_textbox.Name = "Services_detail_textbox";
            this.Services_detail_textbox.Size = new System.Drawing.Size(223, 33);
            this.Services_detail_textbox.TabIndex = 1;
            this.Services_detail_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Services_detail_textbox_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(296, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "نام خدمت";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(272, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "کد F16           ";
            // 
            // Comment_textBox
            // 
            this.Comment_textBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Comment_textBox.Location = new System.Drawing.Point(12, 201);
            this.Comment_textBox.Name = "Comment_textBox";
            this.Comment_textBox.Size = new System.Drawing.Size(223, 33);
            this.Comment_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(296, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "توضیحات";
            // 
            // Code_numericUpDown
            // 
            this.Code_numericUpDown.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.Code_numericUpDown.Location = new System.Drawing.Point(12, 151);
            this.Code_numericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Code_numericUpDown.Name = "Code_numericUpDown";
            this.Code_numericUpDown.Size = new System.Drawing.Size(223, 33);
            this.Code_numericUpDown.TabIndex = 2;
            this.Code_numericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Code_numericUpDown_KeyDown);
            // 
            // F16_ins_f
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(361, 247);
            this.Controls.Add(this.Code_numericUpDown);
            this.Controls.Add(this.Comment_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Services_detail_textbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F16_ins_f";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم F16";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F16_ins_f_FormClosing);
            this.Load += new System.EventHandler(this.F16_ins_f_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Code_numericUpDown)).EndInit();
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
        public System.Windows.Forms.TextBox Comment_textBox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown Code_numericUpDown;
        public System.Windows.Forms.Label label1;
    }
}