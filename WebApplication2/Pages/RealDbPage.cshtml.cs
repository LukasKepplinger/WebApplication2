using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Data.IRepositories;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class RealDbPageModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public List<Person> Persons { get; set; }


        // Instead of injecting the DbContext directly we will use the repo instead
        // We inject the the Interface so we get the implementation we have chosen in the Program.cs
        public IPersonRepo PersonRepo { get; }
        public RealDbPageModel(IPersonRepo personRepo) 
        {
            PersonRepo = personRepo;
        }


        public async void OnGet()
        {
            Persons = await PersonRepo.GetAll();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await PersonRepo.Insert(Person);
                return RedirectToAction("RealDbPage");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
