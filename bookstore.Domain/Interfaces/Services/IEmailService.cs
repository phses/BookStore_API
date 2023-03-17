
namespace bookstore.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        void EnviaEmailConfirmacao(string emailDestinatario, Guid tokenEmailConfirmacao);
    }
}
