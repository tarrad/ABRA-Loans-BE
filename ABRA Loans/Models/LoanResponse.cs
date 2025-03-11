namespace ABRA_Loans.Models
{
    public class LoanResponse
    {
        public bool IsSuccess { get; set; } 
        public double RequestedLoanAmount { get; set; }
        public string? ErrorMsg { get; set; }


        private double _totalLoanAmountToPayBasicInterest;
        public double TotalLoanAmountToPayBasicInterest
        {
            get { return _totalLoanAmountToPayBasicInterest; }
            set { _totalLoanAmountToPayBasicInterest = Math.Round(value, 2); }  // Round to 2 decimal places when setting the value
        }

         private double _totalLoanAmountToPay;
        public double TotalLoanAmountToPay
        {
            get { return _totalLoanAmountToPay; }
            set { _totalLoanAmountToPay = Math.Round(value, 2); }  // Round to 2 decimal places when setting the value
        }



        private double _totalLoanAmountToPayExtraInterest;
        public double TotalLoanAmountToPayExtraInterest
        {
            get { return _totalLoanAmountToPayExtraInterest; }
            set { _totalLoanAmountToPayExtraInterest = Math.Round(value, 2); }  // Round to 2 decimal places when setting the value
        }
    }
}
