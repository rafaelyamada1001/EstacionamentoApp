using EstacionamentoApp.Interface;
using EstacionamentoApp.Management;
using MySql.Data.MySqlClient;

namespace EstacionamentoApp
{
    public partial class FrmPrincipal : Form
    {
        
        private IVeiculoRepository veiculoRepository;

        public FrmPrincipal()
        {
            InitializeComponent();

            int vagas = 0;
            decimal valor = 0;

            string connectionString = "Server=localhost;Database=teste;User ID=root;Password=1234;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT TotalVagas, ValorHora FROM estacionamento";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            valor = reader.GetDecimal("ValorHora");
                            vagas = reader.GetInt32("TotalVagas");
                        }
                        else
                        {
                            Console.WriteLine("Nenhum registro encontrado.");
                            return;
                        }
                    }
                }
            }


            veiculoRepository = new EstacionamentoService(valor, vagas);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(txtUsuario.Text.Equals("123") && txtSenha.Text.Equals("123"))
                {

                    var menu = new FrmMenu(veiculoRepository);
                    menu.Show();

                    this.Visible = false;

                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorretos",
                                    "Erro!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    txtUsuario.Focus();
                    txtSenha.Text = string.Empty;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Desculpe.",
                ex.Message,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
