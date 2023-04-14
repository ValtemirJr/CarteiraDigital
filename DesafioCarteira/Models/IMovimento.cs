using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCarteira.Models
{
    public interface IMovimento
    {
        public Pessoa Pessoa { get; set; }
        public string Descricao { get; set; }
        public double? Valor { get; set; }
    }
}
