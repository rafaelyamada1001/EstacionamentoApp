using EstacionamentoApp.DataBase;
using EstacionamentoApp.Interface;
using EstacionamentoApp.Management;
using MySql.Data.MySqlClient;
using System.Numerics;

namespace EstacionamentoApp
{
    public partial class Menu : Form
    {
        private readonly EstacionamentoService _estacionamentoService;
        public Menu()
        {
            InitializeComponent();
            var bancoDados = new BancoDados(); // injeção do repositório
            int vagas = 0;
            decimal valor = 0;

            string connectionString = "Server=localhost;Database=teste;User ID=root;Password=25130321;";

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

            _estacionamentoService = new EstacionamentoService(valor, vagas);
        }

        private void buttonEstacionar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text.Trim();

            try
            {
                _estacionamentoService.AdicionarVeiculo(placa);
                MessageBox.Show($"Veículo com placa {placa} adicionado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRetirar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text.Trim();


            try
            {
                _estacionamentoService.RemoverVeiculo(placa);
                MessageBox.Show($"Veículo com placa {placa} removido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms["Form1"] as Form1;

            if (form1 != null)
            {
                form1.Show();
            }
            else
            {
                form1 = new Form1();
                form1.Show();
            }

            this.Close();
        }
        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _estacionamentoService.ListarVeiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _estacionamentoService.VagasDesocupadas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}
