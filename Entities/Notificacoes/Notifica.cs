using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notificacoes
{
    public class Notifica
    {
        public Notifica()
        {
            notificacoes = new List<Notifica>();
        }

        public string NomePropriedade { get; set; }

        public string mensagem { get; set; }

        public List<Notifica> notificacoes { get; set; }


        public bool ValidaPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new Notifica { mensagem = "Campo Obrigatório", NomePropriedade = nomePropriedade });
                return false;
            }
            return true;
        }

        public bool ValidaPropriedadeInteiro(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new Notifica { mensagem = "Campo Obrigatório", NomePropriedade = nomePropriedade });
                return false;
            }
            return true;
        }
    }
}
