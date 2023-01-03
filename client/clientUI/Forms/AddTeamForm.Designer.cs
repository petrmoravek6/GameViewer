namespace clientUI.Forms
{
    partial class AddTeamForm
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
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shortname_textBox = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.logger = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(134, 121);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(205, 23);
            this.name_textBox.TabIndex = 0;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(90, 38);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(248, 32);
            this.title.TabIndex = 1;
            this.title.Text = "ADDING NEW TEAM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Shortname: ";
            // 
            // shortname_textBox
            // 
            this.shortname_textBox.Location = new System.Drawing.Point(167, 164);
            this.shortname_textBox.Name = "shortname_textBox";
            this.shortname_textBox.Size = new System.Drawing.Size(172, 23);
            this.shortname_textBox.TabIndex = 4;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(134, 238);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 5;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(215, 238);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 23);
            this.exit_button.TabIndex = 6;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // logger
            // 
            this.logger.ForeColor = System.Drawing.Color.Red;
            this.logger.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logger.Location = new System.Drawing.Point(12, 302);
            this.logger.Name = "logger";
            this.logger.Size = new System.Drawing.Size(427, 25);
            this.logger.TabIndex = 7;
            this.logger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(451, 336);
            this.Controls.Add(this.logger);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.shortname_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.title);
            this.Controls.Add(this.name_textBox);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "AddTeamForm";
            this.Text = "Add new team";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox name_textBox;
        private Label title;
        private Label label2;
        private Label label3;
        private TextBox shortname_textBox;
        private Button save_button;
        private Button exit_button;
        private Label logger;
    }
}