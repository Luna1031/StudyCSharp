﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // button1.Click += Button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EventHandler made");
        }

        /*
        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EventHandler made");
        }
        */
    }
}
