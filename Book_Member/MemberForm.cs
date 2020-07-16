using System;
using System.Data;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Book_Member
{
    public partial class MemberForm : MetroForm
    {
        public enum BaseMode
        {
            NONE,       // 기본상태
            INSERT,     // 입력상태
            UPDATE,     // 수정상태
            DELETE,
            SELECT
        }

        public class Commons
        {
            public static readonly string CONNSTR = "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";
        }

        readonly string strTblName = "divTbl";

        BaseMode MyMode = BaseMode.NONE;    // 최초에는 기본상태

        public MemberForm()
        {
            InitializeComponent();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            UpdateData();
            InitControls();
        }

        private void InitControls()
        {
            TxtIdx.Text = TxtName.Text = string.Empty;
            TxtAdr.Text = TxtPhone.Text = TxtEmail.Text = string.Empty;
            CboGrade.SelectedIndex = 0;
            TxtIdx.Focus();

            TxtIdx.ReadOnly = true;

            MyMode = BaseMode.NONE;
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT Idx, " +
                                   "       Names, " +
                                   "       Levels, " +
                                   "       Addr, " +
                                   "       Mobile, " +
                                   "       Email " +
                                   "  FROM bookrentalshop.membertbl ";

                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = strTblName;
            }
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            DataGridViewColumn column;

            column = GrdDivTbl.Columns[0];
            column.Width = 100;
            column.HeaderText = "순번";

            column = GrdDivTbl.Columns[1];
            column.Width = 100;
            column.HeaderText = "이름";

            column = GrdDivTbl.Columns[2];
            column.Width = 100;
            column.HeaderText = "등급";

            column = GrdDivTbl.Columns[3];
            column.Width = 200;
            column.HeaderText = "주소";

            column = GrdDivTbl.Columns[4];
            column.Width = 100;
            column.HeaderText = "핸드폰";

            column = GrdDivTbl.Columns[5];
            column.Width = 200;
            column.HeaderText = "이메일";
        }

        private void SaveData()
        {
            if (string.IsNullOrEmpty(TxtName.Text)
                || CboGrade.SelectedIndex == 0
                || string.IsNullOrEmpty(TxtAdr.Text)
                || string.IsNullOrEmpty(TxtPhone.Text)
                || string.IsNullOrEmpty(TxtEmail.Text))
            {
                MetroMessageBox.Show(this, "빈값은 넣을 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MyMode == BaseMode.NONE)
            {
                MetroMessageBox.Show(this, "신규등록버튼을 누르고 신규등록하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (MyMode == BaseMode.UPDATE)

                    {
                        cmd.CommandText = "UPDATE bookrentalshop.membertbl " +
                                          "   SET  Names  = @Names, " +
                                          "       Levels = @Levels, " +
                                          "       Addr   = @Addr, " +
                                          "       Mobile = @Mobile, " +
                                          "       Email  = @Email " +
                                          " WHERE Idx    = @Idx ";
                    }
                    else if (MyMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT INTO bookrentalshop.membertbl " +
                                          " ( " +
                                          "     Names, " +
                                          "     Levels, " +
                                          "     Addr, " +
                                          "     Mobile, " +
                                          "     Email) " +
                                          " VALUES " +
                                          " ( " +
                                          "     @Names, " +
                                          "     @Levels, " +
                                          "     @Addr, " +
                                          "     @Mobile, " +
                                          "     @Email) ";
                    }

                    MySqlParameter paramName = new MySqlParameter("@Names", MySqlDbType.VarChar, 45)

                    {
                        Value = TxtName.Text
                    };
                    cmd.Parameters.Add(paramName);

                    MySqlParameter paramLevel = new MySqlParameter("@Levels", MySqlDbType.VarChar, 1)
                    {
                        Value = (char)(CboGrade.SelectedIndex + 64)
                    };
                    cmd.Parameters.Add(paramLevel);

                    MySqlParameter paramAdr = new MySqlParameter("@Addr", MySqlDbType.VarChar, 100)
                    {
                        Value = TxtAdr.Text
                    };
                    cmd.Parameters.Add(paramAdr);

                    MySqlParameter paramPhone = new MySqlParameter("@Mobile", MySqlDbType.VarChar, 13)
                    {
                        Value = TxtPhone.Text
                    };
                    cmd.Parameters.Add(paramPhone);

                    MySqlParameter paramEmail = new MySqlParameter("@Email", MySqlDbType.VarChar, 50)
                    {
                        Value = TxtEmail.Text
                    };
                    cmd.Parameters.Add(paramEmail);

                    if (MyMode == BaseMode.UPDATE)
                    {
                        // Idx:PK
                        MySqlParameter paramIdx = new MySqlParameter("@Idx", MySqlDbType.Int32)
                        {
                            Value = TxtIdx.Text
                        };
                        cmd.Parameters.Add(paramIdx);
                    }

                    var result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateData();
            }
        }

        private void GrdDivTbl_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtName.Text = data.Cells[1].Value.ToString();

                // 디스플레이되는 글자로 인덱스 찾기
                // 코드값을 그대로 할당
                int result = char.Parse(data.Cells[2].Value.ToString()) - 65 + 1;
                CboGrade.SelectedIndex = result;
                TxtAdr.Text = data.Cells[3].Value.ToString();
                TxtPhone.Text = data.Cells[4].Value.ToString();
                TxtEmail.Text = data.Cells[5].Value.ToString();

                TxtIdx.ReadOnly = true;    // 연동된 DB의 Primary Key이기 때문에 절대 변경 불가

                MyMode = BaseMode.UPDATE;       // 수정모드로 변경
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtIdx.Text = TxtName.Text = TxtAdr.Text = TxtPhone.Text = TxtEmail.Text = string.Empty;
            TxtIdx.ReadOnly = true;
            CboGrade.SelectedIndex = 0;

            MyMode = BaseMode.INSERT;       // 신규입력모드
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            InitControls();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MyMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }
            MyMode = BaseMode.DELETE;
            SaveData();
            InitControls();
        }
    }
}
