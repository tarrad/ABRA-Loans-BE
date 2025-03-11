namespace ABRA_Loans.Engines
{
    public class LoanUnder20Engine : ILoanStrategy
    {

        public double CalculateInterest(double primeInterest, double loanAmount)
        {
            return 2 + primeInterest;
        }
    }
}
