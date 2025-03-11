using ABRA_Loans.Models;

namespace ABRA_Loans.Repositories
{
    public interface IClientRepository
    {
        Client GetClientById(int clientId);
    }
}
