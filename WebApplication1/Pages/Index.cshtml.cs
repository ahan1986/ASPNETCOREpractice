using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WhateverYouWantToCallDB _db;

        public IndexModel(WhateverYouWantToCallDB db) { _db = db; }

        public IList<Customers> Customer { get; private set; }

        // adding post it note message here;
        [TempData]
        public string Message { get; set; }

        public async Task OnGetAsync() 
        {
            Customer = await _db.Customer.AsNoTracking().ToListAsync();
        }

        // this is for the delete button on the front page. This will find the id of the button clicked and then searched the database and delete it and then save the changes and then refresh the page using RedirectToPage()
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await _db.Customer.FindAsync(id);

            if(customer != null)
            {
                _db.Customer.Remove(customer);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
