namespace Othello
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
            this.panelTable = new System.Windows.Forms.Panel();
            this.BtReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelTable
            // 
            this.panelTable.BackColor = System.Drawing.Color.Peru;
            this.panelTable.Location = new System.Drawing.Point(12, 12);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(400, 400);
            this.panelTable.TabIndex = 0;
            this.panelTable.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panelTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // BtReset
            // 
            this.BtReset.Location = new System.Drawing.Point(12, 433);
            this.BtReset.Name = "BtReset";
            this.BtReset.Size = new System.Drawing.Size(75, 23);
            this.BtReset.TabIndex = 1;
            this.BtReset.Text = "Reset";
            this.BtReset.UseVisualStyleBackColor = true;
            this.BtReset.Click += new System.EventHandler(this.BtReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 468);
            this.Controls.Add(this.BtReset);
            this.Controls.Add(this.panelTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.Button BtReset;
    }
}

