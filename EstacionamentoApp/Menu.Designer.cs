namespace EstacionamentoApp
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            buttonSair = new Button();
            label2 = new Label();
            txtPlaca = new TextBox();
            label1 = new Label();
            button3 = new Button();
            buttonRetirar = new Button();
            buttonEstacionar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSair);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPlaca);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(buttonRetirar);
            groupBox1.Controls.Add(buttonEstacionar);
            groupBox1.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(490, 467);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // buttonSair
            // 
            buttonSair.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSair.Location = new Point(377, 424);
            buttonSair.Name = "buttonSair";
            buttonSair.Size = new Size(99, 26);
            buttonSair.TabIndex = 6;
            buttonSair.Text = "Sair";
            buttonSair.UseVisualStyleBackColor = true;
            buttonSair.Click += buttonSair_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 225);
            label2.Name = "label2";
            label2.Size = new Size(224, 18);
            label2.TabIndex = 5;
            label2.Text = "Lista de Veículos estacionados";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(24, 70);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(323, 26);
            txtPlaca.TabIndex = 4;
            txtPlaca.TextChanged += txtPlaca_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 39);
            label1.Name = "label1";
            label1.Size = new Size(184, 18);
            label1.TabIndex = 3;
            label1.Text = "Digite a Placa do veículo:";
            // 
            // button3
            // 
            button3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(22, 263);
            button3.Name = "button3";
            button3.Size = new Size(208, 33);
            button3.TabIndex = 2;
            button3.Text = "Veículos Estacionados";
            button3.UseVisualStyleBackColor = true;
            // 
            // buttonRetirar
            // 
            buttonRetirar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonRetirar.Location = new Point(259, 138);
            buttonRetirar.Name = "buttonRetirar";
            buttonRetirar.Size = new Size(208, 32);
            buttonRetirar.TabIndex = 1;
            buttonRetirar.Text = "Retirar Veículo";
            buttonRetirar.UseVisualStyleBackColor = true;
            buttonRetirar.Click += buttonRetirar_Click;
            // 
            // buttonEstacionar
            // 
            buttonEstacionar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonEstacionar.Location = new Point(22, 138);
            buttonEstacionar.Name = "buttonEstacionar";
            buttonEstacionar.Size = new Size(208, 32);
            buttonEstacionar.TabIndex = 0;
            buttonEstacionar.Text = "Estacionar Veículo";
            buttonEstacionar.UseVisualStyleBackColor = true;
            buttonEstacionar.Click += buttonEstacionar_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 491);
            Controls.Add(groupBox1);
            Name = "Menu";
            Text = "Menu";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button3;
        private Button buttonRetirar;
        private Button buttonEstacionar;
        private Label label2;
        private TextBox txtPlaca;
        private Label label1;
        private Button buttonSair;
    }
}