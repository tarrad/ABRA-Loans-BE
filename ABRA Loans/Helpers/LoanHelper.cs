using ABRA_Loans.Models;

namespace ABRA_Loans.Helpers
{
    public static class LoanHelper
    {

        public static double CalculateAnnualInterest(double loanAmount, int loanPeriod, double interest)
        {
            // Calculate the number of full years and remaining months
            int fullYears = loanPeriod / 12;
            double annualInterest = 0;

            // Calculate interest for each full year
            for (int i = 0; i < fullYears; i++)
            {
                annualInterest += loanAmount * interest / 100;
            }

            // Calculate interest for remaining months
            int remainingMonths = loanPeriod % 12;
            if (remainingMonths > 0)
            {
                annualInterest += loanAmount * interest / 100 * (remainingMonths / 12.0);
            }

            return annualInterest;
        }


        public static double CalculateExtraInterest(double loanAmount, int loanPeriod, double interest)
        {
            // Calculate extra months over 12 months
            int extraMonths = Math.Max(0, loanPeriod - 12);
            return extraMonths == 0 ? 0 : ((loanAmount * interest)/100) * extraMonths;
        }



        public static LoanStrategyType DetermineStrategyType(int age)
        {
            if (age < 20)
            {
                return LoanStrategyType.Under20;
            }
            else if (age >= 20 && age <= 35)
            {
                return LoanStrategyType.Between20And35;
            }
            else
            {
                return LoanStrategyType.Above35;
            }
        }
    }
}
