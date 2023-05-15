
namespace Robot_Operatioin
{
    partial class Form1
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button20 = new System.Windows.Forms.Button();
            this.lblCommunicationStatus = new System.Windows.Forms.Label();
            this.lblAuth = new System.Windows.Forms.Label();
            this.lblUnm = new System.Windows.Forms.Label();
            this.lblPcPLCComm = new System.Windows.Forms.Label();
            this.lblManual = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAuthority = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.button20);
            this.panel2.Controls.Add(this.lblCommunicationStatus);
            this.panel2.Controls.Add(this.lblAuth);
            this.panel2.Controls.Add(this.lblUnm);
            this.panel2.Controls.Add(this.lblPcPLCComm);
            this.panel2.Controls.Add(this.lblManual);
            this.panel2.Controls.Add(this.lblWelcome);
            this.panel2.Controls.Add(this.lblAuthority);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1300, 127);
            this.panel2.TabIndex = 2;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.Color.Red;
            this.button20.Location = new System.Drawing.Point(1262, 0);
            this.button20.Margin = new System.Windows.Forms.Padding(0);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(36, 44);
            this.button20.TabIndex = 581;
            this.button20.Text = "X";
            this.button20.UseVisualStyleBackColor = false;
            // 
            // lblCommunicationStatus
            // 
            this.lblCommunicationStatus.BackColor = System.Drawing.Color.Gray;
            this.lblCommunicationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommunicationStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblCommunicationStatus.Location = new System.Drawing.Point(943, 84);
            this.lblCommunicationStatus.Name = "lblCommunicationStatus";
            this.lblCommunicationStatus.Size = new System.Drawing.Size(31, 25);
            this.lblCommunicationStatus.TabIndex = 579;
            // 
            // lblAuth
            // 
            this.lblAuth.AutoSize = true;
            this.lblAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuth.ForeColor = System.Drawing.Color.White;
            this.lblAuth.Location = new System.Drawing.Point(196, 50);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(227, 40);
            this.lblAuth.TabIndex = 149;
            this.lblAuth.Text = "Authorisation";
            this.lblAuth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUnm
            // 
            this.lblUnm.AutoSize = true;
            this.lblUnm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnm.ForeColor = System.Drawing.Color.White;
            this.lblUnm.Location = new System.Drawing.Point(196, 14);
            this.lblUnm.Margin = new System.Windows.Forms.Padding(10);
            this.lblUnm.Name = "lblUnm";
            this.lblUnm.Size = new System.Drawing.Size(199, 40);
            this.lblUnm.TabIndex = 150;
            this.lblUnm.Text = "User Name";
            this.lblUnm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPcPLCComm
            // 
            this.lblPcPLCComm.AutoSize = true;
            this.lblPcPLCComm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPcPLCComm.ForeColor = System.Drawing.Color.White;
            this.lblPcPLCComm.Location = new System.Drawing.Point(436, 72);
            this.lblPcPLCComm.Name = "lblPcPLCComm";
            this.lblPcPLCComm.Size = new System.Drawing.Size(501, 40);
            this.lblPcPLCComm.TabIndex = 578;
            this.lblPcPLCComm.Text = " PC <-> PLC Communication :";
            this.lblPcPLCComm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManual
            // 
            this.lblManual.AutoSize = true;
            this.lblManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManual.ForeColor = System.Drawing.Color.White;
            this.lblManual.Location = new System.Drawing.Point(497, 0);
            this.lblManual.Margin = new System.Windows.Forms.Padding(0);
            this.lblManual.Name = "lblManual";
            this.lblManual.Padding = new System.Windows.Forms.Padding(9);
            this.lblManual.Size = new System.Drawing.Size(365, 73);
            this.lblManual.TabIndex = 2;
            this.lblManual.Text = "PRODUCTION";
            this.lblManual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(12, 13);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(187, 40);
            this.lblWelcome.TabIndex = 151;
            this.lblWelcome.Text = "Welcome :";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAuthority
            // 
            this.lblAuthority.AutoSize = true;
            this.lblAuthority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAuthority.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthority.ForeColor = System.Drawing.Color.White;
            this.lblAuthority.Location = new System.Drawing.Point(12, 50);
            this.lblAuthority.Name = "lblAuthority";
            this.lblAuthority.Size = new System.Drawing.Size(179, 40);
            this.lblAuthority.TabIndex = 152;
            this.lblAuthority.Text = "Authority :";
            this.lblAuthority.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(378, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 368);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 748);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button20;
        internal System.Windows.Forms.Label lblCommunicationStatus;
        private System.Windows.Forms.Label lblAuth;
        private System.Windows.Forms.Label lblUnm;
        internal System.Windows.Forms.Label lblPcPLCComm;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblAuthority;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

