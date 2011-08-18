namespace Othello
{
    partial class Player_mode
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
            this.SingleButton = new System.Windows.Forms.Button();
            this.TwoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.WhiteChk = new System.Windows.Forms.RadioButton();
            this.BlackChk = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SingleButton
            // 
            this.SingleButton.Location = new System.Drawing.Point(19, 19);
            this.SingleButton.Name = "SingleButton";
            this.SingleButton.Size = new System.Drawing.Size(197, 23);
            this.SingleButton.TabIndex = 0;
            this.SingleButton.Text = "Single player";
            this.SingleButton.UseVisualStyleBackColor = true;
            this.SingleButton.Click += new System.EventHandler(this.SingleButton_Click);
            // 
            // TwoButton
            // 
            this.TwoButton.Location = new System.Drawing.Point(41, 184);
            this.TwoButton.Name = "TwoButton";
            this.TwoButton.Size = new System.Drawing.Size(197, 23);
            this.TwoButton.TabIndex = 0;
            this.TwoButton.Text = "Two player";
            this.TwoButton.UseVisualStyleBackColor = true;
            this.TwoButton.Click += new System.EventHandler(this.TwoButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Which mode you want to play?";
            // 
            // WhiteChk
            // 
            this.WhiteChk.AutoSize = true;
            this.WhiteChk.Location = new System.Drawing.Point(19, 55);
            this.WhiteChk.Name = "WhiteChk";
            this.WhiteChk.Size = new System.Drawing.Size(53, 17);
            this.WhiteChk.TabIndex = 2;
            this.WhiteChk.TabStop = true;
            this.WhiteChk.Text = "White";
            this.WhiteChk.UseVisualStyleBackColor = true;
           
            // 
            // BlackChk
            // 
            this.BlackChk.AutoSize = true;
            this.BlackChk.Location = new System.Drawing.Point(19, 81);
            this.BlackChk.Name = "BlackChk";
            this.BlackChk.Size = new System.Drawing.Size(52, 17);
            this.BlackChk.TabIndex = 2;
            this.BlackChk.TabStop = true;
            this.BlackChk.Text = "Black";
            this.BlackChk.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SingleButton);
            this.groupBox1.Controls.Add(this.BlackChk);
            this.groupBox1.Controls.Add(this.WhiteChk);
            this.groupBox1.Location = new System.Drawing.Point(22, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 121);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single Mode";
            // 
            // Player_mode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(301, 234);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TwoButton);
            this.Name = "Player_mode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mode";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SingleButton;
        private System.Windows.Forms.Button TwoButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton WhiteChk;
        private System.Windows.Forms.RadioButton BlackChk;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}