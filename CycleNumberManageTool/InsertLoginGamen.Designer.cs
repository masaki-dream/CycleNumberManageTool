namespace CycleNumberManageTool
{
    partial class InsertLoginGamen
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
            WelcomLoginLabel = new Label();
            InsertPasswordText = new TextBox();
            PasswordLabel = new Label();
            label1 = new Label();
            InsertUserNameText = new TextBox();
            ReCheckPasswordText = new TextBox();
            label2 = new Label();
            CreateAccountButton = new Button();
            BackButton = new Button();
            SuspendLayout();
            // 
            // WelcomLoginLabel
            // 
            WelcomLoginLabel.AutoSize = true;
            WelcomLoginLabel.Font = new Font("Yu Gothic UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 128);
            WelcomLoginLabel.Location = new Point(462, 107);
            WelcomLoginLabel.Name = "WelcomLoginLabel";
            WelcomLoginLabel.Size = new Size(927, 59);
            WelcomLoginLabel.TabIndex = 5;
            WelcomLoginLabel.Text = "鎌ケ谷駐輪場アプリのアカウント新規作成画面です。";
            // 
            // InsertPasswordText
            // 
            InsertPasswordText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            InsertPasswordText.Location = new Point(641, 522);
            InsertPasswordText.MaxLength = 10;
            InsertPasswordText.Name = "InsertPasswordText";
            InsertPasswordText.PasswordChar = '●';
            InsertPasswordText.Size = new Size(538, 50);
            InsertPasswordText.TabIndex = 9;
            InsertPasswordText.TextAlign = HorizontalAlignment.Center;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Yu Gothic UI", 13F, FontStyle.Bold);
            PasswordLabel.Location = new Point(641, 443);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(151, 47);
            PasswordLabel.TabIndex = 10;
            PasswordLabel.Text = "パスワード";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 13F, FontStyle.Bold);
            label1.Location = new Point(641, 235);
            label1.Name = "label1";
            label1.Size = new Size(160, 47);
            label1.TabIndex = 7;
            label1.Text = "ユーザー名";
            // 
            // InsertUserNameText
            // 
            InsertUserNameText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            InsertUserNameText.Location = new Point(641, 328);
            InsertUserNameText.MaxLength = 20;
            InsertUserNameText.Name = "InsertUserNameText";
            InsertUserNameText.Size = new Size(538, 50);
            InsertUserNameText.TabIndex = 8;
            InsertUserNameText.TextAlign = HorizontalAlignment.Center;
            // 
            // ReCheckPasswordText
            // 
            ReCheckPasswordText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            ReCheckPasswordText.Location = new Point(641, 721);
            ReCheckPasswordText.MaxLength = 10;
            ReCheckPasswordText.Name = "ReCheckPasswordText";
            ReCheckPasswordText.PasswordChar = '●';
            ReCheckPasswordText.Size = new Size(538, 50);
            ReCheckPasswordText.TabIndex = 11;
            ReCheckPasswordText.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 13F, FontStyle.Bold);
            label2.Location = new Point(641, 637);
            label2.Name = "label2";
            label2.Size = new Size(256, 47);
            label2.TabIndex = 12;
            label2.Text = "パスワード再確認";
            // 
            // CreateAccountButton
            // 
            CreateAccountButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            CreateAccountButton.Location = new Point(707, 846);
            CreateAccountButton.Name = "CreateAccountButton";
            CreateAccountButton.Size = new Size(163, 54);
            CreateAccountButton.TabIndex = 13;
            CreateAccountButton.Text = "新規作成";
            CreateAccountButton.UseVisualStyleBackColor = true;
            CreateAccountButton.Click += ShinkiLoginButton_Click;
            // 
            // BackButton
            // 
            BackButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            BackButton.Location = new Point(928, 846);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(163, 54);
            BackButton.TabIndex = 14;
            BackButton.Text = "戻る";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // InsertLoginGamen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1823, 1018);
            Controls.Add(BackButton);
            Controls.Add(CreateAccountButton);
            Controls.Add(ReCheckPasswordText);
            Controls.Add(label2);
            Controls.Add(InsertPasswordText);
            Controls.Add(PasswordLabel);
            Controls.Add(label1);
            Controls.Add(InsertUserNameText);
            Controls.Add(WelcomLoginLabel);
            Name = "InsertLoginGamen";
            Text = "InsertLoginGamen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label WelcomLoginLabel;
        private TextBox InsertPasswordText;
        private Label PasswordLabel;
        private Label label1;
        private TextBox InsertUserNameText;
        private TextBox ReCheckPasswordText;
        private Label label2;
        private Button CreateAccountButton;
        private Button BackButton;
    }
}