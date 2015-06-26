namespace Spotnashki
{
    partial class frmMainScreen
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.lbSteps = new System.Windows.Forms.Label();
            this.lbSteps_value = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbStatus_value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(497, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(154, 48);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Начать игру";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(497, 98);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(154, 48);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel
            // 
            this.panel.BackgroundImage = global::Spotnashki.Properties.Resources.background;
            this.panel.Location = new System.Drawing.Point(30, 30);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 400);
            this.panel.TabIndex = 3;
            // 
            // lbSteps
            // 
            this.lbSteps.AutoSize = true;
            this.lbSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSteps.Location = new System.Drawing.Point(32, 456);
            this.lbSteps.Name = "lbSteps";
            this.lbSteps.Size = new System.Drawing.Size(56, 25);
            this.lbSteps.TabIndex = 4;
            this.lbSteps.Text = "Ход:";
            // 
            // lbSteps_value
            // 
            this.lbSteps_value.AutoSize = true;
            this.lbSteps_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSteps_value.Location = new System.Drawing.Point(117, 456);
            this.lbSteps_value.Name = "lbSteps_value";
            this.lbSteps_value.Size = new System.Drawing.Size(24, 25);
            this.lbSteps_value.TabIndex = 5;
            this.lbSteps_value.Text = "0";
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatus.Location = new System.Drawing.Point(296, 456);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(87, 25);
            this.lbStatus.TabIndex = 6;
            this.lbStatus.Text = "Статус:";
            // 
            // lbStatus_value
            // 
            this.lbStatus_value.AutoSize = true;
            this.lbStatus_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatus_value.ForeColor = System.Drawing.Color.Red;
            this.lbStatus_value.Location = new System.Drawing.Point(411, 456);
            this.lbStatus_value.Name = "lbStatus_value";
            this.lbStatus_value.Size = new System.Drawing.Size(129, 25);
            this.lbStatus_value.TabIndex = 7;
            this.lbStatus_value.Text = "In process...";
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 523);
            this.Controls.Add(this.lbStatus_value);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbSteps_value);
            this.Controls.Add(this.lbSteps);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Name = "frmMainScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lbSteps;
        private System.Windows.Forms.Label lbSteps_value;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbStatus_value;
    }
}

