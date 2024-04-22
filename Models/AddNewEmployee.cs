using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class AddNewEmployee
    {

        [Required] public string Name { get; set; }
        [Required] public string CivilID { get; set; }
        [Required] public string BankBranch { get; set; }
        [Required] public string Position { get; set; }
    }
}




    









