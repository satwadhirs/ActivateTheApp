
namespace ActiveTheApp
{
    partial class frmActiveTheApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActiveTheApp));
            this.btnactivateapp = new System.Windows.Forms.Button();
            this.lblappname = new System.Windows.Forms.Label();
            this.txtbxappexename = new System.Windows.Forms.TextBox();
            this.txtinterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelappname = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnactivateapp
            // 
            this.btnactivateapp.Location = new System.Drawing.Point(191, 85);
            this.btnactivateapp.Name = "btnactivateapp";
            this.btnactivateapp.Size = new System.Drawing.Size(99, 47);
            this.btnactivateapp.TabIndex = 0;
            this.btnactivateapp.Text = "Activate app";
            this.btnactivateapp.UseVisualStyleBackColor = true;
            this.btnactivateapp.Click += new System.EventHandler(this.btnactivateapp_Click);
            // 
            // lblappname
            // 
            this.lblappname.AutoSize = true;
            this.lblappname.Location = new System.Drawing.Point(12, 18);
            this.lblappname.Name = "lblappname";
            this.lblappname.Size = new System.Drawing.Size(111, 13);
            this.lblappname.TabIndex = 1;
            this.lblappname.Text = "Application exe name:";
            // 
            // txtbxappexename
            // 
            this.txtbxappexename.Location = new System.Drawing.Point(125, 14);
            this.txtbxappexename.Name = "txtbxappexename";
            this.txtbxappexename.Size = new System.Drawing.Size(160, 20);
            this.txtbxappexename.TabIndex = 2;
            this.txtbxappexename.Text = "Skype";
            // 
            // txtinterval
            // 
            this.txtinterval.Location = new System.Drawing.Point(125, 45);
            this.txtinterval.Name = "txtinterval";
            this.txtinterval.Size = new System.Drawing.Size(64, 20);
            this.txtinterval.TabIndex = 8;
            this.txtinterval.Text = "199";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Activate app every:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "second.";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Activate the app";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelappname});
            this.statusStrip1.Location = new System.Drawing.Point(0, 135);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(295, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelappname
            // 
            this.toolStripStatusLabelappname.Name = "toolStripStatusLabelappname";
            this.toolStripStatusLabelappname.Size = new System.Drawing.Size(107, 17);
            this.toolStripStatusLabelappname.Text = "Auto Activate App:";
            // 
            // frmActiveTheApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 157);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtinterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbxappexename);
            this.Controls.Add(this.lblappname);
            this.Controls.Add(this.btnactivateapp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActiveTheApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Active App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmActiveTheApp_FormClosing);
            this.Load += new System.EventHandler(this.frmActiveTheApp_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnactivateapp;
        private System.Windows.Forms.Label lblappname;
        private System.Windows.Forms.TextBox txtbxappexename;
        private System.Windows.Forms.TextBox txtinterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelappname;
    }
}

