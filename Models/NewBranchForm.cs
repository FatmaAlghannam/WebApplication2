using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class NewBranchForm
    {
        [Required] public string LocationName { get; set; }

        [Required] public string Branchmanger { get; set; }
        [Required] public int Id { get; set; }

        [RegularExpression("https?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b([-a-zA-Z0-9()@:%_\\+.~#?&=]*)\r\n")]
        public string LocationURL { get; set; }
        public int EmployeeCount { get; set; }



    }
}



