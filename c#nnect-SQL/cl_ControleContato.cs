using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace c_nnect_SQL
{
    public class cl_ControleContato
    {
        // Instância da classe de conexão ao banco de dados
        cl_Conexao c = new cl_Conexao();

        // Método para cadastrar um novo contato no banco de dados
        public string cadastrar(cl_Contato cont)
        {
            try
            {
                // Construção da consulta SQL para inserção de um novo contato
                string sql = "INSERT INTO tbcontato (nome, telefone, celular, email)" +
                    "VALUES (' " + cont.Nome + "', '" + cont.Telefone + "', '" + cont.Celular + "', '" + cont.Email + "')";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                // Abrindo a conexão
                c.conectar();
                // Executando a consulta
                cmd.ExecuteNonQuery();
                // Fechando a conexão
                c.desconectar();
                return ("Cadastro realizado com sucesso!");
            }
            catch (MySqlException e)
            {
                // Em caso de exceção, retorna uma mensagem de erro
                return (e.ToString());
            }
        }

        // Método para alterar os dados de um contato já existente no banco de dados
        public string alterar(cl_Contato cont)
        {
            try
            {
                // Consulta SQL para atualizar um contato
                string sql = "UPDATE tbcontato SET nome = '" + cont.Nome + "',   telefone = '" + cont.Telefone + "',  celular = '" + cont.Celular + "',  email = '" + cont.Email + "'  WHERE codcontato = '" + cont.Codcontato + "' ";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                // Abrindo a conexão
                c.conectar();
                // Executando a consulta
                cmd.ExecuteNonQuery();
                // Fechando a conexão
                c.desconectar();
                return ("Alteração realizada com sucesso!");
            }
            catch (MySqlException e)
            {
                // Em caso de exceção, retorna uma mensagem de erro
                return (e.ToString());
            }
        }

        // Método para buscar um contato no banco de dados por código
        public cl_Contato buscar(int codigo)
        {
            cl_Contato cont = new cl_Contato();
            try
            {
                // Construção da consulta SQL para selecionar um contato por código
                string sql = "SELECT * FROM tbcontato WHERE codcontato= " + codigo + ";";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                // Abrindo a conexão
                c.conectar();
                // Executando a consulta
                cmd.ExecuteNonQuery();

                MySqlDataReader objDados = cmd.ExecuteReader();
                if (!objDados.HasRows)
                {
                    // Se não houver dados, retorna nulo
                    return null;
                }
                else
                {
                    objDados.Read();
                    // Preenchendo os dados do contato a ser retornado
                    cont.Codcontato = Convert.ToInt32(objDados["codcontato"]);
                    cont.Nome = objDados["nome"].ToString();
                    cont.Telefone = objDados["telefone"].ToString();
                    cont.Celular = objDados["celular"].ToString();
                    cont.Email = objDados["nome"].ToString();

                    objDados.Close();
                    return cont;
                }
            }
            catch (MySqlException e)
            {
                // Em caso de exceção, lança a exceção
                throw (e);
            }
            finally
            {
                // Garante que a conexão é fechada mesmo em caso de exceção
                c.desconectar();
            }
        }

        // Método para excluir um contato do banco de dados
        public string excluir(cl_Contato cont)
        {
            try
            {
                // Construção da consulta SQL para excluir um contato
                string sql = "DELETE from tbcontato WHERE codcontato = '" + cont.Codcontato + "' ";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                // Abrindo a conexão
                c.conectar();
                // Executando a consulta
                cmd.ExecuteNonQuery();
                // Fechando a conexão
                c.desconectar();
                return ("Exclusão realizada com sucesso!");
            }
            catch (MySqlException e)
            {
                // Em caso de exceção, retorna uma mensagem de erro
                return (e.ToString());
            }
        }

        // Método para pesquisar contatos por código
        public DataTable pesquisaCodigo(int codigo)
        {
            // Construção da consulta SQL para pesquisar contatos por código
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, " + "celular as Celular, email as Email from tbcontato where codcontato = " + codigo + " ; ";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            // Abrindo a conexão
            c.conectar();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            // Preenchendo o DataTable com os resultados da consulta
            da.Fill(contato);

            // Fechando a conexão
            c.desconectar();

            return contato;
        }

        // Método para pesquisar contatos por nome
        public DataTable pesquisanome(string nomecontato)
        {
            // Construção da consulta SQL para pesquisar contatos por nome
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where nome like '%" + nomecontato + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            // Abrindo a conexão
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            // Preenchendo o DataTable com os resultados da consulta
            da.Fill(contato);
            // Fechando a conexão
            c.desconectar();
            return contato;
        }

        //Método para pesquisar contatos por telefone
        public DataTable pesquisatelefone(string telefonecontato)
        {
            // Construção da consulta SQL para pesquisar contatos por telefone
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where telefone like '%" + telefonecontato + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            // Abrindo a conexão
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            // Preenchendo o DataTable com os resultados da consulta
            da.Fill(contato);
            // Fechando a conexão
            c.desconectar();
            return contato;
        }

        // Método para pesquisar contatos por celular
        public DataTable pesquisacelular(string celularcontato)
        {
            // Construção da consulta SQL para pesquisar contatos por celular
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where celular like '%" + celularcontato + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            // Abrindo a conexão
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            // Preenchendo o DataTable com os resultados da consulta
            da.Fill(contato);
            // Fechando a conexão
            c.desconectar();
            return contato;
        }

        // Método para pesquisar contatos por email
        public DataTable pesquisaemail(string emailcontato)
        {
            // Construção da consulta SQL para pesquisar contatos por email
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where email like '%" + emailcontato + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            // Abrindo a conexão
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            // Preenchendo o DataTable com os resultados da consulta
            da.Fill(contato);
            // Fechando a conexão
            c.desconectar();
            return contato;
        }

        // Método para obter todos os contatos cadastrados no banco de dados
        public DataTable PreencherTodos()
        {
            // Construção da consulta SQL para selecionar todos os contatos
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato;";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            // Abrindo a conexão
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            // Preenchendo o DataTable com os resultados da consulta
            da.Fill(contato);
            // Fechando a conexão
            c.desconectar();
            return contato;
        }

        // Método para realizar backup do banco de dados
        public string Backup(string Caminho)
        {
            // Obtém a data atual para incluir no nome do arquivo de backup
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            // Monta o caminho completo para o arquivo de backup
            string CaminhoBackup = Caminho + "\\backupContatos_" + dataAtual + ".sql";

            try
            {
                // Cria um comando MySQL para execução do backup
                MySqlCommand cmd = new MySqlCommand(CaminhoBackup, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);
                // Abre a conexão
                c.conectar();
                // Executa o backup para o arquivo especificado
                mb.ExportToFile(CaminhoBackup);
                // Fecha a conexão
                c.desconectar();
                return ("Backup do banco de dados realizado com sucesso!");
            }
            catch (MySqlException e)
            {
                // Em caso de exceção, retorna uma mensagem de erro
                return (e.ToString());
            }
        }

        // Método para realizar restauração do banco de dados a partir de um arquivo de backup
        public string Restore(string Caminho)
        {
            try
            {
                // Cria um comando MySQL para execução da restauração
                MySqlCommand cmd = new MySqlCommand(Caminho, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);
                // Abre a conexão
                c.conectar();
                // Executa a restauração a partir do arquivo especificado
                mb.ImportFromFile(Caminho);
                // Fecha a conexão
                c.desconectar();
                return ("Banco de dados restaurado com sucesso!");
            }
            catch (MySqlException e)
            {
                // Em caso de exceção, retorna uma mensagem de erro
                return (e.ToString());
            }
        }
    }
}

