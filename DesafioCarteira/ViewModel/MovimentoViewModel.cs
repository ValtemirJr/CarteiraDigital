using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Models
{
    public class MovimentoViewModel
    {
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "Escolha um tipo de movimento.")]
        public bool TipoMovimento { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Coloque um valor minimo.")]
        [Range(0, double.MaxValue, ErrorMessage = "Coloque um valor maior que 0")]
        public double Valor { get; set; }
    }
}
    