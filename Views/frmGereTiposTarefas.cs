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
    public partial class frmGereTiposTarefas : Form
    {
        private Utilizador _utilizador;

        public frmGereTiposTarefas(Utilizador utilizador)
        {
            InitializeComponent();
            _utilizador = utilizador;
        }

        private void frmGereTiposTarefas_Load(object sender, EventArgs e)
        {

        }
    }
}