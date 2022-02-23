using System;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace game.Models
{
    public class Carros
    {
        private readonly static string stringDeConexao = @"Server=DESKTOP-DUMK4UJ\SQLEXPRESS;Initial Catalog = Concessionaria; Integrated Security = true; Connect Timeout = 30; Encrypt=false; TrustServerCertificate=false; ApplicationIntent=ReadWrite; MultiSubnetFailover=false;";
 
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Modelo { get; set; }

        public double Valor { get; set; }

        public int Ano { get; set; }

        public string Cor { get; set; }

        public Carros(){   }

        public Carros(int id, string nome, string modelo, double valor, int ano, string cor)
        {
            this.Id = id;
            this.Nome = nome;
            this.Modelo = modelo;
            this.Valor = valor;
            this.Ano = ano;
            this.Cor = cor;
        }

        public static List<Carros> PegarCarros()
        {
            var listaCarros = new List<Carros>();
            var sql = "SELECT * FROM Carros";
            
            try{

            
            using(var conexao = new SqlConnection(stringDeConexao))
            {
                conexao.Open();
                using(var comando = new SqlCommand(sql, conexao))
                {
                    using(var dr = comando.ExecuteReader())
                    {
                        if(dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                listaCarros.Add(new Carros(

                                    Convert.ToInt32(dr["Id"]),
                                    dr["Nome"].ToString(),
                                    dr["Modelo"].ToString(),
                                    Convert.ToDouble(dr["Valor"]),
                                    Convert.ToInt32(dr["Ano"]),
                                    dr["Cor"].ToString()
                                    
                                ));
                            }
                        }
                    }
                }
            }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
            return listaCarros;
        }

        public void Salvar(Carros user, int id)
        {

            Id = id;

            var sql = "";

            if(Id == 0)
            {
                sql = "INSERT INTO carros(nome, modelo, valor, ano, cor) values (@nome, @modelo, @valor, @ano, @cor)";
            }
            else
            {
                sql = "UPDATE carros SET nome = @nome, modelo = @modelo, valor = @valor, ano = @ano, cor = @cor WHERE id = " + Id;
            }
            
            try
            {
                using(var conexao = new SqlConnection(stringDeConexao))
                {
                    conexao.Open();
                    using(var comando = new SqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", (user.Nome).ToUpper());
                        comando.Parameters.AddWithValue("@modelo", (user.Modelo).ToUpper());
                        comando.Parameters.AddWithValue("@valor", user.Valor);
                        comando.Parameters.AddWithValue("@ano", user.Ano);
                        comando.Parameters.AddWithValue("@cor", (user.Cor).ToUpper());

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }

        public void Excluir()
        {
            var sql = "DELETE FROM carros WHERE id = " + Id;

            try
            {
                
                using (var conexao = new SqlConnection(stringDeConexao))
                {
                    conexao.Open();
                    using (var comando = new SqlCommand(sql, conexao))
                    {
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }

        public void PegarInformacoes(int id)
        {
            var sql = "SELECT nome, modelo, valor, ano, cor FROM Carros WHERE id = " + id;
            
            try{

            
            using(var conexao = new SqlConnection(stringDeConexao))
            {
                conexao.Open();
                using(var comando = new SqlCommand(sql, conexao))
                {
                    using(var dr = comando.ExecuteReader())
                    {
                        if(dr.HasRows)
                        {
                            if(dr.Read())
                            {
                                Id = id;
                                Nome = dr["Nome"].ToString();
                                Modelo = dr["Modelo"].ToString();
                                Valor = Convert.ToDouble(dr["Valor"]);
                                Ano = Convert.ToInt32(dr["Ano"]);
                                Cor = dr["Cor"].ToString();
    
                            }
                        }
                    }
                }
            }
            }
            catch(Exception ex)
            {
                Nome = "Falha: " + ex.Message;
                Console.WriteLine("Falha: " + ex.Message);
            }
        }
           
    }
}