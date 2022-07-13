using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {

        public string Title { get; set; }
        public List<Person> Persons { get; set; }


        public void OnGet()
        {
            Title = "Hello World!";
            Persons = new List<Person>()
            {
                new Person()
                {
                    FirstName = "Max", 
                    LastName = "Mustermann"
                },
                new Person()
                {
                    FirstName = "Hermann",
                    LastName = "Gruber"
                }
            };
        }

    }
}