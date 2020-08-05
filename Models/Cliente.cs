using System;
using System.ComponentModel.DataAnnotations;

namespace TesteSinapse.Models
{
    public class Cliente
    {
        [Key]
        public int Cod_Cliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public char Tipo_Cliente{ get;set;}
        public bool Visivel { get; set; }
    }
}