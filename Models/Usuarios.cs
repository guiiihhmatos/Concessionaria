using System;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace game.Models
{
    public class Usuarios
    {
        private readonly static string stringDeConexao = @"Server=DESKTOP-DUMK4UJ\SQLEXPRESS;Initial Catalog = Concessionaria; Integrated Security = true; Connect Timeout = 30; Encrypt=false; TrustServerCertificate=false; ApplicationIntent=ReadWrite; MultiSubnetFailover=false;";

        public int Id { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public bool Login()
        {
            var verificacao = false;
            var sql = "SELECT * FROM usuarios WHERE email = '" + this.Email + "'";

            try
            {
                using(var conexao = new SqlConnection(stringDeConexao))
                {
                    conexao.Open();
                    using(var comando = new SqlCommand(sql, conexao))
                    {
                        using(var dr = comando.ExecuteReader())
                        {
                            if(dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    if(this.Senha == dr["senha"].ToString())
                                    {
                                        this.Id = Convert.ToInt32(dr["Id"]);
                                        this.Nome = dr["nomeUsuario"].ToString();
                                        
                                        verificacao = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            } 

            return verificacao;
        }
        public void Salvar(Usuarios user)
        {
            this.Email = user.Email;
            this.Nome = user.Nome;
            this.Senha = user.Senha;
        }

        public void Cadastrar(Usuarios user)
        {
            var sql = "INSERT INTO usuarios (email, nomeUsuario, senha) VALUES (@email, @nomeUsuario, @senha)";

            try
            {
                using(var conexao = new SqlConnection(stringDeConexao))
                {
                    conexao.Open();
                    using(var comando = new SqlCommand(sql, conexao))
                    {
                        
                        comando.Parameters.AddWithValue("@email", (user.Email).ToUpper());
                        comando.Parameters.AddWithValue("@nomeUsuario", (user.Nome).ToUpper());
                        comando.Parameters.AddWithValue("@senha", (user.Senha).ToUpper());
                            
                        comando.ExecuteNonQuery();
                               
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            } 

        }
    }
}