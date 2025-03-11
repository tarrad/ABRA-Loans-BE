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
            // Use DI to resolve the correct strategy based on the enum value
            switch (strategyType)
            {
                case LoanStrategyType.Under20:
                    return _serviceProvider.GetRequiredService<LoanUnder20Engine>();

                case LoanStrategyType.Between20And35:
                    return _serviceProvider.GetRequiredService<LoanBetween20And35Engine>();

                case LoanStrategyType.Above35:
                    return _serviceProvider.GetRequiredService<LoanAbove35Engine>();

                default:
                    throw new InvalidOperationException($"Strategy not found for {strategyType}");
            }
        }
    }
}
