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
    public partial class SearchItemForm : MetroForm//Form
    {
        public SearchItemForm()
        {
            InitializeComponent();
        }

        private void SearchItemForm_Load(object sender, EventArgs e)
        {
            //폰트 나눔고딕체로 변경
            //DgvSearchItems.Font = new Font(@"NanumGothic", 9, FontStyle.Regular);
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void Mtlback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MainForm main = new MainForm();
            main.Location = this.Location;
            main.ShowDialog();
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8};
            XmlDocument doc = new XmlDocument();

            StringBuilder str = new StringBuilder();
            str.Append("http://api.seibro.or.kr/openapi/service/StockSvc/getStkIsinByNmN1");//open API기본URL
            str.Append("?serviceKey=11poYjHNBOrURz3WyVLHJ0RR62hXhiPMRUULdLQdxQI5rqDh%2BBJIuOfcKuHYCDkJjlp3QesCYpCmXe4PTHQZaw%3D%3D"); //인증 키
            str.Append($"&secnNm={TxtSearchItem.Text}");    //검색어
            str.Append("&pageNo=1");                         //페이지 수
            str.Append("&numOfRows=200");                     //읽어올 데이터수
            str.Append("&martTpcd=11");                      //주시시장 종류 : 11은 유가증권시장

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);//xml을 보냄

            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item"); //<item> </item>으로 나눔

            DgvSearchItems.Rows.Clear();

            foreach (XmlNode item in items)
            {
                try
                {
                    DgvSearchItems.Rows.Add(item["isin"].InnerText,         //표준코드
                                        item["issuDt"].InnerText,      //주식 발행일자 item["issuDt"] == null ? string.Empty : item["issuDt"].InnerText,
                                        item["korSecnNm"].InnerText,    //한글 종목명
                                        item["secnKacdNm"].InnerText,   //보통주/우선주
                                        item["shotnIsin"].InnerText);   //단축코드
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show($"에러발생 : {ex.Message}", "에러", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                DgvSearchItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //그리드 크기가 알아서 조정
            }
        }

        private void TextSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) BtnSearch_Click(sender,new EventArgs()); //원하는 이벤트를 실행
        }
    }
}