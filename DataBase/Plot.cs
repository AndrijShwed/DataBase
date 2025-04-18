﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Plot: Form
    {
        public Plot()
        {
            InitializeComponent();
        }

        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = Application.OpenForms.OfType<Головна>().FirstOrDefault();
            if(form != null)
            {
                form.BringToFront();
                form.Focus();
            }
            else
            {
                form = new Головна();
                form.Show();
            }
            this.Close();
        }

        private void Пошук_Click(object sender, EventArgs e)
        {
            PlotSearch form = new PlotSearch();
            this.Close();
            form.Show();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            AddPlot form = new AddPlot();
            this.Close();
            form.Show();
        }
    }
}
