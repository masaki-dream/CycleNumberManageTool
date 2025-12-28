namespace CycleNumberManageTool
{
    partial class CycleNumberKeisanGamen
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
            CurrentStateText = new TextBox();
            CurrentTimeText = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            InputCycleNumberText = new TextBox();
            ExecuteButton = new Button();
            HenkoButton = new Button();
            WorkNowLabel = new Label();
            CurrentMoneyLabel = new Label();
            StartingWorkButton = new Button();
            FinishingWorkButton = new Button();
            TodayCycleNumberLabel = new Label();
            KoteiWorkNowText = new TextBox();
            KoteiTodayCycleNumberText = new TextBox();
            KoteiCurrentMoneyText = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // CurrentStateText
            // 
            CurrentStateText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CurrentStateText.Location = new Point(113, 437);
            CurrentStateText.Name = "CurrentStateText";
            CurrentStateText.Size = new Size(473, 50);
            CurrentStateText.TabIndex = 2;
            // 
            // CurrentTimeText
            // 
            CurrentTimeText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CurrentTimeText.Location = new Point(113, 270);
            CurrentTimeText.Name = "CurrentTimeText";
            CurrentTimeText.Size = new Size(222, 50);
            CurrentTimeText.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(766, 122);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(414, 39);
            dateTimePicker1.TabIndex = 4;
            // 
            // InputCycleNumberText
            // 
            InputCycleNumberText.Font = new Font("Yu Gothic UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            InputCycleNumberText.ForeColor = SystemColors.GrayText;
            InputCycleNumberText.Location = new Point(782, 237);
            InputCycleNumberText.Name = "InputCycleNumberText";
            InputCycleNumberText.Size = new Size(381, 46);
            InputCycleNumberText.TabIndex = 5;
            InputCycleNumberText.Text = "駐輪番号を入力して下さい。";
            InputCycleNumberText.TextAlign = HorizontalAlignment.Center;
            // 
            // ExecuteButton
            // 
            ExecuteButton.Location = new Point(1233, 237);
            ExecuteButton.Name = "ExecuteButton";
            ExecuteButton.Size = new Size(135, 46);
            ExecuteButton.TabIndex = 6;
            ExecuteButton.Text = "確定";
            ExecuteButton.UseVisualStyleBackColor = true;
            ExecuteButton.Click += ExecuteButton_Click;
            // 
            // HenkoButton
            // 
            HenkoButton.Location = new Point(1392, 237);
            HenkoButton.Name = "HenkoButton";
            HenkoButton.Size = new Size(126, 46);
            HenkoButton.TabIndex = 7;
            HenkoButton.Text = "変更";
            HenkoButton.UseVisualStyleBackColor = true;
            HenkoButton.Click += HenkoButton_Click;
            // 
            // WorkNowLabel
            // 
            WorkNowLabel.AutoSize = true;
            WorkNowLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorkNowLabel.Location = new Point(872, 425);
            WorkNowLabel.Name = "WorkNowLabel";
            WorkNowLabel.Size = new Size(148, 45);
            WorkNowLabel.TabIndex = 8;
            WorkNowLabel.Text = "出勤状況";
            // 
            // CurrentMoneyLabel
            // 
            CurrentMoneyLabel.AutoSize = true;
            CurrentMoneyLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CurrentMoneyLabel.Location = new Point(1272, 488);
            CurrentMoneyLabel.Name = "CurrentMoneyLabel";
            CurrentMoneyLabel.Size = new Size(387, 45);
            CurrentMoneyLabel.TabIndex = 9;
            CurrentMoneyLabel.Text = "現在の駐輪金額は0円です。";
            // 
            // StartingWorkButton
            // 
            StartingWorkButton.BackColor = Color.SkyBlue;
            StartingWorkButton.Font = new Font("Yu Gothic UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 128);
            StartingWorkButton.Location = new Point(501, 749);
            StartingWorkButton.Name = "StartingWorkButton";
            StartingWorkButton.Size = new Size(394, 233);
            StartingWorkButton.TabIndex = 11;
            StartingWorkButton.Text = "出勤";
            StartingWorkButton.UseVisualStyleBackColor = false;
            StartingWorkButton.Click += StartingWorkButton_Click;
            // 
            // FinishingWorkButton
            // 
            FinishingWorkButton.BackColor = Color.Salmon;
            FinishingWorkButton.FlatStyle = FlatStyle.Flat;
            FinishingWorkButton.Font = new Font("Yu Gothic UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 128);
            FinishingWorkButton.Location = new Point(1027, 749);
            FinishingWorkButton.Name = "FinishingWorkButton";
            FinishingWorkButton.Size = new Size(394, 233);
            FinishingWorkButton.TabIndex = 12;
            FinishingWorkButton.Text = "退勤";
            FinishingWorkButton.UseVisualStyleBackColor = false;
            FinishingWorkButton.Click += FinishingWorkButton_Click;
            // 
            // TodayCycleNumberLabel
            // 
            TodayCycleNumberLabel.AutoSize = true;
            TodayCycleNumberLabel.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TodayCycleNumberLabel.Location = new Point(782, 612);
            TodayCycleNumberLabel.Name = "TodayCycleNumberLabel";
            TodayCycleNumberLabel.Size = new Size(360, 50);
            TodayCycleNumberLabel.TabIndex = 13;
            TodayCycleNumberLabel.Text = "駐輪番号が空白です。";
            TodayCycleNumberLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // KoteiWorkNowText
            // 
            KoteiWorkNowText.BackColor = SystemColors.ControlLight;
            KoteiWorkNowText.Enabled = false;
            KoteiWorkNowText.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            KoteiWorkNowText.ForeColor = Color.DarkSlateGray;
            KoteiWorkNowText.Location = new Point(848, 365);
            KoteiWorkNowText.Name = "KoteiWorkNowText";
            KoteiWorkNowText.Size = new Size(200, 57);
            KoteiWorkNowText.TabIndex = 14;
            KoteiWorkNowText.Text = "出勤状況";
            KoteiWorkNowText.TextAlign = HorizontalAlignment.Center;
            // 
            // KoteiTodayCycleNumberText
            // 
            KoteiTodayCycleNumberText.BackColor = SystemColors.ControlLight;
            KoteiTodayCycleNumberText.Enabled = false;
            KoteiTodayCycleNumberText.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            KoteiTodayCycleNumberText.ForeColor = Color.DarkSlateGray;
            KoteiTodayCycleNumberText.Location = new Point(798, 552);
            KoteiTodayCycleNumberText.Name = "KoteiTodayCycleNumberText";
            KoteiTodayCycleNumberText.Size = new Size(315, 57);
            KoteiTodayCycleNumberText.TabIndex = 15;
            KoteiTodayCycleNumberText.Text = "駐輪番号の状況";
            KoteiTodayCycleNumberText.TextAlign = HorizontalAlignment.Center;
            // 
            // KoteiCurrentMoneyText
            // 
            KoteiCurrentMoneyText.BackColor = SystemColors.ControlLight;
            KoteiCurrentMoneyText.Enabled = false;
            KoteiCurrentMoneyText.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            KoteiCurrentMoneyText.ForeColor = Color.DarkSlateGray;
            KoteiCurrentMoneyText.Location = new Point(1297, 418);
            KoteiCurrentMoneyText.Name = "KoteiCurrentMoneyText";
            KoteiCurrentMoneyText.Size = new Size(315, 57);
            KoteiCurrentMoneyText.TabIndex = 16;
            KoteiCurrentMoneyText.Text = "現在の駐輪金額";
            KoteiCurrentMoneyText.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlLight;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            textBox1.ForeColor = Color.DarkSlateGray;
            textBox1.Location = new Point(122, 182);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 57);
            textBox1.TabIndex = 17;
            textBox1.Text = "現在時刻";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlLight;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            textBox2.ForeColor = Color.DarkSlateGray;
            textBox2.Location = new Point(122, 365);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(360, 57);
            textBox2.TabIndex = 18;
            textBox2.Text = "管理者からのメッセージ";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ControlLight;
            textBox3.Enabled = false;
            textBox3.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            textBox3.ForeColor = Color.DarkSlateGray;
            textBox3.Location = new Point(276, 36);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(1358, 57);
            textBox3.TabIndex = 19;
            textBox3.Text = "鎌ケ谷駅の駐輪番号を管理します。";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // CycleNumberKeisanGamen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1923, 1150);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(KoteiCurrentMoneyText);
            Controls.Add(KoteiTodayCycleNumberText);
            Controls.Add(KoteiWorkNowText);
            Controls.Add(TodayCycleNumberLabel);
            Controls.Add(FinishingWorkButton);
            Controls.Add(StartingWorkButton);
            Controls.Add(CurrentMoneyLabel);
            Controls.Add(WorkNowLabel);
            Controls.Add(HenkoButton);
            Controls.Add(ExecuteButton);
            Controls.Add(InputCycleNumberText);
            Controls.Add(dateTimePicker1);
            Controls.Add(CurrentTimeText);
            Controls.Add(CurrentStateText);
            Name = "CycleNumberKeisanGamen";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox CurrentStateText;
        private TextBox CurrentTimeText;
        private DateTimePicker dateTimePicker1;
        private TextBox InputCycleNumberText;
        private Button ExecuteButton;
        private Button HenkoButton;
        private Label WorkNowLabel;
        private Label CurrentMoneyLabel;
        private Button StartingWorkButton;
        private Button FinishingWorkButton;
        private Label TodayCycleNumberLabel;
        private TextBox KoteiWorkNowText;
        private TextBox KoteiTodayCycleNumberText;
        private TextBox KoteiCurrentMoneyText;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}
