using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class BankBranches
    {
        public string LocationName { get; set; }
        public int Id { get; set; }
        public string LocationURL {  get; set; }
        public string Branchmanger { get; set; }
        public int EmployeeCount { get; set; }
        public List<Employee> Employees { get; set; }
    }
    //public class Employee
    //{
    //    public int Id { get; set; }
    //    public int BankBranchId { get; set; } 
    //    public string Name { get; set; }
    //    [Required]
    //    public string CivilID { get; set; }
    //    public BankBranches BankBranch {  get; set; }
    //    public string Position { get; set; }

    //}
}
