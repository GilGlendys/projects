using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WellBeings.Pages;

namespace WellBeings.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(ContactusModel model)
        {
            //read cookie from IHttpContextAccessor  
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies[model.Name];
            //read cookie from Request object  
            string cookieValueFromReq = Request.Cookies[model.Name];
            //set the key value in Cookie  
            Set("test", "True", 10);
            //Delete the cookie object  
            Remove(model.Name);
            return View();
        }

        /// <summary>  
        /// Get the cookie  
        /// </summary>  
        /// <param name="key">Key </param>  
        /// <returns>string value</returns>  
        public string Get(string key)
        {
            return Request.Cookies[key];
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
    }

    //[HttpGet]
    //public ViewResult Index()
    //{
    //    return View();
    //}
}

