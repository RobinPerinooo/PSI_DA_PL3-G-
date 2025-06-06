﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmKanban : Form
    {
        public frmKanban(string username, string tipo)
        {
            InitializeComponent();
            this.username = username;
            this.tipo = tipo;
        }

        private string username;
        private string tipo;

        private void frmKanban_Load(object sender, EventArgs e)
        {
            label1.Text = "Bem-vindo(a), " + username + "!" + "(" + tipo + ")";
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGereUtilizadores gereUtilizadores = new frmGereUtilizadores();
            gereUtilizadores.Show();
        }
    }
}
