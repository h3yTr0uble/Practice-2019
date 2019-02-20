namespace Tanks
{
    partial class TanksForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.map = new System.Windows.Forms.PictureBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctlScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.GameStep = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.Color.Black;
            this.map.Location = new System.Drawing.Point(24, 23);
            this.map.Margin = new System.Windows.Forms.Padding(6);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(500, 500);
            this.map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.map.TabIndex = 0;
            this.map.TabStop = false;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(536, 146);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(6);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(267, 86);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.TabStop = false;
            this.btnStartGame.Text = "New Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ctlScore);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(536, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 93);
            this.panel1.TabIndex = 2;
            // 
            // ctlScore
            // 
            this.ctlScore.AutoSize = true;
            this.ctlScore.Location = new System.Drawing.Point(115, 25);
            this.ctlScore.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ctlScore.Name = "ctlScore";
            this.ctlScore.Size = new System.Drawing.Size(0, 32);
            this.ctlScore.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(536, 263);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(267, 84);
            this.button2.TabIndex = 3;
            this.button2.TabStop = false;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // GameStep
            // 
            this.GameStep.Interval = 50;
            this.GameStep.Tick += new System.EventHandler(this.GameStep_Tick);
            // 
            // TanksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(813, 548);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.map);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TanksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanks";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TanksForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ctlScore;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox map;
        public System.Windows.Forms.Timer GameStep;
    }
}

