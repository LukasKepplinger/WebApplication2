using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class FakeDbPageModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public List<Person> Persons { get; set; }
        public FakePersonsDb PersonsDb { get; }

        public FakeDbPageModel(FakePersonsDb personsDb)
        {
            Persons = new List<Person>();
            PersonsDb = personsDb;
        }

        public void OnGet()
        {
            Persons = PersonsDb.GetAll();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                PersonsDb.Add(Person);
                return RedirectToAction("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
