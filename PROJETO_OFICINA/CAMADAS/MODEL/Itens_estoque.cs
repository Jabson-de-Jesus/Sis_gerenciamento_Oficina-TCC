using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.MODEL
{
    public class Itens_estoque
    {
        public int id { get; set; }
        public int idestoque { get; set; }
        public int idmaterial { get; set; }
        public string nome_material { get; set; }
        public int quantidade { get; set; }
        public float valor { get; set; }    


    }
}
