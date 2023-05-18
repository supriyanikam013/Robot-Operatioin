
namespace Robot_Operatioin
{
    partial class PlcDataReadWrite
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
            this.lblCommunicationStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.btnwrite = new System.Windows.Forms.Button();
            this.btnread = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCommunicationStatus
            // 
            this.lblCommunicationStatus.BackColor = System.Drawing.Color.Gray;
            this.lblCommunicationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommunicationStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblCommunicationStatus.Location = new System.Drawing.Point(192, 58);
            this.lblCommunicationStatus.Name = "lblCommunicationStatus";
            this.lblCommunicationStatus.Size = new System.Drawing.Size(28, 20);
            this.lblCommunicationStatus.TabIndex = 586;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 25);
            this.label3.TabIndex = 585;
            this.label3.Text = "Check connection :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 584;
            this.label1.Text = "Text Value";
            // 
            // txtvalue
            // 
            this.txtvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalue.Location = new System.Drawing.Point(159, 92);
            this.txtvalue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(232, 30);
            this.txtvalue.TabIndex = 583;
            // 
            // btnwrite
            // 
            this.btnwrite.Location = new System.Drawing.Point(269, 140);
            this.btnwrite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnwrite.Name = "btnwrite";
            this.btnwrite.Size = new System.Drawing.Size(122, 40);
            this.btnwrite.TabIndex = 582;
            this.btnwrite.Text = "Write";
            this.btnwrite.UseVisualStyleBackColor = true;
            // 
            // btnread
            // 
            this.btnread.Location = new System.Drawing.Point(159, 140);
            this.btnread.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(101, 40);
            this.btnread.TabIndex = 581;
            this.btnread.Text = "Read";
            this.btnread.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnwrite);
            this.groupBox1.Controls.Add(this.lblCommunicationStatus);
            this.groupBox1.Controls.Add(this.btnread);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtvalue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 246);
            this.groupBox1.TabIndex = 587;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // PlcDataReadWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 287);
            this.Controls.Add(this.groupBox1);
            this.Name = "PlcDataReadWrite";
            this.Text = "PlcDataReadWrite";
            this.Load += new System.EventHandler(this.PlcDataReadWrite_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblCommunicationStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtvalue;
        private System.Windows.Forms.Button btnwrite;
        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}