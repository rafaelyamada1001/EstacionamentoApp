using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionamentoApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonEstacionar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text.Trim();


            if (string.IsNullOrEmpty(placa))
            {
                MessageBox.Show("Por favor, insira uma placa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"A placa inserida foi: {placa}", "Informação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void buttonRetirar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text.Trim();


            if (string.IsNullOrEmpty(placa))
            {
                MessageBox.Show("Por favor, insira uma placa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"O Veículo de placa:{placa}, Foi Retirado Valor:",
                            "Informação", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

        }
        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

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
    }
}
