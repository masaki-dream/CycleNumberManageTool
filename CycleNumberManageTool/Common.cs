using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CycleNumberManageTool
{
    public class Common
    {
        /// <summary>
        /// 定数宣言
        /// </summary>

        //【重要】ユーザ名とパスワードを取り出すときは、以下のように取り出す。
        // string pw = Common.CyclePassword;  // 読み取り専用で使用可能
        // ログアウト時は以下も実装する。
        // Common.ClearCredentials(); // メモリ上の値も破棄

        // ユーザ名
        public static int CycleNumber = 0;

        // ユーザ名
        public static string CycleUserName = "";

        // ユーザID
        public static int UserID = 0;

        // パスワードは内部で変換して保持
        private static string _securedPassword = string.Empty;

        // 読み取り専用プロパティ
        public static string CyclePassword
        {
            get
            {
                return Unsecure(_securedPassword);
            }
        }

        // ログイン時に初期化
        public static void SetCredentials(string loginUserName, string password)
        {
            CycleUserName = loginUserName;
            _securedPassword = Secure(password);
        }

        // ログアウト時に破棄（☓ボタン押したときに実装する）
        public static void ClearCredentials()
        {
            CycleUserName = string.Empty;
            _securedPassword = string.Empty;
        }

        // 簡易「隠す」処理（Base64 → 文字反転）
        private static string Secure(string plain)
        {
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(plain));
            char[] arr = base64.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        // 元に戻す
        private static string Unsecure(string secured)
        {
            char[] arr = secured.ToCharArray();
            Array.Reverse(arr);
            string base64 = new string(arr);
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }


        /// <summary>
        /// ログイン時に使用するメソッド
        /// </summary>
        public bool IsCheckError(String userName, String password)
        {
            // テキストにユーザー名が入力されているか確認
            if (userName == "")
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("ユーザー名を入力して下さい。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // falseを返す
                return false;
            }

            // テキストにパスワードが入力されているか確認
            if (password == "")
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("パスワードを入力して下さい。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // falseを返す
                return false;
            }

            // ユーザー名の文字数チェックを行う
            if (30 < userName.Length)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("ユーザー名が長すぎます。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // falseを返す
                return false;
            }

            // パスワードの文字数チェックを行う
            if (15 < password.Length)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("パスワードが長すぎます。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // falseを返す
                return false;
            }

            // エラーがなければtrueを返す
            return true;

        }

        /// <summary>
        /// テキストを空白にする処理
        /// </summary>
        public Func<String> NameAndPasswordTextChangeBlank = () => "";

        /// <summary>
        /// Gvにアカウント情報をセットする
        /// </summary>
        public void SetDataTableVaue(DataGridView dgv, Button ExcuteButton)
        {

            // 管理グリッドビュー,更新ボタン,削除ボタンを表示
            dgv.Visible = true;
            //UpdateBtn.Visible = true;
            //DelereBtn.Visible = true;
            ExcuteButton.Visible = true;

            // 色を変更する為の設定
            dgv.EnableHeadersVisualStyles = false;

            // 接続文字列作成
            string connectionString = "Data Source=localhost;Initial Catalog=LoginCycle;Integrated Security=SSPI; TrustServerCertificate = True";

            // 接続成功時の処理
            try
            {
                // SqlConnectionのインスタンスを作成
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    // 接続
                    connection.Open();

                    // ここでデータベース操作を行う
                    SqlCommand cmd = connection.CreateCommand();

                    // ここにSQL文を実行する
                    cmd.CommandText = "select * from LoginCycleNumber order by UserId";

                    // ここからGvの情報を取得
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd.CommandText, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgv.DataSource = dataTable;

                    // Gvの列幅を自動調整
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    //主キーの修正は不可にする 
                    dgv.Columns["UserId"].ReadOnly = true;

                    // 更新チェック列
                    DataGridViewCheckBoxColumn updateCol = new DataGridViewCheckBoxColumn();
                    updateCol.Name = "UpdateCheck";
                    updateCol.HeaderText = "更新行";
                    updateCol.Width = 30;
                    updateCol.ReadOnly = false;
                    // 列背景色（濃い青）
                    updateCol.DefaultCellStyle.BackColor = Color.FromArgb(180, 215, 255);
                    // ヘッダー色
                    updateCol.HeaderCell.Style.BackColor = Color.FromArgb(160, 200, 255);
                    updateCol.HeaderCell.Style.ForeColor = Color.Black;

                    // 削除チェック列
                    DataGridViewCheckBoxColumn deleteCol = new DataGridViewCheckBoxColumn();
                    deleteCol.Name = "DeleteCheck";
                    deleteCol.HeaderText = "削除行";
                    deleteCol.Width = 30;
                    deleteCol.ReadOnly = false;
                    // 列背景色（濃い赤）
                    deleteCol.DefaultCellStyle.BackColor = Color.FromArgb(255, 190, 190);
                    // ヘッダー色
                    deleteCol.HeaderCell.Style.BackColor = Color.FromArgb(255, 160, 160);
                    deleteCol.HeaderCell.Style.ForeColor = Color.Black;

                    // 重複追加を避けるためのチェック
                    if (!dgv.Columns.Contains("UpdateCheck"))
                        dgv.Columns.Add(updateCol);

                    if (!dgv.Columns.Contains("DeleteCheck"))
                        dgv.Columns.Add(deleteCol);

                    // 使用したら閉じる
                    //reder.Close();
                    cmd.Dispose();

                }

            }
            // 接続失敗の処理
            catch (SqlException e)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("SQLの接続エラーです。" + e.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 認証時に使用するメソッド
        /// </summary>
        public bool Authentication(String userName, String password, String cmdText)
        {
            // 接続文字列作成
            string connectionString = "Data Source=localhost;Initial Catalog=LoginCycle;Integrated Security=SSPI; TrustServerCertificate = True";

            // 接続成功時の処理
            try
            {
                // SqlConnectionのインスタンスを作成
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    // 接続
                    connection.Open();

                    // ここでデータベース操作を行う
                    SqlCommand cmd = connection.CreateCommand();

                    // 引数のcmdを取得
                    cmd.CommandText = cmdText;

                    // ここにパラメータを追加する(SQLインジェクション禁止の為)
                    cmd.Parameters.AddWithValue("@UserName", userName);

                    // SQL Serverから取得したデータを読み込む
                    SqlDataReader reder = cmd.ExecuteReader();

                    // SQLが読み込める限り先頭から一つずつデータを読み込む
                    while (reder.Read() == true)
                    {
                        int id = ((int)reder["UserId"]);
                        string DBname = ((string)reder["UserName"]).Trim();
                        string DBpassword = ((string)reder["Password"]).Trim();

                        // ユーザー名・パスワードが合致するか確認
                        if (userName == DBname && password == DBpassword)
                        {
                            // ユーザIDを格納
                            UserID = id;

                            // 使用したら閉じる
                            reder.Close();
                            cmd.Dispose();

                            // 合致する場合
                            return true;
                        }

                    }

                    // 使用したら閉じる
                    reder.Close();
                    cmd.Dispose();

                    // ユーザー名・パスワード共に合致しなかった場合
                    return false;
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
        /// フラグの通りにクエリを実行する
        /// ExcecuteFlag：1=INSERT, 2=UPDATE, 3=DELETE
        /// </summary>
        public bool ExecuteSql(int ExcecuteFlag, int insertflg, string syutokuCmd, int userId, string userName, string pass)
        {
            // 接続文字列
            string connectionString = "Data Source=localhost;Initial Catalog=LoginCycle;Integrated Security=SSPI;TrustServerCertificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();

                    // フラグによって実行するSQLを切り替える
                    switch (ExcecuteFlag)
                    {
                        case 1: // INSERT                   
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Parameters.AddWithValue("@UserName", userName);

                            // 駐輪番号をDBに格納時に使用
                            if (insertflg == 1) 
                            {
                                cmd.Parameters.AddWithValue("@CycleNumber", Common.CycleNumber);
                            }
                            // アカウント新規作成時の処理
                            else if(insertflg == 0)
                            {
                                cmd.Parameters.AddWithValue("@Password", pass);
                            }

                            cmd.CommandText = syutokuCmd;

                            break;

                        case 2: // UPDATE

                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Parameters.AddWithValue("@UserName", userName);
                            // 以下、管理画面の更新で使用
                            cmd.Parameters.AddWithValue("@Password", pass);
                            // 以下、退勤ボタン押下で使用
                            cmd.Parameters.AddWithValue("@CheckOutTime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Today", DateTime.Today);

                            cmd.CommandText = syutokuCmd;
                            
                            break;

                        case 3: // DELETE

                            cmd.Parameters.AddWithValue("@UserId", userId);

                            cmd.CommandText = syutokuCmd;
                            
                            break;

                        default:
                            MessageBox.Show("不正なフラグ値です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                    }

                    // 実行（INSERT/UPDATE/DELETEは ExecuteNonQuery を使う）
                    int result = cmd.ExecuteNonQuery();

                    cmd.Dispose();

                    // result は変更された行数。0なら処理失敗とみなす
                    return (result > 0);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("SQL実行中にエラーが発生しました。\n" + e.Message,
                    "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        /// <summary>
        /// 新規アカウント作成・名前更新時に、「既に登録されている名前であるか」確認する処理
        /// </summary>
        public bool IsUserNameExists(string userName)
        {
            // 接続成功時の処理
            try
            {
                // 接続文字列作成
                string connectionString = "Data Source=localhost;Initial Catalog=LoginCycle;Integrated Security=SSPI; TrustServerCertificate = True";

                const string userNameCheckQuery = "SELECT COUNT(*) FROM LoginCycleNumber WHERE UserName = @UserName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();

                    // select文を渡す
                    cmd.CommandText = userNameCheckQuery;


                    // パラメータを追加
                    cmd.Parameters.AddWithValue("@UserName", userName);

                    // 存在確認
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // 既にDBに同じ名前が存在しているときの処理
                    if (count > 0)
                    {
                        // 既に名前が登録されている場合は、falseを返す。
                        return false;
                    }
                    else
                    {
                        // 名前が存在しなかった場合は、trueとする。
                        return true;
                    }
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
        /// Selectした値の結果が帰ってくる処理（True : 結果あり False : 結果無し）
        /// </summary>
        public object[] IsSelectResult(string cmdText)
        {
            // 接続成功時の処理
            try
            {
                // 接続文字列作成
                string connectionString = "Data Source=localhost;Initial Catalog=LoginCycle;Integrated Security=SSPI; TrustServerCertificate = True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddWithValue("@UserId", Common.UserID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new object[]
                            {
                                reader.IsDBNull(0) ? null : reader.GetString(0),
                                reader.IsDBNull(1) ? null : reader.GetDateTime(1),
                                reader.IsDBNull(2) ? null : reader.GetDateTime(2)
                            };
                        }
                    }

                    return null;
                }                
            }

            // 接続失敗の処理
            catch (SqlException e)
            {
                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("SQLの接続エラーです。" + e.Message,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // エラーの場合nullを返す
                return null;
            }
        }


    }
}
