using DesafioCarteira.Enumerables;
using DesafioCarteira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DesafioCarteira.ViewModel
{
    public class GeraExtratoViewModel
    {
        public EnumFiltroExtrato OpcaoDiasExtrato { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public IList<Object> Extrato { get; set; }
        public int PessoaId { get; set; }
    }
}
