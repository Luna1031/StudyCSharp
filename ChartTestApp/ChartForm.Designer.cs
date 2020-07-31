namespace ChartTestApp
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.BtnYValue = new MetroFramework.Controls.MetroButton();
            this.BtnXyValues = new MetroFramework.Controls.MetroButton();
            this.BtnDataBind = new MetroFramework.Controls.MetroButton();
            this.BtnMultiChart = new MetroFramework.Controls.MetroButton();
            this.BtnDBBind = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(23, 77);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Score";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(977, 533);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.BtnDBBind);
            this.metroPanel1.Controls.Add(this.BtnMultiChart);
            this.metroPanel1.Controls.Add(this.BtnDataBind);
            this.metroPanel1.Controls.Add(this.BtnXyValues);
            this.metroPanel1.Controls.Add(this.BtnYValue);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(1006, 77);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 533);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // BtnYValue
            // 
            this.BtnYValue.Location = new System.Drawing.Point(3, 3);
            this.BtnYValue.Name = "BtnYValue";
            this.BtnYValue.Size = new System.Drawing.Size(194, 46);
            this.BtnYValue.TabIndex = 2;
            this.BtnYValue.Text = "Only Y Values";
            this.BtnYValue.UseSelectable = true;
            this.BtnYValue.Click += new System.EventHandler(this.BtnYValue_Click);
            // 
            // BtnXyValues
            // 
            this.BtnXyValues.Location = new System.Drawing.Point(3, 55);
            this.BtnXyValues.Name = "BtnXyValues";
            this.BtnXyValues.Size = new System.Drawing.Size(194, 46);
            this.BtnXyValues.TabIndex = 2;
            this.BtnXyValues.Text = "XY Values";
            this.BtnXyValues.UseSelectable = true;
            this.BtnXyValues.Click += new System.EventHandler(this.BtnXyValues_Click);
            // 
            // BtnDataBind
            // 
            this.BtnDataBind.Location = new System.Drawing.Point(3, 141);
            this.BtnDataBind.Name = "BtnDataBind";
            this.BtnDataBind.Size = new System.Drawing.Size(194, 46);
            this.BtnDataBind.TabIndex = 2;
            this.BtnDataBind.Text = "Data Bind";
            this.BtnDataBind.UseSelectable = true;
            this.BtnDataBind.Click += new System.EventHandler(this.BtnDataBind_Click);
            // 
            // BtnMultiChart
            // 
            this.BtnMultiChart.Location = new System.Drawing.Point(3, 193);
            this.BtnMultiChart.Name = "BtnMultiChart";
            this.BtnMultiChart.Size = new System.Drawing.Size(194, 46);
            this.BtnMultiChart.TabIndex = 2;
            this.BtnMultiChart.Text = "Multi Chart";
            this.BtnMultiChart.UseSelectable = true;
            this.BtnMultiChart.Click += new System.EventHandler(this.BtnMultiChart_Click);
            // 
            // BtnDBBind
            // 
            this.BtnDBBind.Location = new System.Drawing.Point(3, 281);
            this.BtnDBBind.Name = "BtnDBBind";
            this.BtnDBBind.Size = new System.Drawing.Size(194, 46);
            this.BtnDBBind.TabIndex = 2;
            this.BtnDBBind.Text = "DB Bind";
            this.BtnDBBind.UseSelectable = true;
            this.BtnDBBind.Click += new System.EventHandler(this.BtnDBBind_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.chart1);
            this.MaximizeBox = false;
            this.Name = "ChartForm";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "Chart Test App";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton BtnXyValues;
        private MetroFramework.Controls.MetroButton BtnYValue;
        private MetroFramework.Controls.MetroButton BtnDataBind;
        private MetroFramework.Controls.MetroButton BtnMultiChart;
        private MetroFramework.Controls.MetroButton BtnDBBind;
    }
}

