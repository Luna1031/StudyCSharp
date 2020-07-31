using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BookRentalShopApp20.Items
{
    public partial class RentalMngForm : MetroForm
    {
        readonly string strTblName = "divTbl";

        BaseMode MyMode = BaseMode.NONE;    // 최초에는 기본상태

        public RentalMngForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            UpdateComboMember();
            UpdateComboBook();

            UpdateData();

            InitControls();
        }

        private void UpdateComboBook()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT b.Idx, b.Names, " +
                " (SELECT Names FROM divTbl WHERE Division = b.Division) AS Division " +
                "    FROM booksTbl AS b; ";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read())
                {
                    temps.Add($"[{reader[2]}]{reader[1]}", $"{reader[0]}");
                }

                CboBook.DataSource = new BindingSource(temps, null);
                CboBook.DisplayMember = "Key";
                CboBook.ValueMember = "Value";
            }
        }

        private void UpdateComboMember()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT Idx, Names FROM memberTbl ";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while(reader.Read())
                {
                    temps.Add(reader[1].ToString(), reader[0]. ToString());
                }

                CboMember.DataSource = new BindingSource(temps, null);
                CboMember.DisplayMember = "Key";
                CboMember.ValueMember = "Value";
                CboMember.SelectedIndex = 0;
            }
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = "     SELECT r.Idx AS '대여번호', " +
                                   "            m.Names AS '대여회원', " +
                                   "            b.Names AS '대여책제목', " +
                                   "            b.ISBN, " +
                                   "            r.rentalDate AS '대여일', " +
                                   "            r.returnDate AS '반납일', " +
                                   "            r.memberIdx, " +
                                   "            r.BookIdx " +
                                   "       FROM rentaltbl AS r " +
                                   " INNER JOIN memberTbl AS m " +
                                   "         ON r.memberIdx = m.Idx " +
                                   " INNER JOIN bookstbl AS b " +
                                   "         ON r.bookIdx = b.Idx ";

                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdRentalTbl.DataSource = ds;
                GrdRentalTbl.DataMember = strTblName;
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            DataGridViewColumn column;

            column = GrdRentalTbl.Columns[0];
            column.Width = 50;
            column.HeaderText = "번호";

            column = GrdRentalTbl.Columns[1];
            column.Width = 100;
            column.HeaderText = "회원";

            column = GrdRentalTbl.Columns[2];
            column.Width = 150;
            column.HeaderText = "책";

            column = GrdRentalTbl.Columns[3];
            column.Width = 100;
            column.HeaderText = "ISBN";

            column = GrdRentalTbl.Columns[4];   // 대여일
            column.Width = 90;

            column = GrdRentalTbl.Columns[5];   // 반납일
            column.Width = 120;

            column = GrdRentalTbl.Columns[6];
            column.Visible = false;

            column = GrdRentalTbl.Columns[7];
            column.Visible = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(MyMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }
            MyMode = BaseMode.DELETE;
            SaveData();
            InitControls();
        }

        private void InitControls()
        {
            TxtIdx.Text = String.Empty;
            TxtIdx.Focus();
            TxtIdx.ReadOnly = true;

            CboMember.SelectedIndex = CboBook.SelectedIndex = 0;

            DtpRentalDate.CustomFormat = "yyyy-MM-dd";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;
            DtpRentalDate.Value = DateTime.Now;

            DtpReturnDate.CustomFormat = "";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;

            MyMode = BaseMode.NONE;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            InitControls();
            MyMode = BaseMode.INSERT;       // 신규입력모드
        }

        private void SaveData()
        {
            if (string.IsNullOrEmpty(TxtIdx.Text))
            {
                MetroMessageBox.Show(this, " 빈값은 넣을 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(MyMode == BaseMode.NONE)
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
                        cmd.CommandText = "UPDATE rentaltbl " +
                                          "   SET memberIdx = @memberIdx " +
                                          "     , bookIdx = @bookIdx " +
                                          "     , rentalDate = @rentalDate " +
                                          "     , returnDate = @returnDate " +
                                          " WHERE Idx = @Idx ";
                    }
                    else if (MyMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT INTO rentaltbl " +
                                          " ( " +
                                          " memberIdx, " +
                                          " bookIdx, " +
                                          " rentalDate, " +
                                          " returnDate" +
                                          " ) " +
                                          " VALUES " +
                                          " ( " +
                                          "   @memberIdx, " +
                                          "   @bookIdx, " +
                                          "   @rentalDate, " +
                                          "   @returnDate" +
                                          " ) ";
                    }

                    MySqlParameter paramMemberIdx = new MySqlParameter("@memberIdx", MySqlDbType.Int32);
                    paramMemberIdx.Value = CboMember.SelectedValue;
                    cmd.Parameters.Add(paramMemberIdx);

                    MySqlParameter paramBookIdx = new MySqlParameter("@bookIdx", MySqlDbType.Int32);
                    paramBookIdx.Value = CboBook.SelectedValue;
                    cmd.Parameters.Add(paramBookIdx);

                    MySqlParameter paramRentalDate = new MySqlParameter("@rentalDate", MySqlDbType.Date);
                    paramRentalDate.Value = DtpRentalDate.Value;
                    cmd.Parameters.Add(paramRentalDate);

                    MySqlParameter paramRetrunDate = new MySqlParameter("@returnDate", MySqlDbType.Date);
                    if (MyMode == BaseMode.INSERT)
                    {
                        paramRentalDate.Value = null;
                    }
                    else
                    {
                        paramRentalDate.Value = DtpReturnDate.Value;
                    }
                    cmd.Parameters.Add(paramRetrunDate);


                    if (MyMode == BaseMode.UPDATE)
                    {
                        MySqlParameter paraIdx = new MySqlParameter("@Idx", MySqlDbType.Int32);
                        paramMemberIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(paraIdx);
                    }

                    var result = cmd.ExecuteNonQuery();

                    if (MyMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다", "신규입력");
                    }
                    else if (MyMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정변경되었습니다", "수정변경");
                    }
                    else if (MyMode == BaseMode.DELETE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 삭제변경되었습니다", "삭제변경");
                    }
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MyMode = BaseMode.UPDATE;
            SaveData();
            UpdateComboBook();
            UpdateComboMember();
            UpdateData();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdRentalTbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();
                CboMember.SelectedValue = data.Cells[6].Value.ToString();  // ToString
                CboBook.SelectedValue = data.Cells[7].Value.ToString();    // ToString
                DtpRentalDate.Value = DateTime.Parse(data.Cells[4].Value.ToString());

                if(string.IsNullOrEmpty(data.Cells[5].Value.ToString()))
                {
                    DtpReturnDate.CustomFormat = "yyyy-MM-dd";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                    DtpReturnDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());
                }
                else
                {
                    DtpReturnDate.CustomFormat = " ";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                }

                MyMode = BaseMode.UPDATE;       // 수정모드로 변경
            }
        }

        private void DtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (MyMode == BaseMode.UPDATE)
            {
                DtpReturnDate.CustomFormat = "yyyy-MM-dd";
                DtpReturnDate.Format = DateTimePickerFormat.Custom;
            }
        }

        private void BtnExcelExport_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("sheet1");
            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Rental Book Data");
            int x = 1;

            DataSet ds = GrdRentalTbl.DataSource as DataSet;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                IRow row = sheet1.CreateRow(i);
                for (int j = 0; j < ds.Tables[0].Rows[0].ItemArray.Length; j++)
                {
                    if (j == 4 || j == 5)
                    {
                        var value = string.IsNullOrEmpty(ds.Tables[0].Rows[i].ItemArray[j].ToString()) ?
                            "" : ds.Tables[0].Rows[i].ItemArray[j].ToString().Substring(0, 10);
                        row.CreateCell(j).SetCellValue(value);
                    }
                    else if (j > 5)
                    {
                        break;
                    }
                    else
                    {
                        row.CreateCell(j).SetCellValue(ds.Tables[0].Rows[i].ItemArray[i].ToString());
                    }
                }
                FileStream file = File.Create(Environment.CurrentDirectory + $@"\export.xlsx");
                workbook.Write(file);
                file.Close();

                MessageBox.Show("Export done!");
            }
        }
    }
}