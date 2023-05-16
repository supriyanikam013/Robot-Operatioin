
namespace Robot_Operatioin
{
    partial class frmSettings
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
            this.panelHeaderMaster = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.txtPcPlcIpAddress = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelHeaderMaster.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeaderMaster
            // 
            this.panelHeaderMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelHeaderMaster.Controls.Add(this.label25);
            this.panelHeaderMaster.Location = new System.Drawing.Point(-322, -1);
            this.panelHeaderMaster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeaderMaster.Name = "panelHeaderMaster";
            this.panelHeaderMaster.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelHeaderMaster.Size = new System.Drawing.Size(1821, 82);
            this.panelHeaderMaster.TabIndex = 436;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label25.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(1012, 10);
            this.label25.Margin = new System.Windows.Forms.Padding(0);
            this.label25.Name = "label25";
            this.label25.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.label25.Size = new System.Drawing.Size(419, 63);
            this.label25.TabIndex = 2;
            this.label25.Text = "Communication IP";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnupdate);
            this.groupBox1.Controls.Add(this.txtPcPlcIpAddress);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(548, 315);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(672, 286);
            this.groupBox1.TabIndex = 437;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " PC <------> PLC";
            // 
            // btnupdate
            // 
            this.btnupdate.AutoSize = true;
            this.btnupdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnupdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(62)))));
            this.btnupdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnupdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(66)))), ((int)(((byte)(103)))));
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnupdate.Location = new System.Drawing.Point(276, 206);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Padding = new System.Windows.Forms.Padding(18, 8, 18, 8);
            this.btnupdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnupdate.Size = new System.Drawing.Size(122, 52);
            this.btnupdate.TabIndex = 585;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // txtPcPlcIpAddress
            // 
            this.txtPcPlcIpAddress.Location = new System.Drawing.Point(276, 128);
            this.txtPcPlcIpAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPcPlcIpAddress.Name = "txtPcPlcIpAddress";
            this.txtPcPlcIpAddress.Size = new System.Drawing.Size(312, 38);
            this.txtPcPlcIpAddress.TabIndex = 34;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.White;
            this.label50.Location = new System.Drawing.Point(84, 126);
            this.label50.Margin = new System.Windows.Forms.Padding(0);
            this.label50.Name = "label50";
            this.label50.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.label50.Size = new System.Drawing.Size(140, 39);
            this.label50.TabIndex = 33;
            this.label50.Text = "IP Address  :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(62)))));
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(66)))), ((int)(((byte)(103)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Location = new System.Drawing.Point(434, 206);
            this.btnExit.Margin = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(18, 8, 18, 8);
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExit.Size = new System.Drawing.Size(98, 52);
            this.btnExit.TabIndex = 586;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1726, 882);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelHeaderMaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelHeaderMaster.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderMaster;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtPcPlcIpAddress;
        internal System.Windows.Forms.Button btnupdate;
        internal System.Windows.Forms.Button btnExit;
    }
}