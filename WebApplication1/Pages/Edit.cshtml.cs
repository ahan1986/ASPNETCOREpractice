using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class EditModel : PageModel
    {
        private readonly WhateverYouWantToCallDB _db;

        public EditModel(WhateverYouWantToCallDB db)
        {
            _db = db;
        }

        [BindProperty]
        public Customers Customer { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _db.Customer.FindAsync(id);
            
            if(Customer == null)
            {
                return RedirectToPage("./Index");
            } 
            return Page();
        }

        //just in case someone else is in the site and is editing at the same time, we need to do a try catch to prevent any conflicts
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) {
                throw new Exception($"Customer {Customer.Id} not found!", e);
            }

            return RedirectToPage("./Index");
        }
    }
}