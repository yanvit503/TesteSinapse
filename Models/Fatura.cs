using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteSinapse.Models
{
    public class Fatura
    {
        [Key]
        public int Num_Fatura { get; set; }
        public int Cod_Cliente { get; set; }
        public DateTime Data_Emissao { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public float Valor { get; set; }

        [ForeignKey(nameof(Cod_Cliente))]
        public Cliente Cliente {get;set;}
    }
}