using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.Models
{

    public class Employee
    {
        public int Id { get; set; }
        public int BankBranchId { get; set; }
        public string Name { get; set; }
        [Required]
        public string CivilID { get; set; }
        public BankBranches BankBranch { get; set; }
        public string Position { get; set; }

    }
}