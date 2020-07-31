using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace BookRentalShopApp20.Items
{
    public partial class MemberMngForm : MetroForm
    {
        #region 멤버변수 영역

        readonly string strTblName = "memberTbl";

        #endregion

        public MemberMngForm()
        {
            InitializeComponent();
        }

        private void MemberMngForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateComboDivision()
        {
            // A, B, C, D 등급
            var KeyValues = new Dictionary<string, string>();
            KeyValues.Add("선택", "");
            KeyValues.Add("A", "A");
            KeyValues.Add("B", "B");
            KeyValues.Add("C", "C");
            KeyValues.Add("D", "D");

            CboLevels.DataSource = new BindingSource(KeyValues, null);
            CboLevels.DisplayMember = "Key";
            CboLevels.ValueMember = "Value";
        }
            
        
    }
}
