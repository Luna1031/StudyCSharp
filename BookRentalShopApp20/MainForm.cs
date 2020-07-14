using System;
using System.Windows.Forms;
using BookRentalShopApp20.Items;
using MetroFramework;
using MetroFramework.Forms;

namespace BookRentalShopApp20
{
    public partial class MainForm : MetroForm
    {
        public object FormWidowState { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MetroMessageBox.Show(this, "종료하시겠습니다?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void MnuItemCodeMng_Click(object sender, EventArgs e)
        {
            DivMngForm form = new DivMngForm();
            form.MdiParent = this;
            form.Text = "구분코드 관리";
            form.Dock = DockStyle.Fill;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void MnuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
