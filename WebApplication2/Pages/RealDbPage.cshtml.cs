using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;

namespace WebApplication2.Pages
{
    public class RealDbPageModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public List<Person> Persons { get; set; }

        public RealDbPageModel(MyDbContext context)
        {
            Context = context;
        }

        public MyDbContext Context { get; }

        public void OnGet()
        {
            Persons = Context.Persons.ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Context.Persons.Add(Person);
                Context.SaveChanges();
                return RedirectToAction("RealDbPage");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
