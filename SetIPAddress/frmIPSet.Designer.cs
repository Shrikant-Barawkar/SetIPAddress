namespace SetIPAddress
{
    partial class frmIPSet
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
            this.cmbPTselection = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblHostName = new System.Windows.Forms.Label();
            this.textBoxInterfaceName = new System.Windows.Forms.TextBox();
            this.textBoxNewIP = new System.Windows.Forms.TextBox();
            this.textBoxSubnetMask = new System.Windows.Forms.TextBox();
            this.textBoxGateway = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBoxHostName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbInterfaceName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbPTselection
            // 
            this.cmbPTselection.FormattingEnabled = true;
            this.cmbPTselection.Location = new System.Drawing.Point(106, 57);
            this.cmbPTselection.Name = "cmbPTselection";
            this.cmbPTselection.Size = new System.Drawing.Size(121, 21);
            this.cmbPTselection.TabIndex = 0;
            this.cmbPTselection.SelectedValueChanged += new System.EventHandler(this.cmbPTselection_SelectedValueChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(75, 282);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(103, 39);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.Location = new System.Drawing.Point(31, 60);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(69, 13);
            this.lblHostName.TabIndex = 20;
            this.lblHostName.Text = "Host Name : ";
            // 
            // textBoxInterfaceName
            // 
            this.textBoxInterfaceName.Location = new System.Drawing.Point(150, 327);
            this.textBoxInterfaceName.Name = "textBoxInterfaceName";
            this.textBoxInterfaceName.Size = new System.Drawing.Size(100, 20);
            this.textBoxInterfaceName.TabIndex = 25;
            this.textBoxInterfaceName.Visible = false;
            // 
            // textBoxNewIP
            // 
            this.textBoxNewIP.Location = new System.Drawing.Point(121, 140);
            this.textBoxNewIP.Name = "textBoxNewIP";
            this.textBoxNewIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewIP.TabIndex = 26;
            // 
            // textBoxSubnetMask
            // 
            this.textBoxSubnetMask.Location = new System.Drawing.Point(121, 170);
            this.textBoxSubnetMask.Name = "textBoxSubnetMask";
            this.textBoxSubnetMask.Size = new System.Drawing.Size(100, 20);
            this.textBoxSubnetMask.TabIndex = 27;
            // 
            // textBoxGateway
            // 
            this.textBoxGateway.Location = new System.Drawing.Point(121, 196);
            this.textBoxGateway.Name = "textBoxGateway";
            this.textBoxGateway.Size = new System.Drawing.Size(100, 20);
            this.textBoxGateway.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Interface Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Subnet Mask";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Gateway";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxHostName
            // 
            this.textBoxHostName.Location = new System.Drawing.Point(121, 88);
            this.textBoxHostName.Name = "textBoxHostName";
            this.textBoxHostName.Size = new System.Drawing.Size(100, 20);
            this.textBoxHostName.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Host Name";
            // 
            // cmbInterfaceName
            // 
            this.cmbInterfaceName.FormattingEnabled = true;
            this.cmbInterfaceName.Location = new System.Drawing.Point(120, 114);
            this.cmbInterfaceName.Name = "cmbInterfaceName";
            this.cmbInterfaceName.Size = new System.Drawing.Size(101, 21);
            this.cmbInterfaceName.TabIndex = 32;
            // 
            // frmIPSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 350);
            this.Controls.Add(this.cmbInterfaceName);
            this.Controls.Add(this.textBoxHostName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxGateway);
            this.Controls.Add(this.textBoxSubnetMask);
            this.Controls.Add(this.textBoxNewIP);
            this.Controls.Add(this.textBoxInterfaceName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cmbPTselection);
            this.Name = "frmIPSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set IP Address";
            this.Load += new System.EventHandler(this.frmIPSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPTselection;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.TextBox textBoxInterfaceName;
        private System.Windows.Forms.TextBox textBoxNewIP;
        private System.Windows.Forms.TextBox textBoxSubnetMask;
        private System.Windows.Forms.TextBox textBoxGateway;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBoxHostName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbInterfaceName;
    }
}

