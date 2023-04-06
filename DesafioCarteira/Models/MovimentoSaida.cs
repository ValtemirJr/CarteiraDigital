using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Models
{
    public class MovimentoSaida
    {
        public virtual int SaidaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual DateTime DataSaida { get; set; }
        public virtual string Descricao { get; set; }
        public virtual double Valor { get; set; }

        public MovimentoSaida()
        {
            DataSaida = DateTime.Now;
        }
    }
}
