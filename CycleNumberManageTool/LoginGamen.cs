using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CycleNumberManageTool
{
    public partial class LoginGamen : Form
    {
        public LoginGamen()
        {
            InitializeComponent();

            // タイトルバーのテキストを設定
            this.Text = "ログイン画面";
        }

        /// <summary>
        /// ログイン画面ロード時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginGamen_Load(object sender, EventArgs e)
        {
            // 何かあれば適宜追加
        }

        /// <summary>
        /// ログイン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // bool型の変数を用意
            bool check = false;

            // Commonクラスのインスタンス作成(クラスを使用する為)
            Common commonInstance = new Common();

            // 新規作成画面のユーザー名(publicも)とパスワードとcmdを取得
            String userName      = UserNameText.Text;
            Common.CycleUserName = userName;
            String password      = PasswordText.Text;
            String cmdText       = "select * from LoginCycleNumber where UserName = @UserName";

            // 入力値の確認
            check = commonInstance.IsCheckError(userName, password);

            // 戻り値がfalseの場合処理を中断する
            if (check == false)
            {
                return;
            }

            // DBと照合して認証する処理
            check = commonInstance.Authentication(userName, password, cmdText);

            // 認証結果を返す
            if (check == true)
            {

                // ユーザ名、パスワードを共通変数に格納
                Common.SetCredentials(userName, password);

                MessageBox.Show("ようこそ！ " + UserNameText.Text + " さん\n駐輪場画面に遷移します。", "認証完了",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                // 遷移元の画面を非表示にする
                this.Hide();

                // 駐輪画面に遷移する
                CycleNumberKeisanGamen circleGamen = new CycleNumberKeisanGamen();
                circleGamen.Show();

            }
            // 認証失敗の場合
            else
            {
                // 入力されたユーザー名・パスワードのテキストを空白にする
                UserNameText.Text = commonInstance.NameAndPasswordTextChangeBlank();
                PasswordText.Text = commonInstance.NameAndPasswordTextChangeBlank();

                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("ユーザー名またはパスワードに誤りがあります。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 新規作成押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 遷移元の画面を非表示にする
            this.Hide();

            // アカウント新規作成画面のインスタンス作成
            InsertLoginGamen insertAccount = new InsertLoginGamen();

            // アカウント新規作成画面に遷移する
            insertAccount.Show();

        }

        // 管理者ページのログインボタン
        private void kanriButton_Click(object sender, EventArgs e)
        {
            // 遷移元の画面を非表示にする
            this.Hide();

            // アカウント新規作成画面のインスタンス作成
            KanriGamen kanriAccount = new KanriGamen();

            // アカウント新規作成画面に遷移する
            kanriAccount.Show();
        }
    }
}
