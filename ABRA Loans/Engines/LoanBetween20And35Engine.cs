namespace ABRA_Loans.Engines
{
    public class LoanBetween20And35Engine : ILoanStrategy
    {
        public double CalculateInterest(double primeInterest, double loanAmount)
        {
            if(loanAmount <= 5000)
            {
                return 2;
            }
            else if(loanAmount <= 30000)
            {
                return 1.5 + primeInterest;
            }
            return 1 + primeInterest;
        }
    }
}
