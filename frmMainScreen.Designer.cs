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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.Steps = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Начать игру";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(497, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.BackgroundImage = global::Spotnashki.Properties.Resources.background;
            this.panel.Location = new System.Drawing.Point(32, 29);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 400);
            this.panel.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(32, 456);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(79, 25);
            this.label.TabIndex = 4;
            this.label.Text = "Ходов:";
            // 
            // Steps
            // 
            this.Steps.AutoSize = true;
            this.Steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Steps.Location = new System.Drawing.Point(117, 456);
            this.Steps.Name = "Steps";
            this.Steps.Size = new System.Drawing.Size(24, 25);
            this.Steps.TabIndex = 5;
            this.Steps.Text = "0";
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 523);
            this.Controls.Add(this.Steps);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmMainScreen";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label Steps;
        private System.Windows.Forms.Timer timer1;
    }
}

