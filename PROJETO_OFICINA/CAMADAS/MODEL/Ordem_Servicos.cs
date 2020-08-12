using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.MODEL
{
   public class Ordem_Servicos
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public int idautomovel { get; set; }
        public DateTime data { get; set; }
        public DateTime entrada_veiculo { get; set; }
        public DateTime saida_veiculo { get; set; }
        public int total { get; set; }
        public string status { get; set; }

    }
}
