using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
=======
using System.Data.SqlClient;
>>>>>>> a74d764 (Login)

namespace iTasks
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
=======

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

       

      

        private void btnRegister_Click(object sender, EventArgs e)
        {
            List<Utilizador> utilizadores = new List<Utilizador>
            {
                new Utilizador { Username = "test1", Password = "123", Tipo = "Programador"},
                new Utilizador {Username = "test2", Password = "123", Tipo = "Gestor"}
            };

            var user = utilizadores.FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);
            if (user != null)
            {
                SessaoAtual.UtilizadorLogado = user;
                this.Hide();
                frmKanban kanban = new frmKanban(user.Username, user.Tipo);
                kanban.Show();
            }
            else
            {
                MessageBox.Show("Login inválido");
            }
        }

        private void checkBxShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '•';

            }
        }
>>>>>>> a74d764 (Login)
    }
}
