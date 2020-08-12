using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA
{
   public class Servico_prestados
    {
        public int id { get; set; }
        public int idordemservico { get; set; }
        public int idservico { get; set; }
        public string nomeservico { get; set; }
        public int valor_unit { get; set; }
        public int valor_total { get; set; }

    }
}
