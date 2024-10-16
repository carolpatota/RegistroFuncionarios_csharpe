using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3935_Carolina_T04
{
    public partial class Form1 : Form
    {

        String[,] funcionarios = new string[9, 7];

        int index = 0;

        private System.Windows.Forms.ToolTip toolTip1;

        public Form1()
        {
            InitializeComponent();
            toolTip1 = new System.Windows.Forms.ToolTip();
        }
       
        private void VisualizaFuncionarios()
        {
           
            lbl_numero.Text = funcionarios[index, 0];
            lbl_nome.Text = funcionarios[index, 1];
            lbl_genero.Text = funcionarios[index, 2];
            msk_box_datanasc.Text = funcionarios[index, 3];
            lbl_nacionalidade.Text = funcionarios[index, 4];
            lbl_categoria.Text = funcionarios[index, 5];
            pic_funcionario.ImageLocation = funcionarios[index, 6];

            DateTime data_atual = DateTime.Today;
            DateTime data_nasc = DateTime.ParseExact(msk_box_datanasc.Text, "dd-MM-yyyy", new CultureInfo("pt-PT"));


            int anos = data_atual.Year - data_nasc.Year;
            if (data_atual < data_nasc.AddYears(anos))
            {
                anos--;
            }

            int meses = data_atual.Month - data_nasc.AddYears(anos).Month;
            if (data_atual.Day < data_nasc.AddYears(anos).Day)
            {
                meses--;
            }

            int dias = (data_atual - data_nasc.AddYears(anos).AddMonths(meses)).Days;

            lbl_idade.Text = anos + " anos, " + meses + " meses e " + dias + " dias.";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
             StreamWriter sw = new StreamWriter("funcionarios.txt")
            {
            sw.WriteLine("1; Paulo Forte;Masculino; 12-03-1987; Portuguesa; Programador, pic_1.jpg");
            sw.WriteLine("2; Maria josé; Feminino; 10-06-1990; Espanhola; Secretária; pic_2.jpg");
            sw.WriteLine("3; Ana Freitas; Feminino; 05-06-1987; Portuguesa; Contabilista; pic_3.jpg");
            
            }
            /*
            funcionarios[0, 0] = "1";
            funcionarios[0, 1] = "Paulo Forte";
            funcionarios[0, 2] = "Masculino";
            funcionarios[0, 3] = "12-03-1987";
            funcionarios[0, 4] = "Portuguesa";
            funcionarios[0, 5] = "Programador";
            funcionarios[0, 6] = "pic_1.jpg";

            funcionarios[1, 0] = "2";
            funcionarios[1, 1] = "Maria Jose";
            funcionarios[1, 2] = "Feminino";
            funcionarios[1, 3] = "10-06-1990";
            funcionarios[1, 4] = "Espanhola";
            funcionarios[1, 5] = "Secretaria";
            funcionarios[1, 6] = "pic_2.jpg";

            funcionarios[2, 0] = "3";
            funcionarios[2, 1] = "Ana Freitas";
            funcionarios[2, 2] = "feminino";
            funcionarios[2, 3] = "05-06-1987";
            funcionarios[2, 4] = "Portuguesa";
            funcionarios[2, 5] = "Contabilista";
            funcionarios[2, 6] = "pic_3.jpg";

            funcionarios[3, 0] = "4";
            funcionarios[3, 1] = "John Smith";
            funcionarios[3, 2] = "Masculino";
            funcionarios[3, 3] = "25-07-1991";
            funcionarios[3, 4] = "Inglesa";
            funcionarios[3, 5] = "Web Designer";
            funcionarios[3, 6] = "pic_4.jpg";

            funcionarios[4, 0] = "5";
            funcionarios[4, 1] = "Vandeerlei Silva";
            funcionarios[4, 2] = "Masculino";
            funcionarios[4, 3] = "22-06-1988";
            funcionarios[4, 4] = "Brasileira";
            funcionarios[4, 5] = "Economista";
            funcionarios[4, 6] = "pic_5.jpg";

            funcionarios[5, 0] = "6";
            funcionarios[5, 1] = "Estela Dias";
            funcionarios[5, 2] = "FEminino";
            funcionarios[5, 3] = "05-06-1985";
            funcionarios[5, 4] = "Portuguesa";
            funcionarios[5, 5] = "Auditora";
            funcionarios[5, 6] = "pic_6.jpg";

            funcionarios[6, 0] = "7";
            funcionarios[6, 1] = "Marta Frando";
            funcionarios[6, 2] = "Feminino";
            funcionarios[6, 3] = "15-06-1988";
            funcionarios[6, 4] = "Portuguesa";
            funcionarios[6, 5] = "Adgvogada";
            funcionarios[6, 6] = "pic_7.jpg";

            funcionarios[7, 0] = "8";
            funcionarios[7, 1] = "Ana Aleixo";
            funcionarios[7, 2] = "Feminino";
            funcionarios[7, 3] = "23-07-1985";
            funcionarios[7, 4] = "Portuguesa";
            funcionarios[7, 5] = "Comercial";
            funcionarios[7, 6] = "pic_8.jpg";

            funcionarios[8, 0] = "9";
            funcionarios[8, 1] = "Joao Andrade";
            funcionarios[8, 2] = "Masculino";
            funcionarios[8, 3] = "22-06-1989";
            funcionarios[8, 4] = "Brasileira";
            funcionarios[8, 5] = "tecnico de Sistemas";
            funcionarios[8, 6] = "pic_9.jpg";
            */
           
            VisualizaFuncionarios();
        }

        private void btn_seguinte_Click(object sender, EventArgs e)
        {
            index++;
            if (index > 8)
            {
                MessageBox.Show("Fim da lista", "Atencao",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                index = 0;
            }
            VisualizaFuncionarios();
        }


        private void btn_anterior_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                MessageBox.Show("Inicio da lista", "Atencao",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                index = 8;
            }
            VisualizaFuncionarios();
        }
        private void btn_inicio_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("funcionarios.txt")
        {
            string linha;
            while ((linha = sr.ReadLine()) != null)
            {
                string[] dados = linha.Split(';');

                for (int j = 0; j < dados.Length; j++)
                {
                    funcionarios[index, j] = dados[j];
                }

                index++;
            }
        }
            index = 0;
            VisualizaFuncionarios();
        }
        private void btn_fim_Click(object sender, EventArgs e)
        {
            index = 8;
            VisualizaFuncionarios();
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f1 = new Font("Arial", 14, FontStyle.Bold);
            Font f2 = new Font("Arial", 12, FontStyle.Regular);

            int larguraPagina = 800; // largura da página
            int posicaoInicial = 100; // posição inicial da impressão
            int espacamento = 30; // espacamento entre as linhas
            int colunas = 3; // número de colunas

            e.Graphics.DrawString("Info Funcionarios", f1, Brushes.Blue, 50, posicaoInicial);

            int y = posicaoInicial + 50; // posição inicial da impressão para os funcionários

            for (int i = 0; i < funcionarios.GetLength(0); i++)
            {
                int x = (i % colunas) * (larguraPagina / colunas) + 50;

                e.Graphics.DrawString("Numero: " + funcionarios[i, 0], f2, Brushes.Black, x, y);
                e.Graphics.DrawString("Nome: " + funcionarios[i, 1], f2, Brushes.Black, x, y + espacamento);
                e.Graphics.DrawString("Genero: " + funcionarios[i, 2], f2, Brushes.Black, x, y + (2 * espacamento));
                e.Graphics.DrawString("Data de Nascimento: " + funcionarios[i, 3], f2, Brushes.Black, x, y + (3 * espacamento));
                e.Graphics.DrawString("Nacionalidade: " + funcionarios[i, 4], f2, Brushes.Black, x, y + (4 * espacamento));
                e.Graphics.DrawString("Categoria: " + funcionarios[i, 5], f2, Brushes.Black, x, y + (5 * espacamento));
                e.Graphics.DrawString("Foto: " + funcionarios[i, 6], f2, Brushes.Black, x, y + (6 * espacamento));

                if ((i + 1) % colunas == 0) y += 9 * espacamento;
            }
        }
        private void pic_paulo_MouseHover(object sender, EventArgs e)
        {
            string n = "1";
            string nome = "Paulo Forte";
            string genero = "Masculino";
            string data_nasc = "12-03-1987";
            string nacionalidade = "Portuguesa";
            string categoria = "Programador";

            toolTip1.SetToolTip(pic_paulo, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }

        private void pic_maria_MouseHover(object sender, EventArgs e)
        {
            string n = "2";
            string nome = "Maria Jose";
            string genero = "Feminino";
            string data_nasc = "10-06-1990";
            string nacionalidade = "Espanhola";
            string categoria = "Secretaria";

            toolTip1.SetToolTip(pic_maria, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }

        private void pic_anaf_MouseHover(object sender, EventArgs e)
        {
            string n = "3";
            string nome = "Ana Freitas";
            string genero = "Feminino";
            string data_nasc = "05-06-1987";
            string nacionalidade = "Portuguesa";
            string categoria = "Contabilista";

            toolTip1.SetToolTip(pic_anaf, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }

        private void pic_john_MouseHover(object sender, EventArgs e)
        {
            string n = "4";
            string nome = "John Smith";
            string genero = "Masculino";
            string data_nasc = "25-07-1991";
            string nacionalidade = "Inglesa";
            string categoria = "Web Designer";

            toolTip1.SetToolTip(pic_john, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }

        private void pic_vanderlei_MouseHover(object sender, EventArgs e)
        {
            string n = "5";
            string nome = "Vanderlei Silva";
            string genero = "Masculino";
            string data_nasc = "22-06-1988";
            string nacionalidade = "Brasileira";
            string categoria = "Economista";

            toolTip1.SetToolTip(pic_vanderlei, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }

        private void pic_estela_MouseHover(object sender, EventArgs e)
        {
            string n = "6";
            string nome = "Estela Dias";
            string genero = "Feminino";
            string data_nasc = "05-06-1985";
            string nacionalidade = "Portuguesa";
            string categoria = "Auditora";

            toolTip1.SetToolTip(pic_estela, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }

        private void pic_marta_MouseHover(object sender, EventArgs e)
        {
            string n = "7";
            string nome = "Marta Franco";
            string genero = "Feminino";
            string data_nasc = "15-06-1988";
            string nacionalidade = "Portuguesa";
            string categoria = "Advogada";

            toolTip1.SetToolTip(pic_marta, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }

        private void pic_anaa_MouseHover(object sender, EventArgs e)
        {
            string n = "8";
            string nome = "Ana Aleixo";
            string genero = "Feminino";
            string data_nasc = "23-07-1985";
            string nacionalidade = "Portuguesa";
            string categoria = "Comercial";

            toolTip1.SetToolTip(pic_anaa, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }

        private void pic_joao_MouseHover(object sender, EventArgs e)
        {
            string n = "9";
            string nome = "Joao Andrade";
            string genero = "Masculino";
            string data_nasc = "22-06-1989";
            string nacionalidade = "Brasleira";
            string categoria = "Tecnico de Sistemas";

            toolTip1.SetToolTip(pic_joao, "Numero: " + n + "\nNome: " + nome + "\nGênero: " + genero +
                "\nData de Nascimento: " + data_nasc + "\nNacionalidade: " + nacionalidade +
                "\nCategoria: " + categoria);
        }
    }
}
