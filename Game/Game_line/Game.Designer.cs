using System.Windows.Forms;

namespace Game_line
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.EASY = new System.Windows.Forms.Button();
            this.average = new System.Windows.Forms.Button();
            this.hard = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // EASY
            // 
            this.EASY.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.EASY.BackgroundImage = global::Game_line.Properties.Resources._309430571_5969846613049377_5292086020603637971_n;
            this.EASY.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EASY.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.EASY.Location = new System.Drawing.Point(737, 13);
            this.EASY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EASY.Name = "EASY";
            this.EASY.Size = new System.Drawing.Size(160, 54);
            this.EASY.TabIndex = 0;
            this.EASY.Text = "Easy";
            this.EASY.UseVisualStyleBackColor = false;
            this.EASY.Click += new System.EventHandler(this.menuDe_Click);
            // 
            // average
            // 
            this.average.BackgroundImage = global::Game_line.Properties.Resources._309430571_5969846613049377_5292086020603637971_n;
            this.average.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.average.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.average.Location = new System.Drawing.Point(737, 100);
            this.average.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.average.Name = "average";
            this.average.Size = new System.Drawing.Size(160, 54);
            this.average.TabIndex = 1;
            this.average.Text = "Average";
            this.average.UseVisualStyleBackColor = true;
            this.average.Click += new System.EventHandler(this.menuTrung_Click);
            // 
            // hard
            // 
            this.hard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.hard.BackgroundImage = global::Game_line.Properties.Resources._309430571_5969846613049377_5292086020603637971_n1;
            this.hard.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hard.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hard.Location = new System.Drawing.Point(737, 184);
            this.hard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(160, 54);
            this.hard.TabIndex = 2;
            this.hard.Text = "Hard";
            this.hard.UseVisualStyleBackColor = false;
            this.hard.TextChanged += new System.EventHandler(this.menuKho_Click);
            this.hard.Click += new System.EventHandler(this.menuKho_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Game_line.Properties.Resources._309430571_5969846613049377_5292086020603637971_n1;
            this.button1.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(737, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.helpmenu_click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(909, 773);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.average);
            this.Controls.Add(this.EASY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Timer timer;
        private Timer timer1;
        private Button EASY;
        private Button average;
        private Button hard;
        private Button button1;
    }
}

