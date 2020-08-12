using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.MODEL
{
    public class Estoque
    {
        public int id { get; set; }
        public int idfuncionario { get; set; }
        public int idautomovel { get; set; }
        public DateTime data { get; set; }
        public string relatorio { get; set; }
        public float total { get; set; }


    }
}
