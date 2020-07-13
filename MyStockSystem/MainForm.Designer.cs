namespace MyStockSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MtlStockAnals = new MetroFramework.Controls.MetroTile();
            this.MltInvestSimul = new MetroFramework.Controls.MetroTile();
            this.MtlSearchItem = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // MtlStockAnals
            // 
            this.MtlStockAnals.Location = new System.Drawing.Point(329, 63);
            this.MtlStockAnals.Name = "MtlStockAnals";
            this.MtlStockAnals.Size = new System.Drawing.Size(150, 150);
            this.MtlStockAnals.Style = MetroFramework.MetroColorStyle.Orange;
            this.MtlStockAnals.TabIndex = 0;
            this.MtlStockAnals.Text = "주식정보분석";
            this.MtlStockAnals.TileImage = global::MyStockSystem.Properties.Resources.analysis2;
            this.MtlStockAnals.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlStockAnals.UseTileImage = true;
            // 
            // MltInvestSimul
            // 
            this.MltInvestSimul.Location = new System.Drawing.Point(329, 219);
            this.MltInvestSimul.Name = "MltInvestSimul";
            this.MltInvestSimul.Size = new System.Drawing.Size(300, 150);
            this.MltInvestSimul.Style = MetroFramework.MetroColorStyle.Lime;
            this.MltInvestSimul.TabIndex = 0;
            this.MltInvestSimul.Text = "투자시뮬레이션";
            this.MltInvestSimul.TileImage = global::MyStockSystem.Properties.Resources.simulator2;
            this.MltInvestSimul.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MltInvestSimul.UseTileImage = true;
            // 
            // MtlSearchItem
            // 
            this.MtlSearchItem.Location = new System.Drawing.Point(23, 63);
            this.MtlSearchItem.Name = "MtlSearchItem";
            this.MtlSearchItem.Size = new System.Drawing.Size(300, 150);
            this.MtlSearchItem.Style = MetroFramework.MetroColorStyle.Pink;
            this.MtlSearchItem.TabIndex = 0;
            this.MtlSearchItem.Text = "주식정보검색";
            this.MtlSearchItem.TileImage = global::MyStockSystem.Properties.Resources.marketing2;
            this.MtlSearchItem.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlSearchItem.UseTileImage = true;
            this.MtlSearchItem.Click += new System.EventHandler(this.MtlSearchItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.MtlStockAnals);
            this.Controls.Add(this.MltInvestSimul);
            this.Controls.Add(this.MtlSearchItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "주식분석시스템";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile MtlSearchItem;
        private MetroFramework.Controls.MetroTile MtlStockAnals;
        private MetroFramework.Controls.MetroTile MltInvestSimul;
    }
}

