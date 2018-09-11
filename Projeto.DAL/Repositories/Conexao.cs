using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Projeto.DAL.Repositories
{
    public class Conexao
    {

        // Atributos
        // protected -> permite acesso por meio de herança
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;


        // Abrir a conexão com o banco de dados
        protected void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString);
            con.Open();
        }


        // Fechar a conexão com o banco de dados
        protected void CloseConnection()
        {
            con.Close();
        }
    }
}
