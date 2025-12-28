using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleNumberManageTool
{
    public partial class InsertLoginGamen : Form
    {
        public InsertLoginGamen()
        {
            InitializeComponent();

            // タイトルバーのテキストを設定
            this.Text = "アカウント新規追加画面";
        }

        // 新規作成ボタン押下時処理
        private void ShinkiLoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Commonクラスのインスタンス作成(クラスを使用する為)
                Common commonInstance = new Common();

                // 入力チェックを行う

                // bool型の変数を用意
                bool check       = false;
                bool insertCheck = false;

                // 入力値の確認
                check = this.IsCheckShinkiError(commonInstance);

                // 戻り値がfalseの場合処理を中断する
                if (check == false)
                {
                    return;
                }

                // ユーザーに内容の確認をするメッセージ
                MessageBox.Show("以下の内容で登録してもよろしいでしょうか。\n" +
                        "ユーザー名 : " + InsertUserNameText.Text +"\n" +
                        "パスワード : " + InsertPasswordText.Text, "アカウント新規作成前確認",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // ID取得用変数
                int userID_insert = 0;
                String userName = InsertUserNameText.Text;
                String password = InsertPasswordText.Text;

                // INSERT文
                string syutokuCmd = "INSERT INTO LoginCycleNumber (UserId, UserName,Password) VALUES (@UserId, @UserName, @Password)";


                // 同じユーザが存在しないかの確認とID取得
                check = this.addAccount(commonInstance, ref userID_insert);

                // 同じユーザが存在した場合は処理終了
                if (check == true) 
                {
                    // DBにinsertする処理
                    insertCheck = commonInstance.ExecuteSql(1, 0, syutokuCmd, userID_insert, userName, password);
                }

                // 認証結果を返す
                if (check == true && insertCheck == true)
                {
                    MessageBox.Show("アカウントの新規作成が正常に行われました。\n" +
                        "ログイン画面でログインし直して下さい。", "新規作成完了",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    // 遷移元の画面を非表示にする
                    this.Hide();

                    // ログイン画面に遷移する
                    LoginGamen login = new LoginGamen();
                    login.Show();

                }
                // DBにinset失敗の場合
                else
                {
                    // ユーザー向けのエラーメッセージを表示
                    MessageBox.Show("アカウントの新規作成が出来ませんでした。",
                        "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 接続失敗の処理
            catch (SqlException )
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("SQLの接続エラーです。" ,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 新規作成時のエラーチェック処理
        /// </summary>
        private bool IsCheckShinkiError(Common commonInstance)
        {
            // 新規作成画面のユーザー名とパスワードを取得
            String userName = InsertUserNameText.Text;
            String password = InsertPasswordText.Text;

            // 入力値の確認
            bool check = commonInstance.IsCheckError(userName, password);

            // 戻り値がfalseの場合処理を中断する
            if (check == false)
            {
                return false;
            }


            // パスワード再確認を取得
            String rePassword = ReCheckPasswordText.Text;

            // 入力されたパスワードとパスワード再確認が一致している場合
            if(password == rePassword)
            {
                // 一致していればtrue
                return true;
            }
            // 入力されたパスワードとパスワード再確認が一致していない場合
            else
            {
                // パスワードテキストを空白にする
                InsertPasswordText.Text = commonInstance.NameAndPasswordTextChangeBlank();
                ReCheckPasswordText.Text = commonInstance.NameAndPasswordTextChangeBlank();

                // エラーメッセージ
                MessageBox.Show("パスワードとパスワード再確認が一致しません。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 一致していないとfalse
                return false;
            }
        }

        /// <summary>
        /// アカウントをDBに登録する処理
        /// </summary>
        private bool addAccount(Common commonInstance, ref int userID_insert)
        {
            // 接続文字列作成
            string connectionString = "Data Source=localhost;Initial Catalog=LoginCycle;Integrated Security=SSPI; TrustServerCertificate = True";

            // 接続成功時の処理
            try
            {
                // SqlConnectionのインスタンスを作成
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    // ユーザID,ユーザー名,パスワードを準備する
                    int userId = 0;
                    String userName = InsertUserNameText.Text;
                    String password = InsertPasswordText.Text;

                    // 接続
                    connection.Open();

                    // 既に名前が登録されているか確認
                    bool resultCount = commonInstance.IsUserNameExists(userName);

                    // 既にDBに同じ名前が存在しているときの処理
                    if (!resultCount)
                    {
                        // 全てのテキストを空白にする
                        InsertUserNameText.Text = commonInstance.NameAndPasswordTextChangeBlank();
                        InsertPasswordText.Text = commonInstance.NameAndPasswordTextChangeBlank();
                        ReCheckPasswordText.Text = commonInstance.NameAndPasswordTextChangeBlank();

                        // 同じ名前が存在する場合エラー文を表示
                        MessageBox.Show("他のユーザー名にして下さい。",
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // エラーの場合falseを返す
                        return false;
                    }

                    // 現在の最大 userId を取得
                    const string getMaxUserIdQuery = "SELECT ISNULL(MAX(UserId), 0) FROM LoginCycleNumber";

                    using (SqlCommand getMaxUserIdCommand = new SqlCommand(getMaxUserIdQuery, connection))
                    {

                        // 最初の列にある値を取得する(UserIDの最大値)
                        object result = getMaxUserIdCommand.ExecuteScalar();

                        // 最大 userId に 1 を加える
                        userId = (int)result + 1;

                        // insertで使用する為、userID_insertに格納
                        userID_insert = userId;
                    }

                    // 新規作成が成功したのでtrue
                    return true;
                }

            }
            // 接続失敗の処理
            catch (SqlException e)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("SQLの接続エラーです。" + e.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // エラーの場合falseを返す
                return false;
            }
        }

        /// <summary>
        /// 戻るボタン押下時処理
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            // ダイアログを表示
            DialogResult result = MessageBox.Show
            (
                "ログイン画面に戻りますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // ユーザが「はい」を押した場合
            if( result == DialogResult.Yes )
            {
                // ログイン画面に移動する
                MessageBox.Show("ログイン画面に遷移します。", "ログイン画面に移動",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                // インスタンス作成
                LoginGamen loginGamen = new LoginGamen();

                // 遷移元の画面を非表示にする
                this.Hide();

                // ログイン画面に遷移する
                loginGamen.Show();
                
            }
            // ユーザが「いいえ」を押した場合
            else if ( result == DialogResult.No )
            {
                // 操作を取り消す
                MessageBox.Show("操作が取り消されました。", "操作取り消し",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }

    }
}
