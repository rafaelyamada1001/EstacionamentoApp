namespace EstacionamentoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                    var menu = new Menu();
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
