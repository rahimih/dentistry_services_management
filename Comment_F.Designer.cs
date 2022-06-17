namespace PIHO_DENTIST_SOFTWARE
{
    partial class Comment_F
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
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.Del_Button = new System.Windows.Forms.Button();
            this.edit_Button = new System.Windows.Forms.Button();
            this.Ins_Button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comment_textbox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem4.Text = "انصراف";
            this.toolStripMenuItem4.Visible = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem2.Text = "ویرایش";
            this.toolStripMenuItem2.Visible = false;
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem1.Text = "ثبت";
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 92);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem3.Text = "حذف";
            this.toolStripMenuItem3.Visible = false;
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // radGridView1
            // 
            this.radGridView1.AutoScroll = true;
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView1.Location = new System.Drawing.Point(0, 91);
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
            this.radGridView1.ReadOnly = true;
            this.radGridView1.Size = new System.Drawing.Size(842, 285);
            this.radGridView1.TabIndex = 22;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "ControlDefault";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.cancel_button);
            this.panel1.Controls.Add(this.Del_Button);
            this.panel1.Controls.Add(this.edit_Button);
            this.panel1.Controls.Add(this.Ins_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 91);
            this.panel1.TabIndex = 20;
            // 
            // cancel_button
            // 
            this.cancel_button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.del1;
            this.cancel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_button.Enabled = false;
            this.cancel_button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.cancel_button.Location = new System.Drawing.Point(226, 8);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 75);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "انصراف";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // Del_Button
            // 
            this.Del_Button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.del4;
            this.Del_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Del_Button.Enabled = false;
            this.Del_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.Del_Button.Location = new System.Drawing.Point(154, 8);
            this.Del_Button.Name = "Del_Button";
            this.Del_Button.Size = new System.Drawing.Size(75, 75);
            this.Del_Button.TabIndex = 2;
            this.Del_Button.Text = "حذف";
            this.Del_Button.UseVisualStyleBackColor = true;
            this.Del_Button.Click += new System.EventHandler(this.Del_Button_Click);
            // 
            // edit_Button
            // 
            this.edit_Button.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.Insicons4;
            this.edit_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edit_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.edit_Button.Location = new System.Drawing.Point(79, 8);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(767, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 26);
            this.label9.TabIndex = 32;
            this.label9.Text = "توضیحات";
            // 
            // comment_textbox
            // 
            this.comment_textbox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comment_textbox.Location = new System.Drawing.Point(227, 33);
            this.comment_textbox.Name = "comment_textbox";
            this.comment_textbox.Size = new System.Drawing.Size(535, 33);
            this.comment_textbox.TabIndex = 1;
            this.comment_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comment_textbox_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.comment_textbox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 376);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 101);
            this.panel2.TabIndex = 21;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(45, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(165, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "پرینت در تمامی معرفی نامه ها";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Comment_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 477);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Comment_F";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "توضیحات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Comment_F_FormClosing);
            this.Load += new System.EventHandler(this.Comment_F_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel_button;
        public System.Windows.Forms.Button Del_Button;
        private System.Windows.Forms.Button edit_Button;
        private System.Windows.Forms.Button Ins_Button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox comment_textbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}