namespace Tanks
{
    partial class SettingsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlSpeed = new System.Windows.Forms.TrackBar();
            this.ctlApplesCount = new System.Windows.Forms.NumericUpDown();
            this.ctlTanksCount = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctlSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlApplesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlTanksCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apples count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tanks count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed:";
            // 
            // ctlSpeed
            // 
            this.ctlSpeed.LargeChange = 1;
            this.ctlSpeed.Location = new System.Drawing.Point(235, 141);
            this.ctlSpeed.Maximum = 2;
            this.ctlSpeed.Name = "ctlSpeed";
            this.ctlSpeed.Size = new System.Drawing.Size(120, 56);
            this.ctlSpeed.TabIndex = 5;
            this.ctlSpeed.Value = 1;
            // 
            // ctlApplesCount
            // 
            this.ctlApplesCount.Location = new System.Drawing.Point(235, 26);
            this.ctlApplesCount.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ctlApplesCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ctlApplesCount.Name = "ctlApplesCount";
            this.ctlApplesCount.Size = new System.Drawing.Size(120, 38);
            this.ctlApplesCount.TabIndex = 6;
            this.ctlApplesCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ctlTanksCount
            // 
            this.ctlTanksCount.Location = new System.Drawing.Point(235, 81);
            this.ctlTanksCount.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ctlTanksCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ctlTanksCount.Name = "ctlTanksCount";
            this.ctlTanksCount.Size = new System.Drawing.Size(120, 38);
            this.ctlTanksCount.TabIndex = 7;
            this.ctlTanksCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(384, 182);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(123, 51);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 245);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ctlTanksCount);
            this.Controls.Add(this.ctlApplesCount);
            this.Controls.Add(this.ctlSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlApplesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlTanksCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar ctlSpeed;
        private System.Windows.Forms.NumericUpDown ctlApplesCount;
        private System.Windows.Forms.NumericUpDown ctlTanksCount;
        private System.Windows.Forms.Button btnOk;
    }
}