using System;
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
        private Utilizador _utilizador; 

        public frmKanban(Utilizador utilizador)
        {
            InitializeComponent();
            _utilizador = utilizador; 

            if (_utilizador.Tipo == TipoUtilizador.Programador)
            {
                utilizadoresToolStripMenuItem.Visible = false; 
            }
        }

        private void frmKanban_Load(object sender, EventArgs e)
        {
            label1.Text = $"Bem-vindo: {Session.NomeUtilizador}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGereUtilizadores frmGereUtilizadores = new frmGereUtilizadores(_utilizador);
            frmGereUtilizadores.Show();
        }

        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGereTiposTarefas frmGereTiposTarefas = new frmGereTiposTarefas(_utilizador);
            frmGereTiposTarefas.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
