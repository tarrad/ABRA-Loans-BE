namespace ABRA_Loans.Engines
{
    public interface ILoanStrategy
    {
        double CalculateInterest(double primeInterest, double loanAmount);
    }
}
