namespace ABRA_Loans.Models
{
    public class LoanRequest
    {
        public int ClientId { get; set; }
        public double LoanAmount { get; set; }
        public int LoanPeriod { get; set; }
    }
}
