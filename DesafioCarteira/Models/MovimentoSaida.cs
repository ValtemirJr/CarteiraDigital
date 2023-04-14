using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCarteira.Models
{
    public class MovimentoSaida : IMovimento
    {
        public virtual int SaidaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DataSaida { get; set; }
        public virtual string Descricao { get; set; }
        public virtual double? Valor { get; set; }

        public MovimentoSaida()
        {
            DataSaida = DateTime.Now;
        }
    }
}
