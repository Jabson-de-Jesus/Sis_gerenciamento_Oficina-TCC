using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.MODEL
{
   public class Caixa
    {
        public int id { get; set; }
        public int saldo_inicial { get; set; }
        public int saldo_final { get; set; }
        public DateTime hora_inicial { get; set; }
        public DateTime hora_final { get; set; }
        public string status { get; set; }

    }
}
