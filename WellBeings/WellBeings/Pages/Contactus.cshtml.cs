using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WellBeings.Controllers;

namespace WellBeings.Pages
{
    public class ContactusModel : PageModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        private HomeController cookie;


        public string OnGet()
        {
            Name = "Enter your name here";
            Email = "Enter your email here";
            Message = "Enter your message here";

            HomeController cookie1 = cookie;
            var myCookie = cookie1.Get("test");

            if (myCookie != null)
            {
                return ("You already submitted the form");
            }
            return string.Empty;
        }
        public void OnPost()
        {
            Name = Request.Form[nameof(Name)];
            Email = Request.Form[nameof(Email)];
            Message = Request.Form[nameof(Message)];
        }
    }
}
