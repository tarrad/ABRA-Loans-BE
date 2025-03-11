using ABRA_Loans.Models;

namespace ABRA_Loans.Repositories
{
    public class ClientRepositoryMock : IClientRepository
    {
        // Simulating a database with an in-memory list of clients
        private readonly List<Client> _clients;

        public ClientRepositoryMock()
        {
            // Example clients in an in-memory list
            _clients = new List<Client>
        {
            new Client
            {
                ClientId = 1,
                Age = 19,
            },
            new Client
            {
                ClientId = 2,
                Age = 25,
            },
            new Client
            {
                ClientId = 3,
                Age = 40,
            },
            new Client
            {
                ClientId = 4,
                Age = 50,
            }
        };
        }

        // Implement the method to fetch client details by their ID
        public Client GetClientById(int clientId)
        {
            // Simulating fetching data from a database
            var client = _clients.FirstOrDefault(c => c.ClientId == clientId);

            if (client == null)
            {
                // If client not found, return null or throw an exception depending on your needs
                return null;
            }

            return client;
        }
    }
}
