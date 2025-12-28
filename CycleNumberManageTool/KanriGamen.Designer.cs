namespace CycleNumberManageTool
{
    partial class KanriGamen
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
            UserNameLabel = new Label();
            PasswordLabel = new Label();
            KanriPasswordText = new TextBox();
            KanriUserText = new TextBox();
            LoginButton = new Button();
            BackButton = new Button();
            KanriGv = new DataGridView();
            KanriPanelGridContainer = new Panel();
            ExcuteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)KanriGv).BeginInit();
            KanriPanelGridContainer.SuspendLayout();
            SuspendLayout();
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Yu Gothic UI", 13F, FontStyle.Bold);
            UserNameLabel.Location = new Point(754, 67);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(265, 47);
            UserNameLabel.TabIndex = 2;
            UserNameLabel.Text = "管理者ユーザー名";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Yu Gothic UI", 13F, FontStyle.Bold);
            PasswordLabel.Location = new Point(763, 242);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(256, 47);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "管理者パスワード";
            // 
            // KanriPasswordText
            // 
            KanriPasswordText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            KanriPasswordText.Location = new Point(618, 324);
            KanriPasswordText.MaxLength = 10;
            KanriPasswordText.Name = "KanriPasswordText";
            KanriPasswordText.PasswordChar = '●';
            KanriPasswordText.Size = new Size(538, 50);
            KanriPasswordText.TabIndex = 5;
            KanriPasswordText.TextAlign = HorizontalAlignment.Center;
            // 
            // KanriUserText
            // 
            KanriUserText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            KanriUserText.Location = new Point(618, 148);
            KanriUserText.MaxLength = 10;
            KanriUserText.Name = "KanriUserText";
            KanriUserText.Size = new Size(538, 50);
            KanriUserText.TabIndex = 4;
            KanriUserText.TextAlign = HorizontalAlignment.Center;
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            LoginButton.Location = new Point(731, 404);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(137, 59);
            LoginButton.TabIndex = 6;
            LoginButton.Text = "ログイン";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // BackButton
            // 
            BackButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            BackButton.Location = new Point(910, 403);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(136, 60);
            BackButton.TabIndex = 15;
            BackButton.Text = "戻る";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // KanriGv
            // 
            KanriGv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            KanriGv.Dock = DockStyle.Fill;
            KanriGv.Location = new Point(0, 0);
            KanriGv.Name = "KanriGv";
            KanriGv.RowHeadersWidth = 82;
            KanriGv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            KanriGv.Size = new Size(1494, 752);
            KanriGv.TabIndex = 16;
            // 
            // KanriPanelGridContainer
            // 
            KanriPanelGridContainer.Controls.Add(KanriGv);
            KanriPanelGridContainer.Location = new Point(156, 518);
            KanriPanelGridContainer.Name = "KanriPanelGridContainer";
            KanriPanelGridContainer.Size = new Size(1494, 752);
            KanriPanelGridContainer.TabIndex = 17;
            // 
            // ExcuteButton
            // 
            ExcuteButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            ExcuteButton.Location = new Point(817, 1325);
            ExcuteButton.Name = "ExcuteButton";
            ExcuteButton.Size = new Size(136, 60);
            ExcuteButton.TabIndex = 20;
            ExcuteButton.Text = "実行";
            ExcuteButton.UseVisualStyleBackColor = true;
            ExcuteButton.Click += ExcuteButton_Click;
            // 
            // KanriGamen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1802, 1507);
            Controls.Add(ExcuteButton);
            Controls.Add(BackButton);
            Controls.Add(LoginButton);
            Controls.Add(KanriUserText);
            Controls.Add(KanriPasswordText);
            Controls.Add(PasswordLabel);
            Controls.Add(UserNameLabel);
            Controls.Add(KanriPanelGridContainer);
            Name = "KanriGamen";
            Text = "KanriGamen";
            Load += KanriGamen_Load;
            ((System.ComponentModel.ISupportInitialize)KanriGv).EndInit();
            KanriPanelGridContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label UserNameLabel;
        private Label PasswordLabel;
        private TextBox KanriPasswordText;
        private TextBox KanriUserText;
        private Button LoginButton;
        private Button BackButton;
        private DataGridView KanriGv;
        private Panel KanriPanelGridContainer;
        private Button KanriUpdateBtn;
        private Button KanriDeleteButton;
        private Button ExcuteButton;
    }
}