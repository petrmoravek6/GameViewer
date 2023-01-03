namespace clientUI;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.team_button = new System.Windows.Forms.Button();
            this.player_button = new System.Windows.Forms.Button();
            this.match_button = new System.Windows.Forms.Button();
            this.mainList = new System.Windows.Forms.ListBox();
            this.display_button = new System.Windows.Forms.Button();
            this.remove_button = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // team_button
            // 
            this.team_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.team_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.team_button.Location = new System.Drawing.Point(12, 12);
            this.team_button.Name = "team_button";
            this.team_button.Size = new System.Drawing.Size(186, 30);
            this.team_button.TabIndex = 0;
            this.team_button.Text = "TEAMS";
            this.team_button.UseVisualStyleBackColor = true;
            // 
            // player_button
            // 
            this.player_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.player_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.player_button.Location = new System.Drawing.Point(195, 12);
            this.player_button.Name = "player_button";
            this.player_button.Size = new System.Drawing.Size(186, 30);
            this.player_button.TabIndex = 1;
            this.player_button.Text = "PLAYERS";
            this.player_button.UseVisualStyleBackColor = false;
            // 
            // match_button
            // 
            this.match_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.match_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.match_button.Location = new System.Drawing.Point(378, 12);
            this.match_button.Name = "match_button";
            this.match_button.Size = new System.Drawing.Size(186, 30);
            this.match_button.TabIndex = 2;
            this.match_button.Text = "MATCHES";
            this.match_button.UseVisualStyleBackColor = false;
            // 
            // mainList
            // 
            this.mainList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainList.FormattingEnabled = true;
            this.mainList.ItemHeight = 17;
            this.mainList.Location = new System.Drawing.Point(12, 48);
            this.mainList.Name = "mainList";
            this.mainList.Size = new System.Drawing.Size(552, 616);
            this.mainList.TabIndex = 3;
            // 
            // display_button
            // 
            this.display_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.display_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.display_button.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.display_button.Location = new System.Drawing.Point(626, 155);
            this.display_button.Name = "display_button";
            this.display_button.Size = new System.Drawing.Size(207, 47);
            this.display_button.TabIndex = 4;
            this.display_button.Text = "Display";
            this.display_button.UseVisualStyleBackColor = false;
            // 
            // remove_button
            // 
            this.remove_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.remove_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.remove_button.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.remove_button.Location = new System.Drawing.Point(626, 208);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(207, 46);
            this.remove_button.TabIndex = 5;
            this.remove_button.Text = "Remove";
            this.remove_button.UseVisualStyleBackColor = false;
            // 
            // add_button
            // 
            this.add_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.add_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.add_button.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.add_button.Location = new System.Drawing.Point(626, 260);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(207, 48);
            this.add_button.TabIndex = 6;
            this.add_button.Text = "Add";
            this.add_button.UseVisualStyleBackColor = false;
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit_button.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exit_button.Location = new System.Drawing.Point(626, 465);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(207, 48);
            this.exit_button.TabIndex = 7;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(886, 684);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.display_button);
            this.Controls.Add(this.mainList);
            this.Controls.Add(this.match_button);
            this.Controls.Add(this.player_button);
            this.Controls.Add(this.team_button);
            this.Name = "MainForm";
            this.Text = "Game Viewer 1.0";
            this.ResumeLayout(false);

    }

    #endregion

    private Button team_button;
    private Button player_button;
    private Button match_button;
    private ListBox mainList;
    private Button display_button;
    private Button remove_button;
    private Button add_button;
    private Button exit_button;
}