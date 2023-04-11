using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Models
{
    public class MovimentoEntrada
    {
        public virtual int EntradaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual DateTime DataEntrada { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatório.")]
        public virtual string Descricao { get; set; }
        [Required(ErrorMessage = "Coloque um valor minimo.")]
        public virtual double? Valor { get; set; }

        public MovimentoEntrada()
        {
            DataEntrada = DateTime.Now;
        }
    }
}
