namespace ABRA_Loans.Engines
{
    public class LoanAbove35Engine : ILoanStrategy
    {
        public double CalculateInterest(double primeInterest, double loanAmount)
        {
            if (loanAmount <= 15000)
            {
                return 1 + primeInterest;
            }
            else if (loanAmount <= 30000)
            {
                return 3 + primeInterest;
            }
            return 1;
        }
    }
}
