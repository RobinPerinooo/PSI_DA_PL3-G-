using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (var db = new ItasksContext())
            {
                var utilizador = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                if (utilizador == null)
                {
                    MessageBox.Show("Utilizador não encontrado.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (utilizador.Password != password)
                {
                    MessageBox.Show("Password incorreta.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Login com sucesso
                MessageBox.Show($"Bem-vindo, {utilizador.Username}!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Session.NomeUtilizador = utilizador.Username;  // guardar o nome do utilizador logado
                frmKanban kanban = new frmKanban(utilizador);            // abrir o formulário Kanban
                kanban.Show();
                this.Hide();                                    // esconder o formulário de login

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
