using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Services
{
    public interface IPlanoContaService
    {
        List<PlanoConta> ListarRegistros();
        void Salvar(PlanoConta item);
        void Excluir(int id);
        PlanoConta RetornarRegistro (int id);

        
    }
}