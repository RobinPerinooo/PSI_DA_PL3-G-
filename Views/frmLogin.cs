using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.SqlClient;


namespace iTasks
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

     

    
     

        private void btLogin_Click(object sender, EventArgs e)
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

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '•';

            }
        }
    }
}
