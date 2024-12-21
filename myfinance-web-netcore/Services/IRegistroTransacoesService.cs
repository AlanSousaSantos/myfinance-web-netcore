using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Services
{
    public interface IRegistroTransacoesService
    {
        List<Transacao> ListarRegistros();
        void Salvar(Transacao item);
        void Excluir(int id);
        Transacao RetornarRegistro(int id);
    }
}
