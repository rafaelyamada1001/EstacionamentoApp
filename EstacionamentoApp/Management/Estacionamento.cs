using EstacionamentoApp.DataBase;
using EstacionamentoApp.Interface;
using MySql.Data.MySqlClient;


namespace EstacionamentoApp.Management
{
    public class EstacionamentoService : IVeiculoRepository

    {
        private string connectionString = "Server=localhost;Database=teste;User ID=root;Password=1234;";

        private decimal valorHora;
        public int Vagas { get; set; }

        public EstacionamentoService(decimal valorHora, int vagas)
        {
            this.valorHora = valorHora;
            Vagas = vagas;
        }


        public void AdicionarVeiculo(string placa)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT count(placa) as qtde FROM movger WHERE horasaida is null";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    string verificaPlacaQuery = "SELECT COUNT(placa) as qtde FROM movger WHERE placa = @placa AND horasaida IS NULL";
                    using (MySqlCommand verificaPlacaCommand = new MySqlCommand(verificaPlacaQuery, connection))
                    {
                        verificaPlacaCommand.Parameters.AddWithValue("@placa", placa);
                        int veiculosComMesmaPlaca = Convert.ToInt32(verificaPlacaCommand.ExecuteScalar());

                        if (veiculosComMesmaPlaca > 0)
                        {
                            MessageBox.Show("Já existe um veículo estacionado com essa placa!", 
                                "Atenção",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("");
                        }
                        int vagasOcupadas = reader.GetInt32("qtde");


                        if (string.IsNullOrEmpty(placa))
                        {
                            MessageBox.Show("Campo não pode ser vazio!", 
                                            "Atenção", 
                                            MessageBoxButtons.OK, 
                                            MessageBoxIcon.Warning);
                            return;
                               
                        }

                        if (vagasOcupadas >= Vagas)
                        {
                            MessageBox.Show("Estacionamento cheio!",
                                            "Atenção",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return;
                        }
                        var veiculo = new Veiculo(placa);
                        Console.WriteLine($"Veículo {placa} adicionado ao estacionamento às {veiculo.HoraEntrada}.");
                        var banco = new BancoDados();
                        banco.EntradaVeiculo(veiculo);

                    }
                }
            }
        }
        public void RemoverVeiculo(string placa)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT placa, HoraEntrada FROM movger WHERE placa = @placa and HoraSaida is null";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Placa", placa);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Veiculo não encontrado");
                            return;
                        }

                        DateTime horaEntrada = reader.GetDateTime("HoraEntrada");

                        var horaSaida = DateTime.Now;
                        var tempoEstacionado = horaSaida - horaEntrada;
                        var horasEstacionadas = tempoEstacionado.TotalHours;
                        var minutosEstacionados = tempoEstacionado.Minutes;

                        var valorTotal = (decimal)tempoEstacionado.TotalHours * valorHora;

                        var banco = new BancoDados();
                        banco.SaidaVeiculo(placa, horaSaida, horasEstacionadas, minutosEstacionados, valorTotal);                        
                        MessageBox.Show ($"Entrada: {horaEntrada} | Saída: {horaSaida} | \nValor Total: R${valorTotal:F2} | " +
                            $"HorasEstacionadas:{Math.Round(horasEstacionadas)}h {minutosEstacionados}min ");

                    }
                }
            }
        }
        public void ListarVeiculos()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT placa, HoraEntrada FROM movger WHERE horasaida is null";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            List<string> veiculos =  new List<string> ();
                            while (reader.Read())
                            {
                                string placa = reader.GetString("placa");
                                DateTime horaEntrada = reader.GetDateTime("HoraEntrada");
                                veiculos.Add($"Placa:{placa} - Hora Entrada:{horaEntrada}");
                            }
                            string mensagem = "Veículos estacionados:\n" + string.Join("\n", veiculos);
                            MessageBox.Show(mensagem, "Veículos Estacionados", 
                                            MessageBoxButtons.OK, 
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nenhum veículo estacionado");
                        }
                    }
                }
            }
        }
        public void VagasDesocupadas()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT count(placa) as qtde FROM movger WHERE horasaida is null";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            string message = ($"Vagas Desocupadas:{Vagas}");
                            MessageBox.Show(message);
                            return;
                        }

                        int vagasOcupadas = reader.GetInt32("qtde");
                        var vagasLivres = Vagas - vagasOcupadas;
                        string messageVagasLivres = ($"Vagas Disponíveis: {vagasLivres}");
                        MessageBox.Show (messageVagasLivres);
                    }
                }
            }
        }
    }
}
