using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace c_nnect_SQL
{
    class cl_Login
    {
        // Cria uma instância da classe de conexão
        cl_Conexao c = new cl_Conexao();

        // Método para verificar se um usuário pode fazer login
        public bool Logar(string login, string senha)
        {
            try
            {
                // Consulta SQL para verificar se há um usuário com o login e senha que ele digitou
                string sql = "select login, senha from tblogin where login like '" + login + "' and senha like '" + senha + "';";

                // Cria um comando MySQL com a consulta e a conexão
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                // Abre a conexão com o banco de dados
                c.conectar();

                // Executa a consulta e obtém os resultados
                MySqlDataReader objDados = cmd.ExecuteReader();

                // Verifica se há linhas (registros) retornadas pela consulta
                if (!objDados.HasRows)
                {
                    // Se não houver, significa que o login falhou
                    return false;
                }
                else
                {
                    // Se houver, significa que o login deu bom
                    return true;
                }
            }
            catch (MySqlException e)
            {
                // Em caso de erro no MySQL, lança a exceção
                throw (e);
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                c.desconectar();
            }
        }

    }
}
