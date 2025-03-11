In this project, I used several design patterns to implement a structured solution using .NET Core 8 Web API. The key patterns I applied are as follows:

Repository Pattern: I used the Repository pattern to manage the data in an organized way. Since we're not using a real database in this assignment, I created different implementations of ClientRepository.

The one that was injected is a mock repository that uses in-memory data to fetch client information. The benefit of this approach is flexibility—before runtime, we can easily switch between different repository implementations, if needed.

Strategy Pattern: The Strategy pattern is applied to handle different loan interest strategies based on the client's characteristics. The GetStrategy method is used to fetch the appropriate strategy, ensuring that the correct loan interest calculation method is applied 
to each client.

Factory Pattern: The Factory pattern is used to manage the creation of the loan interest calculation strategies. Based on the client’s age and loan amount, the factory helps generate the correct strategy to calculate the loan interest.

API Origin: The API is set to serve requests from http://localhost:5173.
