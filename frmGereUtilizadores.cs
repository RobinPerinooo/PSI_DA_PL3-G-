using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        private Utilizador _utilizador;

        private List<int> idsUsados = new List<int>();
        public frmGereUtilizadores(Utilizador utilizador)
        {
            InitializeComponent();
            _utilizador = utilizador;
        }

        private void frmGereUtilizadores_Load(object sender, EventArgs e)
        {
            cbDepartamento.Items.Clear();
            cbDepartamento.Items.Add("IT");
            cbDepartamento.Items.Add("Marketing");
            cbDepartamento.Items.Add("Administração");

            // Opcional: seleciona um item por padrão
            cbDepartamento.SelectedIndex = 0;
            CarregarListaGestores();
            CarregarGestoresParaComboBox();


        }

        private void CarregarListaGestores()
        {
            lstListaGestores.Items.Clear();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iTasksDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome, Username, Departamento FROM Utilizadors WHERE Tipo = '1'";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                        string username = reader.GetString(2);
                        int departamentoId = reader.GetInt32(3);
                        string departamento = ((Departamento)departamentoId).ToString();

                        lstListaGestores.Items.Add($"ID: {id}");
                        lstListaGestores.Items.Add($"Nome: {nome}");
                        lstListaGestores.Items.Add($"Username: {username}");
                        lstListaGestores.Items.Add($"Departamento: {departamento}");
                        lstListaGestores.Items.Add("_______________________________________________________");
                        lstListaGestores.Items.Add("");
                    }

                    connection.Close();
                }
            }
        }

        private void CarregarGestoresParaComboBox()
        {
            cbGestorProg.Items.Clear();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iTasksDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome FROM Utilizadors WHERE Tipo = 1"; // 1 = Gestor

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.IsDBNull(1) ? "Sem Nome" : reader.GetString(1);

                        // Adiciona o par Id-Nome à ComboBox
                        cbGestorProg.Items.Add(new KeyValuePair<int, string>(id, nome));
                    }
                }
            }

            cbGestorProg.DisplayMember = "Value"; // Mostra o nome do gestor
            cbGestorProg.ValueMember = "Key";     // Guarda o ID do gestor
        }

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            string nome = txtNomeGestor.Text.Trim();
            string username = txtUsernameGestor.Text.Trim();
            string password = txtPasswordGestor.Text.Trim();
            string departamento = cbDepartamento.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(departamento))
            {
                MessageBox.Show("Preencha todos os campos (exceto ID, que é automático).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            int novoId = 1;
            while (idsUsados.Contains(novoId))
            {
                novoId++;
            }

           
            idsUsados.Add(novoId);

          
            txtIdGestor.Text = novoId.ToString();


            lstListaGestores.Items.Add($"ID: {novoId}");
            lstListaGestores.Items.Add($"Nome: {nome}");
            lstListaGestores.Items.Add($"Username: {username}");
            lstListaGestores.Items.Add($"Departamento: {departamento}");
            lstListaGestores.Items.Add("_______________________________________________________");
            lstListaGestores.Items.Add("");



            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iTasksDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Utilizadors (Nome, Username, Password, Tipo, Departamento, Nivel) VALUES (@Nome, @Username, @Password, @Tipo, @Departamento, @Nivel)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", novoId);
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Tipo", (int)TipoUtilizador.Gestor);
                    cmd.Parameters.AddWithValue("@Departamento", (int)Enum.Parse(typeof(Departamento), departamento));
                    cmd.Parameters.AddWithValue("@Nivel", (int)TipoUtilizador.Gestor);

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    connection.Close();
                    CarregarListaGestores();

                }
            }

            // Limpa os campos para nova entrada
            txtIdGestor.Clear();
            txtNomeGestor.Clear();
            txtUsernameGestor.Clear();
            cbDepartamento.SelectedIndex = -1;
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {
            string nome = txtNomeGestor.Text.Trim();
            string username = txtUsernameGestor.Text.Trim();
            string password = txtPasswordGestor.Text.Trim();
            string nivelexperiencia = cbNivelProg.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(nivelexperiencia) || cbGestorProg.SelectedItem == null)
            {
                MessageBox.Show("Preencha todos os campos e selecione um Gestor.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var gestorSelecionado = (KeyValuePair<int, string>)cbGestorProg.SelectedItem;
            int gestorId = gestorSelecionado.Key;

            int novoId = 1;
            while (idsUsados.Contains(novoId)) { novoId++; }
            idsUsados.Add(novoId);

            lstListaGestores.Items.Add($"ID: {novoId}");
            lstListaGestores.Items.Add($"Nome: {nome}");
            lstListaGestores.Items.Add($"Username: {username}");
            lstListaGestores.Items.Add($"Nível de experiência: {nivelexperiencia}");
            lstListaGestores.Items.Add($"Gestor: {gestorSelecionado.Value}");
            lstListaGestores.Items.Add("_______________________________________________________");
            lstListaGestores.Items.Add("");

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iTasksDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Utilizadors (Id, Nome, Username, Password, Tipo, Nivel, GestorId) VALUES (@Id, @Nome, @Username, @Password, @Tipo, @Nivel, @GestorId)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", novoId);
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Tipo", (int)TipoUtilizador.Programador);
                    cmd.Parameters.AddWithValue("@Nivel", nivelexperiencia);
                    cmd.Parameters.AddWithValue("@GestorId", gestorId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            // Limpa os campos
            txtIdGestor.Clear();
            txtNomeGestor.Clear();
            txtUsernameGestor.Clear();
            cbDepartamento.SelectedIndex = -1;
            cbGestorProg.SelectedIndex = -1;
        }

        private void cbGestorProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGestorProg.SelectedItem is KeyValuePair<int, string> gestor)
            {
                MessageBox.Show($"Gestor selecionado: {gestor.Value}", "Gestor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

