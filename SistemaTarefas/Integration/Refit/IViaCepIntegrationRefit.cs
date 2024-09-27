using Refit;
using SistemaTarefas.Integration.Response;

namespace SistemaTarefas.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        //nao precisa colocar o $, apenas a variavel
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}
