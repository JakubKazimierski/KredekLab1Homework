namespace JakubKazimierskiGame
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveBackground = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.LeftTimer = new System.Windows.Forms.Timer(this.components);
            this.RightTimer = new System.Windows.Forms.Timer(this.components);
            this.MunitionTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemiesTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemiesMunitionTimer = new System.Windows.Forms.Timer(this.components);
            this.EndButton = new System.Windows.Forms.Button();
            this.ReplayButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.BulletsLabel = new System.Windows.Forms.Label();
            this.SpeedLvlLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBackground
            // 
            this.MoveBackground.Enabled = true;
            this.MoveBackground.Interval = 10;
            this.MoveBackground.Tick += new System.EventHandler(this.MoveBackground_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = global::JakubKazimierskiGame.Properties.Resources.Spaceship_PNG_File___Kopia;
            this.Player.Location = new System.Drawing.Point(298, 453);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(50, 50);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // LeftTimer
            // 
            this.LeftTimer.Interval = 5;
            this.LeftTimer.Tick += new System.EventHandler(this.LeftTimer_Tick);
            // 
            // RightTimer
            // 
            this.RightTimer.Interval = 5;
            this.RightTimer.Tick += new System.EventHandler(this.RightTimer_Tick);
            // 
            // MunitionTimer
            // 
            this.MunitionTimer.Interval = 31;
            this.MunitionTimer.Tick += new System.EventHandler(this.MunitionTimer_Tick);
            // 
            // MoveEnemiesTimer
            // 
            this.MoveEnemiesTimer.Enabled = true;
            this.MoveEnemiesTimer.Tick += new System.EventHandler(this.MoveEnemiesTimer_Tick);
            // 
            // EnemiesMunitionTimer
            // 
            this.EnemiesMunitionTimer.Enabled = true;
            this.EnemiesMunitionTimer.Interval = 20;
            this.EnemiesMunitionTimer.Tick += new System.EventHandler(this.EnemiesMunitionTimer_Tick);
            // 
            // EndButton
            // 
            this.EndButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EndButton.Location = new System.Drawing.Point(225, 279);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(210, 43);
            this.EndButton.TabIndex = 1;
            this.EndButton.Text = "End";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Visible = false;
            this.EndButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReplayButton
            // 
            this.ReplayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReplayButton.Location = new System.Drawing.Point(225, 205);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(210, 43);
            this.ReplayButton.TabIndex = 2;
            this.ReplayButton.Text = "Replay";
            this.ReplayButton.UseVisualStyleBackColor = true;
            this.ReplayButton.Visible = false;
            this.ReplayButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.InfoText;
            this.label1.Font = new System.Drawing.Font("Impact", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(222, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "StarBattle";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreLabel.ForeColor = System.Drawing.Color.Silver;
            this.scoreLabel.Location = new System.Drawing.Point(530, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(94, 33);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "SCORE: 0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.levelLabel.ForeColor = System.Drawing.Color.Silver;
            this.levelLabel.Location = new System.Drawing.Point(530, 51);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(90, 23);
            this.levelLabel.TabIndex = 5;
            this.levelLabel.Text = "LEVEL: 0";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.BackColor = System.Drawing.Color.Transparent;
            this.MoneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MoneyLabel.ForeColor = System.Drawing.Color.Silver;
            this.MoneyLabel.Location = new System.Drawing.Point(524, 89);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(96, 23);
            this.MoneyLabel.TabIndex = 6;
            this.MoneyLabel.Text = "MONEY: 0";
            this.MoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BulletsLabel
            // 
            this.BulletsLabel.BackColor = System.Drawing.Color.Transparent;
            this.BulletsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BulletsLabel.ForeColor = System.Drawing.Color.Silver;
            this.BulletsLabel.Location = new System.Drawing.Point(512, 123);
            this.BulletsLabel.Name = "BulletsLabel";
            this.BulletsLabel.Size = new System.Drawing.Size(108, 23);
            this.BulletsLabel.TabIndex = 7;
            this.BulletsLabel.Text = "BULLETS: 1";
            this.BulletsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpeedLvlLabel
            // 
            this.SpeedLvlLabel.BackColor = System.Drawing.Color.Transparent;
            this.SpeedLvlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SpeedLvlLabel.ForeColor = System.Drawing.Color.Silver;
            this.SpeedLvlLabel.Location = new System.Drawing.Point(526, 155);
            this.SpeedLvlLabel.Name = "SpeedLvlLabel";
            this.SpeedLvlLabel.Size = new System.Drawing.Size(94, 23);
            this.SpeedLvlLabel.TabIndex = 8;
            this.SpeedLvlLabel.Text = "SPEED LVL: 1";
            this.SpeedLvlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(639, 515);
            this.Controls.Add(this.SpeedLvlLabel);
            this.Controls.Add(this.BulletsLabel);
            this.Controls.Add(this.MoneyLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReplayButton);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.Player);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(655, 553);
            this.MinimumSize = new System.Drawing.Size(655, 553);
            this.Name = "Form1";
            this.Text = "StarBattle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer MoveBackground;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer LeftTimer;
        private System.Windows.Forms.Timer RightTimer;
        private System.Windows.Forms.Timer MunitionTimer;
        private System.Windows.Forms.Timer MoveEnemiesTimer;
        private System.Windows.Forms.Timer EnemiesMunitionTimer;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Button ReplayButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label MoneyLabel;
        private System.Windows.Forms.Label BulletsLabel;
        private System.Windows.Forms.Label SpeedLvlLabel;
    }
}

