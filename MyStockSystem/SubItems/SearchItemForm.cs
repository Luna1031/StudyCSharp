using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MyStockSystem.SubItems
{
    public partial class SearchItemForm : MetroForm
    {
        public SearchItemForm()
        {
            InitializeComponent();
        }

        private void SerachItemForm_Load(object sender, EventArgs e)
        {
            DgvSearchItems.Font = new Font(@"NanumGothic", 9, FontStyle.Italic);
        }

        private void MtlBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            MainForm main = new MainForm();
            main.Location = this.Location;
            main.ShowDialog();

            this.Close();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient { Encoding = Encoding.UTF8 };
            XmlDocument doc = new XmlDocument();

            StringBuilder str = new StringBuilder();
            str.Append("http://api.seibro.or.kr/openapi/service/StockSvc/getStkIsinByNmN1");     // OpenAPI 기본 
            str.Append("?serviceKey=8zM4bOCfp2qSTfRECbNqx18v2XNzcH74SIy5u%2FqNnOuYGNesMgjfOWFce24yF4MexR1w5qo70soTRJHERI2IZg%3D%3D");   // 최초의 파라미터값은 '?', 다음부터는 '&'
            str.Append($"&secnNm={TxtSearchItem.Text}");    // 검색어
            str.Append("&numOfRows=200");                   // 읽어 올 데이터 수
            str.Append("&pageNo=1");                        // 페이지 번호
            str.Append("&martTpcd=11");                     // 주식시장 종류 11 유가증권

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            DgvSearchItems.Rows.Clear();

            try
            {
                foreach (XmlNode item in items)
                {
                    DgvSearchItems.Rows.Add(item["isin"].InnerText,                                                         // isin 표준코드
                                            item["issuDt"] == null ? string.Empty : item["issuDt"].InnerText,               // 주식발행일자
                                            item["korSecnNm"].InnerText,                                                    // 한글종목명
                                            item["secnKacdNm"].InnerText,                                                   // 보통주/우선주
                                            item["shotnIsin"].InnerText);                                                   // 단축코드
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"에러 발생 : {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            DgvSearchItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void TxtSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnSearch_Click(sender, new EventArgs());
            }
        }
    }
}
