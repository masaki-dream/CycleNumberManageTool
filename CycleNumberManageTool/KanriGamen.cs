using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CycleNumberManageTool
{
    public partial class KanriGamen : Form
    {
        public KanriGamen()
        {
            InitializeComponent();

            // タイトルバーのテキストを設定
            this.Text = "管理画面";
        }

        /// <summary>
        /// ロード画面
        /// </summary>
        private void KanriGamen_Load(object sender, EventArgs e)
        {
            // 管理ユーザー名にフォーカスが行くようにする(プロパティのTabIndexを変えてもいける)
            this.KanriUserText.Focus();

            // 管理グリッドビューを非表示
            KanriGv.Visible = false;
            ExcuteButton.Visible = false;

            // グリッドビューの選択行の管理(更新、削除それぞれ片方しかチェックできないようにする)
            KanriGv.CellValueChanged += KanriGv_CellValueChanged;
            KanriGv.CurrentCellDirtyStateChanged += KanriGv_CurrentCellDirtyStateChanged;
        }

        /// <summary>
        /// グリッドビューのチェック行コミット処理
        /// </summary>
        private void KanriGv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (KanriGv.IsCurrentCellDirty)
            {
                KanriGv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 更新、削除チェック押下時に同時に押せないように制御
        /// </summary>
        private void KanriGv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダー行は無視
            if (e.RowIndex < 0) return;

            DataGridViewRow row = KanriGv.Rows[e.RowIndex];

            if (KanriGv.Columns[e.ColumnIndex].Name == "UpdateCheck")
            {
                bool isUpdateChecked = Convert.ToBoolean(row.Cells["UpdateCheck"].Value ?? false);
                bool isDeleteChecked = Convert.ToBoolean(row.Cells["DeleteCheck"].Value ?? false);

                if (isUpdateChecked && isDeleteChecked)
                {
                    MessageBox.Show("この行は削除チェックが付いているため、更新チェックはできません。", "操作エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["UpdateCheck"].Value = false; // 無効化（押された更新チェックを戻す）
                    return;
                }

            }
            else if (KanriGv.Columns[e.ColumnIndex].Name == "DeleteCheck")
            {
                bool isDeleteChecked = Convert.ToBoolean(row.Cells["DeleteCheck"].Value ?? false);
                bool isUpdateChecked = Convert.ToBoolean(row.Cells["UpdateCheck"].Value ?? false);

                if (isDeleteChecked && isUpdateChecked)
                {
                    MessageBox.Show("この行は更新チェックが付いているため、削除チェックはできません。", "操作エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["DeleteCheck"].Value = false; // 無効化（押された削除チェックを戻す）
                    return;
                }

            }
        }

        /// <summary>
        /// 管理画面ログイン押下時
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // bool型の変数を用意
            bool check = false;

            // Commonクラスのインスタンス作成(クラスを使用する為)
            Common commonInstance = new Common();

            // 新規作成画面のユーザー名とパスワードとcmdを取得
            String userName = KanriUserText.Text;
            String password = KanriPasswordText.Text;
            String cmdText  = "SELECT * FROM KanriTable WHERE UserName = @UserName";

            // 入力値の確認
            check = commonInstance.IsCheckError(userName, password);

            // 戻り値がfalseの場合処理を中断する
            if (check == false)
            {
                return;
            }

            // 管理者のユーザーであるかチェック
            // DBと照合して認証する処理
            check = commonInstance.Authentication(userName, password, cmdText);

            // 認証結果を返す
            if (check == true)
            {
                MessageBox.Show("ようこそ！管理者の " + KanriUserText.Text + " さん\n以下のグリッドがデータとなります。", "認証完了",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                // グリッドビューに情報を格納
                commonInstance.SetDataTableVaue(KanriGv, ExcuteButton);

            }
            // 認証失敗の場合
            else
            {
                // 入力されたユーザー名・パスワードのテキストを空白にする
                KanriUserText.Text = commonInstance.NameAndPasswordTextChangeBlank();
                KanriPasswordText.Text = commonInstance.NameAndPasswordTextChangeBlank();

                // ユーザー向けのエラーメッセージを表示
                MessageBox.Show("ユーザー名またはパスワードに誤りがあります。",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (result == DialogResult.Yes)
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
            else if (result == DialogResult.No)
            {
                // 操作を取り消す
                MessageBox.Show("操作が取り消されました。", "操作取り消し",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }

        ///// <summary>
        ///// 更新・削除ボタン押下時処理
        ///// </summary>
        private void ExcuteButton_Click(object sender, EventArgs e)
        {
            // 確認ダイアログを表示
            DialogResult result = MessageBox.Show(
                "更新・削除処理を実行しますか？",
                "確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            // キャンセルされた場合は何もしない
            if (result != DialogResult.OK)
            {
                return;
            }

            try
            {
                // 削除対象フラグ
                bool updateFlg = false;
                
                // 更新した行をカウントする変数
                int updateCount = 0;

                // Commonクラスのインスタンス作成(クラスを使用する為)
                Common commonInstance = new Common();

                // 更新Gvまで繰り返す
                foreach (DataGridViewRow row in KanriGv.Rows)
                {
                    // 行が新規行でない、かつUpdateCheckがtrueの場合のみ更新
                    if (!row.IsNewRow && Convert.ToBoolean(row.Cells["UpdateCheck"].Value) == true)
                    {
                        // 値を取得
                        int userId = Convert.ToInt32(row.Cells["UserId"].Value);
                        string userName = row.Cells["UserName"].Value?.ToString() ?? "";
                        string password = row.Cells["Password"].Value?.ToString() ?? "";

                        // 今ログインしている管理自身を更新・削除しようとした場合、処理を中止する。
                        if (userId - 1 == Common.UserID)
                        {
                            // 管理者は削除できない旨を表示
                            MessageBox.Show("現在ログインしている管理者アカウントは更新できません。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // スキップ
                            continue;
                        }
                        else
                        {

                            // 更新するユーザー名が既に存在しているか確認
                            // 既に名前が登録されているか確認
                            bool resultCount = commonInstance.IsUserNameExists(userName);

                            if (resultCount)
                            {
                                // SQLコマンド作成
                                string syutokuCmd = "UPDATE LoginCycleNumber SET UserName = @UserName, Password = @Password WHERE UserId = @UserId";

                                // DBに更新する処理
                                updateFlg = commonInstance.ExecuteSql(2, 0, syutokuCmd, userId, userName, password);

                                // 更新した行数をインクリメント
                                updateCount++;
                            }
                            else
                            {
                                MessageBox.Show(
                                    $"{userName} は既に存在している為、ユーザー名を更新できません。",
                                    "情報",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                // 処理をスキップ（削除行チェックに行く）
                                continue;
                            }

                        }
                    }
                }


                // 削除対象フラグ
                bool deleteFlg = false;

                // 更新した行をカウントする変数
                int deleteCount = 0;

                // 行を逆順に取得（削除時のインデックスずれを防ぐ）
                for (int i = KanriGv.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = KanriGv.Rows[i];

                    // 行が新規行でない、かつDeleteCheckがtrueの場合のみ削除
                    if (!row.IsNewRow && Convert.ToBoolean(row.Cells["DeleteCheck"].Value) == true)
                    {
                        int userId = Convert.ToInt32(row.Cells["UserId"].Value);

                        // 今ログインしている管理自身を更新・削除しようとした場合、処理を中止する。
                        if (userId - 1 == Common.UserID)
                        {
                            // 管理者は削除できない旨を表示
                            MessageBox.Show("現在ログインしている管理者アカウントは削除できません。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // スキップ
                            continue;
                        }
                        else
                        {
                            string syutokuCmd = "DELETE FROM LoginCycleNumber WHERE UserId = @UserId";

                            // DBに削除する処理
                            deleteFlg = commonInstance.ExecuteSql(3, 0, syutokuCmd, userId, "", "");

                            // グリッドビュー上の行も削除（UI反映）
                            KanriGv.Rows.RemoveAt(i);

                            // 削除した行数をインクリメント
                            deleteCount++;
                        }
                    }
                }

                // メッセージ表示
                if (deleteFlg && updateFlg)
                {
                    MessageBox.Show($"更新 {updateCount} 行・削除 {deleteCount} 行が実行されました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (deleteFlg && !updateFlg)
                {
                    MessageBox.Show($"削除が {deleteCount} 行完了しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!deleteFlg && updateFlg)
                {
                    MessageBox.Show($"更新が {updateCount} 行完了しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("更新・削除対象が選択されていません。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("更新・削除中にエラーが発生しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
