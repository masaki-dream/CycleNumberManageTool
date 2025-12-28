namespace CycleNumberManageTool
{
    partial class LoginGamen
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
            UserNameText = new TextBox();
            UserNameLabel = new Label();
            PasswordLabel = new Label();
            PasswordText = new TextBox();
            WelcomLoginLabel = new Label();
            LoginButton = new Button();
            ShinkiLoginLabel = new Label();
            ShinkiLoginButton = new Button();
            KanriLabel = new Label();
            kanriButton = new Button();
            SuspendLayout();
            // 
            // UserNameText
            // 
            UserNameText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            UserNameText.Location = new Point(614, 419);
            UserNameText.MaxLength = 20;
            UserNameText.Name = "UserNameText";
            UserNameText.Size = new Size(538, 50);
            UserNameText.TabIndex = 1;
            UserNameText.TextAlign = HorizontalAlignment.Center;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Yu Gothic UI", 13F, FontStyle.Bold);
            UserNameLabel.Location = new Point(614, 326);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(160, 47);
            UserNameLabel.TabIndex = 1;
            UserNameLabel.Text = "ユーザー名";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Yu Gothic UI", 13F, FontStyle.Bold);
            PasswordLabel.Location = new Point(614, 542);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(151, 47);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "パスワード";
            // 
            // PasswordText
            // 
            PasswordText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            PasswordText.Location = new Point(614, 626);
            PasswordText.MaxLength = 10;
            PasswordText.Name = "PasswordText";
            PasswordText.PasswordChar = '●';
            PasswordText.Size = new Size(538, 50);
            PasswordText.TabIndex = 2;
            PasswordText.TextAlign = HorizontalAlignment.Center;
            // 
            // WelcomLoginLabel
            // 
            WelcomLoginLabel.AutoSize = true;
            WelcomLoginLabel.Font = new Font("Yu Gothic UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 128);
            WelcomLoginLabel.Location = new Point(557, 120);
            WelcomLoginLabel.Name = "WelcomLoginLabel";
            WelcomLoginLabel.Size = new Size(720, 59);
            WelcomLoginLabel.TabIndex = 4;
            WelcomLoginLabel.Text = "鎌ケ谷駐輪場アプリのログイン画面です。";
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            LoginButton.Location = new Point(802, 735);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(137, 59);
            LoginButton.TabIndex = 3;
            LoginButton.Text = "ログイン";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // ShinkiLoginLabel
            // 
            ShinkiLoginLabel.AutoSize = true;
            ShinkiLoginLabel.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold);
            ShinkiLoginLabel.ForeColor = Color.Red;
            ShinkiLoginLabel.Location = new Point(1182, 757);
            ShinkiLoginLabel.Name = "ShinkiLoginLabel";
            ShinkiLoginLabel.Size = new Size(580, 37);
            ShinkiLoginLabel.TabIndex = 6;
            ShinkiLoginLabel.Text = "アカウントをお持ちでない方はボタンを押してください。";
            // 
            // ShinkiLoginButton
            // 
            ShinkiLoginButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            ShinkiLoginButton.Location = new Point(1368, 834);
            ShinkiLoginButton.Name = "ShinkiLoginButton";
            ShinkiLoginButton.Size = new Size(192, 69);
            ShinkiLoginButton.TabIndex = 4;
            ShinkiLoginButton.Text = "新規作成";
            ShinkiLoginButton.UseVisualStyleBackColor = true;
            ShinkiLoginButton.Click += button1_Click;
            // 
            // KanriLabel
            // 
            KanriLabel.AutoSize = true;
            KanriLabel.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold);
            KanriLabel.ForeColor = Color.Red;
            KanriLabel.Location = new Point(1344, 940);
            KanriLabel.Name = "KanriLabel";
            KanriLabel.Size = new Size(231, 37);
            KanriLabel.TabIndex = 7;
            KanriLabel.Text = "管理者の方はこちら";
            // 
            // kanriButton
            // 
            kanriButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            kanriButton.Location = new Point(1368, 998);
            kanriButton.Name = "kanriButton";
            kanriButton.Size = new Size(192, 69);
            kanriButton.TabIndex = 8;
            kanriButton.Text = "管理者";
            kanriButton.UseVisualStyleBackColor = true;
            kanriButton.Click += kanriButton_Click;
            // 
            // LoginGamen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1819, 1098);
            Controls.Add(kanriButton);
            Controls.Add(KanriLabel);
            Controls.Add(ShinkiLoginButton);
            Controls.Add(ShinkiLoginLabel);
            Controls.Add(LoginButton);
            Controls.Add(WelcomLoginLabel);
            Controls.Add(PasswordText);
            Controls.Add(PasswordLabel);
            Controls.Add(UserNameLabel);
            Controls.Add(UserNameText);
            Name = "LoginGamen";
            Text = "LoginGamen";
            Load += LoginGamen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserNameText;
        private Label UserNameLabel;
        private Label PasswordLabel;
        private TextBox PasswordText;
        private Label WelcomLoginLabel;
        private Button LoginButton;
        private Label ShinkiLoginLabel;
        private Button ShinkiLoginButton;
        private Label KanriLabel;
        private Button kanriButton;
    }
}