using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Projeto.DAL.Entities;

namespace Projeto.DAL.Repositories
{
    public class ClienteRepositorio : Conexao
    {

        // Listar todos os registros
        public List<Cliente> ListAll()
        {
            // Abrir conexão
            OpenConnection();

            string strsql = "select * from cliente";
            cmd = new SqlCommand(strsql, con);
            dr = cmd.ExecuteReader();

            // declarando uma lista de clientes
            List<Cliente> lista = new List<Cliente>();

            while(dr.Read())
            {
                Cliente c = new Cliente();
                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);

                lista.Add(c);
            }
            
            // Fechar a conexão
            CloseConnection();
            return lista;
        }

        // Método para retornar 1 cliente pelo Id  
        public Cliente FindById(int id)
        {
            // Abrir conexão
            OpenConnection();

            string strSql = "Select * from Cliente where IdCliente = @IdCliente";

            // Executando o comando
            cmd = new SqlCommand(strSql, con);
            cmd.Parameters.AddWithValue("@IdCliente", id);
            dr = cmd.ExecuteReader();

            // declarando um cliente com valor default null
            Cliente c = null;

            // verificar se o datareader retornou algum resultado
            if(dr.Read())
            {
                c = new Cliente();
                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
            }

            // Fechar conexão
            CloseConnection();
            return c;
        }



        // método para inserir registro na tabela de cliente
        public void Insert(Cliente c)
        {
            // Abrir conexão
            OpenConnection();

            string strSql = "insert into cliente(nome, email, datacadastro)"
                       + "values(@nome, @email, getdate())";

            // executando o comando
            cmd = new SqlCommand(strSql, con);
            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.ExecuteNonQuery();

            // fechando a conexao
            CloseConnection();
        }

        // método para excluir registro da tabela de cliente
        public void Delete(int id)
        {
            // Abrir conexao
            OpenConnection();

            string strsql = "delete from cliente where idCliente = @IdCliente";

            // executando o comando
            cmd = new SqlCommand(strsql, con);
            cmd.Parameters.AddWithValue("@IdCliente", id);
            cmd.ExecuteNonQuery();

            // Fechar a conexão
            CloseConnection();
        }


        // método para atualizar o registro de cliente
        public void Update(Cliente c)
        {
            // abrir conexao
            OpenConnection();

            string strsql = "Update cliente "
                          + "set nome = @Nome, "
                          + "email = @Email "
                          + "where IdCliente = @IdCliente";

            // executando o comando
            cmd = new SqlCommand(strsql, con);
            cmd.Parameters.AddWithValue("@IdCliente", c.IdCliente);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.ExecuteNonQuery();

            // fechar a conexao
            CloseConnection();
        }

        // método para validar e-mail único
        public bool HasEmail(string email)
        {
            OpenConnection();

            string query = "select count(1) from cliente "
                         + "where email = @Email";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Email", email);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }
    }
}
