using iTasks.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        public frmGereUtilizadores()
        {
            InitializeComponent();
        }

        private void frmGereUtilizadores_Load(object sender, EventArgs e)
        {
           // Verifica se o utilizador logado é um Gestor
            if (SessaoAtual.UtilizadorLogado == null || SessaoAtual.UtilizadorLogado.Tipo != "Gestor")
            {
                MessageBox.Show("Apenas os Gestores podem aceder a esta área!", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new Action(() => this.Close())); // Fecha após mostrar mensagem
                return;
            }


        }

        // Método para verificar se o Username já existe
        private bool UsernameExiste(string username)
        {
            username = username.Trim().ToLower();

            foreach (var item in lstListaGestores.Items)
            {
                if (item is Utilizador gestor && gestor.Username.ToLower() == username)
                    return true;
            }

            foreach (var item in lstListaProgramadores.Items)
            {
                if (item is Utilizador programador && programador.Username.ToLower() == username)
                    return true;
            }

            return false;
        }

        private int GerarNovoId()
        {
            return SessaoAtual.TodosUtilizadores.Count > 0
                ? SessaoAtual.TodosUtilizadores.Max(u => u.Id) + 1
                : 1;
        }


        private void AtualizarListas()
        {
            lstListaGestores.Items.Clear();
            lstListaProgramadores.Items.Clear();

            foreach (var user in SessaoAtual.TodosUtilizadores)
            {
                if (user.Tipo == "Gestor")
                    lstListaGestores.Items.Add(user);
                else
                    lstListaProgramadores.Items.Add(user);
            }
        }


        private void LimparCampos()
        {
            txtIdGestor.Clear();
            txtNomeGestor.Clear();
            txtUsernameGestor.Clear();
            txtPasswordGestor.Clear();
            chkGereUtilizadores.Checked = false;
        }

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
           
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {
            
        }

        private void btGravarGestor_Click_1(object sender, EventArgs e)
        {
            if (SessaoAtual.UtilizadorLogado.Tipo != "Gestor")
            {
                MessageBox.Show("Apenas gestores podem gravar dados.");
                return;
            }

            string username = txtUsernameGestor.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("O Username é obrigatório.");
                return;
            }

            // Verifica se é novo ou edição
            int.TryParse(txtIdGestor.Text, out int id);
            Utilizador existente = SessaoAtual.TodosUtilizadores.FirstOrDefault(u => u.Id == id);

            if (existente == null)
            {
                if (UsernameExiste(username))
                {
                    MessageBox.Show("Username já existe.");
                    return;
                }

                Utilizador novoUtilizador = new Utilizador
                {
                    Id = GerarNovoId(),
                    Username = username,
                    Password = txtPasswordGestor.Text,
                    Nome = txtNomeGestor.Text,
                    Tipo = "Gestor"
                };

                SessaoAtual.TodosUtilizadores.Add(novoUtilizador);
                MessageBox.Show("Utilizador criado com sucesso!");
            }
            else
            {
                existente.Username = username;
                existente.Password = txtPasswordGestor.Text;
                existente.Nome = txtNomeGestor.Text;
                existente.Tipo = chkGereUtilizadores.Checked ? "Gestor" : "Programador";
                MessageBox.Show("Utilizador atualizado com sucesso!");
            }

            AtualizarListas();
            LimparCampos();

        }

        private void lstListaProgramadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SessaoAtual.UtilizadorLogado.Tipo != "Gestor")
            {
                MessageBox.Show("Apenas gestores podem gravar dados.");
                return;
            }

            string username = txtUsernameProg.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("O Username é obrigatório.");
                return;
            }

            // Verifica se é novo ou edição
            int.TryParse(txtIdProg.Text, out int id);
            Utilizador existente = SessaoAtual.TodosUtilizadores.FirstOrDefault(u => u.Id == id);

            if (existente == null)
            {
                if (UsernameExiste(username))
                {
                    MessageBox.Show("Username já existe.");
                    return;
                }

                Utilizador novoUtilizador = new Utilizador
                {
                    Id = GerarNovoId(),
                    Username = username,
                    Password = txtPasswordProg.Text,
                    Nome = txtNomeProg.Text,
                    Tipo = "Programador"
                };

                SessaoAtual.TodosUtilizadores.Add(novoUtilizador);
                MessageBox.Show("Utilizador criado com sucesso!");
            }
            else
            {
                existente.Username = username;
                existente.Password = txtPasswordProg.Text;
                existente.Nome = txtNomeProg.Text;
                existente.Tipo = "Programador";
                MessageBox.Show("Utilizador atualizado com sucesso!");
            }

            AtualizarListas();
            LimparCampos();

        }
    }
}
