using SistemaTarefas.Integration.Interfaces;
using SistemaTarefas.Integration.Response;
using SistemaTarefas.Integration.Refit;

namespace SistemaTarefas.Integration
{
    public class ViaCepIntegracao : IViaCepIntegracaoRefit
    {
        private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;

        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit) 
        {
            _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }

        public async Task<ViaCepResponse> GetViaCepIntegracao(string cep)
        {
           var responseData = await _viaCepIntegracaoRefit.GetViaCepIntegracao(cep);

            if (responseData != null)
            {
                return responseData;
            }

            return null;
        }
    }
}
