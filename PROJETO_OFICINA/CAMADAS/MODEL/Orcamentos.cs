using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.MODEL
{
   public class Orcamentos
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public string automovel { get; set; }
        public string cor { get; set; }
        public string placa { get; set; }
        public string discriminacao { get; set; }
        public int total { get; set; }

    }
}
