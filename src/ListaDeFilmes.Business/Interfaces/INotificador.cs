using ListaDeFilmes.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeFilmes.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
