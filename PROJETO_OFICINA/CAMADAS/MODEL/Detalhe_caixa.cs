using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.MODEL
{
   public class Detalhe_caixa
    {
        public int id { get; set; }
        public int idcaixa { get; set; }
        public DateTime data { get; set; }
        public string descricao { get; set; }
        public int valor_entrada { get; set; }
        public int valor_saida { get; set; }
        public string observacao { get; set; }
    }
}
