using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WhateverYouWantToCallDB _db;

        private ILogger<CreateModel> Log;

        public CreateModel(WhateverYouWantToCallDB db, ILogger<CreateModel> log)
        {
            _db = db;
            Log = Log;
        }

        // this string is part of the page model and nothing from the database.  This is like a post it note that lets the user know that you have done something and a sign will show up. Kind of like a view model like a temp data.  This will have to deliver a message in the Task
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customers Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customer.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer {Customer.Name} added!";
            return RedirectToPage("/Index");
        }

    }
}