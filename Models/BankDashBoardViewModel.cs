namespace WebApplication2.Models
{
    public class BankDashBoardViewModel
    {
        public int TotalBranch { get; set; }
        public int TotalEmployee { get; set; }
        public BankBranches BranchWithMostEmployees { get; set; }
        public List<BankBranches> BranchList {get; set;}
    }
}
