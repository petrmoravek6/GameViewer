namespace clientUI.Forms
{
    partial class ViewPlayerForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.logger = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.ComboBox();
            this.month = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.team = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.teamsWon = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(150, 63);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(227, 23);
            this.name_textBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date of birth: ";
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(284, 105);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(93, 23);
            this.year.TabIndex = 4;
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.save_button.Location = new System.Drawing.Point(179, 254);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 5;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exit_button.Location = new System.Drawing.Point(271, 254);
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
            this.logger.Location = new System.Drawing.Point(12, 291);
            this.logger.Name = "logger";
            this.logger.Size = new System.Drawing.Size(486, 25);
            this.logger.TabIndex = 7;
            this.logger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day
            // 
            this.day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.day.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.day.Location = new System.Drawing.Point(150, 105);
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
            this.month.Location = new System.Drawing.Point(218, 105);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(51, 23);
            this.month.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Position: ";
            // 
            // position
            // 
            this.position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.position.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.position.FormattingEnabled = true;
            this.position.Items.AddRange(new object[] {
            "Goalkeeper",
            "Defender",
            "Midfielder",
            "Attacker",
            "Unknown"});
            this.position.Location = new System.Drawing.Point(150, 140);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(227, 23);
            this.position.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Team: ";
            // 
            // team
            // 
            this.team.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.team.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.team.FormattingEnabled = true;
            this.team.Location = new System.Drawing.Point(150, 177);
            this.team.Name = "team";
            this.team.Size = new System.Drawing.Size(227, 23);
            this.team.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(179, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // teamsWon
            // 
            this.teamsWon.FormattingEnabled = true;
            this.teamsWon.ItemHeight = 15;
            this.teamsWon.Location = new System.Drawing.Point(149, 371);
            this.teamsWon.Name = "teamsWon";
            this.teamsWon.Size = new System.Drawing.Size(228, 184);
            this.teamsWon.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "View teams that the player won against";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ViewPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(510, 578);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.teamsWon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.team);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.position);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.month);
            this.Controls.Add(this.day);
            this.Controls.Add(this.logger);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name_textBox);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "ViewPlayerForm";
            this.Text = "Player information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox name_textBox;
        private Label label2;
        private Label label3;
        private TextBox year;
        private Button save_button;
        private Button exit_button;
        private Label logger;
        private ComboBox day;
        private ComboBox month;
        private Label label1;
        private ComboBox position;
        private Label label4;
        private ComboBox team;
        private Button button1;
        private ListBox teamsWon;
        private Button button2;
    }
}