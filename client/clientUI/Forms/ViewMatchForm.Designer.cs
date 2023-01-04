namespace clientUI.Forms
{
    partial class ViewMatchForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.logger = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.ComboBox();
            this.month = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ageLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.homeTeam = new System.Windows.Forms.ComboBox();
            this.awayTeam = new System.Windows.Forms.ComboBox();
            this.homeTeamScore = new System.Windows.Forms.TextBox();
            this.awayTeamScore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.participants = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(306, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "VS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date:";
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(329, 172);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(93, 23);
            this.year.TabIndex = 4;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(232, 613);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 5;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(324, 613);
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
            this.logger.Location = new System.Drawing.Point(12, 648);
            this.logger.Name = "logger";
            this.logger.Size = new System.Drawing.Size(639, 25);
            this.logger.TabIndex = 7;
            this.logger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day
            // 
            this.day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.day.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.day.FormattingEnabled = true;
            this.day.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.day.Location = new System.Drawing.Point(195, 172);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(51, 23);
            this.day.TabIndex = 8;
            // 
            // month
            // 
            this.month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.month.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.month.FormattingEnabled = true;
            this.month.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.month.Location = new System.Drawing.Point(263, 172);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(51, 23);
            this.month.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Age seniority:";
            // 
            // ageLevel
            // 
            this.ageLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ageLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ageLevel.FormattingEnabled = true;
            this.ageLevel.Items.AddRange(new object[] {
            "Kids",
            "Pupils",
            "U18",
            "U21",
            "Senior"});
            this.ageLevel.Location = new System.Drawing.Point(195, 210);
            this.ageLevel.Name = "ageLevel";
            this.ageLevel.Size = new System.Drawing.Size(227, 23);
            this.ageLevel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Players: ";
            // 
            // homeTeam
            // 
            this.homeTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.homeTeam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.homeTeam.FormattingEnabled = true;
            this.homeTeam.Location = new System.Drawing.Point(81, 54);
            this.homeTeam.Name = "homeTeam";
            this.homeTeam.Size = new System.Drawing.Size(171, 23);
            this.homeTeam.TabIndex = 14;
            // 
            // awayTeam
            // 
            this.awayTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.awayTeam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.awayTeam.FormattingEnabled = true;
            this.awayTeam.Location = new System.Drawing.Point(386, 54);
            this.awayTeam.Name = "awayTeam";
            this.awayTeam.Size = new System.Drawing.Size(171, 23);
            this.awayTeam.TabIndex = 15;
            // 
            // homeTeamScore
            // 
            this.homeTeamScore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.homeTeamScore.Location = new System.Drawing.Point(263, 112);
            this.homeTeamScore.Name = "homeTeamScore";
            this.homeTeamScore.Size = new System.Drawing.Size(41, 27);
            this.homeTeamScore.TabIndex = 16;
            this.homeTeamScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // awayTeamScore
            // 
            this.awayTeamScore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.awayTeamScore.Location = new System.Drawing.Point(332, 112);
            this.awayTeamScore.Name = "awayTeamScore";
            this.awayTeamScore.Size = new System.Drawing.Size(41, 27);
            this.awayTeamScore.TabIndex = 17;
            this.awayTeamScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(314, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = ":";
            // 
            // participants
            // 
            this.participants.FormattingEnabled = true;
            this.participants.Location = new System.Drawing.Point(157, 263);
            this.participants.Name = "participants";
            this.participants.Size = new System.Drawing.Size(325, 292);
            this.participants.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(232, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewMatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(664, 682);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.participants);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.awayTeamScore);
            this.Controls.Add(this.homeTeamScore);
            this.Controls.Add(this.awayTeam);
            this.Controls.Add(this.homeTeam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ageLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.month);
            this.Controls.Add(this.day);
            this.Controls.Add(this.logger);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "ViewMatchForm";
            this.Text = "Match information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox year;
        private Button save_button;
        private Button exit_button;
        private Label logger;
        private ComboBox day;
        private ComboBox month;
        private Label label1;
        private ComboBox ageLevel;
        private Label label4;
        private ComboBox homeTeam;
        private ComboBox awayTeam;
        private TextBox homeTeamScore;
        private TextBox awayTeamScore;
        private Label label5;
        private CheckedListBox participants;
        private Button button1;
    }
}