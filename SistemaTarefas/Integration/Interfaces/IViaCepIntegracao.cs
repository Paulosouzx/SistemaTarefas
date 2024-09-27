using SistemaTarefas.Integration.Response;

namespace SistemaTarefas.Integration.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> GetViaCepIntegracao(string cep);
    }
}
