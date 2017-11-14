namespace AutoShot
{
    partial class MainScreen
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
            if (disposing && (components != null)) {
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
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.checkBoxIncludeCursor = new System.Windows.Forms.CheckBox();
            this.buttonResetPath = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxLog.Location = new System.Drawing.Point(12, 75);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(420, 214);
            this.textBoxLog.TabIndex = 0;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(13, 13);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStartStop.TabIndex = 1;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(3, 6);
            this.labelPath.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(77, 13);
            this.labelPath.TabIndex = 3;
            this.labelPath.Text = "Save Directory";
            this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxIncludeCursor
            // 
            this.checkBoxIncludeCursor.AutoSize = true;
            this.checkBoxIncludeCursor.Location = new System.Drawing.Point(129, 16);
            this.checkBoxIncludeCursor.Name = "checkBoxIncludeCursor";
            this.checkBoxIncludeCursor.Size = new System.Drawing.Size(94, 17);
            this.checkBoxIncludeCursor.TabIndex = 4;
            this.checkBoxIncludeCursor.Text = "Include Cursor";
            this.checkBoxIncludeCursor.UseVisualStyleBackColor = true;
            // 
            // buttonResetPath
            // 
            this.buttonResetPath.Location = new System.Drawing.Point(341, 3);
            this.buttonResetPath.Name = "buttonResetPath";
            this.buttonResetPath.Size = new System.Drawing.Size(75, 23);
            this.buttonResetPath.TabIndex = 5;
            this.buttonResetPath.Text = "Reset";
            this.buttonResetPath.UseVisualStyleBackColor = true;
            this.buttonResetPath.Click += new System.EventHandler(this.buttonResetPath_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBoxPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetPath, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelPath, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(419, 30);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Location = new System.Drawing.Point(86, 3);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(249, 20);
            this.textBoxPath.TabIndex = 2;
            this.textBoxPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPath_KeyUp);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 301);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.checkBoxIncludeCursor);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.textBoxLog);
            this.Name = "MainScreen";
            this.Text = "AutoShot";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.CheckBox checkBoxIncludeCursor;
        private System.Windows.Forms.Button buttonResetPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}