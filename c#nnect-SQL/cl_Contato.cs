using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace c_nnect_SQL
{
    // Definição da classe cl_Contato, que representa dados de um contato

    public class cl_Contato
    {
        // Campos privados que armazenam dados do contato
        private int codcontato;
        private string nome;
        private string telefone;
        private string celular;
        private string email;

        // Propriedades públicas que fornecem acesso aos campos privados

        // Propriedade para o código do contato
        public int Codcontato
        {
            get => codcontato;
            set => codcontato = value;
        }

        // Propriedade para o nome do contato
        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        // Propriedade para o telefone do contato
        public string Telefone
        {
            get => telefone;
            set => telefone = value;
        }

        // Propriedade para o celular do contato
        public string Celular
        {
            get => celular;
            set => celular = value;
        }

        // Propriedade para o email do contato
        public string Email
        {
            get => email;
            set => email = value;
        }
    }

}
