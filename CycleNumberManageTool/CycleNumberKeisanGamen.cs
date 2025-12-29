using System.Data;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CycleNumberManageTool
{
    public partial class CycleNumberKeisanGamen : Form
    {
        public CycleNumberKeisanGamen()
        {
            InitializeComponent();

            // タイトルバーのテキストを設定
            this.Text = "駐輪画面";
        }

        // --------- 定数の宣言 --------------

        // 駐輪場の尻番号(変わるかもしれないので変数に格納)
        private const int lastCycleNumber = 383;
        // 駐輪場料金の時間間隔(14時間毎に100円)
        private const int hoursInterval = 14;
        // 駐輪場の追加金額(100円)
        private const int paymentIncrement = 100;

        // -------------------------------------

        // ------- 以降は計算式で使用 ----------
        // 確定ボタン押下時にTrue
        private Boolean isCheckExcecuteFlg = false;
        // 変更ボタン押下時にTrue
        private Boolean isCheckHenkoFlg = false;
        // 出勤ボタン押下時にTrue
        private Boolean isCheckStartingButtonFlg = false;
        // 退勤ボタン押下時にTrue
        private Boolean isCheckFinishingButtonFlg = false;
        // DateTime型のフィールド
        private DateTime startTime;
        // 駐輪番号
        private int cycleNumber = 0;
        // 駐輪場金額の初期金額
        private int currentPaymentMoney = 100;

        // ---------------------------------------

        /// <summary>
        /// メイン画面ロード時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 画面ロード時の処理 
                SetLoad();

                // 1日2回以上駐輪場を使用する場合は、最新の駐輪場に止めた時間を取得
                String cmdText = @"
                    SELECT TOP 1
                        CycleNumber,
                        CheckInTime,
                        CheckOutTime
                    FROM RecordsCycleNumber
                    WHERE UserId = @UserId
                        AND CycleNumber IS NOT NULL
                        AND CAST(WorkDate AS date) = CAST(GETDATE() AS date)
                    ORDER BY CheckInTime DESC;
                ";

                // インスタンス作成
                Common commonInstance = new Common();

                // 判定用変数
                object[] result = commonInstance.IsSelectResult(cmdText);

                // 本日、駐輪番号を格納した場合(退勤ボタン押下した場合はfalse)
                if (result != null && result[0] != null && result[2] == null)
                {
                    // 駐輪番号をテキストボックスに格納
                    InputCycleNumberText.Text = result[0].ToString();

                    // 駐輪番号にDBからの駐輪番号を格納
                    cycleNumber = Convert.ToInt32(InputCycleNumberText.Text);

                    // 駐輪場を利用し始めた時間「startTime」を代入
                     startTime = (DateTime)result[1];

                    // 出勤ボタンをtrue
                    isCheckStartingButtonFlg = true;

                    // 退勤ボタンをfalse
                    isCheckFinishingButtonFlg = false;

                    // 確定ボタンを非活性化
                    ExecuteButton.Enabled = false;

                    // 出勤ボタン押下した時のメソッド
                    SetWorkButton();

                }
            }
            catch (Exception ex)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("エラーが発生しました\nエラー内容:" + ex.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 画面ロード時の処理
        /// </summary>
        private void SetLoad()
        {
            // 時間に応じてテキストメッセージを変更する(午前⇒おはようなど)
            SetTimeTextChange();
            // 現在時刻をテキストに表示する
            SetDateTime();
            // 出勤状況をラベルに表示する
            SetWorkIsNow();
            // 1分ごとに繰り返し実行する(現在時刻によって処理が存在する為)
            SetReLoadOneMinute();
            // イベントハンドルの追加処理
            SetAddEventHandler();
        }

        /// <summary>
        /// イベントを追加するときの処理
        /// </summary>
        private void SetAddEventHandler()
        {
            // イベントハンドラーの登録(テキストの追加)
            InputCycleNumberText.GotFocus += TextBox_GotFocus;
            InputCycleNumberText.LostFocus += TextBox_LostFocus;
            // フォームにTextBoxを追加
            Controls.Add(InputCycleNumberText);
        }

        /// <summary>
        /// 時間に応じてメッセージを変更する(午前⇒おはようなど)
        /// </summary>
        private void SetTimeTextChange()
        {
            // 今の時間を取得
            DateTime currentTime = DateTime.Now;
            // 現在時刻が5:00 ～ 11:00の場合
            if (currentTime.Hour >= 5 && currentTime.Hour < 12)
            {
                CurrentStateText.Text = "おはようございます。";
            }
            // 現在時刻が12:00 ～ 15:00の場合
            else if (currentTime.Hour <= 15)
            {
                CurrentStateText.Text = "もうお昼ですね。";
            }
            // 現在時刻が16:00 ～ 17:00の場合
            else if (currentTime.Hour <= 17)
            {
                CurrentStateText.Text = "もう夕方ですね。";
            }
            // それ以外の処理
            else
            {
                CurrentStateText.Text = "夜までお疲れ様です。";
            }

            // テキストを修正不可
            CurrentStateText.Enabled = false;

            // 文字を書き換えられないようにする
            CurrentTimeText.Enabled = false;
        }

        /// <summary>
        /// 時間に応じてメッセージを変更する(午前⇒おはようなど)
        /// </summary>
        private void SetDateTime()
        {
            // 今の時間を取得
            DateTime currentTime = DateTime.Now;
            // 分の整形(12:5⇒12:50)
            if (currentTime.Minute == 0)
            {
                CurrentTimeText.Text =
                    currentTime.Hour + "時 " + currentTime.Minute + "0分 ";
            }
            // 分の修正(12:5⇒12:05)
            else if (currentTime.Minute < 10)
            {
                CurrentTimeText.Text =
                    currentTime.Hour + "時 " + "0" + currentTime.Minute + "分 ";
            }
            // それ以外の場合
            else
            {
                CurrentTimeText.Text =
                    currentTime.Hour + "時 " + currentTime.Minute + "分 ";
            }

        }

        /// <summary>
        /// 出勤状況をラベルに表示する
        /// </summary>
        private void SetWorkIsNow()
        {
            // ラベルの初期表示
            WorkNowLabel.Text = "退勤済です。";

            // 出勤ボタンが押されている場合
            if (isCheckStartingButtonFlg == true)
            {
                WorkNowLabel.Text = "出勤済です。";
            }
        }

        /// <summary>
        /// 1分ごとに処理を繰り返し実行する
        /// </summary>
        private void SetReLoadOneMinute()
        {

            // System.Timers.Timer型のフィールド
            System.Windows.Forms.Timer checkTimer;

            // Timerのインスタンスを作成
            checkTimer = new System.Windows.Forms.Timer();

            // インターバルを設定（15秒 = 15000ミリ秒）
            checkTimer.Interval = 15000;

            // タイマーのTickイベントを処理するメソッドを設定
            checkTimer.Tick += CheckTimer_Tick;

            // タイマーを開始
            checkTimer.Start();
        }

        /// <summary>
        /// タイマーのTickイベント処理
        /// </summary>
        private void CheckTimer_Tick(object? sender, EventArgs? e)
        {
            // 1分ごとに駐輪金額を再計算する
            SetRecalculationCurrentMoney();
        }

        /// <summary>
        /// タイマーのTickイベント処理
        /// </summary>
        private void SetRecalculationCurrentMoney()
        {
            // 出勤ボタンが押されていないと処理できないようにしたい
            if (isCheckStartingButtonFlg == true)
            {
                // 現在の時刻から出勤ボタンが押された時間を引いた変数
                TimeSpan paymentTime = DateTime.Now - startTime;

                // 14時間を経過しているか確認
                if (paymentTime.Hours >= hoursInterval)
                {
                    // 何時間経過しているか確認
                    int recalc = (int)Math.Floor(paymentTime.TotalHours / hoursInterval);

                    // 14時間ごとに100(円)加算
                    currentPaymentMoney += recalc * paymentIncrement;
                }

                CurrentMoneyLabel.Text =
                     "現在の駐輪金額は " + currentPaymentMoney + " 円です。";
            }

        }


        /// <summary>
        /// テキストボックスにフォーカスされた時のプレースホルダ処理
        /// </summary>
        private void TextBox_GotFocus(object? sender, EventArgs? e)
        {

            // フォーカスされたときにプレースホルダーを消す
            if (InputCycleNumberText.Text == "駐輪番号を入力して下さい。")
            {
                InputCycleNumberText.Text = "";
                InputCycleNumberText.ForeColor = System.Drawing.Color.Black;
            }


        }

        /// <summary>
        /// テキストボックスのフォーカスが外れたときの処理
        /// </summary>
        private void TextBox_LostFocus(object? sender, EventArgs? e)
        {
            // フォーカスが外れたときにプレースホルダーを表示
            if (string.IsNullOrWhiteSpace(InputCycleNumberText.Text))
            {
                InputCycleNumberText.Text = "駐輪番号を入力して下さい。";
                InputCycleNumberText.ForeColor = System.Drawing.Color.Gray;
            }
        }

        /// <summary>
        /// 確定ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 駐輪番号を格納
                String input = InputCycleNumberText.Text;

                // 駐輪番号を格納するまでの一連の操作
                SetCycleNumberKeisan(input, ref isCheckExcecuteFlg);

                // 正しく変更処理できた場合
                if (isCheckExcecuteFlg == true)
                {
                    MessageBox.Show(cycleNumber.ToString() + " 番に自転車を駐輪しました。", "駐輪完了",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("エラーが発生しました\nエラー内容:" + ex.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 駐輪番号を格納するまでの一連の操作
        /// </summary>
        private void SetCycleNumberKeisan(String input, ref Boolean isBooleanFlg)
        {
            // 駐輪番号格納メソッド
            SetCycleNumber(input, ref isBooleanFlg);
            // 本日の駐輪番号のテキストを表示する
            SetTodayCycleNumberChangeText();
            // 確定・変更ボタンのフラグの状態を変える
            SetTransformButton();
        }

        /// <summary>
        /// 駐輪番号を格納するメソッド
        /// </summary>
        private void SetCycleNumber(String input, ref Boolean isBooleanFlg)
        {

            try
            {
                // 入力された値を数値に変換
                int intputInt = int.Parse(input);

                // 入力された値が駐輪場最終番号より大きくないか確認
                if (intputInt <= lastCycleNumber)
                {
                    // 結果を駐輪番号に格納
                    cycleNumber = intputInt;

                    // commonの駐輪番号にも格納
                    Common.CycleNumber = intputInt;

                    // 確定ボタンフラグか変更フラグをtrue
                    isBooleanFlg = true;
                }
                else
                {
                    // エラーの場合は出勤・変更フラグをfalse
                    isBooleanFlg = false;

                    // 入力された値が駐輪場最終番号より大きい場合
                    throw new OverflowException();
                }

            }
            catch (OverflowException)
            {
                // エラーの場合は出勤・変更フラグをfalse
                isBooleanFlg = false;

                MessageBox.Show($"入力された数値が大きすぎます。 " + lastCycleNumber + " 番まで入力できます。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                // エラーの場合は出勤・変更フラグをfalse
                isBooleanFlg = false;

                MessageBox.Show($"入力された文字列が数値に変換できません。\nエラー内容: " + ex.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // エラーの場合は出勤・変更フラグをfalse
                isBooleanFlg = false;

                // その他の予期しないエラー
                MessageBox.Show($"予期しないエラーが発生しました。\nエラー内容: " + ex.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 現在の駐輪番号を画面に表示する(出勤時と退勤時で使用)
        /// </summary>
        private void SetTodayCycleNumberChangeText()
        {
            // 出勤ボタンが押されている時
            if (isCheckStartingButtonFlg == true && isCheckFinishingButtonFlg == false)
            {
                // 今日の駐輪番号をラベルに表示する
                TodayCycleNumberLabel.Text = "本日の駐輪場番号は " + cycleNumber + " 番です。";
            }
            // 退勤ボタンが押されている時
            else if (isCheckFinishingButtonFlg == true)
            {
                // 退勤ボタンが押されている場合はメッセージを変える
                TodayCycleNumberLabel.Text = "本日もお疲れ様です。";
            }
            else
            {
                // どちらも押されていない場合
                TodayCycleNumberLabel.Text = "出勤ボタンを押してください。";
            }
        }

        /// <summary>
        /// 確定・変更ボタン押下時の活性化処理
        /// </summary>
        private void SetTransformButton()
        {
            // 確定ボタン押下時
            if (isCheckExcecuteFlg == true)
            {
                // 確定ボタンを非活性化
                ExecuteButton.Enabled = false;
            }
        }

        /// <summary>
        /// 変更ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HenkoButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 確定ボタンが押さているかつ、確定ボタンが押下されていないか確認
                if (isCheckExcecuteFlg       == true && 
                    isCheckStartingButtonFlg != true)
                {
                    // 駐輪番号を格納
                    String input = InputCycleNumberText.Text;

                    // ダイアログを表示
                    DialogResult result = MessageBox.Show
                    (
                        "駐輪番号を " + input + " 番に変更しますか？",
                        "確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // はいを選択した場合
                    if (result == DialogResult.Yes)
                    {
                        // 駐輪番号を格納するまでの一連の操作
                        SetCycleNumberKeisan(input, ref isCheckHenkoFlg);

                        // 正しく変更処理できた場合
                        if (isCheckHenkoFlg == true)
                        {
                            MessageBox.Show("駐輪番号を " + cycleNumber + " 番に変更しました。", "変更完了",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }

                    }
                    // いいえを選択した場合
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show(" 操作がキャンセルされました。", "操作取り消し",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
                // 出勤ボタンが押下されている場合は、変更できない
                else if (isCheckStartingButtonFlg == true)
                {
                    MessageBox.Show($"出勤ボタンが押下された為、駐輪番号を変更することができません。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // 確定ボタン押下していない場合
                else
                {
                    MessageBox.Show($"最初に確定ボタンを押して下さい。",
                   "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("エラーが発生しました\nエラー内容:" + ex.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("直前に変更した " + cycleNumber + " 番が格納されています。");
            }
        }

        /// <summary>
        /// 出勤ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartingWorkButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 確定ボタンを押して駐輪番号が格納されている場合
                if (isCheckExcecuteFlg        == true && 
                    InputCycleNumberText.Text == cycleNumber.ToString())
                {
                    // 出勤ボタンをtrue
                    isCheckStartingButtonFlg = true;

                    // 退勤ボタンをfalse
                    isCheckFinishingButtonFlg = false;

                    // 出勤・退勤ボタン押下時の処理
                    SetWorkButton();

                    // コマンド入力
                    string syutokuCmd = @"
                    INSERT INTO dbo.RecordsCycleNumber 
                    (UserId, UserName, CycleNumber, WorkDate, CheckInTime, IsCheckedOut)
                    VALUES (@UserId, @UserName, @CycleNumber, CONVERT(date, GETDATE()), GETDATE(), 0)";

                    // DB接続、駐輪番号をレコードテーブルに格納する
                    SetPublicCycleNumberAndDBConnect(syutokuCmd, 1);

                    // 駐輪番号を格納している場合、テキストに表示
                    String cmdText = @"
                    SELECT TOP 1
                        CycleNumber,
                        CheckInTime,
                        CheckOutTime
                    FROM RecordsCycleNumber
                    WHERE UserId = @UserId
                        AND CycleNumber IS NOT NULL
                        AND CAST(WorkDate AS date) = CAST(GETDATE() AS date)
                    ORDER BY CheckInTime DESC;
                ";

                    // インスタンス作成
                    Common commonInstance = new Common();

                    // 判定用変数
                    object[] result = commonInstance.IsSelectResult(cmdText);

                    // 本日、駐輪番号を格納した場合
                    if (result != null && result[0] != DBNull.Value)
                    {
                        // 今日の駐輪場を利用し始めた時間を格納
                        startTime = (DateTime)result[1];
                    }
                    else
                    {
                        MessageBox.Show($"駐輪場に格納した時間の取得に失敗しました。",
                        "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // 現在の時刻を格納
                        startTime = DateTime.Now;
                    }

                }
                // 確定ボタンを押しているかつ、格納されている駐輪番号とテキストに表示されている駐輪番号が一致しない場合
                else if (isCheckExcecuteFlg       == true && 
                        InputCycleNumberText.Text != cycleNumber.ToString())
                {
                    MessageBox.Show($"元々格納した駐輪番号に正しくするか、駐輪番号を変更してください。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // 確定ボタンを押していない場合
                else
                {
                    MessageBox.Show($"先に駐輪番号を入力して確定ボタンを押してください。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("エラーが発生しました\nエラー内容:" + ex.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 退勤ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishingWorkButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 出勤ボタンを押しているか確認
                if (isCheckStartingButtonFlg == true)
                {
                    // 退勤ボタンをtrue
                    isCheckFinishingButtonFlg = true;

                    // 出勤ボタンをfalse
                    isCheckStartingButtonFlg = false;

                    // 駐輪番号を格納するテキストを空白にする(個人的に気になる為)
                    InputCycleNumberText.Text = "";

                    // 出勤・退勤ボタン押下時の処理
                    SetWorkButton();

                    // コマンド入力
                    string syutokuCmd = @"
                        UPDATE RecordsCycleNumber
                        SET CheckOutTime = @CheckOutTime
                        WHERE UserId = @UserId
                          AND UserName = @UserName
                          AND CAST(WorkDate AS date) = CAST(@Today AS date);
                    ";

                    // DB接続、駐輪番号をレコードテーブルに格納する
                    SetPublicCycleNumberAndDBConnect(syutokuCmd, 2);
                }
                // 出勤ボタンを押していない場合
                else
                {
                    MessageBox.Show($"出勤ボタンが押されていない為出勤できません。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("エラーが発生しました\nエラー内容:" + ex.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 出勤・退勤ボタン押下時のひとまとまり処理
        /// </summary>
        private void SetWorkButton()
        {
            // 出勤・退勤ボタン押下時のそれぞれのテキストチェンジなど
            SetWorkChangeText();

            // 出勤状況をラベルに表示する
            SetWorkIsNow();

            // 現在の駐輪番号を画面に表示する(出勤時と退勤時で使用)
            SetTodayCycleNumberChangeText();
        }

        /// <summary>
        /// 出勤・退勤ボタン押下時のそれぞれのテキストチェンジなど
        /// </summary>
        private void SetWorkChangeText()
        {
            // 出勤ボタンが押下された場合
            if (isCheckStartingButtonFlg == true && isCheckFinishingButtonFlg == false)
            {
                // 出勤ボタンを非活性
                StartingWorkButton.Enabled = false;

                // 駐輪番号を変更できないようにする。
                InputCycleNumberText.Enabled = false;

                // 今の駐輪金額を表示
                CurrentMoneyLabel.Text = "現在の駐輪金額は " + currentPaymentMoney + " 円です。";

                // 出勤した旨をユーザに知らせる
                MessageBox.Show(" 出勤しました。", "出勤ボタン押下",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            }
            // 退勤ボタンが押下された場合
            else if (isCheckFinishingButtonFlg == true)
            {
                // 出勤ボタンを活性化
                StartingWorkButton.Enabled = true;

                // 駐輪番号を変更できるようにする。
                InputCycleNumberText.Enabled = true;

                // 確定ボタン活性の変更ボタン非活性
                ExecuteButton.Enabled = true;

                // 確定ボタンフラグを非活性
                isCheckExcecuteFlg = false;

                // 退勤ボタン押下時に現在の駐輪金額を初期化
                currentPaymentMoney = 100;

                // 今の駐輪金額を表示
                CurrentMoneyLabel.Text = "現在の駐輪金額は " + 0 + " 円です。";

                // 退勤した旨をユーザに知らせる
                MessageBox.Show(" 本日もお疲れさまでした。", "退勤ボタン押下",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// DB接続と駐輪番号（Common）を格納
        /// insertOrUpdateFlg：1=INSERT, 2=UPDATE, 3=DELETE
        /// </summary>
        private void SetPublicCycleNumberAndDBConnect(string syutokuCmd, int insertOrUpdateFlg)
        {
            try
            {
                // インスタンス作成
                Common commonInstance = new Common();

                // 追加・更新が成功したか判断する為の変数
                bool insertOk = false;
                bool updateOk = false;

                if (insertOrUpdateFlg == 1)
                {
                    // インサート実行（駐輪番号をDBに格納）
                    insertOk = commonInstance.ExecuteSql(1, 1, syutokuCmd, Common.UserID, Common.CycleUserName, "0");
                }
                else if (insertOrUpdateFlg == 2)
                {
                    // アップデート実行（退勤時刻をDBへ格納）
                    updateOk = commonInstance.ExecuteSql(2, 0, syutokuCmd, Common.UserID, Common.CycleUserName, "");
                }
            }

            catch (Exception ex)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("エラーが発生しました\nエラー内容:" + ex.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
