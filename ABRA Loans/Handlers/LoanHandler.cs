using ABRA_Loans.Engines;
using ABRA_Loans.Models;

namespace ABRA_Loans.Handlers
{
    public class LoanHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public LoanHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILoanStrategy GetStrategy(LoanStrategyType strategyType)
        {
            string strategyName = Enum.GetName(typeof(LoanStrategyType), strategyType);

            if (string.IsNullOrEmpty(strategyName))
            {
                throw new InvalidOperationException($"Invalid strategy type: {strategyType}");

            }

            // Construct the engine class name based on the enum value
            string engineClassName = $"{strategyName}Engine";

            // Use reflection to find the type of the engine class
            var engineType = typeof(LoanHandler)
                .Assembly.GetTypes()
                .FirstOrDefault(t => t.Name == engineClassName);

            if (engineType == null)
            {
                throw new InvalidOperationException($"Engine not found for strategy: {strategyName}");
            }

            // Use DI to resolve the engine type
            return (ILoanStrategy)_serviceProvider.GetRequiredService(engineType);
        }
    }
}

