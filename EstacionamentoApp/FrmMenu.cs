﻿using EstacionamentoApp.DataBase;
using EstacionamentoApp.Interface;
using EstacionamentoApp.Management;
using MySql.Data.MySqlClient;
using System.Numerics;

namespace EstacionamentoApp
{
    public partial class FrmMenu : Form
    {

        private readonly IVeiculoRepository _veiculoRepository;
        public FrmMenu(IVeiculoRepository veiculoRepository)
        {
            InitializeComponent();
            _veiculoRepository = veiculoRepository;
        }

        private void buttonEstacionar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text.Trim();

            try
            {
                _veiculoRepository.AdicionarVeiculo(placa);
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
                _veiculoRepository.RemoverVeiculo(placa);
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            FrmPrincipal form1 = Application.OpenForms["Form1"] as FrmPrincipal;

            if (form1 != null)
            {
                form1.Show();
            }
            else
            {
                form1 = new FrmPrincipal();
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
                _veiculoRepository.ListarVeiculos();
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
                _veiculoRepository.VagasDesocupadas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}
