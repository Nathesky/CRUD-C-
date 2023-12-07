using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace c_nnect_SQL
{
    class cl_Conexao
    {
        //string de conexão
        public MySqlConnection con = new MySqlConnection(@"Server=localhost; Port=3306; Database=agenda; User=root");
        // Método para criar conexão
        public string conectar()
        {
            try
            {
                con.Open();
                return
                    ("Conexão Realizada com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }
        // Método para fechar conexão
        public string desconectar()
        {
            try
            {
                con.Close();
                return ("Conexão encerrada!");
            }
            catch(MySqlException e)
            {
                return (e.ToString());
            }
        }

    }
}
