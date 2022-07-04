using System.ComponentModel.DataAnnotations;

namespace WebApplication2
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
