using ABRA_Loans.Engines;
using ABRA_Loans.Handlers;
using ABRA_Loans.Helpers;
using ABRA_Loans.Models;
using ABRA_Loans.Repositories;

namespace ABRA_Loans.Services
{
    public class LoanCalculationService
    {
        private readonly LoanHandler _loanHandler;
        private readonly IClientRepository _clientRepository;
        private readonly double _primeInterest;
        private readonly double _extraInterestAboveTwelveMonths;
        public LoanCalculationService(LoanHandler loanHandler, IClientRepository clientRepository, IConfiguration configuration)
        {
            _loanHandler = loanHandler;
            _clientRepository = clientRepository;
            _primeInterest = configuration.GetValue<double>("PrimeInterest");
            _extraInterestAboveTwelveMonths = configuration.GetValue<double>("ExtraInterestAboveTwelve");
        }

        public LoanResponse CalculateTotalAmountForLoan(LoanRequest loanRequest)
        {
            List<string> errors = new List<string>();
            LoanResponse response = new LoanResponse();
            // Fetch client data (In a real app, this would come from a database, here we will use in memory and mock repository)
            Client client = null;
            try
            {
                client = _clientRepository.GetClientById(loanRequest.ClientId);
                if (client == null)
                {
                    response.ErrorMsg = "הפרופיל המבוקש להלוואה לא נמצא";
                    return response;
                }
                else if (loanRequest.LoanPeriod < 12)
                {

                    response.ErrorMsg = "לא ניתן לבקש הלוואה לפרק זמן שקטן מ12 חודשים";
                    return response;
                }

                else if (loanRequest.LoanAmount <= 0)
                {
                    response.ErrorMsg = "לא ניתן לבקש הלוואה שערכה קטן או שווה ל0";
                    return response;
                }




                LoanStrategyType strategyType = LoanHelper.DetermineStrategyType(client.Age);

                // Get the appropriate strategy using the factory to calcualte the right interest based on the age
                ILoanStrategy strategy = _loanHandler.GetStrategy(strategyType);


                double baseLoanInterest = strategy.CalculateInterest(_primeInterest, loanRequest.LoanAmount);

                response.RequestedLoanAmount = loanRequest.LoanAmount;
                // Calculate the base loan amount
                response.TotalLoanAmountToPayBasicInterest = LoanHelper.CalculateAnnualInterest(loanRequest.LoanAmount, loanRequest.LoanPeriod, baseLoanInterest);


                // Add extra interest for months over 12
                response.TotalLoanAmountToPayExtraInterest = LoanHelper.CalculateExtraInterest(loanRequest.LoanAmount, loanRequest.LoanPeriod, _extraInterestAboveTwelveMonths);


                response.TotalLoanAmountToPay = loanRequest.LoanAmount + response.TotalLoanAmountToPayBasicInterest + response.TotalLoanAmountToPayExtraInterest;


                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.ErrorMsg = "שגיאה בחישוב ההלואה";
                return response;
                //we can implement logging here to catch the exception and the stacktrace
            }


            return response;


        }


    }
}
