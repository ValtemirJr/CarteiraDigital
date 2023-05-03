using DesafioCarteira.Enumerables;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCarteira.Models
{
    public class MovimentoViewModel
    {
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "Escolha um tipo de movimento.")]
        [EnumDataType(typeof(EnumTipoMovimento))]
        public EnumTipoMovimento TipoMovimento { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Coloque um valor minimo.")]
        [Range(0, double.MaxValue, ErrorMessage = "Coloque um valor maior que 0")]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }
    }
}
    