using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioCarteira.Models
{
    public class Pessoa
    {
        public virtual int PessoaId { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "Preencha este campo com pelo menos 3 letras.")]
        [StringLength(50)]
        public virtual string Nome { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
        public virtual string Email { get; set; }
        public virtual double Salario { get; set; }
        public virtual double Limite { get; set; }
        [Required(ErrorMessage = "Coloque um valor minimo.")]
        public virtual double? Minimo { get; set; }
        public virtual double? Saldo { get; set; }
        public virtual IList<MovimentoEntrada> Entradas { get; set; }
        public virtual IList<MovimentoSaida> Saidas { get; set; }

        public Pessoa()
        {
            this.Saldo = 0;
        }
    }
}
