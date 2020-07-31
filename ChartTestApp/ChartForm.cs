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
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;

namespace ChartTestApp
{
    public partial class ChartForm : MetroForm
    {
        public readonly string strConnstring =
            "Data Source = localhost;Port=3306;Database=employees;Uid=root;password=mysql_p@ssw0rd";

        public readonly string strQuery =
            "SELECT CONCAT(em.first_name, ' ' , em.last_name ) AS emp_name, "+
            "  	    em.gender, " +
            "       em.hire_date, " +
            "       dp.dept_no, " +
            "       dt.dept_name, " +
            "	    MAX(sl.salary) AS max_salary " +
            "  FROM employees AS em " +
            " INNER JOIN dept_emp AS dp " +
            "    ON em.emp_no = dp.emp_no " +
            " INNER JOIN departments AS dt " +
            "    ON dp.dept_no = dt.dept_no " +
            " INNER JOIN salaries AS sl " +
            "    ON em.emp_no = sl.emp_no " +
            " WHERE em.hire_date >= '2000-01-01' " +
            " GROUP BY em.first_name, em.last_name, em.gender, em.hire_date, dt.dept_name " +
            " ORDER BY em.first_name ASC ";
        public ChartForm()
        {
            InitializeComponent();
        }

        private void BtnYValue_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();  // 초기화
            chart1.Series[0].Points.Add(98);
            chart1.Series[0].Points.Add(72);
            chart1.Series[0].Points.Add(50);
            chart1.Series[0].Points.Add(100);
            chart1.Series[0].Points.Add(88);
            chart1.Series[0].Points.Add(63);

            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.Series[0].ChartType = SeriesChartType.Area;
        }

        private void BtnXyValues_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();  // 초기화
            chart1.Series[0].Points.AddXY("이예은", 98);
            chart1.Series[0].Points.AddXY("김희지", 72);
            chart1.Series[0].Points.AddXY("이채은", 50);
            chart1.Series[0].Points.AddXY("김가람", 100);
            chart1.Series[0].Points.AddXY("이하영", 88);
            chart1.Series[0].Points.AddXY("여예지", 63);

            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.Series[0].ChartType = SeriesChartType.Pie;
        }

        private void BtnDataBind_Click(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("여예지", 98.4));
            students.Add(new Student("이하영", 100));
            students.Add(new Student("김가람", 95.4));
            students.Add(new Student("이채은", 96.4));
            students.Add(new Student("김희지", 98.4));
            students.Add(new Student("이예은", 97.4));

            chart1.Series[0].Points.DataBind(students, "Name", "Score", null);
            chart1.Series[0].ChartType = SeriesChartType.Bar;
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0].Color = Color.Beige;
        }

        private class Student
        {
            public string Name { get; set; }
            public double Score { get; set; }

            public Student(string name, double score)
            {
                Name = name;
                Score = score;
            }
        }

        private void BtnMultiChart_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Add("area1");
            chart1.ChartAreas.Add("area2");

            chart1.Series.Add("series1");
            chart1.Series.Add("series2");
            chart1.Series.Add("series3");

            chart1.Series["series1"].ChartArea = "area1";
            chart1.Series["series2"].ChartArea = "area2";
            chart1.Series["series3"].ChartArea = "area2";

            chart1.Series["series1"].ChartType = SeriesChartType.Spline;
            chart1.Series["series2"].ChartType = SeriesChartType.Line;
            chart1.Series["series3"].ChartType = SeriesChartType.Bubble;

            chart1.Series["series1"].Color = Color.Red;
            chart1.Series["series2"].Color = Color.Green;
            chart1.Series["series3"].Color = Color.Blue;

            chart1.Series["series1"].Points.AddXY(1, 100);
            chart1.Series["series1"].Points.AddXY(2, 200);
            chart1.Series["series1"].Points.AddXY(3, 300);
            chart1.Series["series1"].Points.AddXY(4, 400);
            chart1.Series["series1"].Points.AddXY(5, 500);

            chart1.Series["series2"].Points.AddXY(1, 200);
            chart1.Series["series2"].Points.AddXY(2, 400);
            chart1.Series["series2"].Points.AddXY(3, 600);
            chart1.Series["series2"].Points.AddXY(4, 800);
            chart1.Series["series2"].Points.AddXY(5, 1000);

            chart1.Series["series3"].Points.AddXY(1, 300);
            chart1.Series["series3"].Points.AddXY(2, 600);
            chart1.Series["series3"].Points.AddXY(3, 900);
            chart1.Series["series3"].Points.AddXY(4, 1200);
            chart1.Series["series3"].Points.AddXY(5, 1500);

            chart1.Series["series2"].Points[3].Color = Color.HotPink;
            chart1.Series["series2"].Points[4].Color = Color.Honeydew;
        }

        private void BtnDBBind_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(strConnstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                chart1.DataSource = ds.Tables[0];
                chart1.Series[0].XValueMember = "emp_Name";
                chart1.Series[0].YValueMembers = "max_salary";
                chart1.DataBind();

                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                chart1.ChartAreas[0].AxisX.Title = "Employees";
                chart1.ChartAreas[0].AxisY.Title = "Salaries";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "${0, 0}";

                chart1.Series[0].IsValueShownAsLabel = true;
                chart1.Series[0].Name = "salary";
                chart1.Series[0].LabelFormat = "{0, 0}";
                chart1.Series[0].Color = Color.Gold;
            }
        }
    }
}
