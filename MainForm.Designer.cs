namespace Device_Renamer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_wmi_friendly_name = new System.Windows.Forms.TextBox();
            this.txt_wmi_hwid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_wmi_manufacturer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_save_registry_friendlyname = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btn_regedit = new System.Windows.Forms.Button();
            this.btn_reset_name = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_save_registry_devicedesc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_registry_friendlyname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_registry_devicedesc = new System.Windows.Forms.TextBox();
            this.txt_registry_manufacturer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Friendly Name:";
            // 
            // txt_wmi_friendly_name
            // 
            this.txt_wmi_friendly_name.Dock = System.Windows.Forms.DockStyle.Right;
            this.txt_wmi_friendly_name.Location = new System.Drawing.Point(95, 16);
            this.txt_wmi_friendly_name.Name = "txt_wmi_friendly_name";
            this.txt_wmi_friendly_name.ReadOnly = true;
            this.txt_wmi_friendly_name.Size = new System.Drawing.Size(192, 20);
            this.txt_wmi_friendly_name.TabIndex = 3;
            // 
            // txt_wmi_hwid
            // 
            this.txt_wmi_hwid.Location = new System.Drawing.Point(58, 39);
            this.txt_wmi_hwid.Name = "txt_wmi_hwid";
            this.txt_wmi_hwid.ReadOnly = true;
            this.txt_wmi_hwid.Size = new System.Drawing.Size(226, 20);
            this.txt_wmi_hwid.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "HWID:";
            // 
            // txt_wmi_manufacturer
            // 
            this.txt_wmi_manufacturer.Location = new System.Drawing.Point(87, 65);
            this.txt_wmi_manufacturer.Name = "txt_wmi_manufacturer";
            this.txt_wmi_manufacturer.ReadOnly = true;
            this.txt_wmi_manufacturer.Size = new System.Drawing.Size(197, 20);
            this.txt_wmi_manufacturer.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Manufacturer:";
            // 
            // btn_save_registry_friendlyname
            // 
            this.btn_save_registry_friendlyname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_registry_friendlyname.AutoSize = true;
            this.btn_save_registry_friendlyname.Location = new System.Drawing.Point(250, 14);
            this.btn_save_registry_friendlyname.Name = "btn_save_registry_friendlyname";
            this.btn_save_registry_friendlyname.Size = new System.Drawing.Size(42, 23);
            this.btn_save_registry_friendlyname.TabIndex = 8;
            this.btn_save_registry_friendlyname.Text = "Save";
            this.btn_save_registry_friendlyname.UseVisualStyleBackColor = true;
            this.btn_save_registry_friendlyname.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(322, 450);
            this.treeView1.TabIndex = 9;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btn_regedit
            // 
            this.btn_regedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_regedit.AutoSize = true;
            this.btn_regedit.Location = new System.Drawing.Point(339, 415);
            this.btn_regedit.Name = "btn_regedit";
            this.btn_regedit.Size = new System.Drawing.Size(58, 23);
            this.btn_regedit.TabIndex = 10;
            this.btn_regedit.Text = "Browse";
            this.btn_regedit.UseVisualStyleBackColor = true;
            this.btn_regedit.Click += new System.EventHandler(this.btn_regedit_Click);
            // 
            // btn_reset_name
            // 
            this.btn_reset_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reset_name.AutoSize = true;
            this.btn_reset_name.Location = new System.Drawing.Point(554, 415);
            this.btn_reset_name.Name = "btn_reset_name";
            this.btn_reset_name.Size = new System.Drawing.Size(58, 23);
            this.btn_reset_name.TabIndex = 11;
            this.btn_reset_name.Text = "Reset";
            this.btn_reset_name.UseVisualStyleBackColor = true;
            this.btn_reset_name.Click += new System.EventHandler(this.btn_reset_name_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_wmi_friendly_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_wmi_hwid);
            this.groupBox1.Controls.Add(this.txt_wmi_manufacturer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(328, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WMI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_save_registry_devicedesc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_registry_friendlyname);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_registry_devicedesc);
            this.groupBox2.Controls.Add(this.txt_registry_manufacturer);
            this.groupBox2.Controls.Add(this.btn_save_registry_friendlyname);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(328, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 99);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registry";
            // 
            // btn_save_registry_devicedesc
            // 
            this.btn_save_registry_devicedesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_registry_devicedesc.AutoSize = true;
            this.btn_save_registry_devicedesc.Location = new System.Drawing.Point(250, 40);
            this.btn_save_registry_devicedesc.Name = "btn_save_registry_devicedesc";
            this.btn_save_registry_devicedesc.Size = new System.Drawing.Size(42, 23);
            this.btn_save_registry_devicedesc.TabIndex = 9;
            this.btn_save_registry_devicedesc.Text = "Save";
            this.btn_save_registry_devicedesc.UseVisualStyleBackColor = true;
            this.btn_save_registry_devicedesc.Click += new System.EventHandler(this.btn_save_registry_devicedesc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "FriendlyName:";
            // 
            // txt_registry_friendlyname
            // 
            this.txt_registry_friendlyname.Location = new System.Drawing.Point(87, 16);
            this.txt_registry_friendlyname.Name = "txt_registry_friendlyname";
            this.txt_registry_friendlyname.Size = new System.Drawing.Size(155, 20);
            this.txt_registry_friendlyname.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "DeviceDesc:";
            // 
            // txt_registry_devicedesc
            // 
            this.txt_registry_devicedesc.Location = new System.Drawing.Point(87, 42);
            this.txt_registry_devicedesc.Name = "txt_registry_devicedesc";
            this.txt_registry_devicedesc.Size = new System.Drawing.Size(155, 20);
            this.txt_registry_devicedesc.TabIndex = 5;
            // 
            // txt_registry_manufacturer
            // 
            this.txt_registry_manufacturer.Location = new System.Drawing.Point(87, 68);
            this.txt_registry_manufacturer.Name = "txt_registry_manufacturer";
            this.txt_registry_manufacturer.ReadOnly = true;
            this.txt_registry_manufacturer.Size = new System.Drawing.Size(208, 20);
            this.txt_registry_manufacturer.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Manufacturer:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_reset_name);
            this.Controls.Add(this.btn_regedit);
            this.Controls.Add(this.treeView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Device Renamer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_wmi_friendly_name;
        private System.Windows.Forms.TextBox txt_wmi_hwid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_wmi_manufacturer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_save_registry_friendlyname;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btn_regedit;
        private System.Windows.Forms.Button btn_reset_name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_registry_friendlyname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_registry_devicedesc;
        private System.Windows.Forms.TextBox txt_registry_manufacturer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_save_registry_devicedesc;
    }
}

