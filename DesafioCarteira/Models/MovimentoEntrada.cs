using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCarteira.Models
{
    public class MovimentoEntrada : IMovimento
    {
        public virtual int EntradaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual DateTime DataEntrada { get; set; }
        public virtual string Descricao { get; set; }
        public virtual double? Valor { get; set; }

        public MovimentoEntrada()
        {
            DataEntrada = DateTime.Now;
        }
    }
}
