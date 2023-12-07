using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace c_nnect_SQL
{
    public partial class FormPrincipal : Form
    {
        cl_ControleContato controle = new cl_ControleContato();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cria uma instância da classe de conexão
            cl_Conexao con = new cl_Conexao();

            // Exibe uma mensagem informando o resultado da tentativa de conexão
            MessageBox.Show(con.conectar());
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria uma instância do formulário de cadastro
            FormCadastro cad = new FormCadastro();
            // Exibe o formulário de cadastro
            cad.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Encerra a aplicação
            Application.Exit();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria uma instância do formulário de consulta
            FormConsulta consulta = new FormConsulta();

            // Exibe o formulário de consulta
            consulta.ShowDialog();
        }

        private void manuelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria uma instância do formulário Manuel
            FormManuel manuel = new FormManuel();

            // Exibe o Manuel 
            manuel.ShowDialog();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria uma instância do formulário Sobre
            FormSobre sobre = new FormSobre();

            // Exibe o formulário Sobre
            sobre.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exibe uma mensagem informando o resultado da operação de backup
            MessageBox.Show(controle.Backup("C:\\Backup"), "Backup do Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void restauraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria uma instância da caixa de diálogo de seleção de arquivo
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Define os filtros de arquivo para permitir apenas arquivos SQL
            openFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";

            // Se o usuário selecionar um arquivo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho do arquivo selecionado
                string CaminhoBackup = openFileDialog1.FileName;

                // Mensagem de como está o estado da restauração (se deu bom ou se deu ruim)
                MessageBox.Show(controle.Restore(CaminhoBackup), "Restauração do BD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
