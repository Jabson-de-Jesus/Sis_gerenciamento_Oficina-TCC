using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_OFICINA.CAMADAS.DAL
{
   public class conexao
    {
        public static string getconexao() {

            return @"Data Source=.\sqlexpress;Initial Catalog=PROJETO_OFICINA;Integrated Security=True";
        }

    }
}
