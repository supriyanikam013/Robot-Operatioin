
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.button20 = new System.Windows.Forms.Button();
            this.panelHeaderMaster.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeaderMaster
            // 
            this.panelHeaderMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelHeaderMaster.Controls.Add(this.button20);
            this.panelHeaderMaster.Controls.Add(this.label25);
            this.panelHeaderMaster.Location = new System.Drawing.Point(-362, -1);
            this.panelHeaderMaster.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeaderMaster.Name = "panelHeaderMaster";
            this.panelHeaderMaster.Padding = new System.Windows.Forms.Padding(30, 31, 30, 31);
            this.panelHeaderMaster.Size = new System.Drawing.Size(2049, 103);
            this.panelHeaderMaster.TabIndex = 436;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label25.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(691, 4);
            this.label25.Margin = new System.Windows.Forms.Padding(0);
            this.label25.Name = "label25";
            this.label25.Padding = new System.Windows.Forms.Padding(15);
            this.label25.Size = new System.Drawing.Size(862, 91);
            this.label25.TabIndex = 2;
            this.label25.Text = "FIRST IN FIRST OUT CHAMBER  ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(275, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 357);
            this.groupBox1.TabIndex = 437;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " PC <------> PLC";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(311, 160);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 44);
            this.textBox1.TabIndex = 34;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.White;
            this.label50.Location = new System.Drawing.Point(94, 157);
            this.label50.Margin = new System.Windows.Forms.Padding(0);
            this.label50.Name = "label50";
            this.label50.Padding = new System.Windows.Forms.Padding(9);
            this.label50.Size = new System.Drawing.Size(166, 47);
            this.label50.TabIndex = 33;
            this.label50.Text = "IP Address  :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.Color.Red;
            this.button20.Location = new System.Drawing.Point(1616, 8);
            this.button20.Margin = new System.Windows.Forms.Padding(0);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(40, 44);
            this.button20.TabIndex = 582;
            this.button20.Text = "X";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1305, 667);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelHeaderMaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button20;
    }
}