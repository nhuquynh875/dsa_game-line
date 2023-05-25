namespace Game_line
{
    partial class GameRule
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
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.BackgroundImage = global::Game_line.Properties.Resources.istockphoto_1150113426_612x612;
            this.exit.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.exit.Location = new System.Drawing.Point(29, 12);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(127, 72);
            this.exit.TabIndex = 0;
            this.exit.Text = "exit";
            this.exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.OK_click);
            // 
            // GameRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Game_line.Properties.Resources.gamerule9;
            this.ClientSize = new System.Drawing.Size(698, 491);
            this.Controls.Add(this.exit);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 460);
            this.Name = "GameRule";
            this.Text = "Gamerule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exit;
    }
}