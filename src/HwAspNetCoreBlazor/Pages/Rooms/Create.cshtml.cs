using HwAspNetCoreBlazor.Core.Interfaces.Repositories;
using HwAspNetCoreBlazor.Core.Models;
using HwAspNetCoreBlazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Pages.Rooms
{
    public class CreateModel : PageModel
    {

        public CreateModel()
        {
            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoomModel Room { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add logic
            // Save logic

            return RedirectToPage("./Index");
        }
    }
}
