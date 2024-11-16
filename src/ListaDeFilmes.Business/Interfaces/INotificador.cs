using ListaDeFilmes.Business.Notificacoes;
using System.Collections.Generic;

namespace ListaDeFilmes.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
