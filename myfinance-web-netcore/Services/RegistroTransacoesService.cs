using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;

namespace myfinance_web_netcore.Services
{
    public class RegistroTransacoesService : IRegistroTransacoesService
    {
        private MyFinanceDbContext _myFinanceDbContext;
        private readonly ILogger<RegistroTransacoesService> _logger;

        public RegistroTransacoesService(
            MyFinanceDbContext myFinanceDbContext,
            ILogger<RegistroTransacoesService> logger
        )
        {
            _myFinanceDbContext = myFinanceDbContext;
            _logger = logger;
        }

        public void Excluir(int id)
        {
            var item = RetornarRegistro(id);
            _myFinanceDbContext.Attach(item);
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public List<Transacao> ListarRegistros()
        {
            var lista = _myFinanceDbContext.Transacao.ToList();
            return lista;
        }

        public Transacao RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
            return item;
        }

        public void Salvar(Transacao item)
        {
            _logger.LogInformation("Iniciando o método Salvar");
            _logger.LogInformation(
                "Transacao ID: {Id}, Data: {Data}, Valor: {Valor}, Historico: {Historico}, Tipo: {Tipo}, PlanoContaId: {PlanoContaId}",
                item.Id,
                item.Data,
                item.Valor,
                item.Historico,
                item.Tipo,
                item.PlanoContaId
            );

            var dbSet = _myFinanceDbContext.Transacao;
            if (item.Id == 0)
            {
                _logger.LogInformation("Adicionando nova transação");
                dbSet.Add(item);
            }
            else
            {
                _logger.LogInformation("Atualizando transação existente");
                dbSet.Attach(item);
                _myFinanceDbContext.Entry(item).State = Microsoft
                    .EntityFrameworkCore
                    .EntityState
                    .Modified;
            }

            _myFinanceDbContext.SaveChanges();
            _logger.LogInformation("Transação salva com sucesso");
        }
    }
}
