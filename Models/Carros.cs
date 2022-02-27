using System;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace game.Models
{
    public class Carros
    {
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
           
    }
}